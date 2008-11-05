using System;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes.XPath
{
	public class Select
	{
		public Select()
		{			
		}

		[XmlElement("expression")]
		public string[] XPathExpressions;

		[XmlAttribute("elementName")]
		public string ElementName = "result";

		[XmlAttribute("inputIndex")]
		public int InputIndex;
	}
}
