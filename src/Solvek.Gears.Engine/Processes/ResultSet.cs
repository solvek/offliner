using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("resultSet")]
	public class ResultSet : BaseProcess
	{
		public ResultSet()
		{
		}

		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument res = new XmlDocument();
			XmlNode root = res.CreateElement("resultSet");
			res.AppendChild(root);

			int i = 0;
			foreach (XmlDocument input in inputs)
			{
				XmlNode result = res.CreateElement("result");
				XmlAttribute attr = res.CreateAttribute("id");
				attr.Value = i.ToString();
				result.Attributes.Append(attr);
				root.AppendChild(result);
				result.InnerXml = input.DocumentElement.OuterXml;
				i++;
			}

			return res;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			DataType[] types = new DataType[inputs.Length];
			for (int i = 0; i < inputs.Length; i++)
			{
				types[i] = DataType.XmlDocument;
			}
			ValidateTypes(inputs, types);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputXmlDocument((XmlDocument)obj, stream);
		}
	}
}
