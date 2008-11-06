using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes.XPath
{
	[XmlRoot("xpath")]
	public class XPathSelector : BaseProcess
	{
		public XPathSelector()
		{
		}

		[XmlElement("select")]
		public Select[] Selects;

		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument res = new XmlDocument();
			XmlNode root = res.CreateElement("resultSet");
			res.AppendChild(root);

			foreach (Select s in Selects)
			{
				XmlNode result = res.CreateElement(s.ElementName);
				if (inputs.Length <= s.InputIndex || s.InputIndex<0)
				{
					throw new ApplicationException(string.Format("Не знайдено вхідного параметру з індексом {0}.", s.InputIndex));
				}

				XmlDocument d = (XmlDocument) inputs[s.InputIndex];
				XmlNamespaceManager nm = new XmlNamespaceManager(d.NameTable);
				if (s.Namespaces != null)
				{
					foreach (Namespace ns in s.Namespaces)
					{
						nm.AddNamespace(ns.Prefix, ns.NamespaceUri);
					}
				}

				if (s.XPathExpressions != null)
				{
					foreach (Expression x in s.XPathExpressions)
					{
						if (x.SelectAll)
						{
							SelectAllAndAppend(x.Value, d, result, nm);
						}
						else
						{
							SelectAndAppend(x.Value, d, result, nm);	
						}
					}
				}
				root.AppendChild(result);
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

		static private void SelectAndAppend(string expression, XmlNode source, XmlNode currentNode, XmlNamespaceManager nm)
		{
			XmlNode node = source.SelectSingleNode(expression, nm);

			if (node == null)
			{
				throw new ApplicationException(string.Format("Вираз {0} не знайдено.", expression));
			}

			currentNode.InnerXml += node.OuterXml;
		}

		static private void SelectAllAndAppend(string expression, XmlNode source, XmlNode currentNode, XmlNamespaceManager nm)
		{
			XmlNodeList nodes = source.SelectNodes(expression, nm);

			if (nodes == null)
			{
				throw new ApplicationException(string.Format("Вираз {0} не знайдено.", expression));
			}

			foreach (XmlNode node in nodes)
			{
				currentNode.InnerXml += node.OuterXml;	
			}			
		}
	}
}