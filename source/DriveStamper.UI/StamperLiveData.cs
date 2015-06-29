using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveStamper.Entities;
using System.IO;

namespace DriveStamper.UI
{
  public class StamperLiveData
  {
    public static Project Project = null;
    public static eStampMode Mode = eStampMode.Manual;
    public static Dictionary<DriveInfo, eDriveState> Drives;

    public static Dictionary<DriveInfo, eDriveState> ObservedDriveState = new Dictionary<DriveInfo, eDriveState>();

    public static string SessionLog = String.Empty;

    public static event Action<string> OnProjectChanged = null;
    public static event Action<string> OnSessionLogChanged = null;
    public static event Action<Dictionary<DriveInfo, eDriveState>> OnDrivesUpdated = null;

    public static void SendProjectChanged()
    {
      if (OnProjectChanged != null)
      {
        string file = Project.DataFile != null ? new FileInfo(Project.DataFile).Name : "<new>";
        OnProjectChanged(file);
      }
    }

    public static void SendDrivesUpdate()
    {
      if (OnDrivesUpdated != null)
      {
        OnDrivesUpdated(ObservedDriveState);
      }
    }

    public static void Log(string msg)
    {
      string datedMsg = DateTime.Now.ToString("G") + " - " + msg + "\n";
      
      SessionLog += datedMsg;
      SaveToLog(datedMsg);

      if (OnSessionLogChanged != null)
      {
        OnSessionLogChanged(SessionLog);
      }
    }

    private static void SaveToLog(string msg)
    {
      File.AppendAllText(
        Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
          "stamper.log"),
        msg);
    }

    public static string GetLastProjectFilename()
    {
      return Properties.Stamper.Default.LastProject;
    }

    public static void SetLastProjectName(string filename)
    {
      Properties.Stamper.Default.LastProject = filename;
      Properties.Stamper.Default.Save();
    }
  }

  public enum eDriveState { Ready = 0, Stamped = 2, NoSpace = 1 }

  public enum eStampMode { Automatic, SemiAutomatic, Manual }

  public enum eActivity { None, Stamping }
}
