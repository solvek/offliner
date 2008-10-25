using System;
using MSXML2;
using System.IO;

namespace System.Xml.Xsl
{
    public sealed class XslCompiledTransform
    {
    	public XslCompiledTransform()
		{
		}

    	public void Load(XmlReader reader)
        {
			string xslt = reader.ReadOuterXml();
			myXsl.loadXML(xslt);
        }

        public void Transform(XmlReader reader, XmlWriter writer)
        {
            DOMDocument toTransform = new DOMDocumentClass();
        	string xml = reader.ReadOuterXml();
			toTransform.loadXML(xml);
        	string transformed = toTransform.transformNode(myXsl);
			writer.WriteString(transformed);
        }

		readonly DOMDocument myXsl = new DOMDocumentClass();
    }
}


