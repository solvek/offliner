using System;
using System.IO;
using System.Xml;

namespace Solvek.Offliner.Lib
{
	public interface IFilter
	{
		XmlReader Apply(TextReader data);
	}
}
