using System;
using System.IO;
using System.Windows.Forms;

using log4net;
using log4net.Appender;
using log4net.Repository;

using NuSoft.Log4Net;

using Solvek.Offliner.Lib;
using Solvek.Offliner.Lib.Helpers;

namespace Solvek.Offliner.WidgetTest
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.InitLogging();
			this.LoadSettings();
		}

		private void LoadSettings()
		{
			try
			{
				this._settings = Settings.LoadSettings(SettingsFilePath);
			}
			catch (Exception ex)
			{
				_log.Warn("Failed to load settings", ex);
				this._settings = new Settings();
			}

			this.widgetPath.Text = this._settings.LastWidget;
		}

		private void InitLogging()
		{
			ILoggerRepository r = LogManager.GetRepository();
			foreach (IAppender appender in r.GetAppenders())
			{
				if (appender.Name == "TextBoxAppender")
				{
					((TextBoxAppender)appender).TextBox = this.textBoxLog;
				}
			}
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			_settings.LastWidget = widgetPath.Text;
			_applicationFolder.EnsureExisting();
			_settings.SaveSettings(SettingsFilePath);
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
				widgetPath.Text = folderBrowserDialog1 .SelectedPath;
			}
		}

		private void toolStripButtonClearLog_Click(object sender, EventArgs e)
		{
			textBoxLog.Clear();
		}

		private string SettingsFilePath
		{
			get { return Path.Combine(_applicationFolder.ApplicationPath, "Settings.xml"); }
		}

		private void toolStripButtonLoadWidget_Click(object sender, EventArgs e)
		{
			this._widget = new RunningWidget(this.widgetPath.Text, "");
		}

		private Settings _settings;
		private readonly ApplicationFolder _applicationFolder = new ApplicationFolder("Solvek", "GearsWT");
		private RunningWidget _widget;

		static private readonly ILog _log = LogManager.GetLogger(typeof(MainForm));
	}
}