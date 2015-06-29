using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DriveStamper.Entities;
using System.IO;

namespace DriveStamper.UI
{
  public partial class ProjectForm : Form
  {
    private SaveFileDialog _saveDialog;
    private OpenFileDialog _openDialog;
    private OpenFileDialog _addFilesDialog;

    public ProjectForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Basic form initialisation.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ProjectForm_Load(object sender, EventArgs e)
    {
      StamperLiveData.OnProjectChanged += ProjectChanged;

      InitialiseDialogs();
      InitialiseIgnoreList();
      LoadFromProject();
    }

    public void ProjectChanged(string filename)
    {
      LoadFromProject();
    }

    /// <summary>
    /// Initialises the load/save dialogs.
    /// </summary>
    private void InitialiseDialogs()
    {
      _saveDialog = new SaveFileDialog();
      _saveDialog.Filter = "Drive Stamper Project Files (*.stp)|*.stp|All files (*.*)|*.*";
      _saveDialog.Title = "Save project";
      _saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      _saveDialog.CheckPathExists = true;

      _openDialog = new OpenFileDialog();
      _openDialog.Filter = "Drive Stamper Project Files (*.stp)|*.stp|All files (*.*)|*.*";
      _openDialog.Title = "Open project";
      _openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      _openDialog.Multiselect = false;
      _openDialog.CheckFileExists = true;
      _openDialog.CheckPathExists = true;

      _addFilesDialog = new OpenFileDialog();
      _addFilesDialog.Filter = "All files (*.*)|*.*";
      _addFilesDialog.Title = "Select files for inclusion";
      _addFilesDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
      _addFilesDialog.Multiselect = true;
      _addFilesDialog.CheckFileExists = true;
      _addFilesDialog.CheckPathExists = true;
    }

    /// <summary>
    /// Initialise the ignorable drives list.
    /// </summary>
    private void InitialiseIgnoreList()
    {
      IgnoreDrivesCheckedListBox.Items.Clear();
      foreach (var c in "abcdefghijklmnopqrstuvwxyz".ToCharArray())
      {
        IgnoreDrivesCheckedListBox.Items.Add(c);
      }
    }

    /// <summary>
    /// Load data from the Current Project.
    /// </summary>
    private void LoadFromProject()
    {
      Text = "DriveStamper Project: " + (CurrentProject.DataFile == null ? "new" : new FileInfo(CurrentProject.DataFile).Name);

      // include files
      FilesListBox.Items.Clear();
      foreach (var f in CurrentProject.Content)
      {
        FilesListBox.Items.Add(f);
      }

      // ignore drives
      for (int i = 0; i < IgnoreDrivesCheckedListBox.Items.Count; i++)
      {
        bool check = CurrentProject.IgnoreDrives.Contains(IgnoreDrivesCheckedListBox.Items[i].ToString()[0]);
        IgnoreDrivesCheckedListBox.SetItemChecked(i, check);
      }

      // settings
      IgnoreMissingFilesCheckbox.Checked = CurrentProject.IgnoreMissingFiles;
      OverwriteFilesCheckbox.Checked = CurrentProject.OverwriteFiles;
    }

    /// <summary>
    /// Save data to the Current Project
    /// </summary>
    private void SaveToCurrentProject()
    {
      Text = "DriveStamper Project: " + (CurrentProject.DataFile == null ? "new" : new FileInfo(CurrentProject.DataFile).Name);

      // files
      CurrentProject.Content = FilesListBox.Items.Cast<string>().ToList();

      // drives
      CurrentProject.IgnoreDrives = IgnoreDrivesCheckedListBox.CheckedItems.Cast<char>().ToList();

      // settings
      CurrentProject.IgnoreMissingFiles = IgnoreMissingFilesCheckbox.Checked;
      CurrentProject.OverwriteFiles = OverwriteFilesCheckbox.Checked;
    }

    /// <summary>
    /// The current project
    /// </summary>
    private Project CurrentProject 
    {
      get 
      { 
        return StamperLiveData.Project; 
      }
      set 
      {
        StamperLiveData.Project = value;
        LoadFromProject();
      }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenProject();
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // get filename
      var result = _saveDialog.ShowDialog();

      if (result == DialogResult.OK)
      {
        // set filename in project
        CurrentProject.DataFile = _saveDialog.FileName;

        // save project with that filename
        SaveProject();
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrWhiteSpace(CurrentProject.DataFile) || !new FileInfo(CurrentProject.DataFile).Directory.Exists)
      {
        saveAsToolStripMenuItem_Click(sender, e);
        return;
      }

      SaveProject();
    }

    public void OpenProject()
    {
      // get filename
      var result = _openDialog.ShowDialog();

      if (result == DialogResult.OK)
      {
        // set filename in project
        DriveStamperUI.LoadProject(_openDialog.FileName);
      }
    }

    private void SaveProject()
    {
      // commit data to CurrentProject
      SaveToCurrentProject();

      bool success;

      string data = XmlHelper.Serialize(CurrentProject, out success);

      if (success)
      {
        // actual save
        File.WriteAllText(CurrentProject.DataFile, data);

        MessageBox.Show(
          "Project saved.", "Save", 
          MessageBoxButtons.OK, MessageBoxIcon.Information);

        StamperLiveData.SendProjectChanged();
      }
      else
      {
        MessageBox.Show(
          "A problem occured serializing the project data.", 
          "Save error", 
          MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void IgnoreDrivesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        this.BeginInvoke(new MethodInvoker(SaveToCurrentProject), null);
    }

    private void IgnoreMissingFilesCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      this.BeginInvoke(new MethodInvoker(SaveToCurrentProject), null);
    }

    private void OverwriteFilesCheckbox_CheckedChanged(object sender, EventArgs e)
    {
      this.BeginInvoke(new MethodInvoker(SaveToCurrentProject), null);
    }

    private void AddFilesButton_Click(object sender, EventArgs e)
    {
      _addFilesDialog.ShowDialog();

      foreach (var f in _addFilesDialog.FileNames)
      {
        FilesListBox.Items.Add(f);
      }

      this.BeginInvoke(new MethodInvoker(SaveToCurrentProject), null);
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
      foreach (int i in FilesListBox.SelectedIndices.Cast<int>().OrderByDescending(i => i))
      {
        FilesListBox.Items.RemoveAt(i);
      }

      this.BeginInvoke(new MethodInvoker(SaveToCurrentProject), null);
    }

    private void IgnoreDrivesCheckedListBox_SelectedValueChanged(object sender, EventArgs e)
    {
      DriveStamperUI.Instance.UpdateDrives();
    }

    private void ProjectForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      StamperLiveData.OnProjectChanged -= ProjectChanged;
    }

  }
}
