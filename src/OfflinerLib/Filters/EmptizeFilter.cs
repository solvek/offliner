using System;
using System.IO;
using System.Xml;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Filters
{
	class EmptizeFilter : IFilter
	{
		public XmlReader Apply(TextReader data)
		{
			MemoryStream ms = new MemoryStream();
			return new XmlTextReader(ms);
		}
	}
}
