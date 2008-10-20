using System;
using System.IO;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Fetching
{
	public interface IFetcher
	{
		Stream Fetch(Source source);
	}
}
