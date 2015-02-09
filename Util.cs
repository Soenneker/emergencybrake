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
using System.Diagnostics;
using System.IO;
using System.Reflection;

#endregion

namespace EmergencyBrake
{
    public static class Util
    {
        /// <summary> Starts a process in a SAFE (try/catch) way. </summary>
        public static void StartProcess(string process)
        {
            Process proc = null;

            try
            {
                proc = Process.Start(process);
            }
            catch (Exception e)
            {
                Engine.Error(e.ToString());
            }
            finally
            {
                if (proc != null)
                    proc.Dispose();
            }
        }

        /// <summary> Prints a message to System.Diagnostics.Debug IF the program is in Debug mode. </summary>
        /// <param name="msg">The string to print.</param>
        [Conditional("DEBUG")]
        public static void Debug(string msg)
        {
            System.Diagnostics.Debug.WriteLine(msg);
        }

        /// <summary>
        /// Retrieves the version of a executable via a file name. Local files UNACCEPTABLE (Full location only).
        /// Exception safe, and will give 0.0 if it fails.
        /// </summary>
        /// <param name="fullFileName"></param>
        /// <returns></returns>
        public static Version GetVersion(string fullFileName)
        {
            Version version = new Version();

            try
            {
                if (File.Exists(fullFileName))
                    version = AssemblyName.GetAssemblyName(fullFileName).Version;
                else
                    Engine.Error("Could not retrieve version! File does not exist!: " + fullFileName);
            }
            catch (Exception e)
            {
                Engine.Error("Could not load assembly version! Exception: " + e);
            }

            return version;
        }
    }
}