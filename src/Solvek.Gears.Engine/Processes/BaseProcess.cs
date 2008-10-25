using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using log4net;

using Solvek.Gears.Engine.Host;
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
		public Input[] Inputs;

		[XmlAttribute("input")]
		public string InputId;

        public object Execute()
        {
			if (!_hasResult)
			{
				this.PrepareInputIds();

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
				throw new ApplicationException(String.Format(HostInfo.GetString("Errors_Process_InputsAmount"), 
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

				bool valid = false;

				if (((t & DataType.String) != 0) && (inputs[i] is String))
				{
					valid = true;
				}

				if (((t & DataType.XmlDocument) != 0) && (inputs[i] is XmlDocument))
				{
					valid = true;
				}

				if (valid)
				{
					continue;
				}
				if (i == 0 && inputs.Length == 1)
				{
					throw new ApplicationException(String.Format(HostInfo.GetString("Errors_Process_WrongType"), t));
				}
				throw new ApplicationException(String.Format(HostInfo.GetString("Errors_Process_WrongTypeN"), i + 1, t));
			}
		}

		protected static void ValidateNoInputs(object[] inputs)
		{
			if (inputs.Length > 0)
			{
				throw new ApplicationException(String.Format(HostInfo.GetString("Errors_Process_NoInputAllowed"), inputs.Length));
			}
		}
		#endregion

		#region Outputters
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
			object[] inputs = new object[this._inpIds.Length];
			for (int i = 0; i < this._inpIds.Length; i++)
			{
				inputs[i] = this.Context.Widget.Processes.ExecuteProcess(this._inpIds[i]);
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

		private void PrepareInputIds()
		{
			if (this._inpIds != null)
			{
				return;
			}
			int cn = String.IsNullOrEmpty(this.InputId) ? 0 : 1;
			if (this.Inputs != null)
			{
				cn += Inputs.Length;
			}
			this._inpIds = new string[cn];

			if (Inputs != null)
			{
				for (int i = 0; i < this.Inputs.Length; i++)
				{
					this._inpIds[i] = this.Inputs[i].Id;
				}
			}

			if (!String.IsNullOrEmpty(this.InputId))
			{
				this._inpIds[cn-1] = this.InputId;
			}
			this.Inputs = null;
			this.InputId = null;
		}

		private string ProcessMessage(string operation)
		{
			return String.Format("Process: {0}, Operation: {1}", Id, operation);
		}

		protected object _output;
		private bool _hasResult;
		private string[] _inpIds;

		static private readonly ILog _log = LogManager.GetLogger(typeof(BaseProcess));
	}
}
