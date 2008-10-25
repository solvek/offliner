using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	public class LoadXml : BaseProcess
	{
		public LoadXml()
		{}

		[XmlAttribute("path")]
		public string XmlPath;

		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load(Context.WidgetFilePath(XmlPath));
			return doc;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateNoInputs(inputs);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputString((string)obj, stream);
		}
	}
}
