using System;

using Solvek.Gears.Engine.Host;

namespace Solvek.Gears.Engine.Runtime
{
	public class WidgetState
	{
		public WidgetState()
		{}

		public DateTime LastUpdate;
		public Status Status = Status.NotUpdated;

		public string GetStatusText()
		{
			return HostInfo.GetString("WidgetStatus_"+Status);
		}

		public WidgetState Clone()
		{
			WidgetState ws = new WidgetState();
			ws.LastUpdate = this.LastUpdate;
			ws.Status = this.Status;
			return ws;
		}
	}
}
