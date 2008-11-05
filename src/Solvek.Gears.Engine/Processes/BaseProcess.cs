using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using log4net;
using Solvek.Gears.Engine.Runtime;

namespace Solvek.Gears.Engine.Processes
{
	public abstract class BaseProcess
	{
		protected BaseProcess()
		{}
		
		[XmlAttribute("output")]
		public string OutputFile;

		[XmlAttribute("id")]
		public string Id;

		[XmlElement("input")]
		public string[] Inputs;

        public object Execute()
        {
			if (!_hasResult)
			{
				object[] inputs = this.GetArguments();

				ValidateInputs(inputs);
				_log.DebugFormat("Started process execution ({0})", ProcessMessage("Execution"));
				_output = ExecuteInternal(inputs);

				this.SaveOutputToFile();
				_hasResult = true;
			}
			return _output;
        }

		public void Output(Stream stream)
		{
			Output(_output, stream);
		}

		public void ResetResult()
		{
			_hasResult = false;
		}

		#region Input validators
		protected static void ValidateInputAmount(object[] inputs, int expected)
		{
			if (inputs.Length != expected)
			{
				throw new ApplicationException(String.Format(Properties.Resources.Errors_Process_InputsAmount, 
					expected,
					(inputs.Length == 1) ? "" : "s",
					inputs.Length));
			}
		}

		protected static void ValidateTypes(object[] inputs, DataType[] types)
		{
			for (int i = 0; i < inputs.Length; i++)
			{
				if (i >= types.Length)
				{
					return;
				}

				DataType t = types[i];
				Type type = inputs[i].GetType();

				bool valid = false;

				if (((t & DataType.String) != 0) && (inputs[i] is String))
				{
					valid = true;
				}

				if (((t & DataType.XmlDocument) != 0) && (inputs[i] is XmlDocument))
				{
					valid = true;
				}

				if (((t & DataType.RowData) != 0) && type.IsArray)
				{
					valid = true;
				}

				if (valid)
				{
					continue;
				}
				if (i == 0 && inputs.Length == 1)
				{
					throw new ApplicationException(String.Format(Properties.Resources.Errors_Process_WrongType, t));
				}
				throw new ApplicationException(String.Format(Properties.Resources.Errors_Process_WrongTypeN, i + 1, t));
			}
		}

		protected static void ValidateNoInputs(object[] inputs)
		{
			if (inputs.Length > 0)
			{
				throw new ApplicationException(String.Format(Properties.Resources.Errors_Process_NoInputAllowed, inputs.Length));
			}
		}
		#endregion

		#region Outputters
		protected static void OutputBinary(byte[] buf, Stream stream)
		{
			stream.Write(buf, 0, buf.Length);
		}

		protected static void OutputString(string s, Stream stream)
		{
			using (StreamWriter writer = new StreamWriter(stream))
			{
				writer.Write(s);
				writer.Close();
			}
		}

		protected static void OutputXmlDocument(XmlDocument doc, Stream stream)
		{
			using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
			{
				doc.WriteTo(writer);
				writer.Close();
			}
		}
		#endregion

		protected abstract object ExecuteInternal(object[] inputs);
		protected abstract void ValidateInputs(object[] inputs);
		protected abstract void Output(object obj, Stream stream);

		protected internal WidgetProcessor Context;

		private object[] GetArguments()
		{
			if (Inputs == null)
			{
				return new object[0];
			}
			object[] inputs = new object[Inputs.Length];
			for (int i = 0; i < Inputs.Length; i++)
			{
				inputs[i] = this.Context.Widget.Processes.ExecuteProcess(this.Inputs[i]);
			}
			return inputs;
		}

		private void SaveOutputToFile()
		{
			if (!String.IsNullOrEmpty(this.OutputFile))
			{
				using (FileStream file = new FileStream(this.Context.WidgetFilePath(this.OutputFile), FileMode.Create))
				{
					this.Output(this._output, file);
					file.Close();
				}
			}
		}

        private string ProcessMessage(string operation)
		{
			return String.Format("Process: {0}, Operation: {1}", Id, operation);
		}

		protected object _output;
		private bool _hasResult;

		static private readonly ILog _log = LogManager.GetLogger(typeof(BaseProcess));
	}
}
