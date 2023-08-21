﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
using System;
using Android.Content;
using Android.Views;

namespace Microsoft.Maui.Controls.Handlers.Items
{
	internal class SizedItemContentView : ItemContentView
	{
		readonly Func<double> _width;
		readonly Func<double> _height;

		public SizedItemContentView(Context context, Func<double> width, Func<double> height)
			: base(context)
		{
			_width = width;
			_height = height;
		}

		protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
		{
			if (Content == null)
			{
				SetMeasuredDimension(0, 0);
				return;
			}

			double targetWidth = _width();
			double targetHeight = _height();

			if (!double.IsInfinity(targetWidth))
				targetWidth = (int)Context.FromPixels(targetWidth);

			if (!double.IsInfinity(targetHeight))
				targetHeight = (int)Context.FromPixels(targetHeight);

			if (Content.VirtualView.Handler is IPlatformViewHandler pvh)
			{
				var widthSpec = Context.CreateMeasureSpec(targetWidth,
					double.IsInfinity(targetWidth) ? double.NaN : targetWidth
					, targetWidth);

				var heightSpec = Context.CreateMeasureSpec(targetHeight, double.IsInfinity(targetHeight) ? double.NaN : targetHeight
					, targetHeight);

				var size = pvh.MeasureVirtualView(widthSpec, heightSpec);

				SetMeasuredDimension((int)size.Width, (int)size.Height);
			}
		}
	}
}
