#region LICENSE

/*
Emergency Brake - A simple application to recursively convert media utilizing HandBrake.
Copyright (C) 2014 Soenneker LLC

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion LICENSE

#region

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#endregion

namespace EmergencyBrake
{
    public partial class Form1 : Form
    {
        public delegate void BarDelegate();

        private readonly object _countLock = new object();
        private readonly List<string> filesToDo = new List<string>();
        private bool CancelConversion;
        private bool DeleteSourceFile;

        private string HandBrakeDir = "";

        private string HandBrakeProfile = "";
        private string SourceDirectory = "";
        private string SourceExtension = "";
        private string TargetExtension = "";
        private int _threadCount;

        private int fileCount;

        // This is the delegate that runs on the UI thread to update the bar.

        public Form1()
        {
            InitializeComponent();
            Engine.InitializeEngine();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ActiveControl = txtSource;

            string program32 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\";
            string program64 = program32.Substring(0, program32.Length - 7) + @"\";

            if (Directory.Exists(program64 + @"HandBrake\"))
                HandBrakeDir = program64 + @"HandBrake\";
            else if (Directory.Exists(program32 + @"HandBrake\"))
                HandBrakeDir = program32 + @"HandBrake\";

            if (HandBrakeDir != "" && !File.Exists(HandBrakeDir + "HandBrakeCLI.exe"))
            {
                Engine.Error("HandBrakeCLI.exe has not been found in the HandBrake directory! Please download it from " + Settings.HandBrakeLocation +
                             " or select a different directory.");
                HandBrakeDir = "";
            }

            txtHandBrakeLocation.Text = HandBrakeDir;
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            Engine.ClosingOverride(e);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ColoringReset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!HelpToolStripMenuItem.Selected && !HelpToolStripMenuItem.DropDown.Visible && HelpToolStripMenuItem.ForeColor == Color.FromArgb(64, 64, 64))
                HelpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);

            if (!fileToolStripMenuItem.Selected && !fileToolStripMenuItem.DropDown.Visible && fileToolStripMenuItem.ForeColor == Color.FromArgb(64, 64, 64))
                fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void ProcessFile(object a)
        {
            while (true)
            {
                lock (_countLock)
                {
                    if (_threadCount < 1)
                    {
                        _threadCount++;

                        try
                        {
                            ProcessVideo(((ThreadInfo)a).FileName);
                            Invoke(new BarDelegate(UpdateBar));
                        }
                        catch {}
                        finally
                        {
                            _threadCount--;
                        }

                        break;
                    }
                }
                Thread.Sleep(50);
            }
        }

        private void UpdateBar()
        {
            progressBar1.Value++;

            fileCount++;

            lblNumFiles.Text = (filesToDo.Count - fileCount) + @" / " + filesToDo.Count;

            if (progressBar1.Value == progressBar1.Maximum)
            {
                lblStatus.Visible = false;
                progressBar1.Visible = false;
                btnCancel.Visible = false;
                btnAnalyze.Visible = true;
                filesToDo.Clear();
                lblNumFiles.Text = "0";
                MessageBox.Show("All files have been converted!", "Success!", MessageBoxButtons.OK);
                EnableInputs();
            }
        }

        private void DisableInputs()
        {
            txtSource.Enabled = false;
            txtHandBrakeLocation.Enabled = false;
            txtHandBrakeProfile.Enabled = false;
            txtSourceExtension.Enabled = false;
            txtTargetExtension.Enabled = false;
            chkDeleteSource.Enabled = false;
            btnBrowseHandBrake.Enabled = false;
            btnBrowseTarget.Enabled = false;
        }

        private void EnableInputs()
        {
            txtSource.Enabled = true;
            txtHandBrakeLocation.Enabled = true;
            txtHandBrakeProfile.Enabled = true;
            txtSourceExtension.Enabled = true;
            txtTargetExtension.Enabled = true;
            chkDeleteSource.Enabled = true;
            btnBrowseHandBrake.Enabled = true;
            btnBrowseTarget.Enabled = true;
        }

        #region MENU STRIP

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            Refresh();
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);

            About ab = new About(this);
            ab.Show();

            Visible = false;
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Util.StartProcess(Settings.HelpLocation);
        }

        #region COLORING

        private void fileToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            fileToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            HelpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void fileToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!fileToolStripMenuItem.Selected && !fileToolStripMenuItem.DropDown.Visible)
                fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void HelpToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            HelpToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
            fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void HelpToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            if (!HelpToolStripMenuItem.Selected && !HelpToolStripMenuItem.DropDown.Visible)
                HelpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void aboutToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void aboutToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void exitToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void exitToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            exitToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void helpToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void helpToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            helpToolStripMenuItem1.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void ColoringReset()
        {
            fileToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
            HelpToolStripMenuItem.ForeColor = Color.FromArgb(255, 255, 255);
        }

        #endregion COLORING

        #endregion MENU STRIP

        #region BUTTONS

        private void btnBrowseHandBrake_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                txtHandBrakeLocation.Text = fbd.SelectedPath + @"\";
                HandBrakeDir = txtHandBrakeLocation.Text;
            }

            if (!File.Exists(HandBrakeDir + Settings.HandBrakeExe))
            {
                Engine.Error("HandBrakeCLI.exe has not been found in the HandBrake directory! Please download it from " + Settings.HandBrakeLocation +
                             " or select a different directory.");
                txtHandBrakeLocation.Text = "";
            }
        }

        private void btnBrowseTarget_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();

            if (dr == DialogResult.OK)
                txtSource.Text = fbd.SelectedPath + @"\";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelConversion = true;
            Engine.KillProcess(Settings.HandBrakeExe.Substring(0, Settings.HandBrakeExe.Length - 4));

            progressBar1.Visible = false;
            btnConvert.Visible = false;
            btnCancel.Visible = false;
            btnAnalyze.Visible = true;
            lblNumFiles.Text = "0";
            filesToDo.Clear();
            btnAnalyze.Select();
            EnableInputs();
        }

        private bool ErrorDetection()
        {
            if (txtSource.Text.Trim() != "")
            {
                SourceDirectory = txtSource.Text;

                if (!Directory.Exists(SourceDirectory))
                    Engine.Error("Target directory does not exist!");
            }
            else
            {
                Engine.Error("Please input a target media directory.");
                return false;
            }

            if (txtHandBrakeProfile.Text.Trim() != "")
                HandBrakeProfile = txtHandBrakeProfile.Text;
            else
            {
                Engine.Error("Please input a HandBrake profile.");
                return false;
            }

            if (txtSourceExtension.Text.Trim() != "")
                SourceExtension = txtSourceExtension.Text;
            else
            {
                Engine.Error("Please input a source media extension.");
                return false;
            }

            if (txtTargetExtension.Text.Trim() != "")
                TargetExtension = txtTargetExtension.Text;
            else
            {
                Engine.Error("Please input a target media extension.");
                return false;
            }

            DeleteSourceFile = chkDeleteSource.Checked;

            if (SourceExtension == TargetExtension)
            {
                Engine.Error("The source and target media extension cannot be the same.");
                return false;
            }

            return true;
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            if (!ErrorDetection())
                return;

            progressBar1.Value = 0;
            fileCount = 0;
            lblNumFiles.Visible = true;
            lblFileConversion.Visible = true;
            lblStatus.Visible = false;
            CancelConversion = false;

            string[] files;

            try
            {
                files = Directory.GetFiles(SourceDirectory, "*.*", SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                Engine.Error("Cannot retrieve Target Directory file list! Exception: " + ex);
                return;
            }

            foreach (string s in files)
            {
                if (s.EndsWith(SourceExtension))
                    filesToDo.Add(s);
            }

            lblNumFiles.Text = filesToDo.Count.ToString();

            if (filesToDo.Count == 0)
                Engine.Error("There are currently no files to be converted using the source extension you chose.");
            else
            {
                DisableInputs();
                btnConvert.Visible = true;
                btnCancel.Visible = true;
                btnAnalyze.Visible = false;
                btnConvert.Select();
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            lblStatus.Visible = true;
            btnConvert.Visible = false;
            btnCancel.Select();
            lblNumFiles.Text = filesToDo.Count + @" / " + filesToDo.Count;

            progressBar1.Maximum = filesToDo.Count;
            progressBar1.Minimum = 0;
            progressBar1.Visible = true;

            foreach (string s in filesToDo)
            {
                ThreadInfo threadInfo = new ThreadInfo();
                threadInfo.FileName = s;

                ThreadPool.QueueUserWorkItem(ProcessFile, threadInfo);
            }
        }

        private void ProcessVideo(string s)
        {
            if (!CancelConversion)
            {
                List<string> commands = new List<string>();
                commands.Add("cd " + HandBrakeDir);
                string directory = "\"" + Path.GetDirectoryName(s) + "\\";
                string input = Path.GetFileName(s).Substring(0, Path.GetFileName(s).Length - 4);

                if (File.Exists(input + TargetExtension))
                    File.Delete(input + TargetExtension);

                commands.Add(Settings.HandBrakeExe + " -i " + directory + input + "." + SourceExtension + "\"" + " -o " + directory + input + "." + TargetExtension + "\"" +
                             " --preset=\"" + HandBrakeProfile + "\"");

               Engine.ImmediateLog(Engine.CommandPrompt(commands));

                if (DeleteSourceFile)
                    DeleteFile(s);
            }
        }

        private static void DeleteFile(string file)
        {
            int count = 0;
            bool success = false;

            while (success == false)
            {
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                    success = true;
                }
                catch (Exception e)
                {
                    count++;

                    if (count < 20)
                    {
                        success = true;
                        throw;
                    }
                    Thread.Sleep(2000);
                }
            }
        }

        private void chkDeleteSource_CheckedChanged(object sender, EventArgs e)
        {
            DeleteSourceFile = chkDeleteSource.Checked;
        }

        #endregion BUTTONS
    }
}