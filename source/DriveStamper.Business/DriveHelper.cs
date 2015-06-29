using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using DriveStamper.Entities;

namespace DriveStamper.Business
{
  public class DriveHelper
  {
    /// <summary>
    /// Enumerates all drives. Finds all those with drive letters not being ignored
    /// that are ready to be used.
    /// </summary>
    /// <param name="project"></param>
    /// <returns></returns>
    public static IEnumerable<DriveInfo> FindDrives(Project project)
    {
      var drives = new List<DriveInfo>();
      if (project == null) { return drives; }

      foreach (var d in DriveInfo.GetDrives())
      {
        if (!project.IgnoreDrives.Select(i => i.ToString().ToLower()).Contains(d.Name.Substring(0,1).ToLower()) && d.IsReady)
        {
          drives.Add(d);
        }
      }
      return drives;
    }


  }
}
