using System;
using System.Net;

using Solvek.Gears.Engine.Host;

namespace Solvek.Gears.App
{
	class WMHost : HostInfo
	{
		public override WebRequest CreateRequest(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

			if (_proxy != null)
			{
				request.Proxy = _proxy;
			}

			return request;
		}

		public void PopulateConfig(Config config)
		{
			_config = config;

			if (_config.UseProxy)
			{
				_proxy = new WebProxy(_config.ProxyAddress);
				if (_config.RequireAuthentication)
				{
					_proxy.Credentials = new NetworkCredential(_config.UserName, _config.Password);
				}
			}
			else
			{
				_proxy = null;
			}
		}

		private Config _config;
		private IWebProxy _proxy;
	}
}
