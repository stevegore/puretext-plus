/*
    PureText+ - http://code.google.com/p/puretext-plus/
    
    Copyright (C) 2003 Steve P. Miller, http://www.stevemiller.net/puretext/
    Copyright (C) 2011 Melloware, http://www.melloware.com
    Copyright (C) 2012 Anderson Direct Marketing, http://www.andersondm.com
    
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
		public bool Startup = false;
		public bool TrayIconVisible = true;
		public bool PasteIntoActiveWindow = true;
		public bool ModifierPureWindows = true;
		public bool ModifierPureShift = false;
		public bool ModifierPureControl = false;
		public bool ModifierPureAlt = false;
		public string Hotkey = "V";
		public bool ModifierPlainWindows = true;
		public bool ModifierPlainShift = false;
		public bool ModifierPlainControl = false;
		public bool ModifierPlainAlt = false;
		public string PlainTextHotKey = "OemPeriod";
		public bool ModifierHtmlWindows = true;
		public bool ModifierHtmlShift = false;
		public bool ModifierHtmlControl = false;
		public bool ModifierHtmlAlt = false;
		public string HtmlTextHotKey = "Oemcomma";
		
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
				ModifierPureWindows = Convert.ToBoolean(key.GetValue("ModifierPureWindows", true));
				ModifierPureShift = Convert.ToBoolean(key.GetValue("ModifierPureShift", false));
				ModifierPureControl = Convert.ToBoolean(key.GetValue("ModifierPureControl", false));
				ModifierPureAlt = Convert.ToBoolean(key.GetValue("ModifierPureAlt", false));
				ModifierPlainWindows = Convert.ToBoolean(key.GetValue("ModifierPlainWindows", true));
				ModifierPlainShift = Convert.ToBoolean(key.GetValue("ModifierPlainShift", false));
				ModifierPlainControl = Convert.ToBoolean(key.GetValue("ModifierPlainControl", false));
				ModifierPlainAlt = Convert.ToBoolean(key.GetValue("ModifierPlainAlt", false));
				ModifierHtmlWindows = Convert.ToBoolean(key.GetValue("ModifierHtmlWindows", true));
				ModifierHtmlShift = Convert.ToBoolean(key.GetValue("ModifierHtmlShift", false));
				ModifierHtmlControl = Convert.ToBoolean(key.GetValue("ModifierHtmlControl", false));
				ModifierHtmlAlt = Convert.ToBoolean(key.GetValue("ModifierHtmlAlt", false));
				Hotkey = (string) key.GetValue("Hotkey", "V");
				PlainTextHotKey = (string)key.GetValue("PlainTextHotKey", "OemPeriod");
				HtmlTextHotKey = (string)key.GetValue("HtmlTextHotKey", "Oemcomma");
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
					key.SetValue("ModifierPureWindows", ModifierPureWindows, RegistryValueKind.DWord);
					key.SetValue("ModifierPureShift", ModifierPureShift, RegistryValueKind.DWord);
					key.SetValue("ModifierPureControl", ModifierPureControl, RegistryValueKind.DWord);
					key.SetValue("ModifierPureAlt", ModifierPureAlt, RegistryValueKind.DWord);
					key.SetValue("ModifierPlainWindows", ModifierPlainWindows, RegistryValueKind.DWord);
					key.SetValue("ModifierPlainShift", ModifierPlainShift, RegistryValueKind.DWord);
					key.SetValue("ModifierPlainControl", ModifierPlainControl, RegistryValueKind.DWord);
					key.SetValue("ModifierPlainAlt", ModifierPlainAlt, RegistryValueKind.DWord);
					key.SetValue("ModifierHtmlWindows", ModifierHtmlWindows, RegistryValueKind.DWord);
					key.SetValue("ModifierHtmlShift", ModifierHtmlShift, RegistryValueKind.DWord);
					key.SetValue("ModifierHtmlControl", ModifierHtmlControl, RegistryValueKind.DWord);
					key.SetValue("ModifierHtmlAlt", ModifierHtmlAlt, RegistryValueKind.DWord);
					key.SetValue("TrayIconVisible", TrayIconVisible, RegistryValueKind.DWord);
					key.SetValue("PasteIntoActiveWindow", PasteIntoActiveWindow, RegistryValueKind.DWord);
					key.SetValue("Hotkey", Hotkey, RegistryValueKind.String);
					key.SetValue("PlainTextHotKey", PlainTextHotKey, RegistryValueKind.String);
					key.SetValue("HtmlTextHotKey", HtmlTextHotKey, RegistryValueKind.String);
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
