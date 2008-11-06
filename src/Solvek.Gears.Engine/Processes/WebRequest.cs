using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;

using log4net;

using Solvek.Gears.Engine.Host;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("webRequest")]
	public class WebRequest : BaseProcess
	{
		public WebRequest()
		{}

		[XmlAttribute("url")]
		public string Url;
		
		protected override object ExecuteInternal(object[] inputs)
		{
			Uri uri = new Uri(Url);
			System.Net.WebRequest request = HostInfo.Instance.CreateRequest(uri);

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

			return ReadAllFromStream(resp.GetResponseStream());
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateNoInputs(inputs);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputBinary((byte[])obj, stream);
		}

		private static byte[] ReadAllFromStream(Stream s)
		{
			try
			{
				const int bufSize = 9192;
				byte[] res;
				using (MemoryStream mem = new MemoryStream())
				{
					byte[] buf = new byte[bufSize];

					int curSize;
					while ((curSize = s.Read(buf, 0, bufSize)) > 0)
					{
						mem.Write(buf, 0, curSize);
					}
					res = mem.GetBuffer();
					mem.Close();
				}

				return res;				
			}
			finally
			{
				s.Close();
			}
		}

		static private readonly ILog _log = LogManager.GetLogger(typeof(WebRequest));
	}
}