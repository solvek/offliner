using System;
using System.IO;
using System.Xml.Serialization;

using Solvek.Gears.Engine.Processes;

namespace Solvek.Gears.Engine.WidgetDescription
{
	[XmlRoot("widget", Namespace = "http://www.solvek.com/gears/widget")]
	public class Widget
	{
		public Widget()
		{
		}
		
		public static Widget LoadWidget(string path)
		{
			StreamReader reader = new StreamReader(path);
			XmlSerializer dsr = new XmlSerializer(typeof(Widget));
			Widget widget = (Widget)dsr.Deserialize(reader);
			reader.Close();
			return widget;
		}

		[XmlElement("id")]
		public string Id;

		[XmlElement("name")]
		public string Name;

		[XmlElement("widgetUrl")]
		public string WidgetUrl;

		[XmlElement("author")]
		public string Author;

		[XmlElement("authorUrl")]
		public string AuthorUrl;

		[XmlElement("updateProcess")]
		public string UpdateProcess;

		[XmlArray("processes"),
		XmlArrayItem("webRequest", typeof(WebRequest)),
	   XmlArrayItem("loadXml", typeof(LoadXml)),
		XmlArrayItem("xmlize", typeof(Xmlize)),
	   XmlArrayItem("xslTransformation", typeof(XslTransformation))]
		public BaseProcess[] processesDefinitions;

		[XmlIgnore]
		public ProcessCollection Processes
		{
			get
			{
				if (_processes == null)
				{
					_processes = new ProcessCollection(processesDefinitions);
				}
				return _processes;
			}
		}

		private ProcessCollection _processes;
	}
}