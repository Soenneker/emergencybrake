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
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

#endregion

namespace EmergencyBrake
{
    public static class Engine
    {
        /// <summary> Threading lock around log writer</summary>
        public static readonly Object LogLock = new Object();

        public static Version Version;

        public static void InitializeEngine()
        {
            Settings.InitializeSettings();
            Version = Util.GetVersion(Settings.ApplicationDirectory + Settings.ApplicationFileName);
        }

        public static void ClosingOverride(CancelEventArgs e)
        {
            Program.ExitApplication();
        }

        public static void Error(string exception)
        {
            MessageBox.Show("Error!: " + exception, "Error!", MessageBoxButtons.OK);
        }

        public static void KillProcess(string processName)
        {
            try
            {
                Process[] proc = Process.GetProcessesByName(processName);
                if (proc.Length > 0)
                    proc[0].Kill();
            }
            catch (Exception e)
            {
                Error("Error killing the process! Exception: " + e);
            }
        }

        public static string CommandPrompt(List<string> commands)
        {
            Process CMDprocess = null;

            try
            {
                string tempGETCMD = null;
                CMDprocess = new Process();
                ProcessStartInfo StartInfo = new ProcessStartInfo();
                StartInfo.FileName = "cmd";
                StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                StartInfo.CreateNoWindow = true;
                StartInfo.RedirectStandardInput = true;
                StartInfo.RedirectStandardOutput = true;
                StartInfo.UseShellExecute = false;
                CMDprocess.StartInfo = StartInfo;
                CMDprocess.Start();

                StreamReader SR = CMDprocess.StandardOutput;
                StreamWriter SW = CMDprocess.StandardInput;

                foreach (string s in commands)
                {
                    SW.WriteLine(s);
                }

                SW.WriteLine("exit");
                tempGETCMD = SR.ReadToEnd();
                SW.Close();
                SR.Close();
                CMDprocess.WaitForExit();
                return tempGETCMD;
            }
            catch (Exception e)
            {
                Error("Error starting the process with administrator privileges! Exception: " + e);
            }
            finally
            {
                if (CMDprocess != null)
                    CMDprocess.Dispose();
            }

            return "";
        }

        /// <summary> Writes directly to the log file, not waiting for the update delay. Also creates a Toolbox.Debug Message.</summary>
        /// <param name="msg">The message to be written</param>
        public static void ImmediateLog(string msg)
        {
            lock (LogLock)
            {
                StreamWriter logWriter = null;

                try
                {
                    Util.Debug("ImmediateLog! Content: " + msg);

                    string message = DateTime.Now + " " + msg;
                    logWriter = File.AppendText(Settings.TemporaryDataDir + Settings.LogFileName);

                    logWriter.WriteLine(message);
                    logWriter.Flush();
                    logWriter.Close();
                }
                catch (Exception e)
                {
                    Util.Debug("ImmediateLog() failed! " + e);
                }

                if (logWriter != null)
                    logWriter.Dispose();
            }
        }
    }
}