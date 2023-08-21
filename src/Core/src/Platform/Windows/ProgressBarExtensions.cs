﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.Platform
{
	public static class ProgressBarExtensions
	{
		public static void UpdateProgress(this ProgressBar platformProgressBar, IProgress progress)
		{
			platformProgressBar.Value = progress.Progress;
		}

		public static void UpdateProgressColor(this ProgressBar platformProgressBar, IProgress progress)
		{
			Color progressColor = progress.ProgressColor;
			if (progressColor != null)
				platformProgressBar.Foreground = progressColor.ToPlatform();
		}
	}
}