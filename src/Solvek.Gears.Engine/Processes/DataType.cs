using System;

namespace Solvek.Gears.Engine.Processes
{
	[Flags]
	public enum DataType
	{
		None = 0x1,
		String = 0x2,
		XmlDocument = 0x4,
		RowData = 0x8
	}
}
