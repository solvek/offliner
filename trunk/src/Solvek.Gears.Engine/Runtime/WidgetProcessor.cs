using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

using log4net;
using Solvek.Offliner.Lib.Fetching;
using Solvek.Offliner.Lib.WidgetDescription;

namespace Solvek.Offliner.Lib.Runtime
{
	public sealed class WidgetProcessor
	{
		public WidgetProcessor(string homePath, bool debugMode)
		{
			_homePath = homePath;			
			_debugMode = debugMode;

			LoadWidget();
		}
		
		public void Update()
		{
			_log.InfoFormat("Started update for widget {0}", _widget.Name);
			XmlDocument xml = new XmlDocument();
			XmlNode rootNode = xml.CreateElement("resultSet");
			xml.AppendChild(rootNode);

			foreach (Source source in _widget.Sources)
			{
				Stream stream = _fetcher.Fetch(source);
				
				if (_debugMode)
				{
					using (BinaryReader r = new BinaryReader(stream))
					{
						
						const int bufSize = 4048;
						byte[] buf = new byte[bufSize];

						MemoryStream mem = new MemoryStream();

						int curSize;
						while ((curSize = r.Read(buf, 0, bufSize)) > 0)
						{
							mem.Write(buf, 0, curSize);
						}

						mem.Seek(0, SeekOrigin.Begin);
						string dataFile = WidgetStateFilePath("RemoteData.bin");
						_log.DebugFormat("Retrieved data is writing to file {0}", dataFile);
						FileStream file = new FileStream(dataFile, FileMode.Create);
						mem.WriteTo(file);
						file.Close();

						mem.Seek(0, SeekOrigin.Begin);
						stream = mem;
					}
				}

				StreamReader reader = new StreamReader(stream);


				XmlReader xmlR = source.Filter.Apply(reader);

				XmlNode resultNode = xml.CreateElement("result");
				resultNode.InnerXml = xmlR.ReadOuterXml();

				rootNode.AppendChild(resultNode);

				reader.Close();
			}

			if (_debugMode)
			{
				xml.Save(WidgetStateFilePath("xmlResult.xml"));
			}

			XslCompiledTransform xslt = new XslCompiledTransform(_debugMode);
			xslt.Load(WidgetSourceFilePath(_widget.Transformation));

			using(XmlWriter result = new XmlTextWriter(ResultHtmlPath, Encoding.UTF8))
			using (XmlNodeReader nReader = new XmlNodeReader(xml))
			{
				xslt.Transform(nReader, result);
				result.Close();
				nReader.Close();
			}


			_lastUpdated = DateTime.UtcNow;
		}

		public DateTime LastUpdated
		{
			get { return this._lastUpdated; }
		}

		public string ResultHtmlPath
		{
			get { return WidgetStateFilePath("index.html"); }
		}

		private void LoadWidget()
		{
			_widget = Widget.LoadWidget(WidgetSourceFilePath("widget.xml"));
			//_widget = new Widget();
			//_widget.Name = "Test";
			//Source src = new Source();
			//src.Url = "My url";
			//src.FilterType = "sdfsdfd";
			//src.Headers = new KeyValuePair<string, string>[]{new KeyValuePair<string, string>("User-Agent", "Alcatel-BH4/1.0 UP.Browser/6.2.ALCATEL MMP/1.0")};
			//_widget.Sources = new Source[] { src };

			//StreamWriter writer = new StreamWriter(Path.Combine(_homePath, "widget2.xml"));
			//System.Xml.Serialization.XmlSerializer sr = new System.Xml.Serialization.XmlSerializer(typeof(Widget));

			//sr.Serialize(writer, _widget);
		}

		private string WidgetStateFilePath(string fileName)
		{
			return Path.Combine(_homePath, "_sg_" + fileName);
		}

		private string WidgetSourceFilePath(string fileName)
		{
			return Path.Combine(_homePath, fileName);
		}

		private DateTime _lastUpdated;
		private Widget _widget;
		private readonly string _homePath;
		private readonly bool _debugMode;

		private readonly IFetcher _fetcher = new WebFetcher();

		static private readonly ILog _log = LogManager.GetLogger(typeof(WidgetProcessor));
	}
}