using System;
using System.IO;
using System.Net;

using log4net;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Fetching
{
	public class WebFetcher : IFetcher
	{
		public WebFetcher()
		{
		}

		public WebFetcher(ICredentials proxyCredentials)
		{
			_proxyCredentials = proxyCredentials;
		}
		
		public Stream Fetch(Source source)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(source.Url);
			request.Method = "GET";

			if (!String.IsNullOrEmpty(source.UserAgent))
			{
				request.UserAgent = source.UserAgent;
			}

			if (!String.IsNullOrEmpty(request.Accept))
			{
				request.Accept = source.Accept;
			}

			if (_proxyCredentials != null)
			{
				request.Proxy.Credentials = _proxyCredentials;
			}

			HttpWebResponse resp;
			try
			{
				resp = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				_log.Error("Web requesting error: ", ex);
				_log.DebugFormat("WebException datails. Status: {0}, response lenght: {1}", ex.Status, ex.Response.ContentLength);
				throw new ApplicationException(String.Format("Failed to retrieve data from {0}", source.Url), ex);
			}
			return resp.GetResponseStream();
		}

		private readonly ICredentials _proxyCredentials;
		static private readonly ILog _log = LogManager.GetLogger(typeof(WebFetcher));
	}
}
