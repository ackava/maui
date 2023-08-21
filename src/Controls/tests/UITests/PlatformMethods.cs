﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Appium;
using Microsoft.Maui.Controls;

namespace Microsoft.Maui.AppiumTests
{
	internal static class PlatformMethods
	{
		public static Tuple<string[], bool> GetPlatformPropertyQuery(this BindableProperty bindableProperty, TestDevice device)
		{
			return device switch
			{
				TestDevice.Android => PlatformMethodQueries.AndroidPropertyPlatformMethodDictionary[bindableProperty],
				TestDevice.Windows => PlatformMethodQueries.WindowsPropertyPlatformMethodDictionary[bindableProperty],
				_ => PlatformMethodQueries.ApplePropertyPlatformMethodDictionary[bindableProperty],
			};
		}
	}
}