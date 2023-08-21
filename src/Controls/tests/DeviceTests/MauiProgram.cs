﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.LifecycleEvents;
using Microsoft.Maui.TestUtils.DeviceTests.Runners;

namespace Microsoft.Maui.DeviceTests
{
	public static class MauiProgram
	{
#if ANDROID
		public static Android.Content.Context CurrentContext => MauiProgramDefaults.DefaultContext;
#elif WINDOWS
		public static Microsoft.UI.Xaml.Window CurrentWindow => MauiProgramDefaults.DefaultWindow;
#endif

		public static IApplication DefaultTestApp => MauiProgramDefaults.DefaultTestApp;

		public static MauiApp CreateMauiApp() =>
			MauiProgramDefaults.CreateMauiApp(new List<Assembly>()
			{
				typeof(MauiProgram).Assembly
			});
	}
}