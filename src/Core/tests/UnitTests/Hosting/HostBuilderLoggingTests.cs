// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using Xunit;

namespace Microsoft.Maui.UnitTests.Hosting
{
	[Category(TestCategory.Core, TestCategory.Hosting)]
	public class HostBuilderLoggingTests
	{
		[Fact]
		public void GetValidILoggerByDefault()
		{
			var builder = MauiApp.CreateBuilder();
			var mauiApp = builder.Build();

			ILogger logger = mauiApp.Services.GetService<ILogger<HostBuilderLoggingTests>>();
			Assert.NotNull(logger);
			logger.LogError("An error");
		}

		[Fact]
		public void CanAddLoggingProviders()
		{
			var loggerProvider = new MyLoggerProvider();

			var builder = MauiApp.CreateBuilder();
			builder
				.Logging
				.Services
				.AddSingleton<ILoggerProvider>(loggerProvider);

			var mauiApp = builder.Build();

			ILogger logger = mauiApp.Services.GetService<ILogger<HostBuilderLoggingTests>>();
			logger.LogError("An error");
			Assert.Single(loggerProvider.Messages);
			Assert.Equal("An error", loggerProvider.Messages[0]);
		}

		private sealed class MyLoggerProvider : ILoggerProvider, ILogger
		{
			public List<string> Messages { get; } = new();

			public ILogger CreateLogger(string categoryName) => this;
			public IDisposable BeginScope<TState>(TState state) => this;

			public bool IsEnabled(LogLevel logLevel) => true;

			public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
			{
				Messages.Add(formatter(state, exception));
			}

			public void Dispose() { }
		}
	}
}