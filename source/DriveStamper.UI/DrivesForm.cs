using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveStamper.Business;
using System.IO;

namespace DriveStamper.UI
{
  public partial class DrivesForm : Form
  {

    public DrivesForm()
    {
      InitializeComponent();
    }

    private void AutomaticRadio_CheckedChanged(object sender, EventArgs e)
    {
      SaveModeToLiveData();
    }

    private void SemiAutomaticRadio_CheckedChanged(object sender, EventArgs e)
    {
      SaveModeToLiveData();
    }

    private void ManualRadio_CheckedChanged(object sender, EventArgs e)
    {
      SaveModeToLiveData();
    }

    private void SaveModeToLiveData()
    {
      if (AutomaticRadio.Checked)
      {
        StamperLiveData.Mode = eStampMode.Automatic;
      }
      if (SemiAutomaticRadio.Checked)
      {
        StamperLiveData.Mode = eStampMode.SemiAutomatic;
      }
      if (ManualRadio.Checked)
      {
        StamperLiveData.Mode = eStampMode.Manual;
      }

      UpdateManualStampButton();
    }

    private void UpdateManualStampButton()
    {
      StampButton.Enabled = (StamperLiveData.Mode == eStampMode.Manual);
    }

    private void DrivesForm_Load(object sender, EventArgs e)
    {
      LoadModeFromLiveData();
      LoadSessionLogFromLiveData();

      DriveStamperUI.Instance.OnActivityChanged += ActivityChanged;

      StamperLiveData.OnProjectChanged += ProjectChanged;
      StamperLiveData.OnSessionLogChanged += SessionLogChanged;
      StamperLiveData.SendProjectChanged();

      StamperLiveData.OnDrivesUpdated += DrivesUpdated;
      DriveStamperUI.Instance.UpdateDrives();
    }

    public void ProjectChanged(string project)
    {
      projectLabel.Text = "Project: " + project;
      DriveStamperUI.Instance.UpdateDrives();
    }

    private void LoadModeFromLiveData()
    {
      switch (StamperLiveData.Mode)
      {
        case eStampMode.Automatic:
          AutomaticRadio.Checked = true;
          break;
        case eStampMode.SemiAutomatic:
          SemiAutomaticRadio.Checked = true;
          break;
        case eStampMode.Manual:
          ManualRadio.Checked = true;
          break;
      }
      UpdateManualStampButton();
    }

    private void LoadSessionLogFromLiveData()
    {
      SessionLogBox.Text = StamperLiveData.SessionLog;
    }

    private void UpdateButton_Click(object sender, EventArgs e)
    {
      DriveStamperUI.Instance.UpdateDrives();
    }

    private void DrivesUpdated(Dictionary<DriveInfo, eDriveState> drives)
    {
      DrivesListView.Items.Clear();
      foreach (var drive in drives)
      {
        ListViewItem item = new ListViewItem(new [] { drive.Key.Name, drive.Value.ToString() }, (int)drive.Value);
        DrivesListView.Items.Add(item);
      }
    }

    private void DrivesForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      StamperLiveData.OnDrivesUpdated -= DrivesUpdated;
      StamperLiveData.OnProjectChanged -= ProjectChanged;
      StamperLiveData.OnSessionLogChanged -= SessionLogChanged;
      DriveStamperUI.Instance.OnActivityChanged -= ActivityChanged;

      DriveStamperUI.ShowMessage("Drive Stamper is still running.", ToolTipIcon.Info);
    }

    private void EditProjectButton_Click(object sender, EventArgs e)
    {
      DriveStamperUI.ShowProject();
    }

    public void ActivityChanged(eActivity activity)
    {
      switch (activity)
      {
        case eActivity.Stamping:
          Cursor.Current = Cursors.WaitCursor;
          StampButton.Enabled = false;
          DrivesListView.Enabled = false;
          Refresh();
          break;
        default:
          DrivesListView.Enabled = true;
          UpdateManualStampButton();
          Cursor.Current = Cursors.Default;
          break;
      }
    }
    

    private void StampButton_Click(object sender, EventArgs e)
    {
      if (DrivesListView.SelectedItems.Count > 1) { return; }

      // do selected drive
      if (DrivesListView.SelectedItems.Count == 1)
      {
        var selection = DrivesListView.SelectedItems[0];
        var drivename = selection.SubItems[0].Text;
        DriveStamperUI.Instance.StampDrive(new DriveInfo(drivename));
      }
      else
      {
        // nothing selected - do all 'Ready' drives
        foreach (var drive in StamperLiveData.ObservedDriveState.ToList())
        {
          if (drive.Value == eDriveState.Ready)
          {
            DriveStamperUI.Instance.StampDrive(drive.Key);
          }
        }
      }
    }

    private void LoadProjectButton_Click(object sender, EventArgs e)
    {
      DriveStamperUI.LoadAProject();
    }

    private void SessionLogChanged(string log)
    {
      SessionLogBox.Text = log;
    }

    private void NewProjectButton_Click(object sender, EventArgs e)
    {
      DriveStamperUI.LoadProject(null);
    }
  }
}
