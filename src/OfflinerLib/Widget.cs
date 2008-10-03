using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Offliner.Lib
{
	[XmlRoot("widget", Namespace = "http://www.solvek.com/gears/widget")]
	public class Widget
	{
		public Widget()
		{
		}
		
		public static Widget LoadWidget(string path)
		{
			StringReader reader = new StringReader(path);
			XmlSerializer dsr = new XmlSerializer(typeof(Widget));
			return (Widget)dsr.Deserialize(reader);
		}

		[XmlAttribute("name")]
		public string Name;


		[XmlArray("sources")]
		public Source[] Sources;
	}
}