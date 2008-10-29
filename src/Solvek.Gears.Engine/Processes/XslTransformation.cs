using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("xslTransformation")]
	public class XslTransformation : BaseProcess
	{
		public XslTransformation()
		{}
		
		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument xml = (XmlDocument) inputs[0],
			            transformer = (XmlDocument) inputs[1];
			string res;
			XslCompiledTransform xslt = new XslCompiledTransform();
			
			using (XmlNodeReader readTransform = new XmlNodeReader(transformer))
			using (XmlNodeReader nReader = new XmlNodeReader(xml))
			{
				readTransform.MoveToContent();
				nReader.MoveToContent();
				xslt.Load(readTransform);
				res = xslt.Transform(nReader);
				nReader.Close();
				readTransform.Close();
			}

			return res;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateInputAmount(inputs, 2);
			ValidateTypes(inputs, new DataType[] { DataType.XmlDocument, DataType.XmlDocument });
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputString((string)obj, stream);
		}
	}
}
