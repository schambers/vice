using System;
using System.Collections.Generic;
using System.Text;
using log4net.Appender;
using log4net.Layout;

namespace Vice
{
	public class ViceAppender : ConsoleAppender
	{
		private IDictionary<string, Expectation> _verifications;

		public ViceAppender(ILayout layout)
		{
			Layout = layout;
			_verifications = new Dictionary<string, Expectation>();
		}

		public void AddVerification(string message)
		{
			_verifications.Add(message, new Expectation(message, false));
		}

		protected override void Append(log4net.Core.LoggingEvent loggingEvent)
		{
			string message = loggingEvent.MessageObject.ToString();
			if (_verifications.ContainsKey(message))
				_verifications[message].WasCalled = true;
		}

		public bool Verify()
		{
			bool result = true;
			foreach (string key in _verifications.Keys)
				if (!_verifications[key].WasCalled)
					result = false;

			return result;
		}

		public void PrintExpectations()
		{
			foreach (string message in _verifications.Keys)
			{
				var sb = new StringBuilder();
				sb.Append("Logger called '")
					.Append(message)
					.Append("'. Was Called? '")
					.Append(_verifications[message].WasCalled)
					.Append("'");

				Console.WriteLine(sb.ToString());
			}
		}
	}
}
