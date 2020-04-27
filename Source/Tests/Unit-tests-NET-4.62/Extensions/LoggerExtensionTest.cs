using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.Logging.Extensions;
using RegionOrebroLan.Logging.Helpers.Mocks;

namespace RegionOrebroLan.Logging.UnitTests.Net462.Extensions
{
	[CLSCompliant(false)]
	[TestClass]
	public class LoggerExtensionTest
	{
		#region Methods

		[TestMethod]
		public void LogErrorIfEnabled_Test()
		{
			var logger = new LoggerMock();
			logger.LogErrorIfEnabled("Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(0, logger.LogCalls.Count);

			logger = new LoggerMock {Enabled = true};
			logger.LogErrorIfEnabled("Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(1, logger.LogCalls.Count);
			Assert.AreEqual(0, logger.LogCalls.First().Item1);
			Assert.IsNull(logger.LogCalls.First().Item2);
			Assert.AreEqual(LogLevel.Error, logger.LogCalls.First().Item3);
			Assert.AreEqual("Message", logger.LogCalls.First().Item4.ToString());

			logger = new LoggerMock();
			logger.LogErrorIfEnabled(new EventId(1), "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(0, logger.LogCalls.Count);

			logger = new LoggerMock {Enabled = true};
			logger.LogErrorIfEnabled(new EventId(1), "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(1, logger.LogCalls.Count);
			Assert.AreEqual(1, logger.LogCalls.First().Item1);
			Assert.IsNull(logger.LogCalls.First().Item2);
			Assert.AreEqual(LogLevel.Error, logger.LogCalls.First().Item3);
			Assert.AreEqual("Message", logger.LogCalls.First().Item4.ToString());

			var exception = new InvalidOperationException("Error");
			logger = new LoggerMock();
			logger.LogErrorIfEnabled(exception, "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(0, logger.LogCalls.Count);

			logger = new LoggerMock {Enabled = true};
			logger.LogErrorIfEnabled(exception, "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(1, logger.LogCalls.Count);
			Assert.AreEqual(0, logger.LogCalls.First().Item1);
			Assert.AreEqual(exception, logger.LogCalls.First().Item2);
			Assert.AreEqual(LogLevel.Error, logger.LogCalls.First().Item3);
			Assert.AreEqual("Message", logger.LogCalls.First().Item4.ToString());

			exception = new InvalidOperationException("Error");
			logger = new LoggerMock();
			logger.LogErrorIfEnabled(new EventId(1), exception, "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(0, logger.LogCalls.Count);

			logger = new LoggerMock {Enabled = true};
			logger.LogErrorIfEnabled(new EventId(1), exception, "Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(1, logger.LogCalls.Count);
			Assert.AreEqual(1, logger.LogCalls.First().Item1);
			Assert.AreEqual(exception, logger.LogCalls.First().Item2);
			Assert.AreEqual(LogLevel.Error, logger.LogCalls.First().Item3);
			Assert.AreEqual("Message", logger.LogCalls.First().Item4.ToString());
		}

		#endregion
	}
}