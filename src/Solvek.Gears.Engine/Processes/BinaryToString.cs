using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("binaryToString")]
	public class BinaryToString : BaseProcess
	{
		public BinaryToString()
		{}

		[XmlAttribute("encoding")]
		public string Encoding = "utf-8";

		protected override object ExecuteInternal(object[] inputs)
		{
			byte[] buf = (byte[]) inputs[0];
			return System.Text.Encoding.GetEncoding(Encoding).GetString(buf, 0, buf.Length);
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateInputAmount(inputs, 1);
			ValidateTypes(inputs, new DataType[]{DataType.RowData});
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputString((string)obj, stream);
		}
	}
}
