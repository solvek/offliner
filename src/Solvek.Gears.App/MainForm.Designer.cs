namespace Solvek.Gears.App
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemRefresh = new System.Windows.Forms.MenuItem();
			this.menuItemSettings = new System.Windows.Forms.MenuItem();
			this.listViewWidgets = new System.Windows.Forms.ListView();
			this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderStatus = new System.Windows.Forms.ColumnHeader();
			this.imageListIcons = new System.Windows.Forms.ImageList();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItemRefresh);
			this.mainMenu1.MenuItems.Add(this.menuItemSettings);
			// 
			// menuItemRefresh
			// 
			resources.ApplyResources(this.menuItemRefresh, "menuItemRefresh");
			this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
			// 
			// menuItemSettings
			// 
			resources.ApplyResources(this.menuItemSettings, "menuItemSettings");
			this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
			// 
			// listViewWidgets
			// 
			resources.ApplyResources(this.listViewWidgets, "listViewWidgets");
			this.listViewWidgets.Columns.Add(this.columnHeaderName);
			this.listViewWidgets.Columns.Add(this.columnHeaderStatus);
			this.listViewWidgets.FullRowSelect = true;
			this.listViewWidgets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewWidgets.Name = "listViewWidgets";
			this.listViewWidgets.SmallImageList = this.imageListIcons;
			this.listViewWidgets.View = System.Windows.Forms.View.Details;
			this.listViewWidgets.ItemActivate += new System.EventHandler(this.listViewWidgets_ItemActivate);
			// 
			// columnHeaderName
			// 
			resources.ApplyResources(this.columnHeaderName, "columnHeaderName");
			// 
			// columnHeaderStatus
			// 
			resources.ApplyResources(this.columnHeaderStatus, "columnHeaderStatus");
			// 
			// imageListIcons
			// 
			resources.ApplyResources(this.imageListIcons, "imageListIcons");
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.listViewWidgets);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem menuItemRefresh;
		private System.Windows.Forms.ListView listViewWidgets;
		private System.Windows.Forms.MenuItem menuItemSettings;
		private System.Windows.Forms.ImageList imageListIcons;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderStatus;
	}
}

