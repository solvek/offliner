using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

using log4net;

namespace Solvek.Offliner.Lib
{
	public class RunningWidget
	{
		public RunningWidget(string homePath, string statePath)
		{
			_homePath = homePath;
			_statePath = statePath;

			LoadWidget();
		}
		
		public void Update()
		{
			//_log.InfoFormat("Started update for widget {0}", _widget.Name);
			//_xml = new XmlDocument();
			//XmlNode rootNode = _xml.CreateElement("resultSet");
			//_xml.AppendChild(rootNode);

			//foreach (Source source in _widget.Sources)
			//{
			//    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(source.Url);
			//    request.Method = "GET";

			//    HttpWebResponse resp = (HttpWebResponse)request.GetResponse();

			//    StreamReader reader = new StreamReader(resp.GetResponseStream());

			//    XmlReader xmlR = source.Filter.Apply(reader);

			//    XmlNode resultNode = _xml.CreateElement("result");
			//    resultNode.InnerXml = xmlR.ReadElementString();

			//    rootNode.AppendChild(resultNode);

			//    resp.Close();
			//    reader.Close();
			//}

			//_lastUpdated = DateTime.UtcNow;
		}

		public DateTime LastUpdated
		{
			get { return this._lastUpdated; }
		}

		public HtmlDocument Document
		{
			get { return this._document; }
			set { this._document = value; }
		}

		private void LoadWidget()
		{
			_widget = Widget.LoadWidget(Path.Combine(_homePath, "widget.xml"));
		}

		private DateTime _lastUpdated;
		private HtmlDocument _document;
		private XmlDocument _xml;
		private Widget _widget;
		private readonly string _homePath;
		private readonly string _statePath;

		static private readonly ILog _log = LogManager.GetLogger(typeof(RunningWidget));
	}
}