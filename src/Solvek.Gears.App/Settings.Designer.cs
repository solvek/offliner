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
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.label3);
			this.Controls.Add(this._password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this._userName);
			this.Controls.Add(this._reqAuthentication);
			this.Controls.Add(this.label1);
			this.Controls.Add(this._proxyAddress);
			this.Controls.Add(this._useProxy);
			this.KeyPreview = true;
			this.Menu = this.mainMenu1;
			this.Name = "Settings";
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
	}
}