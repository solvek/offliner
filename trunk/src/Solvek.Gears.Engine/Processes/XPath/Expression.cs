using System;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes.XPath
{
	public class Expression
	{
		public Expression()
		{}

		[XmlText]
		public string Value;

		[XmlAttribute("selectAll")]
		public bool SelectAll;
	}
}
