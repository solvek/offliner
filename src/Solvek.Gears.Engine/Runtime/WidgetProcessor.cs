using System;
using System.IO;

using log4net;

using Solvek.Gears.Engine.Processes;
using Solvek.Gears.Engine.WidgetDescription;

namespace Solvek.Gears.Engine.Runtime
{
	public sealed class WidgetProcessor
	{
		public WidgetProcessor(string homePath)
		{
			_homePath = homePath;			
			LoadWidget();
		}
		
		public void Update()
		{
			_log.InfoFormat("Started update for widget {0}", _widget.Name);
			try
			{
				_widget.Processes.ResetResults();
				_widget.Processes.ExecuteProcess(_widget.UpdateProcess);
			}
			catch (Exception ex)
			{
				_log.Error("Failed to update widget "+_widget.Name, ex);
				throw;
			}

			_lastUpdated = DateTime.UtcNow;
			_log.InfoFormat("Finished updating of widget {0}", _widget.Name);
		}

		public DateTime LastUpdated
		{
			get { return this._lastUpdated; }
		}

		public string ResultHtmlPath
		{
			get { return WidgetFilePath("index.html"); }
		}

		public override string ToString()
		{
			return _widget.Name;
		}

		internal string WidgetFilePath(string fileName)
		{
			return Path.Combine(this._homePath, fileName);
		}

		internal Widget Widget
		{
			get{return _widget;}
		}

		private void LoadWidget()
		{
			_widget = Widget.LoadWidget(WidgetFilePath("widget.xml"));
			foreach (BaseProcess proc in _widget.Processes)
			{
				proc.Context = this;
			}
			_widget.processesDefinitions = null;
			//_widget = new Widget();
			//_widget.Name = "Test";
			//Source src = new Source();
			//src.Url = "My url";
			//src.FilterType = "sdfsdfd";
			//src.Headers = new KeyValuePair<string, string>[]{new KeyValuePair<string, string>("User-Agent", "Alcatel-BH4/1.0 UP.Browser/6.2.ALCATEL MMP/1.0")};
			//_widget.Sources = new Source[] { src };

			//StreamWriter writer = new StreamWriter(Path.Combine(_homePath, "widget2.xml"));
			//System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(Widget));

			//sr.Serialize(writer, _widget);
		}

		private DateTime _lastUpdated;
		private Widget _widget;
		private readonly string _homePath;

		static private readonly ILog _log = LogManager.GetLogger(typeof(WidgetProcessor));
	}
}