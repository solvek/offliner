using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Offliner.Lib.WidgetDescription
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

		[XmlAttribute("name")]
		public string Name;

		[XmlArray("sources"), XmlArrayItem("source")]
		public Source[] Sources;

		[XmlAttribute("transformation")]
		public string Transformation;
	}
}