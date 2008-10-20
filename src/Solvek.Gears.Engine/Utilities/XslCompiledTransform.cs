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

    	public void Load(string filePath)
        {
			using (StreamReader file = new StreamReader(filePath))
			{
				myXsl.loadXML(file.ReadToEnd());
				file.Close();
			}
        }

        public void Transform(XmlReader reader, StreamWriter writer)
        {
            DOMDocument toTransform = new DOMDocumentClass();
            toTransform.loadXML(reader.ReadOuterXml());
			writer.Write(toTransform.transformNode(myXsl));
        }

		readonly DOMDocument myXsl = new DOMDocumentClass();
    }
}


