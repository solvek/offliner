using System;
using System.IO;
using System.Xml.Serialization;
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
			DateTime prevUpdate = _state.LastUpdate;
			_state.LastUpdate = DateTime.UtcNow;
			try
			{
				_widget.Processes.ResetResults();
				_widget.Processes.ExecuteProcess(_widget.UpdateProcess);
			}
			catch (Exception ex)
			{
				_state.Status = Status.Failed;
				_state.LastUpdate = prevUpdate;
				_log.Error("Failed to update widget "+_widget.Name, ex);
				throw;
			}

			_state.Status = Status.Success;			

			using(StreamWriter writer = new StreamWriter(GetStateFilePath()))
			{
				XmlSerializer sr = new XmlSerializer(typeof(WidgetState));
				sr.Serialize(writer, _state);
				writer.Close();
			}
			
			_log.InfoFormat("Finished updating of widget {0}", _widget.Name);
		}

		public string ResultHtmlPath
		{
			get { return WidgetFilePath("index.html"); }
		}

		public override string ToString()
		{
			return _widget.Name;
		}

		public WidgetState State
		{
			get { return this._state; }
		}

		public string WidgetFilePath(string fileName)
		{
			return Path.Combine(this._homePath, fileName);
		}

		public Widget Widget
		{
			get{return _widget;}
		}

		internal string GetStateFilePath()
		{
			return this.WidgetFilePath("_sg_state.xml");
		}

		private void LoadWidget()
		{
			_widget = Widget.LoadWidget(WidgetFilePath("widget.xml"));
			foreach (BaseProcess proc in _widget.Processes)
			{
				proc.Context = this;
			}
			//_widget.processesDefinitions = null;

			try
			{
				using (StreamReader reader = new StreamReader(GetStateFilePath()))
				{
					XmlSerializer dsr = new XmlSerializer(typeof(WidgetState));
					_state = (WidgetState)dsr.Deserialize(reader);
					reader.Close();
				}
			}
			catch (Exception ex)
			{
				_state = new WidgetState();
				_log.Warn("Failed to load widget state", ex);
			}

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

		private Widget _widget;
		private WidgetState _state;
		private readonly string _homePath;

		static private readonly ILog _log = LogManager.GetLogger(typeof(WidgetProcessor));
	}
}