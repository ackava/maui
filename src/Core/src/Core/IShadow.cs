﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Graphics;

namespace Microsoft.Maui
{
	/// <summary>
	/// Represents a Shadow that can be applied to a View.
	/// </summary>
	public interface IShadow
	{
		/// <summary>
		/// The radius of the blur used to generate the shadow
		/// </summary>
		float Radius { get; }

		/// <summary>
		/// The opacity of the shadow.
		/// </summary>
		float Opacity { get; }

		/// <summary>
		/// The Paint used to colorize the Shadow.
		/// At this time only SoliPaint works in all platforms
		/// </summary>
		Paint Paint { get; }

		/// <summary>
		/// Offset of the shadow relative to the View
		/// </summary>
		Point Offset { get; }
	}
}
