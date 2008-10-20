using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Solvek.Offliner.Lib.Runtime;

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
			string widgetsPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "Widgets");
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
				//Process process = new Process();
				//process.StartInfo.FileName = item.Processor.ResultHtmlPath;
				//process.StartInfo.UseShellExecute = true;
				//process.Start();
			}
		}

		private readonly WidgetManager _manager = new WidgetManager();

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