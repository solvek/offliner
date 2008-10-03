using System;
using System.IO;
using System.Xml;

using Sgml;

namespace Solvek.Offliner.Lib.Filters
{
	public class HtmlToXhtmlFilter : IFilter
	{
		public XmlReader Apply(TextReader data)
		{
			SgmlReader sgmlReader = new SgmlReader();  
			sgmlReader.DocType = "HTML";  
			sgmlReader.WhitespaceHandling = WhitespaceHandling.All;  
			sgmlReader.CaseFolding = CaseFolding.ToLower;  
			sgmlReader.InputStream = data;

			return sgmlReader;
		}
	}
}
