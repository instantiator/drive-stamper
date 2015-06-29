namespace DriveStamper.UI
{
  partial class ProjectForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.icon = new System.Windows.Forms.NotifyIcon(this.components);
      this.FilesListBox = new System.Windows.Forms.ListBox();
      this.AddFilesButton = new System.Windows.Forms.Button();
      this.RemoveButton = new System.Windows.Forms.Button();
      this.FilesGroupBox = new System.Windows.Forms.GroupBox();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.OverwriteFilesCheckbox = new System.Windows.Forms.CheckBox();
      this.IgnoreMissingFilesCheckbox = new System.Windows.Forms.CheckBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.IgnoreDrivesCheckedListBox = new System.Windows.Forms.CheckedListBox();
      this.FilesGroupBox.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // icon
      // 
      this.icon.Text = "Notification";
      this.icon.Visible = true;
      // 
      // FilesListBox
      // 
      this.FilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.FilesListBox.FormattingEnabled = true;
      this.FilesListBox.Location = new System.Drawing.Point(5, 19);
      this.FilesListBox.Name = "FilesListBox";
      this.FilesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
      this.FilesListBox.Size = new System.Drawing.Size(307, 173);
      this.FilesListBox.TabIndex = 4;
      // 
      // AddFilesButton
      // 
      this.AddFilesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.AddFilesButton.Location = new System.Drawing.Point(156, 198);
      this.AddFilesButton.Name = "AddFilesButton";
      this.AddFilesButton.Size = new System.Drawing.Size(75, 23);
      this.AddFilesButton.TabIndex = 5;
      this.AddFilesButton.Text = "&Add Files...";
      this.AddFilesButton.UseVisualStyleBackColor = true;
      this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
      // 
      // RemoveButton
      // 
      this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.RemoveButton.Location = new System.Drawing.Point(237, 198);
      this.RemoveButton.Name = "RemoveButton";
      this.RemoveButton.Size = new System.Drawing.Size(75, 23);
      this.RemoveButton.TabIndex = 6;
      this.RemoveButton.Text = "&Remove";
      this.RemoveButton.UseVisualStyleBackColor = true;
      this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
      // 
      // FilesGroupBox
      // 
      this.FilesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.FilesGroupBox.Controls.Add(this.RemoveButton);
      this.FilesGroupBox.Controls.Add(this.AddFilesButton);
      this.FilesGroupBox.Controls.Add(this.FilesListBox);
      this.FilesGroupBox.Location = new System.Drawing.Point(12, 27);
      this.FilesGroupBox.Name = "FilesGroupBox";
      this.FilesGroupBox.Size = new System.Drawing.Size(318, 228);
      this.FilesGroupBox.TabIndex = 7;
      this.FilesGroupBox.TabStop = false;
      this.FilesGroupBox.Text = "Files to stamp";
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(337, 24);
      this.menuStrip1.TabIndex = 8;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // projectToolStripMenuItem
      // 
      this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.saveToolStripMenuItem});
      this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
      this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
      this.projectToolStripMenuItem.Text = "&Project";
      // 
      // openToolStripMenuItem
      // 
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.openToolStripMenuItem.Text = "&Open...";
      this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
      // 
      // saveAsToolStripMenuItem
      // 
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As...";
      this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
      // 
      // saveToolStripMenuItem
      // 
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
      this.saveToolStripMenuItem.Text = "&Save...";
      this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox2.Controls.Add(this.OverwriteFilesCheckbox);
      this.groupBox2.Controls.Add(this.IgnoreMissingFilesCheckbox);
      this.groupBox2.Location = new System.Drawing.Point(12, 261);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(130, 104);
      this.groupBox2.TabIndex = 9;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Settings";
      // 
      // OverwriteFilesCheckbox
      // 
      this.OverwriteFilesCheckbox.AutoSize = true;
      this.OverwriteFilesCheckbox.Location = new System.Drawing.Point(6, 46);
      this.OverwriteFilesCheckbox.Name = "OverwriteFilesCheckbox";
      this.OverwriteFilesCheckbox.Size = new System.Drawing.Size(92, 17);
      this.OverwriteFilesCheckbox.TabIndex = 1;
      this.OverwriteFilesCheckbox.Text = "Overwrite files";
      this.OverwriteFilesCheckbox.UseVisualStyleBackColor = true;
      this.OverwriteFilesCheckbox.CheckedChanged += new System.EventHandler(this.OverwriteFilesCheckbox_CheckedChanged);
      // 
      // IgnoreMissingFilesCheckbox
      // 
      this.IgnoreMissingFilesCheckbox.AutoSize = true;
      this.IgnoreMissingFilesCheckbox.Location = new System.Drawing.Point(6, 23);
      this.IgnoreMissingFilesCheckbox.Name = "IgnoreMissingFilesCheckbox";
      this.IgnoreMissingFilesCheckbox.Size = new System.Drawing.Size(114, 17);
      this.IgnoreMissingFilesCheckbox.TabIndex = 0;
      this.IgnoreMissingFilesCheckbox.Text = "Ignore missing files";
      this.IgnoreMissingFilesCheckbox.UseVisualStyleBackColor = true;
      this.IgnoreMissingFilesCheckbox.CheckedChanged += new System.EventHandler(this.IgnoreMissingFilesCheckbox_CheckedChanged);
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.groupBox1.Controls.Add(this.IgnoreDrivesCheckedListBox);
      this.groupBox1.Location = new System.Drawing.Point(151, 261);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(179, 104);
      this.groupBox1.TabIndex = 10;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Ignore Drives";
      // 
      // IgnoreDrivesCheckedListBox
      // 
      this.IgnoreDrivesCheckedListBox.FormattingEnabled = true;
      this.IgnoreDrivesCheckedListBox.Location = new System.Drawing.Point(6, 19);
      this.IgnoreDrivesCheckedListBox.Name = "IgnoreDrivesCheckedListBox";
      this.IgnoreDrivesCheckedListBox.Size = new System.Drawing.Size(167, 79);
      this.IgnoreDrivesCheckedListBox.TabIndex = 0;
      this.IgnoreDrivesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.IgnoreDrivesCheckedListBox_ItemCheck);
      this.IgnoreDrivesCheckedListBox.SelectedValueChanged += new System.EventHandler(this.IgnoreDrivesCheckedListBox_SelectedValueChanged);
      // 
      // ProjectForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(337, 373);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.FilesGroupBox);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "ProjectForm";
      this.Text = "DriveStamper Project: <none>";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProjectForm_FormClosed);
      this.Load += new System.EventHandler(this.ProjectForm_Load);
      this.FilesGroupBox.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.NotifyIcon icon;
    private System.Windows.Forms.ListBox FilesListBox;
    private System.Windows.Forms.Button AddFilesButton;
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.GroupBox FilesGroupBox;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    private System.Windows.Forms.CheckBox OverwriteFilesCheckbox;
    private System.Windows.Forms.CheckBox IgnoreMissingFilesCheckbox;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.CheckedListBox IgnoreDrivesCheckedListBox;
  }
}

