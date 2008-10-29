using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Solvek.Gears.Engine.Processes
{
	public class ProcessCollection : IEnumerable<BaseProcess>, IXmlSerializable
	{
		public ProcessCollection()
		{			
		}

		public object ExecuteProcess(string id)
		{
			BaseProcess proc;
			if (!_proc.TryGetValue(id, out proc))
			{
				throw new ApplicationException(String.Format("Process id {0} does not exist.", id));
			}
			return proc.Execute();
		}

		public void ResetResults()
		{
			foreach(BaseProcess proc in _proc.Values)
			{
				proc.ResetResult();
			}
		}

		public IEnumerator<BaseProcess> GetEnumerator()
		{
			return _proc.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _proc.Values.GetEnumerator();
		}

		public void Add(BaseProcess proc)
		{
			this._proc.Add(proc.Id, proc);
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			reader.Read();
			while(reader.Name != "processes")
			{
				Type t;
				if ((reader.NodeType != XmlNodeType.Element) || (!ProcessTypes.TryGetValue(reader.Name, out t)))
				{
					if (reader.Read())
					{
						continue;
					}
					break;
				}
				XmlSerializer s = new XmlSerializer(t, "http://www.solvek.com/gears/widget");
				BaseProcess p = (BaseProcess) s.Deserialize(reader);
				Add(p);
			}
		}

		public void WriteXml(XmlWriter writer)
		{
			throw new NotImplementedException();
		}

		private readonly Dictionary<string, BaseProcess> _proc = new Dictionary<string, BaseProcess>();

		static private Dictionary<string, Type> ProcessTypes
		{
			get
			{
				if (_processTypes == null)
				{
					_processTypes = new Dictionary<string, Type>();
					foreach(Type t in Assembly.GetCallingAssembly().GetTypes())
					{
						if (t.IsAbstract || !t.IsSubclassOf(typeof(BaseProcess)))
						{
							continue;
						}
						XmlRootAttribute attr = (XmlRootAttribute) Attribute.GetCustomAttribute(t, typeof(XmlRootAttribute));
						if (attr == null)
						{
							throw new ApplicationException(String.Format("Type {0} requires XmlRoot attribute", t.FullName));
						}
						_processTypes.Add(attr.ElementName, t);
					}
				}
				return _processTypes;
			}
		}

		static private Dictionary<string, Type> _processTypes;
	}
}
