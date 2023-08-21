// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using SkiaSharp;

namespace Microsoft.Maui.Graphics.Skia
{
	public interface ISkiaGraphicsRenderer : IDisposable
	{
		WDSkiaGraphicsView GraphicsView { set; }
		ICanvas Canvas { get; }
		IDrawable Drawable { get; set; }
		Color BackgroundColor { get; set; }
		void Draw(SKCanvas canvas, RectF dirtyRect);
		void SizeChanged(int width, int height);
		void Detached();
		void Invalidate();
		void Invalidate(float x, float y, float w, float h);
	}
}
