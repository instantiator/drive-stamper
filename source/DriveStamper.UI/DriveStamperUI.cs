using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using DriveStamper.Entities;
using DriveStamper.Business;
using System.Collections.Generic;
using System.IO;

namespace DriveStamper.UI
{
  public class DriveStamperUI : Form
  {
    public static DriveStamperUI Instance;

    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      Instance = new DriveStamperUI();

      Application.Run(Instance);
    }

    private NotifyIcon _trayIcon;
    private ContextMenu _trayMenu;
    private ProjectForm _projectForm;
    private DrivesForm _drivesForm;

    internal DriveDetector DriveDetector { get; set; }

    public event Action<eActivity> OnActivityChanged = null;

    private static void InitialiseData()
    {
      string file = StamperLiveData.GetLastProjectFilename();

        LoadProject(file);
    }

    public static void LoadProject(string file)
    {
      if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
      {
        StamperLiveData.Project = new Project();
        StamperLiveData.Project.SetDefaults();
        StamperLiveData.SendProjectChanged();
        StamperLiveData.SetLastProjectName(string.Empty);
      }
      else
      {
        StamperLiveData.Project = XmlHelper.Deserialize<Project>(File.ReadAllText(file));
        StamperLiveData.SendProjectChanged();
        StamperLiveData.SetLastProjectName(file);
      }
    }

    public DriveStamperUI()
    {
      // Create a simple tray menu with only one item.
      _trayMenu = new ContextMenu();
      _trayMenu.MenuItems.Add("Project", OnProject);
      _trayMenu.MenuItems.Add("Drives", OnDrives);
      _trayMenu.MenuItems.Add("Exit", OnExit);

      // Create a tray icon. In this example we use a
      // standard system icon for simplicity, but you
      // can of course use your own custom icon too.
      _trayIcon = new NotifyIcon();
      _trayIcon.Text = "Drive Stamper";
      _trayIcon.Icon = new Icon(SystemIcons.Asterisk, 40, 40);

      // Add menu to tray icon and show it.
      _trayIcon.ContextMenu = _trayMenu;
      _trayIcon.Visible = true;

      DriveDetector = new DriveDetector();

      DriveDetector.DeviceArrived += OnDriveArrived;
      DriveDetector.DeviceRemoved += OnDriveRemoved;

      UpdateDrives();
    }

    public void UpdateDrives()
    {
      StamperLiveData.ObservedDriveState.Clear();

      var drives = DriveHelper.FindDrives(StamperLiveData.Project);

      foreach (var drive in drives)
      {
        bool done = Stamper.CheckDrive(drive, StamperLiveData.Project);
        bool space = Stamper.DriveHasSpace(drive, StamperLiveData.Project);

        eDriveState state = done ? eDriveState.Stamped : (space ? eDriveState.Ready : eDriveState.NoSpace);

        StamperLiveData.ObservedDriveState.Add(drive, state);
      }

      StamperLiveData.SendDrivesUpdate();
    }

    protected override void OnLoad(EventArgs e)
    {
      Visible = false; // Hide form window.
      ShowInTaskbar = false; // Remove from taskbar.

      base.OnLoad(e);

      StamperLiveData.Log("Application Started.");

      // load previous project or start new project
      InitialiseData();

      // show the drives form
      OnDrives(null, null);
    }

    private void OnExit(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void OnProject(object sender, EventArgs e)
    {
      if (_projectForm == null || _projectForm.IsDisposed)
      {
        _projectForm = new ProjectForm();
      }

      _projectForm.Show();
    }

    private void OnDrives(object sender, EventArgs e)
    {
      if (_drivesForm == null || _drivesForm.IsDisposed)
      {
        _drivesForm = new DrivesForm();
      }

      _drivesForm.Show();
    }

    private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
    {
      e.HookQueryRemove = false;
      UpdateDrives();

      // match the drive to a key already in the observed state
      var drive = StamperLiveData.ObservedDriveState.Keys.Where(k => k.Name == new DriveInfo(e.Drive).Name).FirstOrDefault();

      if (drive != null)
      {
        StamperLiveData.Log("Drive detected: " + e.Drive + " - in state: " + StamperLiveData.ObservedDriveState[drive].ToString());
      }
      else
      {
        StamperLiveData.Log("Drive detected: " + e.Drive + " - state not detected.");
      }

      if (drive != null && StamperLiveData.ObservedDriveState[drive] == eDriveState.Ready)
      {

        if (StamperLiveData.Mode == eStampMode.Automatic)
        {
          StampDrive(drive);
        }
        if (StamperLiveData.Mode == eStampMode.SemiAutomatic)
        {
          var answer = MessageBox.Show("Stamp drive: " + drive.Name + "?", "Drive detected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

          if (answer == System.Windows.Forms.DialogResult.Yes)
          {
            StampDrive(drive);
          }
        }

        UpdateDrives();
      }
    }

    public void StampDrive(DriveInfo drive)
    {
      try
      {
        if (OnActivityChanged != null)
        {
          OnActivityChanged(eActivity.Stamping);
        }

        IEnumerable<string> failiures = null;
        bool success = false;

        string msg = "Stamping drive: " + drive.Name;
        StamperLiveData.Log(msg);
        DriveStamperUI.ShowMessage(msg, ToolTipIcon.Info);

        success = Stamper.Stamp(drive, StamperLiveData.Project, out failiures);

        if (success)
        {
          string msgOk = "Drive stamped: " + drive.Name;
          StamperLiveData.Log(msgOk);
          DriveStamperUI.ShowMessage(msgOk, ToolTipIcon.Info);
        }
        else
        {
          string msgFail = "Drive not succesfully stamped:\n" + string.Join("\n", (failiures ?? new List<string>()).ToArray());
          StamperLiveData.Log(msgFail);
          DriveStamperUI.ShowMessage(msgFail, ToolTipIcon.Warning);
        }
      }
      catch (Exception e)
      {
        string msgFail = "Unexpected exception:\n" + e.Message;
        StamperLiveData.Log(msgFail);
        DriveStamperUI.ShowMessage(msgFail, ToolTipIcon.Warning);
      }
      finally
      {
        UpdateDrives();
        if (OnActivityChanged != null)
        {
          OnActivityChanged(eActivity.None);
        }
      }
    }

    /// <summary>
    /// Called by DriveDetector after removable device has been unplugged
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
    {
      StamperLiveData.Log("Drive removed: " + e.Drive);
      UpdateDrives();
    }

    protected override void Dispose(bool isDisposing)
    {
      if (isDisposing)
      {
        // Release the icon resource.
        _trayIcon.Dispose();
      }

      base.Dispose(isDisposing);
    }

    public static void ShowMessage(string msg, ToolTipIcon icon)
    {
      Instance._trayIcon.ShowBalloonTip(2000, "Drive Stamper", msg, icon);
    }

    public static void ShowProject()
    {
      Instance.OnProject(null, null);
    }

    public static void LoadAProject()
    {
      Instance.OnProject(null, null);
      Instance._projectForm.OpenProject();
    }
  }
}