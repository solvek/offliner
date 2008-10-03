using System;
using System.IO;

namespace Solvek.Offliner.Lib.Helpers
{
	public class ApplicationFolder
	{
		public ApplicationFolder(string companyName, string applicationName)
		{
			_applicationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 
				String.Format("{0}{1}{2}", companyName, Path.DirectorySeparatorChar, applicationName));
		}

		public string ApplicationPath
		{
			get { return _applicationPath; }
		}

		public void EnsureExisting()
		{
			Directory.CreateDirectory(_applicationPath);
		}

		private readonly string _applicationPath;
	}
}
