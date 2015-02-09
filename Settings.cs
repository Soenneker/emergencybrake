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
using System.IO;
using System.Reflection;

#endregion

namespace EmergencyBrake
{
    public static class Settings
    {
        #region MEMBERS

        public static string WebsiteLocation = "http://soenneker.com";
        public static string HelpLocation = "https://emergencybrake.codeplex.com";
        public static string HandBrakeLocation = "https://handbrake.fr/";

        public static string TemporaryDataDir;

        /// <summary> A solid and sure location of where the executable really is. </summary>
        public static string ApplicationDirectory;

        public static string ApplicationFileName;
        public static string HandBrakeExe = "HandBrakeCLI.exe";
        public static string LogFileName = "Log.txt";

        #endregion MEMBERS

        public static void InitializeSettings()
        {
            try
            {
                TemporaryDataDir = Path.GetTempPath() + @"EmergencyBrake\";

                if (!Directory.Exists(TemporaryDataDir))
                    Directory.CreateDirectory(TemporaryDataDir);
            }
            catch (Exception e)
            {
                Engine.Error(e.ToString());
            }

            try
            {
                ApplicationDirectory = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch (Exception e)
            {
                Engine.Error(e.ToString());
            }

            ApplicationFileName = Assembly.GetEntryAssembly().GetName().Name + ".exe";
        }
    }
}