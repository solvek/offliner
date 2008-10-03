using System;

namespace Solvek.Offliner.Lib
{
	public class Engine
	{
		private Engine()
		{			
		}

		static public Engine Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (typeof(Engine))
					{
						if (_instance == null)
						{
							_instance = new Engine();
						}
					}
				}
				return _instance;
			}
		}

		private static Engine _instance;
	}
}