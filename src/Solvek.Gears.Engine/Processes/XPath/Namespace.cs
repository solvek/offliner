using System;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes.XPath
{
	public class Namespace
	{
		public Namespace()
		{}

		[XmlAttribute("prefix")]
		public string Prefix;

		[XmlText]
		public string NamespaceUri;
	}
}
