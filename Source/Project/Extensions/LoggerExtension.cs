using System;
using Microsoft.Extensions.Logging;

namespace RegionOrebroLan.Logging.Extensions
{
	[CLSCompliant(false)]
	public static class LoggerExtension
	{
		#region Methods

		public static void LogCriticalIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Critical, message, arguments);
		}

		public static void LogCriticalIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Critical, message, arguments);
		}

		public static void LogCriticalIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Critical, message, arguments);
		}

		public static void LogCriticalIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Critical, message, arguments);
		}

		public static void LogDebugIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Debug, message, arguments);
		}

		public static void LogDebugIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Debug, message, arguments);
		}

		public static void LogDebugIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Debug, message, arguments);
		}

		public static void LogDebugIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Debug, message, arguments);
		}

		public static void LogErrorIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Error, message, arguments);
		}

		public static void LogErrorIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Error, message, arguments);
		}

		public static void LogErrorIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Error, message, arguments);
		}

		public static void LogErrorIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Error, message, arguments);
		}

		private static void LogIfEnabled(this ILogger logger, EventId eventId, Exception exception, LogLevel logLevel, string message, params object[] arguments)
		{
			if(logger == null)
				throw new ArgumentNullException(nameof(logger));

			if(!logger.IsEnabled(logLevel))
				return;

			logger.Log(logLevel, eventId, exception, message, arguments);
		}

		public static void LogInformationIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Information, message, arguments);
		}

		public static void LogInformationIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Information, message, arguments);
		}

		public static void LogInformationIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Information, message, arguments);
		}

		public static void LogInformationIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Information, message, arguments);
		}

		public static void LogTraceIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Trace, message, arguments);
		}

		public static void LogTraceIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Trace, message, arguments);
		}

		public static void LogTraceIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Trace, message, arguments);
		}

		public static void LogTraceIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Trace, message, arguments);
		}

		public static void LogWarningIfEnabled(this ILogger logger, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, null, LogLevel.Warning, message, arguments);
		}

		public static void LogWarningIfEnabled(this ILogger logger, EventId eventId, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, null, LogLevel.Warning, message, arguments);
		}

		public static void LogWarningIfEnabled(this ILogger logger, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(0, exception, LogLevel.Warning, message, arguments);
		}

		public static void LogWarningIfEnabled(this ILogger logger, EventId eventId, Exception exception, string message, params object[] arguments)
		{
			logger.LogIfEnabled(eventId, exception, LogLevel.Warning, message, arguments);
		}

		#endregion
	}
}