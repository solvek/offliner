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
			this.menuItemRefresh.Text = "Оновити";
			this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
			// 
			// menuItemSettings
			// 
			this.menuItemSettings.Text = "Налаштувати";
			this.menuItemSettings.Click += new System.EventHandler(this.menuItemSettings_Click);
			// 
			// listViewWidgets
			// 
			this.listViewWidgets.Columns.Add(this.columnHeaderName);
			this.listViewWidgets.Columns.Add(this.columnHeaderStatus);
			this.listViewWidgets.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewWidgets.FullRowSelect = true;
			this.listViewWidgets.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewWidgets.Location = new System.Drawing.Point(0, 0);
			this.listViewWidgets.Name = "listViewWidgets";
			this.listViewWidgets.Size = new System.Drawing.Size(480, 536);
			this.listViewWidgets.SmallImageList = this.imageListIcons;
			this.listViewWidgets.TabIndex = 0;
			this.listViewWidgets.View = System.Windows.Forms.View.Details;
			this.listViewWidgets.ItemActivate += new System.EventHandler(this.listViewWidgets_ItemActivate);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Віджет";
			this.columnHeaderName.Width = 279;
			// 
			// columnHeaderStatus
			// 
			this.columnHeaderStatus.Text = "Статус";
			this.columnHeaderStatus.Width = 304;
			// 
			// imageListIcons
			// 
			this.imageListIcons.ImageSize = new System.Drawing.Size(32, 32);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(480, 536);
			this.Controls.Add(this.listViewWidgets);
			this.Location = new System.Drawing.Point(0, 52);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Solvek Gears";
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

