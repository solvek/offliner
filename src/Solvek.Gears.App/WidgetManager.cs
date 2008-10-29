using System;
using System.Collections.Generic;
using System.IO;

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
			List<WidgetProcessor> t = new List<WidgetProcessor>();
			foreach (string dir in Directory.GetDirectories(path))
			{
				if (Path.GetFileName(dir) != "Common")
				{
					t.Add(new WidgetProcessor(dir));
				}
			}
			_processors = t.ToArray();
			return _processors;
		}

		public WMHost Host
		{
			get { return (WMHost) HostInfo.Instance; }
		}

		private WidgetProcessor[] _processors;
	}
}
