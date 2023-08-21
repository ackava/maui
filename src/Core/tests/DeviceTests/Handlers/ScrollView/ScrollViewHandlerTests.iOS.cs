﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Microsoft.Maui.DeviceTests.Stubs;
using Microsoft.Maui.Handlers;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Platform;
using ObjCRuntime;
using UIKit;
using Xunit;
using Xunit.Sdk;

namespace Microsoft.Maui.DeviceTests
{
	public partial class ScrollViewHandlerTests : CoreHandlerTestBase<ScrollViewHandler, ScrollViewStub>
	{
		[Fact]
		public async Task ContentInitializesCorrectly()
		{
			EnsureHandlerCreated(builder => { builder.ConfigureMauiHandlers(handlers => { handlers.AddHandler<EntryStub, EntryHandler>(); }); });

			bool result = await InvokeOnMainThreadAsync(() =>
			{
				var entry = new EntryStub() { Text = "In a ScrollView" };

				var scrollView = new ScrollViewStub()
				{
					Content = entry
				};

				var scrollViewHandler = CreateHandler(scrollView);

				foreach (var platformView in scrollViewHandler.PlatformView.Subviews)
				{
					// ScrollView on iOS uses an intermediate ContentView to handle content measurement/arrangement
					if (platformView is Microsoft.Maui.Platform.ContentView contentView)
					{
						foreach (var content in contentView.Subviews)
						{
							if (content is MauiTextField)
							{
								return true;
							}
						}
					}
				}

				return false; // No MauiTextField
			});

			Assert.True(result, $"Expected (but did not find) a {nameof(MauiTextField)} in the Subviews array");
		}

		[Fact]
		public async Task ScrollViewContentSizeSet()
		{
			EnsureHandlerCreated(builder => { builder.ConfigureMauiHandlers(handlers => { handlers.AddHandler<EntryStub, EntryHandler>(); }); });

			var scrollView = new ScrollViewStub();
			var entry = new EntryStub() { Text = "In a ScrollView" };
			scrollView.Content = entry;

			var scrollViewHandler = await InvokeOnMainThreadAsync(() =>
			{
				var handler = CreateHandler(scrollView);

				// Setting an arbitrary value so we can verify that the handler is setting
				// the UIScrollView's ContentSize property during AttachAndRun
				handler.PlatformView.ContentSize = new CoreGraphics.CGSize(100, 100);
				return handler;
			});

			await InvokeOnMainThreadAsync(async () =>
			{
				await scrollViewHandler.PlatformView.AttachAndRun(() =>
				{
					// Verify that the ContentSize values have been modified
					Assert.NotEqual(100, scrollViewHandler.PlatformView.ContentSize.Height);
					Assert.NotEqual(100, scrollViewHandler.PlatformView.ContentSize.Width);
				});
			});
		}
	}
}
