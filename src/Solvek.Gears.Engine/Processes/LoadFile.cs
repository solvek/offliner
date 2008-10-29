using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("loadFile")]
	public class LoadFile : BaseProcess
	{
		public LoadFile()
		{}

		[XmlAttribute("path")]
		public string FilePath;

		protected override object ExecuteInternal(object[] inputs)
		{
			byte[] buf;
			using(FileStream s = new FileStream(Context.WidgetFilePath(FilePath), FileMode.Open))
			{
				buf = new byte[s.Length];
				s.Read(buf, 0, Convert.ToInt32(s.Length));
				s.Close();
			}

			return buf;
		}

		protected override void ValidateInputs(object[] inputs)
		{
			ValidateNoInputs(inputs);
		}

		protected override void Output(object obj, Stream stream)
		{
			OutputBinary((byte[])obj, stream);
		}
	}
}
