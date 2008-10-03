using System;
using System.IO;
using System.Xml.Serialization;

namespace Solvek.Offliner.WidgetTest
{
	public class Settings
	{
		public Settings()
		{}

		public static Settings LoadSettings(string path)
		{
			StreamReader reader = new StreamReader(path);
			 
			XmlSerializer dsr = new XmlSerializer(typeof(Settings));
			Settings res = (Settings)dsr.Deserialize(reader);

			reader.Close();

			return res;
		}

		public void SaveSettings(string path)
		{
			XmlSerializer sr = new XmlSerializer(this.GetType());
			FileStream fs = new FileStream(path, FileMode.Create);
			sr.Serialize(fs, this);
			fs.Close();
		}

		public string LastWidget = String.Empty;
	}
}
