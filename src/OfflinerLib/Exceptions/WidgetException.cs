using System;
using WD = Solvek.Offliner.Lib.WidgetDescription.Widget;

namespace Solvek.Offliner.Lib.Exceptions
{
	public class WidgetException : ApplicationException
	{
		public WidgetException(WD widget)
		{
			_widget = widget;
		}

		public WidgetException(string message, WD widget)
			: base(message)
		{
			_widget = widget;
		}

		public WidgetException(string message, Exception innerException, WD widget)
			: base(message, innerException)
		{
			_widget = widget;
		}

		public WD Widget
		{
			get { return this._widget; }
		}

		private readonly WD _widget;
	}
}
