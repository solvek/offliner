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
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.listBoxWidgetManager = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "Refresh";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// listBoxWidgetManager
			// 
			this.listBoxWidgetManager.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxWidgetManager.Location = new System.Drawing.Point(0, 0);
			this.listBoxWidgetManager.Name = "listBoxWidgetManager";
			this.listBoxWidgetManager.Size = new System.Drawing.Size(240, 268);
			this.listBoxWidgetManager.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(240, 268);
			this.Controls.Add(this.listBoxWidgetManager);
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Solvek Gears";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ListBox listBoxWidgetManager;
	}
}

