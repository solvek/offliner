using System;
using System.Collections;
using System.Windows.Forms;
using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace NuSoft.Log4Net
{
    /// <summary>
    /// Implements a log4net appender to send output to a TextBox control.
    /// </summary>
    public class TextBoxAppender : AppenderSkeleton
    {
        protected override void Append (log4net.Core.LoggingEvent LoggingEvent)
        {
            System.IO.StringWriter stringWriter = new System.IO.StringWriter(System.Globalization.CultureInfo.InvariantCulture);
            Layout.Format(stringWriter, LoggingEvent);
            _textBox.AppendText(stringWriter.ToString());
			if (LoggingEvent.ExceptionObject != null)
			{
				_textBox.AppendText(LoggingEvent.ExceptionObject.ToString() + Environment.NewLine);
			}
        }

        public TextBox TextBox
        {
            set
            {
                _textBox = value;
            }
            get
            {
                return _textBox;
            }
        }

        public static void SetTextBox(TextBox tb)
        {
            foreach(IAppender appender in
                GetAppenders())
            {
                if (appender is TextBoxAppender)
                {
                    ((TextBoxAppender)appender).TextBox = tb;
                }
            }
        }

        private static IAppender[] GetAppenders()
        {
            ArrayList appenders = new ArrayList();

        	appenders.AddRange(((Hierarchy) LogManager.GetRepository()).Root.Appenders);
 
            foreach(ILog log in LogManager.GetCurrentLoggers())
            {
                appenders.AddRange(((Logger)log.Logger).Appenders);
            }

            return (IAppender[])appenders.ToArray(typeof(IAppender));

        }

		private TextBox _textBox;
    }
}