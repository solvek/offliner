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
			this.menuItem1.Text = "Ок";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "Скасувати";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// _useProxy
			// 
			this._useProxy.Location = new System.Drawing.Point(21, 20);
			this._useProxy.Name = "_useProxy";
			this._useProxy.Size = new System.Drawing.Size(348, 40);
			this._useProxy.TabIndex = 0;
			this._useProxy.Text = "Використовувати проксі";
			this._useProxy.CheckStateChanged += new System.EventHandler(this._useProxy_CheckStateChanged);
			// 
			// _proxyAddress
			// 
			this._proxyAddress.Location = new System.Drawing.Point(242, 93);
			this._proxyAddress.Name = "_proxyAddress";
			this._proxyAddress.Size = new System.Drawing.Size(201, 41);
			this._proxyAddress.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(221, 40);
			this.label1.Text = "Проксі (хост:порт)";
			// 
			// _reqAuthentication
			// 
			this._reqAuthentication.Location = new System.Drawing.Point(21, 248);
			this._reqAuthentication.Name = "_reqAuthentication";
			this._reqAuthentication.Size = new System.Drawing.Size(360, 50);
			this._reqAuthentication.TabIndex = 6;
			this._reqAuthentication.Text = "Потрібна авторизація";
			this._reqAuthentication.CheckStateChanged += new System.EventHandler(this._reqAuthorization_CheckStateChanged);
			// 
			// _userName
			// 
			this._userName.Location = new System.Drawing.Point(242, 304);
			this._userName.Name = "_userName";
			this._userName.Size = new System.Drawing.Size(201, 41);
			this._userName.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 304);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(175, 41);
			this.label2.Text = "Користувач";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 377);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 41);
			this.label3.Text = "Пароль";
			// 
			// _password
			// 
			this._password.Location = new System.Drawing.Point(242, 377);
			this._password.Name = "_password";
			this._password.PasswordChar = '*';
			this._password.Size = new System.Drawing.Size(201, 41);
			this._password.TabIndex = 3;
			// 
			// Settings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(480, 536);
			this.Controls.Add(this._useProxy);
			this.Controls.Add(this.label3);
			this.Controls.Add(this._userName);
			this.Controls.Add(this._proxyAddress);
			this.Controls.Add(this._reqAuthentication);
			this.Controls.Add(this._password);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.KeyPreview = true;
			this.Location = new System.Drawing.Point(0, 52);
			this.Menu = this.mainMenu1;
			this.Name = "Settings";
			this.Text = "Налаштування";
			this.Load += new System.EventHandler(this.Settings_Load);
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