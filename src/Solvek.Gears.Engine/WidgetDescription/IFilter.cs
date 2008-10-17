using System;
using System.IO;
using System.Xml;

namespace Solvek.Offliner.Lib.WidgetDescription
{
	public interface IFilter
	{
		XmlReader Apply(TextReader data);
	}
}