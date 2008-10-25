using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Serialization;

using log4net;

using Solvek.Gears.Engine.Runtime;

namespace Solvek.Gears.App
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadConfig();
			
			string widgetsPath = GetAppFolderItem("Widgets");
			WidgetProcessor[] procs = this._manager.LoadProcessors(widgetsPath);
			foreach (WidgetProcessor proc in procs)
			{
				listViewWidgets.Items.Add(new WidgetListItem(proc));
			}
		}

		private void menuItemRefresh_Click(object sender, EventArgs e)
		{
			_manager.UpdateAll();
		}

		private void listViewWidgets_ItemActivate(object sender, EventArgs e)
		{
			foreach(int idx in listViewWidgets.SelectedIndices)
			{
				WidgetListItem item = (WidgetListItem)listViewWidgets.Items[idx];
				Process.Start(item.Processor.ResultHtmlPath, String.Empty);
			}
		}

		private void menuItemSettings_Click(object sender, EventArgs e)
		{
			Settings dlg = new Settings();
			dlg.SetConfig(_config);
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				_config = dlg.GetConfig();
				SaveConfig();
			}
		}

		private void LoadConfig()
		{
			try
			{
				StreamReader reader = new StreamReader(ConfigPath());

				XmlSerializer dsr = new XmlSerializer(typeof(Config));
				_config = (Config)dsr.Deserialize(reader);

				reader.Close();
			}
			catch (Exception ex)
			{
				_config = new Config();
				_log.Warn("Failed to load configuration", ex);
			}
		}

		private void SaveConfig()
		{
			XmlSerializer sr = new XmlSerializer(typeof(Config));
			FileStream fs = new FileStream(ConfigPath(), FileMode.Create);
			sr.Serialize(fs, _config);
			fs.Close();
		}

		static private string GetAppFolderItem(string item)
		{
			return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), item);
		}

		static private string ConfigPath()
		{
			return GetAppFolderItem("sgears.config");
		}

		private Config _config;
		private readonly WidgetManager _manager = new WidgetManager();
		static private readonly ILog _log = LogManager.GetLogger(typeof(MainForm));

		private class WidgetListItem : ListViewItem
		{
			public WidgetListItem(WidgetProcessor proc)
				: base(proc.ToString())
			{
				this._proc = proc;
			}

			public WidgetProcessor Processor
			{
				get { return _proc; }
			}

			private readonly WidgetProcessor _proc;
		}
	}
}