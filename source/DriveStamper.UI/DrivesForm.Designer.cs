namespace DriveStamper.UI
{
  partial class DrivesForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrivesForm));
      this.DrivesListView = new System.Windows.Forms.ListView();
      this.driveColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.stateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.DriveStatesImageList = new System.Windows.Forms.ImageList(this.components);
      this.drivesTabsControl = new System.Windows.Forms.TabControl();
      this.liveViewTabPage = new System.Windows.Forms.TabPage();
      this.StampButton = new System.Windows.Forms.Button();
      this.UpdateButton = new System.Windows.Forms.Button();
      this.SemiAutomaticRadio = new System.Windows.Forms.RadioButton();
      this.ManualRadio = new System.Windows.Forms.RadioButton();
      this.AutomaticRadio = new System.Windows.Forms.RadioButton();
      this.logTabPage = new System.Windows.Forms.TabPage();
      this.SessionLogBox = new System.Windows.Forms.RichTextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.LoadProjectButton = new System.Windows.Forms.Button();
      this.EditProjectButton = new System.Windows.Forms.Button();
      this.projectLabel = new System.Windows.Forms.Label();
      this.NewProjectButton = new System.Windows.Forms.Button();
      this.drivesTabsControl.SuspendLayout();
      this.liveViewTabPage.SuspendLayout();
      this.logTabPage.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // DrivesListView
      // 
      this.DrivesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.DrivesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.driveColumnHeader,
            this.stateColumnHeader});
      this.DrivesListView.FullRowSelect = true;
      this.DrivesListView.LargeImageList = this.DriveStatesImageList;
      this.DrivesListView.Location = new System.Drawing.Point(6, 29);
      this.DrivesListView.MultiSelect = false;
      this.DrivesListView.Name = "DrivesListView";
      this.DrivesListView.Size = new System.Drawing.Size(341, 270);
      this.DrivesListView.SmallImageList = this.DriveStatesImageList;
      this.DrivesListView.TabIndex = 0;
      this.DrivesListView.UseCompatibleStateImageBehavior = false;
      this.DrivesListView.View = System.Windows.Forms.View.Details;
      // 
      // driveColumnHeader
      // 
      this.driveColumnHeader.Text = "Drive";
      this.driveColumnHeader.Width = 78;
      // 
      // stateColumnHeader
      // 
      this.stateColumnHeader.Text = "State";
      this.stateColumnHeader.Width = 161;
      // 
      // DriveStatesImageList
      // 
      this.DriveStatesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DriveStatesImageList.ImageStream")));
      this.DriveStatesImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.DriveStatesImageList.Images.SetKeyName(0, "001_09.png");
      this.DriveStatesImageList.Images.SetKeyName(1, "001_02.png");
      this.DriveStatesImageList.Images.SetKeyName(2, "001_06.png");
      // 
      // drivesTabsControl
      // 
      this.drivesTabsControl.Controls.Add(this.liveViewTabPage);
      this.drivesTabsControl.Controls.Add(this.logTabPage);
      this.drivesTabsControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.drivesTabsControl.Location = new System.Drawing.Point(0, 33);
      this.drivesTabsControl.Name = "drivesTabsControl";
      this.drivesTabsControl.SelectedIndex = 0;
      this.drivesTabsControl.Size = new System.Drawing.Size(361, 362);
      this.drivesTabsControl.TabIndex = 1;
      // 
      // liveViewTabPage
      // 
      this.liveViewTabPage.Controls.Add(this.StampButton);
      this.liveViewTabPage.Controls.Add(this.UpdateButton);
      this.liveViewTabPage.Controls.Add(this.SemiAutomaticRadio);
      this.liveViewTabPage.Controls.Add(this.ManualRadio);
      this.liveViewTabPage.Controls.Add(this.AutomaticRadio);
      this.liveViewTabPage.Controls.Add(this.DrivesListView);
      this.liveViewTabPage.Location = new System.Drawing.Point(4, 22);
      this.liveViewTabPage.Name = "liveViewTabPage";
      this.liveViewTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.liveViewTabPage.Size = new System.Drawing.Size(353, 336);
      this.liveViewTabPage.TabIndex = 0;
      this.liveViewTabPage.Text = "Live View";
      this.liveViewTabPage.UseVisualStyleBackColor = true;
      // 
      // StampButton
      // 
      this.StampButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.StampButton.Location = new System.Drawing.Point(267, 306);
      this.StampButton.Name = "StampButton";
      this.StampButton.Size = new System.Drawing.Size(78, 22);
      this.StampButton.TabIndex = 5;
      this.StampButton.Text = "&Stamp";
      this.StampButton.UseVisualStyleBackColor = true;
      this.StampButton.Click += new System.EventHandler(this.StampButton_Click);
      // 
      // UpdateButton
      // 
      this.UpdateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.UpdateButton.Location = new System.Drawing.Point(8, 305);
      this.UpdateButton.Name = "UpdateButton";
      this.UpdateButton.Size = new System.Drawing.Size(75, 23);
      this.UpdateButton.TabIndex = 4;
      this.UpdateButton.Text = "&Refresh";
      this.UpdateButton.UseVisualStyleBackColor = true;
      this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
      // 
      // SemiAutomaticRadio
      // 
      this.SemiAutomaticRadio.AutoSize = true;
      this.SemiAutomaticRadio.Location = new System.Drawing.Point(86, 6);
      this.SemiAutomaticRadio.Name = "SemiAutomaticRadio";
      this.SemiAutomaticRadio.Size = new System.Drawing.Size(98, 17);
      this.SemiAutomaticRadio.TabIndex = 3;
      this.SemiAutomaticRadio.TabStop = true;
      this.SemiAutomaticRadio.Text = "Semi-Automatic";
      this.SemiAutomaticRadio.UseVisualStyleBackColor = true;
      this.SemiAutomaticRadio.CheckedChanged += new System.EventHandler(this.SemiAutomaticRadio_CheckedChanged);
      // 
      // ManualRadio
      // 
      this.ManualRadio.AutoSize = true;
      this.ManualRadio.Location = new System.Drawing.Point(190, 6);
      this.ManualRadio.Name = "ManualRadio";
      this.ManualRadio.Size = new System.Drawing.Size(60, 17);
      this.ManualRadio.TabIndex = 2;
      this.ManualRadio.TabStop = true;
      this.ManualRadio.Text = "Manual";
      this.ManualRadio.UseVisualStyleBackColor = true;
      this.ManualRadio.CheckedChanged += new System.EventHandler(this.ManualRadio_CheckedChanged);
      // 
      // AutomaticRadio
      // 
      this.AutomaticRadio.AutoSize = true;
      this.AutomaticRadio.Location = new System.Drawing.Point(8, 6);
      this.AutomaticRadio.Name = "AutomaticRadio";
      this.AutomaticRadio.Size = new System.Drawing.Size(72, 17);
      this.AutomaticRadio.TabIndex = 1;
      this.AutomaticRadio.TabStop = true;
      this.AutomaticRadio.Text = "Automatic";
      this.AutomaticRadio.UseVisualStyleBackColor = true;
      this.AutomaticRadio.CheckedChanged += new System.EventHandler(this.AutomaticRadio_CheckedChanged);
      // 
      // logTabPage
      // 
      this.logTabPage.Controls.Add(this.SessionLogBox);
      this.logTabPage.Location = new System.Drawing.Point(4, 22);
      this.logTabPage.Name = "logTabPage";
      this.logTabPage.Padding = new System.Windows.Forms.Padding(3);
      this.logTabPage.Size = new System.Drawing.Size(353, 336);
      this.logTabPage.TabIndex = 1;
      this.logTabPage.Text = "Session Log";
      this.logTabPage.UseVisualStyleBackColor = true;
      // 
      // SessionLogBox
      // 
      this.SessionLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SessionLogBox.Location = new System.Drawing.Point(3, 3);
      this.SessionLogBox.Name = "SessionLogBox";
      this.SessionLogBox.Size = new System.Drawing.Size(347, 330);
      this.SessionLogBox.TabIndex = 0;
      this.SessionLogBox.Text = "";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.NewProjectButton);
      this.panel1.Controls.Add(this.LoadProjectButton);
      this.panel1.Controls.Add(this.EditProjectButton);
      this.panel1.Controls.Add(this.projectLabel);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(361, 33);
      this.panel1.TabIndex = 2;
      // 
      // LoadProjectButton
      // 
      this.LoadProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.LoadProjectButton.Location = new System.Drawing.Point(137, 4);
      this.LoadProjectButton.Name = "LoadProjectButton";
      this.LoadProjectButton.Size = new System.Drawing.Size(75, 23);
      this.LoadProjectButton.TabIndex = 2;
      this.LoadProjectButton.Text = "&Load...";
      this.LoadProjectButton.UseVisualStyleBackColor = true;
      this.LoadProjectButton.Click += new System.EventHandler(this.LoadProjectButton_Click);
      // 
      // EditProjectButton
      // 
      this.EditProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.EditProjectButton.Location = new System.Drawing.Point(218, 4);
      this.EditProjectButton.Name = "EditProjectButton";
      this.EditProjectButton.Size = new System.Drawing.Size(75, 23);
      this.EditProjectButton.TabIndex = 1;
      this.EditProjectButton.Text = "&Edit...";
      this.EditProjectButton.UseVisualStyleBackColor = true;
      this.EditProjectButton.Click += new System.EventHandler(this.EditProjectButton_Click);
      // 
      // projectLabel
      // 
      this.projectLabel.AutoSize = true;
      this.projectLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectLabel.Location = new System.Drawing.Point(7, 7);
      this.projectLabel.Name = "projectLabel";
      this.projectLabel.Size = new System.Drawing.Size(104, 16);
      this.projectLabel.TabIndex = 0;
      this.projectLabel.Text = "Project: <new>";
      // 
      // NewProjectButton
      // 
      this.NewProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.NewProjectButton.Location = new System.Drawing.Point(299, 4);
      this.NewProjectButton.Name = "NewProjectButton";
      this.NewProjectButton.Size = new System.Drawing.Size(58, 23);
      this.NewProjectButton.TabIndex = 3;
      this.NewProjectButton.Text = "&New...";
      this.NewProjectButton.UseVisualStyleBackColor = true;
      this.NewProjectButton.Click += new System.EventHandler(this.NewProjectButton_Click);
      // 
      // DrivesForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(361, 395);
      this.Controls.Add(this.drivesTabsControl);
      this.Controls.Add(this.panel1);
      this.Name = "DrivesForm";
      this.Text = "DrivesForm";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DrivesForm_FormClosed);
      this.Load += new System.EventHandler(this.DrivesForm_Load);
      this.drivesTabsControl.ResumeLayout(false);
      this.liveViewTabPage.ResumeLayout(false);
      this.liveViewTabPage.PerformLayout();
      this.logTabPage.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView DrivesListView;
    private System.Windows.Forms.ColumnHeader driveColumnHeader;
    private System.Windows.Forms.ColumnHeader stateColumnHeader;
    private System.Windows.Forms.TabControl drivesTabsControl;
    private System.Windows.Forms.TabPage liveViewTabPage;
    private System.Windows.Forms.RadioButton SemiAutomaticRadio;
    private System.Windows.Forms.RadioButton ManualRadio;
    private System.Windows.Forms.RadioButton AutomaticRadio;
    private System.Windows.Forms.TabPage logTabPage;
    private System.Windows.Forms.Button StampButton;
    private System.Windows.Forms.Button UpdateButton;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button EditProjectButton;
    private System.Windows.Forms.Label projectLabel;
    private System.Windows.Forms.ImageList DriveStatesImageList;
    private System.Windows.Forms.Button LoadProjectButton;
    private System.Windows.Forms.RichTextBox SessionLogBox;
    private System.Windows.Forms.Button NewProjectButton;
  }
}