namespace Solvek.Gears.App
{
	partial class Settings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MainMenu mainMenu1;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this._useProxy = new System.Windows.Forms.CheckBox();
			this._proxyAddress = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this._reqAuthentication = new System.Windows.Forms.CheckBox();
			this._userName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._password = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem2);
			// 
			// menuItem1
			// 
			resources.ApplyResources(this.menuItem1, "menuItem1");
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			resources.ApplyResources(this.menuItem2, "menuItem2");
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// _useProxy
			// 
			resources.ApplyResources(this._useProxy, "_useProxy");
			this._useProxy.Name = "_useProxy";
			this._useProxy.CheckStateChanged += new System.EventHandler(this._useProxy_CheckStateChanged);
			// 
			// _proxyAddress
			// 
			resources.ApplyResources(this._proxyAddress, "_proxyAddress");
			this._proxyAddress.Name = "_proxyAddress";
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// _reqAuthentication
			// 
			resources.ApplyResources(this._reqAuthentication, "_reqAuthentication");
			this._reqAuthentication.Name = "_reqAuthentication";
			this._reqAuthentication.CheckStateChanged += new System.EventHandler(this._reqAuthorization_CheckStateChanged);
			// 
			// _userName
			// 
			resources.ApplyResources(this._userName, "_userName");
			this._userName.Name = "_userName";
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// label3
			// 
			resources.ApplyResources(this.label3, "label3");
			this.label3.Name = "label3";
			// 
			// _password
			// 
			resources.ApplyResources(this._password, "_password");
			this._password.Name = "_password";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			resources.ApplyResources(this.tabControl1, "tabControl1");
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.comboBoxLanguage);
			resources.ApplyResources(this.tabPage1, "tabPage1");
			this.tabPage1.Name = "tabPage1";
			// 
			// label4
			// 
			resources.ApplyResources(this.label4, "label4");
			this.label4.Name = "label4";
			// 
			// comboBoxLanguage
			// 
			this.comboBoxLanguage.DisplayMember = "Language";
			resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
			this.comboBoxLanguage.Name = "comboBoxLanguage";
			this.comboBoxLanguage.ValueMember = "Code";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this._useProxy);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this._proxyAddress);
			this.tabPage2.Controls.Add(this._password);
			this.tabPage2.Controls.Add(this.label1);
			this.tabPage2.Controls.Add(this.label2);
			this.tabPage2.Controls.Add(this._reqAuthentication);
			this.tabPage2.Controls.Add(this._userName);
			resources.ApplyResources(this.tabPage2, "tabPage2");
			this.tabPage2.Name = "tabPage2";
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.tabControl1);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "Settings";
			this.Load += new System.EventHandler(this.Settings_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.CheckBox _useProxy;
		private System.Windows.Forms.TextBox _proxyAddress;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox _reqAuthentication;
		private System.Windows.Forms.TextBox _userName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox _password;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxLanguage;
	}
}