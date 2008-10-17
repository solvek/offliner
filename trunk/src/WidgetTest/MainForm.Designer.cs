namespace Solvek.Offliner.WidgetTest
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

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
			this.widgetPath = new System.Windows.Forms.TextBox();
			this.buttonBrowse = new System.Windows.Forms.Button();
			this.tabMains = new System.Windows.Forms.TabControl();
			this.tabPageWidget = new System.Windows.Forms.TabPage();
			this.webBrowserWidget = new System.Windows.Forms.WebBrowser();
			this.tabPageXml = new System.Windows.Forms.TabPage();
			this.textBoxXml = new System.Windows.Forms.TextBox();
			this.tabPageLog = new System.Windows.Forms.TabPage();
			this.textBoxLog = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonLoadWidget = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonUpdate = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonClearLog = new System.Windows.Forms.ToolStripButton();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.tabMains.SuspendLayout();
			this.tabPageWidget.SuspendLayout();
			this.tabPageXml.SuspendLayout();
			this.tabPageLog.SuspendLayout();
			this.panel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// widgetPath
			// 
			this.widgetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.widgetPath.Location = new System.Drawing.Point(6, 4);
			this.widgetPath.Name = "widgetPath";
			this.widgetPath.Size = new System.Drawing.Size(764, 20);
			this.widgetPath.TabIndex = 0;
			// 
			// buttonBrowse
			// 
			this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonBrowse.Location = new System.Drawing.Point(776, 4);
			this.buttonBrowse.Name = "buttonBrowse";
			this.buttonBrowse.Size = new System.Drawing.Size(25, 20);
			this.buttonBrowse.TabIndex = 1;
			this.buttonBrowse.Text = "...";
			this.buttonBrowse.UseVisualStyleBackColor = true;
			this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
			// 
			// tabMains
			// 
			this.tabMains.Controls.Add(this.tabPageWidget);
			this.tabMains.Controls.Add(this.tabPageXml);
			this.tabMains.Controls.Add(this.tabPageLog);
			this.tabMains.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMains.Location = new System.Drawing.Point(0, 58);
			this.tabMains.Name = "tabMains";
			this.tabMains.SelectedIndex = 0;
			this.tabMains.Size = new System.Drawing.Size(807, 438);
			this.tabMains.TabIndex = 3;
			// 
			// tabPageWidget
			// 
			this.tabPageWidget.Controls.Add(this.webBrowserWidget);
			this.tabPageWidget.Location = new System.Drawing.Point(4, 22);
			this.tabPageWidget.Name = "tabPageWidget";
			this.tabPageWidget.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageWidget.Size = new System.Drawing.Size(799, 412);
			this.tabPageWidget.TabIndex = 0;
			this.tabPageWidget.Text = "Widget";
			this.tabPageWidget.UseVisualStyleBackColor = true;
			// 
			// webBrowserWidget
			// 
			this.webBrowserWidget.AllowWebBrowserDrop = false;
			this.webBrowserWidget.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowserWidget.Location = new System.Drawing.Point(3, 3);
			this.webBrowserWidget.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowserWidget.Name = "webBrowserWidget";
			this.webBrowserWidget.Size = new System.Drawing.Size(793, 406);
			this.webBrowserWidget.TabIndex = 0;
			// 
			// tabPageXml
			// 
			this.tabPageXml.Controls.Add(this.textBoxXml);
			this.tabPageXml.Location = new System.Drawing.Point(4, 22);
			this.tabPageXml.Name = "tabPageXml";
			this.tabPageXml.Size = new System.Drawing.Size(799, 412);
			this.tabPageXml.TabIndex = 2;
			this.tabPageXml.Text = "XML";
			this.tabPageXml.UseVisualStyleBackColor = true;
			// 
			// textBoxXml
			// 
			this.textBoxXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxXml.Location = new System.Drawing.Point(0, 0);
			this.textBoxXml.Multiline = true;
			this.textBoxXml.Name = "textBoxXml";
			this.textBoxXml.ReadOnly = true;
			this.textBoxXml.Size = new System.Drawing.Size(799, 412);
			this.textBoxXml.TabIndex = 0;
			// 
			// tabPageLog
			// 
			this.tabPageLog.Controls.Add(this.textBoxLog);
			this.tabPageLog.Location = new System.Drawing.Point(4, 22);
			this.tabPageLog.Name = "tabPageLog";
			this.tabPageLog.Size = new System.Drawing.Size(799, 412);
			this.tabPageLog.TabIndex = 3;
			this.tabPageLog.Text = "Log";
			this.tabPageLog.UseVisualStyleBackColor = true;
			// 
			// textBoxLog
			// 
			this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxLog.Location = new System.Drawing.Point(0, 0);
			this.textBoxLog.Multiline = true;
			this.textBoxLog.Name = "textBoxLog";
			this.textBoxLog.ReadOnly = true;
			this.textBoxLog.Size = new System.Drawing.Size(799, 412);
			this.textBoxLog.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.widgetPath);
			this.panel1.Controls.Add(this.buttonBrowse);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(807, 33);
			this.panel1.TabIndex = 5;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadWidget,
            this.toolStripButtonUpdate,
            this.toolStripButtonClearLog});
			this.toolStrip1.Location = new System.Drawing.Point(0, 33);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(807, 25);
			this.toolStrip1.TabIndex = 6;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButtonLoadWidget
			// 
			this.toolStripButtonLoadWidget.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonLoadWidget.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadWidget.Image")));
			this.toolStripButtonLoadWidget.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonLoadWidget.Name = "toolStripButtonLoadWidget";
			this.toolStripButtonLoadWidget.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonLoadWidget.Text = "Load widget";
			this.toolStripButtonLoadWidget.Click += new System.EventHandler(this.toolStripButtonLoadWidget_Click);
			// 
			// toolStripButtonUpdate
			// 
			this.toolStripButtonUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonUpdate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpdate.Image")));
			this.toolStripButtonUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonUpdate.Name = "toolStripButtonUpdate";
			this.toolStripButtonUpdate.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonUpdate.Text = "Peform update";
			this.toolStripButtonUpdate.Click += new System.EventHandler(this.toolStripButtonUpdate_Click);
			// 
			// toolStripButtonClearLog
			// 
			this.toolStripButtonClearLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonClearLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClearLog.Image")));
			this.toolStripButtonClearLog.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonClearLog.Name = "toolStripButtonClearLog";
			this.toolStripButtonClearLog.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonClearLog.Text = "Clear log";
			this.toolStripButtonClearLog.Click += new System.EventHandler(this.toolStripButtonClearLog_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(807, 496);
			this.Controls.Add(this.tabMains);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Widget Test";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.tabMains.ResumeLayout(false);
			this.tabPageWidget.ResumeLayout(false);
			this.tabPageXml.ResumeLayout(false);
			this.tabPageXml.PerformLayout();
			this.tabPageLog.ResumeLayout(false);
			this.tabPageLog.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox widgetPath;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.TabControl tabMains;
		private System.Windows.Forms.TabPage tabPageWidget;
		private System.Windows.Forms.TabPage tabPageXml;
		private System.Windows.Forms.TabPage tabPageLog;
		private System.Windows.Forms.TextBox textBoxLog;
		private System.Windows.Forms.WebBrowser webBrowserWidget;
		private System.Windows.Forms.TextBox textBoxXml;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButtonClearLog;
		private System.Windows.Forms.ToolStripButton toolStripButtonLoadWidget;
		private System.Windows.Forms.ToolStripButton toolStripButtonUpdate;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
	}
}