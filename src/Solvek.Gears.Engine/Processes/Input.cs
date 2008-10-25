using System;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	public class Input
	{
		public Input()
		{}

		[XmlAttribute("id")]
		public string Id;
	}
}
