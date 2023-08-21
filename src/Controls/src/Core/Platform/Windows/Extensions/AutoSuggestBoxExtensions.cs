﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.Controls.Platform
{
	internal static class AutoSuggestBoxExtensions
	{
		public static void UpdateText(this AutoSuggestBox platformControl, InputView inputView)
		{
			platformControl.Text = TextTransformUtilites.GetTransformedText(inputView.Text, inputView.TextTransform);
		}
	}
}
