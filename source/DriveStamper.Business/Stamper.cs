using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DriveStamper.Entities;

namespace DriveStamper.Business
{
  public class Stamper
  {
    /// <summary>
    /// Checks to see if the specified project has already been stamped on the specified drive.
    /// Returns true if all the filenames are present.
    /// </summary>
    /// <param name="drive"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public static bool CheckDrive(DriveInfo drive, Project project)
    {
      var rootFileNames = drive.RootDirectory.GetFiles().Select(f => f.Name);
      return project.Content.All(f => rootFileNames.Contains(new FileInfo(f).Name));
    }

    /// <summary>
    /// Quickly ascertains if there is enough space on the drive to stamp the specified project.
    /// </summary>
    /// <param name="drive"></param>
    /// <param name="project"></param>
    /// <returns></returns>
    public static bool DriveHasSpace(DriveInfo drive, Project project)
    {
      return drive.TotalFreeSpace > project.Content.Sum(f => f.Length);
    }

    /// <summary>
    /// Stamps the specified drive with the specified project.
    /// </summary>
    /// <param name="drive"></param>
    /// <param name="project"></param>
    /// <returns>True if succeeded</returns>
    public static bool Stamp(DriveInfo drive, Project project, out IEnumerable<string> failiures)
    {
      try
      {
        if (!project.IgnoreMissingFiles)
        {
          var missing = project.IdentifyMissingFiles();
          if (missing.Count() > 0)
          {
            failiures = missing.Select(m => string.Format("Missing file: " + m));
            return false;
          }
        }
        if (!DriveHasSpace(drive, project))
        {
          failiures = new List<string>(new[] { "Not enough space on drive." });
          return false;
        }

        var rootFileNames = drive.RootDirectory.GetFiles().Select(f => f.Name);
        var fails = new List<string>();

        foreach (var file in project.Content.Where(File.Exists))
        {
          if (!rootFileNames.Contains(new FileInfo(file).Name) || project.OverwriteFiles)
          {
            try
            {
              var fileInfo = new FileInfo(file);
              fileInfo.CopyTo(Path.Combine(drive.RootDirectory.FullName, fileInfo.Name), project.OverwriteFiles);
            }
            catch
            {
              fails.Add(string.Format("Could not copy: {0}", new FileInfo(file).Name));
            }
          }
        }

        failiures = fails;
        return fails.Count() == 0;
      }
      catch (Exception e)
      {
        failiures = new List<string>(new[] { "Unexpected exception during stamping operation: " + e.Message });
        return false;
      }
    }
  }
}

