using System;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Text;

namespace Solvek.Gears.Engine.Processes
{
	public class XslTransformation : BaseProcess
	{
		public XslTransformation()
		{}
		
		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument xml = (XmlDocument) inputs[0],
				transformer = (XmlDocument)inputs[1],
				res = new XmlDocument();
			XslCompiledTransform xslt = new XslCompiledTransform();
			
			using (XmlNodeReader readTransform = new XmlNodeReader(transformer))
			using (MemoryStream mem = new MemoryStream())
			using (XmlWriter result = new XmlTextWriter(mem, Encoding.UTF8))
			using (XmlNodeReader nReader = new XmlNodeReader(xml))
			{
				string x = readTransform.ReadOuterXml();
				xslt.Load(readTransform);
				xslt.Transform(nReader, result);
				mem.Seek(0, SeekOrigin.Begin);
				res.Load(mem);
				
				result.Close();
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
			OutputXmlDocument((XmlDocument)obj, stream);
		}
	}
}
