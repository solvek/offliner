using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

using Sgml;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("xmlize")]
	public class Xmlize : BaseProcess
	{
		public Xmlize()
		{}

		[XmlAttribute("processDocumentTag")]
		public bool ProcessDocumentTag = true;

		protected override object ExecuteInternal(object[] inputs)
		{
			return ExecuteInternal((string)inputs[0]);
		}

		protected XmlDocument ExecuteInternal(string htmlText)
		{
			XmlDocument doc = new XmlDocument();
			using (StringReader txt = new StringReader(htmlText))
			using(SgmlReader reader = new SgmlReader())
			{
				reader.DocType = "HTML";
				reader.WhitespaceHandling = WhitespaceHandling.All;
				reader.CaseFolding = CaseFolding.ToLower;
				reader.ProcessDocumentTag = ProcessDocumentTag;
				reader.InputStream = txt;

				doc.Load(reader);
			}

			return doc;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateInputAmount(inputs, 1);
			ValidateTypes(inputs, new DataType[]{DataType.String});
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputXmlDocument((XmlDocument)obj, stream);
		}
	}
}
