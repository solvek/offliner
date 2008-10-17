using System;
using System.IO;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Fetching
{
	interface IFetcher
	{
		Stream Fetch(Source source);
	}
}
