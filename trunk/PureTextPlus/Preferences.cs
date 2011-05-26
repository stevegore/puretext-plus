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
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace PureTextPlus
{
	/// <summary>
	/// Singleton to hold preferences for the app and store and retrieve from the Registry.
	/// </summary>
	public sealed class Preferences
	{
		// singleton instance
		private static readonly Preferences instance = new Preferences();
		
		// app title
		public const String APPLICATION_TITLE = "PureText+";
		
		// registry key for app settings
		public const string REG_KEY_PURETEXT = @"SOFTWARE\Melloware\PureTextPlus";
		
		// registry key for windows startup entries
		public const string REG_KEY_STARTUP = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
		
		// fields
		public bool PlaySound = false;
		public bool ModifierWindows = true;
		public bool ModifierShift = false;
		public bool ModifierControl = false;
		public bool ModifierAlt = false;
		public bool Startup = false;
		public bool TrayIconVisible = true;
		public bool PasteIntoActiveWindow = true;
		public string Hotkey = "V";
		
		/// <summary>
		/// Singleton access
		/// </summary>
		public static Preferences Instance {
			get {
				return instance;
			}
		}
		
		/// <summary>
		/// Private no arg constructor for Singleton
		/// </summary>
		private Preferences()
		{
			// create the key if it does not exist
			RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_KEY_PURETEXT, true);
			if (key == null) {
				key = Registry.CurrentUser.CreateSubKey(REG_KEY_PURETEXT);
			}
			using (key)
			{
				PlaySound = Convert.ToBoolean(key.GetValue("PlaySound", false));
				ModifierWindows = Convert.ToBoolean(key.GetValue("ModifierWindows", true));
				ModifierShift = Convert.ToBoolean(key.GetValue("ModifierShift", false));
				ModifierControl = Convert.ToBoolean(key.GetValue("ModifierControl", false));
				ModifierAlt = Convert.ToBoolean(key.GetValue("ModifierAlt", false));
				Hotkey = (string) key.GetValue("Hotkey", "V");
				TrayIconVisible = Convert.ToBoolean(key.GetValue("TrayIconVisible", true));
				PasteIntoActiveWindow = Convert.ToBoolean(key.GetValue("PasteIntoActiveWindow", true));
			}
			
			key = Registry.CurrentUser.OpenSubKey(REG_KEY_STARTUP, true);
			using (key)
			{
				Startup = (key.GetValue(APPLICATION_TITLE) != null);
			}
		}
		
		/// <summary>
		/// Saves the values to the registry
		/// </summary>
		public void Save() {
			try {
				RegistryKey key = Registry.CurrentUser.OpenSubKey(REG_KEY_PURETEXT, true);
				using (key)
				{
					key.SetValue("PlaySound", PlaySound, RegistryValueKind.DWord);
					key.SetValue("ModifierWindows", ModifierWindows, RegistryValueKind.DWord);
					key.SetValue("ModifierShift", ModifierShift, RegistryValueKind.DWord);
					key.SetValue("ModifierControl", ModifierControl, RegistryValueKind.DWord);
					key.SetValue("ModifierAlt", ModifierAlt, RegistryValueKind.DWord);
					key.SetValue("TrayIconVisible", TrayIconVisible, RegistryValueKind.DWord);
					key.SetValue("PasteIntoActiveWindow", PasteIntoActiveWindow, RegistryValueKind.DWord);
					key.SetValue("Hotkey", Hotkey, RegistryValueKind.String);
				}
				
				// if startup is checked must add to Run registry entry of Windows
				if (Startup) {
					key = Registry.CurrentUser.OpenSubKey(REG_KEY_STARTUP, true);
					using (key)
					{
						key.SetValue(APPLICATION_TITLE, Application.ExecutablePath, RegistryValueKind.String);
					}
				} else {
					key = Registry.CurrentUser.OpenSubKey(REG_KEY_STARTUP, true);
					using (key)
					{
						key.DeleteValue(APPLICATION_TITLE);
					}
				}
			} catch (Exception ex) {
				// log the exception
				Debug.WriteLine("Unexpected Exception Saving to Registry" + ex.Message);
			}
		}
	}
}
