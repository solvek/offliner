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
			writer.WriteString(toTransform.transformNode(myXsl));
        }

		readonly DOMDocument myXsl = new DOMDocumentClass();
    }
}


