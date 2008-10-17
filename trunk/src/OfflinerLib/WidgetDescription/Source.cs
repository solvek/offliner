using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Solvek.Offliner.Lib.WidgetDescription
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

		[XmlAttribute("user-agent")]
		public string UserAgent;

		[XmlAttribute("accept")]
		public string Accept;

		[XmlIgnore]
		public IFilter Filter
		{
			get
			{
				if (this._filter == null)
				{
					_filter = (IFilter)Activator.CreateInstance(Type.GetType(FilterType));
				}
				return this._filter;
			}
		}

		private IFilter _filter;
	}
}