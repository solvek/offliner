using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("parseXml")]
	public class ParseXml : BaseProcess
	{
		public ParseXml()
		{}

		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(((string)inputs[0]).Trim(' ', (char)0));
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
