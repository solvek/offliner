using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Solvek.Gears.App
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[MTAThread]
		static void Main()
		{
			log4net.Config.XmlConfigurator.Configure(new FileInfo(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase), "log4net.xml")));
			Application.Run(new MainForm());
		}
	}
}