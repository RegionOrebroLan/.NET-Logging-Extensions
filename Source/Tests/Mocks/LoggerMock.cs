using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Moq;

namespace Mocks
{
	public class LoggerMock : ILogger
	{
		#region Properties

		public virtual IList<object> BeginScopeCalls { get; } = new List<object>();
		public virtual bool Enabled { get; set; }
		public virtual IList<LogLevel> IsEnabledCalls { get; } = new List<LogLevel>();
		public virtual IList<Tuple<EventId, Exception, LogLevel, object>> LogCalls { get; } = new List<Tuple<EventId, Exception, LogLevel, object>>();

		#endregion

		#region Methods

		public virtual IDisposable BeginScope<TState>(TState state)
		{
			this.BeginScopeCalls.Add(state);

			return Mock.Of<IDisposable>();
		}

		public virtual bool IsEnabled(LogLevel logLevel)
		{
			this.IsEnabledCalls.Add(logLevel);

			return this.Enabled;
		}

		public virtual void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
		{
			this.LogCalls.Add(Tuple.Create<EventId, Exception, LogLevel, object>(eventId, exception, logLevel, state));
		}

		#endregion
	}
}