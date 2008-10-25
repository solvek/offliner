using System;
using System.Globalization;
using System.Net;
using System.Reflection;
using System.Resources;

namespace Solvek.Gears.Engine.Host
{
	public abstract class HostInfo
	{
		public abstract WebRequest CreateRequest(string url); 

        static public HostInfo Instance;

		private static readonly ResourceManager _resourceManager = new ResourceManager("Solvek.Gears.Engine.Properties.Resources", Assembly.GetExecutingAssembly());

		internal static string GetString(string key)
		{
			string val = _resourceManager.GetString(key);
			return val ?? String.Format("Failed to retrieve value '{0}' for locale {1}",
			                            key,
			                            CultureInfo.CurrentCulture.Name);
		}
	}
}
