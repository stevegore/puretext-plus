/*
    PureText+ - http://code.google.com/p/puretext-plus/
    
    Copyright (C) 2003 Steve P. Miller, http://www.stevemiller.net/puretext/
    Copyright (C) 2011 Melloware, http://www.melloware.com
    
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
    
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
