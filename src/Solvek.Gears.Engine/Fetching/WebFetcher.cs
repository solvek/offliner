using System;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows.Forms;

using Kerr;

using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Fetching
{
	public class WebFetcher : IFetcher
	{
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

			request.Proxy.Credentials = GetProxyCredentials();

			HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

			return resp.GetResponseStream();
		}

		private ICredentials GetProxyCredentials()
		{
			if (_proxyCredentials == null)
			{
				using (PromptForCredential dialog = new PromptForCredential())
				{
					dialog.TargetName = "Proxy";
					dialog.Title = "Proxy Authentication";
					dialog.Message = "Please enter UserName and Password for proxy";
					//dialog.UserName = "initial user name";

					dialog.DoNotPersist = false;
					dialog.ShowSaveCheckBox = true;

					if (dialog.ShowDialog() == DialogResult.OK)
					{
						string p = SecureStringToString(dialog.Password);
						_proxyCredentials = new NetworkCredential(dialog.UserName.Substring(dialog.UserName.IndexOf('\\')+1), p);
					}
				}

			}

			return _proxyCredentials;
		}

		static String SecureStringToString(SecureString value)
		{
			IntPtr bstr = Marshal.SecureStringToBSTR(value);

			try
			{
				return Marshal.PtrToStringBSTR(bstr);
			}
			finally
			{
				Marshal.FreeBSTR(bstr);
			}
		}

		private ICredentials _proxyCredentials;
	}
}
