using System;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes.XPath
{
	public class Select
	{
		public Select()
		{			
		}

		[XmlAttribute("expression")]
		public string XPathExpression;

		[XmlElement("expression")]
		public string[] XPathExpressions;

		[XmlAttribute("namespace")]
		public string Namespace;

		[XmlAttribute("elementName")]
		public string ElementName = "result";

		[XmlAttribute("inputIndex")]
		public int InputIndex;
	}
}
