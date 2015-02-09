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

using System.ComponentModel;
using System.Windows.Forms;

#endregion

namespace EmergencyBrake
{
    public partial class ChildForm : Form
    {
        private readonly Form parent;
        private bool cancel;

        /// <summary> For designer only. Do not use when inheriting. </summary>
        protected ChildForm()
        {
            InitializeComponent();
        }

        protected ChildForm(Form parentForm)
        {
            cancel = false;
            parent = parentForm;
            InitializeComponent();
        }

        private void ChildForm_Closing(object sender, CancelEventArgs e)
        {
            if (!cancel)
                Engine.ClosingOverride(e);
        }

        protected void MoveToParentForm()
        {
            cancel = true;
            parent.Visible = true;
            parent.Focus();
            Close();
        }
    }
}