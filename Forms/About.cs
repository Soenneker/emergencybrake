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
using System.Windows.Forms;

#endregion

namespace EmergencyBrake
{
    public partial class About : ChildForm
    {
        public About(Form form) : base(form)
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            lblVersion.Text = Engine.Version.ToString();
        }

        private void About_Clicked(object sender, EventArgs e)
        {
            MoveToParentForm();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
            MoveToParentForm();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            MoveToParentForm();
        }

        private void lblWebsite_Click(object sender, EventArgs e)
        {
            Util.StartProcess(Settings.WebsiteLocation);
            MoveToParentForm();
        }

        private void lblHelp_Click(object sender, EventArgs e)
        {
            Util.StartProcess(Settings.HelpLocation);
            MoveToParentForm();
        }
    }
}