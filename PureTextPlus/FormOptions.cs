/*
    PureText+ - http://code.google.com/p/puretext-plus/
    
    Copyright (C) 2003 Steve P. Miller, http://www.stevemiller.net/puretext/
    Copyright (C) 2011 Melloware, http://www.melloware.com
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
    
    The idea of the Original PureText Code is Copyright (C) 2003 Steve P. Miller
    
    NO code was taken from the original project this was rewritten from scratch
    from just the idea of Puretext.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PureTextPlus
{
	/// <summary>
	/// Form for the user setting the Options.
	/// </summary>
	public partial class FormOptions : Form
	{
		public FormOptions()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			chkControl.Checked = Preferences.Instance.ModifierControl;
			chkShift.Checked = Preferences.Instance.ModifierShift;
			chkWin.Checked = Preferences.Instance.ModifierWindows;
			cboLetter.SelectedItem = Preferences.Instance.Hotkey;
			chkPasteActiveWindow.Checked = Preferences.Instance.PasteIntoActiveWindow;
			chkPlaySound.Checked = Preferences.Instance.PlaySound;
			chkRunAtStartup.Checked = Preferences.Instance.Startup;
			chkTrayIcon.Checked = Preferences.Instance.TrayIconVisible;
		}
		
		void BtnOKClick(object sender, EventArgs e)
		{
			Preferences.Instance.ModifierControl = chkControl.Checked;
			Preferences.Instance.ModifierShift = chkShift.Checked;
			Preferences.Instance.ModifierWindows = chkWin.Checked;
			Preferences.Instance.PasteIntoActiveWindow = chkPasteActiveWindow.Checked;
			Preferences.Instance.PlaySound = chkPlaySound.Checked;
			Preferences.Instance.Startup = chkRunAtStartup.Checked;
			Preferences.Instance.TrayIconVisible = chkTrayIcon.Checked;
			Preferences.Instance.Hotkey = (string)cboLetter.SelectedItem;
			
			Preferences.Instance.Save();
			this.DialogResult = DialogResult.OK;
			this.Close();

		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
