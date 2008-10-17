using System;

namespace Solvek.Offliner.Lib.Exceptions
{
	public class WidgetLoadingException : ApplicationException
	{
		public WidgetLoadingException(string widgetPath)
		{
			_widgetPath = widgetPath;
		}

		public WidgetLoadingException(string message, string widgetPath)
			: base(message)
		{
			_widgetPath = widgetPath;
		}

		public WidgetLoadingException(string message, Exception innerException, string widgetPath)
			: base(message, innerException)
		{
			_widgetPath = widgetPath;
		}

		public string WidgetPath
		{
			get { return this._widgetPath; }
		}

		private readonly string _widgetPath;
	}
}
