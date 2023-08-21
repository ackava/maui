﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Android.Views;

namespace Microsoft.Maui.Platform
{
	public static class ScrollViewExtensions
	{
		internal static void HandleScrollBarVisibilityChange(this IScrollBarView scrollView)
		{
			// According to the Android Documentation
			// * <p>AwakenScrollBars method should be invoked every time a subclass directly updates
			// *the scroll parameters.</ p >

			// If AwakenScrollBars is never called there are cases where the ScrollDrawable is never called
			// which causes a crash during draw

			if (scrollView.ScrollBarsInitialized)
				scrollView.AwakenScrollBars();

			// The scrollbar drawable won't initialize if ScrollbarFadingEnabled == false
			if (!scrollView.ScrollbarFadingEnabled)
			{
				scrollView.ScrollbarFadingEnabled = true;
				scrollView.AwakenScrollBars();
				scrollView.ScrollbarFadingEnabled = false;
			}
			else
			{
				scrollView.AwakenScrollBars();
			}

			scrollView.ScrollBarsInitialized = true;
		}

		public static void UpdateContent(this MauiScrollView scrollView, IView? content, IMauiContext context)
		{
			var nativeContent = content == null ? null : content.ToPlatform(context);

			scrollView.RemoveAllViews();

			if (nativeContent != null)
			{
				scrollView.SetContent(nativeContent);
			}
		}
	}
}