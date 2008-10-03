using System;
using System.IO;
using System.Xml;

namespace Solvek.Offliner.Lib.Filters
{
	class XmlFilter : IFilter
	{
		public XmlReader Apply(TextReader data)
		{
			return new XmlTextReader(data);
		}
	}
}
