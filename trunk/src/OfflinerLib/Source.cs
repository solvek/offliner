using System;
using System.Xml.Serialization;

namespace Solvek.Offliner.Lib
{
	[XmlRoot("source")]
	public class Source
	{
		public Source()
		{}

		[XmlAttribute("url")]
		public string Url;

		[XmlAttribute("filter")]
		public string FilterType;

		[XmlIgnore]
		public IFilter Filter
		{
			get
			{
				if (_filter == null)
				{
					
				}
				return _filter;
			}
		}

		private IFilter _filter;
	}
}
