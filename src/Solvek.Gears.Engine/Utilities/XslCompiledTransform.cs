using System;
using MSXML2;

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

        public string Transform(XmlReader reader)
        {
            DOMDocument toTransform = new DOMDocumentClass();
        	string xml = reader.ReadOuterXml();
			toTransform.loadXML(xml);
        	string transformed = toTransform.transformNode(myXsl);
			return transformed;
        }

		readonly DOMDocument myXsl = new DOMDocumentClass();
    }
}


