using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

using log4net;

using Solvek.Gears.Engine.Host;

namespace Solvek.Gears.Engine.Processes
{
	public class WebRequest : BaseProcess
	{
		public WebRequest()
		{}

		[XmlAttribute("url")]
		public string Url;
		
		protected override object ExecuteInternal(object[] inputs)
		{
			System.Net.WebRequest request = HostInfo.Instance.CreateRequest(Url);

			request.Method = "GET";

			HttpWebResponse resp;
			try
			{
				resp = (HttpWebResponse)request.GetResponse();
			}
			catch (WebException ex)
			{
				_log.Error("Web requesting error: ", ex);
				_log.DebugFormat("WebException datails. Status: {0}", ex.Status);
				throw new ApplicationException(String.Format("Failed to retrieve data from {0}", Url), ex);
			}

			StreamReader reader = new StreamReader(resp.GetResponseStream());
			string res = reader.ReadToEnd();
			reader.Close();
			return res;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateNoInputs(inputs);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputString((string)obj, stream);
		}

		static private readonly ILog _log = LogManager.GetLogger(typeof(WebRequest));
	}
}