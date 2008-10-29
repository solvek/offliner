using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	[XmlRoot("concatXmls")]
	public class ConcatXmls : BaseProcess
	{
		protected override object ExecuteInternal(object[] inputs)
		{
			throw new System.NotImplementedException();
		}

		protected override void ValidateInputs(object[] inputs)
		{
			throw new System.NotImplementedException();
		}

		protected override void Output(object obj, Stream stream)
		{
			throw new System.NotImplementedException();
		}
	}
}
