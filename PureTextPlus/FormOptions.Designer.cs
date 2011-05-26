/*
 * Created by SharpDevelop.
 * User: lefkoe
 * Date: 5/26/2011
 * Time: 12:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PureTextPlus
{
	partial class FormOptions
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOptions));
			this.gbHotkey = new System.Windows.Forms.GroupBox();
			this.chkControl = new System.Windows.Forms.CheckBox();
			this.chkShift = new System.Windows.Forms.CheckBox();
			this.chkWin = new System.Windows.Forms.CheckBox();
			this.cboLetter = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbActions = new System.Windows.Forms.GroupBox();
			this.chkPasteActiveWindow = new System.Windows.Forms.CheckBox();
			this.chkPlaySound = new System.Windows.Forms.CheckBox();
			this.gbGlobal = new System.Windows.Forms.GroupBox();
			this.chkRunAtStartup = new System.Windows.Forms.CheckBox();
			this.chkTrayIcon = new System.Windows.Forms.CheckBox();
			this.gbHotkey.SuspendLayout();
			this.gbActions.SuspendLayout();
			this.gbGlobal.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbHotkey
			// 
			this.gbHotkey.Controls.Add(this.cboLetter);
			this.gbHotkey.Controls.Add(this.chkWin);
			this.gbHotkey.Controls.Add(this.chkShift);
			this.gbHotkey.Controls.Add(this.chkControl);
			this.gbHotkey.Location = new System.Drawing.Point(12, 12);
			this.gbHotkey.Name = "gbHotkey";
			this.gbHotkey.Size = new System.Drawing.Size(319, 116);
			this.gbHotkey.TabIndex = 0;
			this.gbHotkey.TabStop = false;
			this.gbHotkey.Text = "Hotkey to convert the clipboard to pure text";
			// 
			// chkControl
			// 
			this.chkControl.Location = new System.Drawing.Point(219, 20);
			this.chkControl.Name = "chkControl";
			this.chkControl.Size = new System.Drawing.Size(84, 24);
			this.chkControl.TabIndex = 0;
			this.chkControl.Text = "Control";
			this.chkControl.UseVisualStyleBackColor = true;
			// 
			// chkShift
			// 
			this.chkShift.Location = new System.Drawing.Point(219, 50);
			this.chkShift.Name = "chkShift";
			this.chkShift.Size = new System.Drawing.Size(84, 24);
			this.chkShift.TabIndex = 1;
			this.chkShift.Text = "Shift";
			this.chkShift.UseVisualStyleBackColor = true;
			// 
			// chkWin
			// 
			this.chkWin.Location = new System.Drawing.Point(219, 80);
			this.chkWin.Name = "chkWin";
			this.chkWin.Size = new System.Drawing.Size(84, 24);
			this.chkWin.TabIndex = 2;
			this.chkWin.Text = "Windows";
			this.chkWin.UseVisualStyleBackColor = true;
			// 
			// cboLetter
			// 
			this.cboLetter.FormattingEnabled = true;
			this.cboLetter.Items.AddRange(new object[] {
									"A",
									"B",
									"C",
									"D",
									"E",
									"F",
									"G",
									"H",
									"I",
									"J",
									"K",
									"L",
									"M",
									"N",
									"O",
									"P",
									"Q",
									"R",
									"S",
									"T",
									"U",
									"V",
									"X",
									"Y",
									"Z",
									"0",
									"1",
									"2",
									"3",
									"4",
									"5",
									"6",
									"7",
									"8",
									"9",
									"-",
									"=",
									"[",
									"]",
									";",
									"\'",
									",",
									".",
									"/",
									"`"});
			this.cboLetter.Location = new System.Drawing.Point(6, 22);
			this.cboLetter.Name = "cboLetter";
			this.cboLetter.Size = new System.Drawing.Size(198, 21);
			this.cboLetter.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(336, 12);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(336, 41);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// gbActions
			// 
			this.gbActions.Controls.Add(this.chkPlaySound);
			this.gbActions.Controls.Add(this.chkPasteActiveWindow);
			this.gbActions.Location = new System.Drawing.Point(12, 134);
			this.gbActions.Name = "gbActions";
			this.gbActions.Size = new System.Drawing.Size(319, 84);
			this.gbActions.TabIndex = 3;
			this.gbActions.TabStop = false;
			this.gbActions.Text = "Perform actions on Hotkey pressed";
			// 
			// chkPasteActiveWindow
			// 
			this.chkPasteActiveWindow.Location = new System.Drawing.Point(7, 20);
			this.chkPasteActiveWindow.Name = "chkPasteActiveWindow";
			this.chkPasteActiveWindow.Size = new System.Drawing.Size(296, 24);
			this.chkPasteActiveWindow.TabIndex = 0;
			this.chkPasteActiveWindow.Text = "Paste converted text into active window";
			this.chkPasteActiveWindow.UseVisualStyleBackColor = true;
			// 
			// chkPlaySound
			// 
			this.chkPlaySound.Location = new System.Drawing.Point(7, 50);
			this.chkPlaySound.Name = "chkPlaySound";
			this.chkPlaySound.Size = new System.Drawing.Size(296, 24);
			this.chkPlaySound.TabIndex = 1;
			this.chkPlaySound.Text = "Play a sound";
			this.chkPlaySound.UseVisualStyleBackColor = true;
			// 
			// gbGlobal
			// 
			this.gbGlobal.Controls.Add(this.chkTrayIcon);
			this.gbGlobal.Controls.Add(this.chkRunAtStartup);
			this.gbGlobal.Location = new System.Drawing.Point(12, 224);
			this.gbGlobal.Name = "gbGlobal";
			this.gbGlobal.Size = new System.Drawing.Size(319, 80);
			this.gbGlobal.TabIndex = 4;
			this.gbGlobal.TabStop = false;
			this.gbGlobal.Text = "Global Options";
			// 
			// chkRunAtStartup
			// 
			this.chkRunAtStartup.Location = new System.Drawing.Point(7, 20);
			this.chkRunAtStartup.Name = "chkRunAtStartup";
			this.chkRunAtStartup.Size = new System.Drawing.Size(306, 24);
			this.chkRunAtStartup.TabIndex = 0;
			this.chkRunAtStartup.Text = "Automatically run at Windows startup";
			this.chkRunAtStartup.UseVisualStyleBackColor = true;
			// 
			// chkTrayIcon
			// 
			this.chkTrayIcon.Location = new System.Drawing.Point(7, 50);
			this.chkTrayIcon.Name = "chkTrayIcon";
			this.chkTrayIcon.Size = new System.Drawing.Size(306, 24);
			this.chkTrayIcon.TabIndex = 1;
			this.chkTrayIcon.Text = "Show Tray Icon (WARNING registry edit req to enable)";
			this.chkTrayIcon.UseVisualStyleBackColor = true;
			// 
			// FormOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 313);
			this.Controls.Add(this.gbGlobal);
			this.Controls.Add(this.gbActions);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gbHotkey);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormOptions";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PureText+ Options";
			this.gbHotkey.ResumeLayout(false);
			this.gbActions.ResumeLayout(false);
			this.gbGlobal.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox chkRunAtStartup;
		private System.Windows.Forms.CheckBox chkTrayIcon;
		private System.Windows.Forms.GroupBox gbGlobal;
		private System.Windows.Forms.CheckBox chkPasteActiveWindow;
		private System.Windows.Forms.CheckBox chkPlaySound;
		private System.Windows.Forms.GroupBox gbActions;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ComboBox cboLetter;
		private System.Windows.Forms.CheckBox chkControl;
		private System.Windows.Forms.CheckBox chkShift;
		private System.Windows.Forms.CheckBox chkWin;
		private System.Windows.Forms.GroupBox gbHotkey;
	}
}
