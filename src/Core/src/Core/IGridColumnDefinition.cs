﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui
{
	/// <summary>
	/// Provides the properties for a column in a GridLayout.
	/// </summary>
	public interface IGridColumnDefinition
	{
		/// <summary>
		/// Gets the width of the column.
		/// </summary>
		GridLength Width { get; }
	}
}