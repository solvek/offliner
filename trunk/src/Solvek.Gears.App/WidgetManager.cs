using System;
using System.IO;
using System.Windows.Forms;

using Solvek.Gears.Engine.Host;
using Solvek.Gears.Engine.Runtime;

namespace Solvek.Gears.App
{
	class WidgetManager
	{
		public WidgetManager()
		{
			HostInfo.Instance = new WMHost();
		}
		
		public WidgetProcessor[] LoadProcessors(string path)
		{
			string[] direcotories = Directory.GetDirectories(path);
			_processors = new WidgetProcessor[direcotories.Length];
			for (int i = 0; i < direcotories.Length; i++)
			{
				WidgetProcessor proc = new WidgetProcessor(direcotories[i]);
				_processors[i] = proc;
			}
			return _processors;
		}

		public void UpdateAll()
		{
			foreach (WidgetProcessor processor in _processors)
			{
				try
				{
					processor.Update();
				}
				catch (ApplicationException ex)
				{
					MessageBox.Show(String.Format("Failed to update data for widget {0}. Error: {1}", processor, ex.Message));
				}				
			}
		}

		public WMHost Host
		{
			get { return (WMHost) HostInfo.Instance; }
		}

		private WidgetProcessor[] _processors;
	}
}
