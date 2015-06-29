using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DriveStamper.Entities
{
  /// <summary>
  /// Represents a drive stamping project: information about which changes go where.
  /// </summary>
  [Serializable]
  public class Project
  {
    /// <summary>
    /// Flag indicating there is something more to save
    /// </summary>
    public bool UnsavedData { get; set; }

    /// <summary>
    /// Basic event to be triggered when the UnsavedData flag is changed.
    /// </summary>
    public event Action<bool> UnsavedDataChanged = null;

    /// <summary>
    /// File to save this project to
    /// </summary>
    public string DataFile { get; set; }

    /// <summary>
    /// Files to include
    /// </summary>
    public List<string> Content { get; set; }

    /// <summary>
    /// Drives to overlook
    /// </summary>
    public List<char> IgnoreDrives { get; set; }

    /// <summary>
    /// Setting to overwrite files if they already exist
    /// </summary>
    public bool OverwriteFiles { get; set; }

    /// <summary>
    /// Setting to ignore missing files
    /// </summary>
    public bool IgnoreMissingFiles { get; set; }

    /// <summary>
    /// Standard constructor for new projects.
    /// </summary>
    /// <param name="name"></param>
    public Project()
    {
      UnsavedData = true;
      DataFile = null;
      Content = new List<string>();
      IgnoreDrives = new List<char>();
    }

    public void SetDefaults()
    {
      IgnoreDrives.AddRange("abcd".ToCharArray());
      IgnoreMissingFiles = false;
      OverwriteFiles = true;
    }

    /// <summary>
    /// Retrieves a project from an XML file.
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static Project Load(FileInfo file)
    {
      return XmlHelper.Deserialize<Project>(File.ReadAllText(file.FullName));
    }

    /// <summary>
    /// Identifies any missing files in the project.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> IdentifyMissingFiles()
    {
      return Content.Where(f => !File.Exists(f));
    }
  }
}
