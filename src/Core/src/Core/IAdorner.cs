﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui
{
	/// <summary>
	/// Represents an adorner around a view.
	/// </summary>
	public interface IAdorner : IWindowOverlayElement
	{
		/// <summary>
		/// Gets the Density for the Adorner.
		/// Used to override the default density behavior for the containing border. 
		/// </summary>
		float Density { get; }

		/// <summary>
		/// Gets the underlying <see cref="IView"/> that makes up the border.
		/// </summary>
		IView VisualView { get; }
	}
}