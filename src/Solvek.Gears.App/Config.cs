using System;
using System.IO;
using System.Security.Cryptography;
using System.Xml.Serialization;

namespace Solvek.Gears.App
{
	public class Config
	{
		public Config()
		{}

		static Config()
		{
			_crypter = new DESCryptoServiceProvider();
			_crypter.IV = Convert.FromBase64String("lWdJgFVXtDo=");
			_crypter.Key = Convert.FromBase64String("ENNmcXd1P2Q=");
		}
		
		public bool UseProxy;
		public string ProxyAddress;
		public bool RequireAuthentication;
		public string UserName;
		public string EncryptedPassword;
		public string Loacalization = "uk-UA";

		[XmlIgnore]
		public string Password
		{
			get
			{
				if (String.IsNullOrEmpty(EncryptedPassword))
				{
					return EncryptedPassword;
				}
				SymmetricAlgorithm provider = _crypter;
				byte[] buffer = Convert.FromBase64String(EncryptedPassword);

				MemoryStream ms = new MemoryStream(buffer);

				CryptoStream encStream = new CryptoStream(ms, provider.CreateDecryptor(), CryptoStreamMode.Read);

				StreamReader sr = new StreamReader(encStream);

				string val = sr.ReadLine();

				sr.Close();
				encStream.Close();
				ms.Close();

				return val;
			}
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					EncryptedPassword = value;
					return;
				}
				
				SymmetricAlgorithm provider = _crypter;
				MemoryStream ms = new MemoryStream();

				CryptoStream encStream = new CryptoStream(ms, provider.CreateEncryptor(), CryptoStreamMode.Write);

				StreamWriter sw = new StreamWriter(encStream);

				sw.WriteLine(value);

				sw.Close();
				encStream.Close();

				byte[] buffer = ms.ToArray();
				ms.Close();

				EncryptedPassword = Convert.ToBase64String(buffer);
			}
		}

		static readonly private SymmetricAlgorithm _crypter;
	}
}
