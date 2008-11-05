using System;
using System.Diagnostics;
using System.Drawing;
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
				AppendProcess(proc);
			}
			if (CurrentAutoScaleDimensions.Width < 192)
			{
				imageListIcons.ImageSize = new Size(16, 16);
			}
		}

		private void menuItemRefresh_Click(object sender, EventArgs e)
		{
			menuItemRefresh.Enabled = false;
			listViewWidgets.BeginUpdate();
			foreach (WidgetListItem wli in listViewWidgets.Items)
			{
				wli.Processor.State.Status = Status.Updating;
				wli.RedrawStatus();
			}
			listViewWidgets.EndUpdate();
			listViewWidgets.Refresh();

			foreach (WidgetListItem wli in listViewWidgets.Items)
			{
				WidgetProcessor processor = wli.Processor;
				try
				{
					processor.Update();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(String.Format("Failed to update data for widget {0}. Error: {1}", processor, ex.Message));
				}
				wli.RedrawStatus();
				listViewWidgets.Refresh();
			}

			menuItemRefresh.Enabled = true;

		}

		private void listViewWidgets_ItemActivate(object sender, EventArgs e)
		{
			foreach(int idx in listViewWidgets.SelectedIndices)
			{
				WidgetListItem item = (WidgetListItem)listViewWidgets.Items[idx];
				if (!File.Exists(item.Processor.ResultHtmlPath))
				{
					continue;
				}
				Process.Start(item.Processor.ResultHtmlPath, String.Empty);
				break;
			}
		}

		private void menuItemSettings_Click(object sender, EventArgs e)
		{
			Settings dlg = new Settings();
			dlg.SetConfig(_config);
			if (dlg.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			this._config = dlg.GetConfig();
			this.SaveConfig();
			_manager.Host.PopulateConfig(_config);
		}

		private void AppendProcess(WidgetProcessor proc)
		{
			int index = this.listViewWidgets.Items.Count;
			using(FileStream stream = new FileStream(proc.WidgetFilePath(proc.Widget.Icon), FileMode.Open))
			{
				Image image = new Bitmap(stream);
				imageListIcons.Images.Add(image);
				stream.Close();
			}
			
			WidgetListItem wli = new WidgetListItem(proc);
			wli.ImageIndex = index;
			this.listViewWidgets.Items.Add(wli);
		}

		private void LoadConfig()
		{
			try
			{
				StreamReader reader = new StreamReader(ConfigPath());

				XmlSerializer dsr = new XmlSerializer(typeof(Config));
				_config = (Config)dsr.Deserialize(reader);

				reader.Close();

				_manager.Host.PopulateConfig(_config);
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
				_subItemStatus = SubItems.Add(proc.State.GetStatusText());
			}

			public WidgetProcessor Processor
			{
				get { return _proc; }
			}

			public void RedrawStatus()
			{
				_subItemStatus.Text = _proc.State.GetStatusText();
			}

			private readonly WidgetProcessor _proc;
			private readonly ListViewSubItem _subItemStatus;
		}
	}
}