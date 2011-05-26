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
using System.Reflection;

namespace PureTextPlus
{
	/// <summary>
	/// Description of frmAbout.
	/// </summary>
	public partial class FormAbout : Form
	{
		public FormAbout()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
			AssemblyName asmName = assembly.GetName();
			this.lblTitle.Text = String.Format("{0} {1}", Preferences.APPLICATION_TITLE, asmName.Version );
			
			object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
			if ((customAttributes != null) && (customAttributes.Length > 0)) {
				this.lblDescription.Text = ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
			}
			customAttributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			if ((customAttributes != null) && (customAttributes.Length > 0))
				this.lblCopyright.Text = ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
			
		}
		
		void BtnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
