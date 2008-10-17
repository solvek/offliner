using System;
using System.Xml.Serialization;

namespace Solvek.Offliner.Lib.WidgetDescription
{
	public class StringPair
	{
		public StringPair()
		{
		}

		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("value")]
		public string Value;
	}
}
