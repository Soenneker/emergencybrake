using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EmergencyBrake
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnConvert = new System.Windows.Forms.Button();
            this.btnBrowseHandBrake = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnBrowseTarget = new System.Windows.Forms.Button();
            this.txtHandBrakeLocation = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.lblHB = new System.Windows.Forms.Label();
            this.lblSourceFolder = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtHandBrakeProfile = new System.Windows.Forms.TextBox();
            this.lblFileConversion = new System.Windows.Forms.Label();
            this.lblNumFiles = new System.Windows.Forms.Label();
            this.chkDeleteSource = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSourceExtension = new System.Windows.Forms.TextBox();
            this.lblTargetExtension = new System.Windows.Forms.Label();
            this.txtTargetExtension = new System.Windows.Forms.TextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnConvert.Location = new System.Drawing.Point(12, 191);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(224, 27);
            this.btnConvert.TabIndex = 2;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Visible = false;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // btnBrowseHandBrake
            // 
            this.btnBrowseHandBrake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseHandBrake.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseHandBrake.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseHandBrake.Location = new System.Drawing.Point(321, 83);
            this.btnBrowseHandBrake.Name = "btnBrowseHandBrake";
            this.btnBrowseHandBrake.Size = new System.Drawing.Size(33, 22);
            this.btnBrowseHandBrake.TabIndex = 0;
            this.btnBrowseHandBrake.Text = "...";
            this.btnBrowseHandBrake.UseVisualStyleBackColor = true;
            this.btnBrowseHandBrake.Click += new System.EventHandler(this.btnBrowseHandBrake_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.HelpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(367, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(36, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.MouseEnter += new System.EventHandler(this.fileToolStripMenuItem_MouseEnter);
            this.fileToolStripMenuItem.MouseLeave += new System.EventHandler(this.fileToolStripMenuItem_MouseLeave);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            this.exitToolStripMenuItem.MouseEnter += new System.EventHandler(this.exitToolStripMenuItem_MouseEnter);
            this.exitToolStripMenuItem.MouseLeave += new System.EventHandler(this.exitToolStripMenuItem_MouseLeave);
            // 
            // HelpToolStripMenuItem
            // 
            this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.HelpToolStripMenuItem.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
            this.HelpToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.HelpToolStripMenuItem.Text = "Help";
            this.HelpToolStripMenuItem.MouseEnter += new System.EventHandler(this.HelpToolStripMenuItem_MouseEnter);
            this.HelpToolStripMenuItem.MouseLeave += new System.EventHandler(this.HelpToolStripMenuItem_MouseLeave);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.helpToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
            this.helpToolStripMenuItem1.MouseEnter += new System.EventHandler(this.helpToolStripMenuItem_MouseEnter);
            this.helpToolStripMenuItem1.MouseLeave += new System.EventHandler(this.helpToolStripMenuItem_MouseLeave);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            this.aboutToolStripMenuItem.MouseEnter += new System.EventHandler(this.aboutToolStripMenuItem_MouseEnter);
            this.aboutToolStripMenuItem.MouseLeave += new System.EventHandler(this.aboutToolStripMenuItem_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnBrowseTarget
            // 
            this.btnBrowseTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseTarget.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseTarget.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBrowseTarget.Location = new System.Drawing.Point(322, 40);
            this.btnBrowseTarget.Name = "btnBrowseTarget";
            this.btnBrowseTarget.Size = new System.Drawing.Size(33, 22);
            this.btnBrowseTarget.TabIndex = 1;
            this.btnBrowseTarget.Text = "...";
            this.btnBrowseTarget.UseVisualStyleBackColor = true;
            this.btnBrowseTarget.Click += new System.EventHandler(this.btnBrowseTarget_Click);
            // 
            // txtHandBrakeLocation
            // 
            this.txtHandBrakeLocation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHandBrakeLocation.ForeColor = System.Drawing.Color.White;
            this.txtHandBrakeLocation.Location = new System.Drawing.Point(119, 84);
            this.txtHandBrakeLocation.Name = "txtHandBrakeLocation";
            this.txtHandBrakeLocation.Size = new System.Drawing.Size(196, 22);
            this.txtHandBrakeLocation.TabIndex = 4;
            // 
            // txtSource
            // 
            this.txtSource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSource.ForeColor = System.Drawing.Color.White;
            this.txtSource.Location = new System.Drawing.Point(12, 40);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(304, 22);
            this.txtSource.TabIndex = 5;
            // 
            // lblHB
            // 
            this.lblHB.AutoSize = true;
            this.lblHB.ForeColor = System.Drawing.Color.White;
            this.lblHB.Location = new System.Drawing.Point(120, 69);
            this.lblHB.Name = "lblHB";
            this.lblHB.Size = new System.Drawing.Size(106, 15);
            this.lblHB.TabIndex = 6;
            this.lblHB.Text = "HandBrake Location";
            // 
            // lblSourceFolder
            // 
            this.lblSourceFolder.AutoSize = true;
            this.lblSourceFolder.ForeColor = System.Drawing.Color.White;
            this.lblSourceFolder.Location = new System.Drawing.Point(13, 24);
            this.lblSourceFolder.Name = "lblSourceFolder";
            this.lblSourceFolder.Size = new System.Drawing.Size(76, 15);
            this.lblSourceFolder.TabIndex = 7;
            this.lblSourceFolder.Text = "Source Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "HandBrake Profile";
            // 
            // txtHandBrakeProfile
            // 
            this.txtHandBrakeProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtHandBrakeProfile.ForeColor = System.Drawing.Color.White;
            this.txtHandBrakeProfile.Location = new System.Drawing.Point(12, 84);
            this.txtHandBrakeProfile.Name = "txtHandBrakeProfile";
            this.txtHandBrakeProfile.Size = new System.Drawing.Size(96, 22);
            this.txtHandBrakeProfile.TabIndex = 8;
            this.txtHandBrakeProfile.Text = "High Profile";
            // 
            // lblFileConversion
            // 
            this.lblFileConversion.AutoSize = true;
            this.lblFileConversion.ForeColor = System.Drawing.Color.White;
            this.lblFileConversion.Location = new System.Drawing.Point(12, 162);
            this.lblFileConversion.Name = "lblFileConversion";
            this.lblFileConversion.Size = new System.Drawing.Size(112, 15);
            this.lblFileConversion.TabIndex = 10;
            this.lblFileConversion.Text = "Files to be converted:";
            this.lblFileConversion.Visible = false;
            // 
            // lblNumFiles
            // 
            this.lblNumFiles.AutoSize = true;
            this.lblNumFiles.ForeColor = System.Drawing.Color.White;
            this.lblNumFiles.Location = new System.Drawing.Point(130, 162);
            this.lblNumFiles.Name = "lblNumFiles";
            this.lblNumFiles.Size = new System.Drawing.Size(13, 15);
            this.lblNumFiles.TabIndex = 11;
            this.lblNumFiles.Text = "0";
            this.lblNumFiles.Visible = false;
            // 
            // chkDeleteSource
            // 
            this.chkDeleteSource.AutoSize = true;
            this.chkDeleteSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDeleteSource.ForeColor = System.Drawing.Color.White;
            this.chkDeleteSource.Location = new System.Drawing.Point(241, 126);
            this.chkDeleteSource.Name = "chkDeleteSource";
            this.chkDeleteSource.Size = new System.Drawing.Size(113, 19);
            this.chkDeleteSource.TabIndex = 12;
            this.chkDeleteSource.Text = "Delete source files";
            this.chkDeleteSource.UseVisualStyleBackColor = true;
            this.chkDeleteSource.CheckedChanged += new System.EventHandler(this.chkDeleteSource_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "Source Extension";
            // 
            // txtSourceExtension
            // 
            this.txtSourceExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtSourceExtension.ForeColor = System.Drawing.Color.White;
            this.txtSourceExtension.Location = new System.Drawing.Point(12, 126);
            this.txtSourceExtension.Name = "txtSourceExtension";
            this.txtSourceExtension.Size = new System.Drawing.Size(96, 22);
            this.txtSourceExtension.TabIndex = 13;
            this.txtSourceExtension.Text = "mkv";
            // 
            // lblTargetExtension
            // 
            this.lblTargetExtension.AutoSize = true;
            this.lblTargetExtension.ForeColor = System.Drawing.Color.White;
            this.lblTargetExtension.Location = new System.Drawing.Point(120, 110);
            this.lblTargetExtension.Name = "lblTargetExtension";
            this.lblTargetExtension.Size = new System.Drawing.Size(90, 15);
            this.lblTargetExtension.TabIndex = 16;
            this.lblTargetExtension.Text = "Target Extension";
            // 
            // txtTargetExtension
            // 
            this.txtTargetExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtTargetExtension.ForeColor = System.Drawing.Color.White;
            this.txtTargetExtension.Location = new System.Drawing.Point(119, 126);
            this.txtTargetExtension.Name = "txtTargetExtension";
            this.txtTargetExtension.Size = new System.Drawing.Size(96, 22);
            this.txtTargetExtension.TabIndex = 15;
            this.txtTargetExtension.Text = "m4v";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalyze.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalyze.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAnalyze.Location = new System.Drawing.Point(12, 156);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(343, 62);
            this.btnAnalyze.TabIndex = 17;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(186, 162);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(168, 14);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 18;
            this.progressBar1.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancel.Location = new System.Drawing.Point(241, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(113, 27);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Unicode MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(61, 191);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(119, 25);
            this.lblStatus.TabIndex = 20;
            this.lblStatus.Text = "Converting...";
            this.lblStatus.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(367, 229);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblTargetExtension);
            this.Controls.Add(this.txtTargetExtension);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSourceExtension);
            this.Controls.Add(this.chkDeleteSource);
            this.Controls.Add(this.lblNumFiles);
            this.Controls.Add(this.lblFileConversion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHandBrakeProfile);
            this.Controls.Add(this.lblSourceFolder);
            this.Controls.Add(this.lblHB);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.txtHandBrakeLocation);
            this.Controls.Add(this.btnBrowseHandBrake);
            this.Controls.Add(this.btnBrowseTarget);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emergency Brake";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnBrowseHandBrake;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private Button btnBrowseTarget;
        private TextBox txtHandBrakeLocation;
        private TextBox txtSource;
        private Label lblHB;
        private Label lblSourceFolder;
        private Label label2;
        private TextBox txtHandBrakeProfile;
        private Label lblFileConversion;
        private Label lblNumFiles;
        private CheckBox chkDeleteSource;
        private Label label4;
        private TextBox txtSourceExtension;
        private Label lblTargetExtension;
        private TextBox txtTargetExtension;
        private Button btnAnalyze;
        private ProgressBar progressBar1;
        private Button btnCancel;
        private Label lblStatus;
    }
}

