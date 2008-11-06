using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Solvek.Gears.Engine.Runtime;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("getWidgetState")]
	public class GetWidgetState : BaseProcess
	{
		public GetWidgetState()
		{}
		
		protected override object ExecuteInternal(object[] inputs)
		{
			XmlDocument doc = new XmlDocument();
			using(MemoryStream ms = new MemoryStream())
			using (StreamWriter writer = new StreamWriter(ms))
			{
				WidgetState state = Context.State.Clone();
				state.LastUpdate = DateTime.Now;
				XmlSerializer sr = new XmlSerializer(typeof(WidgetState));
				sr.Serialize(writer, state);
				ms.Seek(0, SeekOrigin.Begin);
				doc.Load(ms);
				writer.Close();
				ms.Close();
			}

			return doc;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateNoInputs(inputs);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputXmlDocument((XmlDocument)obj, stream);
		}
	}
}
