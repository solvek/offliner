using System;
using System.Collections;
using System.Collections.Generic;

namespace Solvek.Gears.Engine.Processes
{
	public class ProcessCollection : IEnumerable<BaseProcess>
	{
		public ProcessCollection(IEnumerable<BaseProcess> processes)
		{
			foreach(BaseProcess p in processes)
			{
				_proc.Add(p.Id, p);
			}
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

		private readonly Dictionary<string, BaseProcess> _proc = new Dictionary<string, BaseProcess>();
	}
}
