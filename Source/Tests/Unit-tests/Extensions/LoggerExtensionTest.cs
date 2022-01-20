using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mocks;
using RegionOrebroLan.Logging.Extensions;

namespace UnitTests.Extensions
{
	[TestClass]
	public class LoggerExtensionTest
	{
		#region Methods

		/// <summary>
		/// Not sure if this test is correct.
		/// </summary>
		[TestMethod]
		public async Task CheckingIsEnabledBeforeLog_ShouldBeFasterThanNotCheckingIsEnabledBeforeLog()
		{
			await Task.CompletedTask;

			const string argument = "Argument";
			const string message = "Debug";

			var logger = new LoggerMock();

			// Warm up
			var times = 10;

			for(var i = 0; i < times; i++)
			{
				logger.LogDebug(message);
				logger.LogDebug(message + ": {0}", argument);
				logger.LogDebug(new InvalidOperationException(message), message);
				logger.LogDebug(new InvalidOperationException(message), message + ": {0}", argument);
			}

			times = 1000000;

			// 1

			var start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebug(message);
			}

			var finish = DateTime.UtcNow;
			var durationWithoutCheck = finish - start;

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebugIfEnabled(message);
			}

			finish = DateTime.UtcNow;
			var durationWithCheck = finish - start;

			Assert.IsTrue(durationWithoutCheck > durationWithCheck, "Speed-test 1 failed.");

			// 2 (checking comes first)

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebugIfEnabled(message);
			}

			finish = DateTime.UtcNow;
			durationWithCheck = finish - start;

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebug(message);
			}

			finish = DateTime.UtcNow;
			durationWithoutCheck = finish - start;

			Assert.IsTrue(durationWithoutCheck > durationWithCheck, "Speed-test 2 failed.");

			// 3

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebug(new InvalidOperationException(message), message + ": {0}", argument);
			}

			finish = DateTime.UtcNow;
			durationWithoutCheck = finish - start;

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebugIfEnabled(new InvalidOperationException(message), message + ": {0}", argument);
			}

			finish = DateTime.UtcNow;
			durationWithCheck = finish - start;

			Assert.IsTrue(durationWithoutCheck > durationWithCheck, "Speed-test 3 failed.");

			// 4 (checking comes first)

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebugIfEnabled(new InvalidOperationException(message), message + ": {0}", argument);
			}

			finish = DateTime.UtcNow;
			durationWithCheck = finish - start;

			start = DateTime.UtcNow;
			for(var i = 0; i < times; i++)
			{
				logger.LogDebug(new InvalidOperationException(message), message + ": {0}", argument);
			}

			finish = DateTime.UtcNow;
			durationWithoutCheck = finish - start;

			Assert.IsTrue(durationWithoutCheck > durationWithCheck, "Speed-test 4 failed.");
		}

		[TestMethod]
		public async Task LogErrorIfEnabled_Test()
		{
			await Task.CompletedTask;

			var logger = new LoggerMock();
			logger.LogErrorIfEnabled("Message");
			Assert.AreEqual(0, logger.BeginScopeCalls.Count);
			Assert.AreEqual(1, logger.IsEnabledCalls.Count);
			Assert.AreEqual(LogLevel.Error, logger.IsEnabledCalls.First());
			Assert.AreEqual(0, logger.LogCalls.Count);

			logger = new LoggerMock { Enabled = true };
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

			logger = new LoggerMock { Enabled = true };
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

			logger = new LoggerMock { Enabled = true };
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

			logger = new LoggerMock { Enabled = true };
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