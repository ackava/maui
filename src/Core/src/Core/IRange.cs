﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui
{
	/// <summary>
	/// Provides functionality to select a value from a range of values.
	/// </summary>
	public interface IRange : IView
	{
		/// <summary>
		/// Gets or sets the minimum selectable value.
		/// </summary>
		double Minimum { get; }

		/// <summary>
		/// Gets or sets the maximum selectable value.
		/// </summary>
		double Maximum { get; }

		/// <summary>
		/// Gets or sets the current value.
		/// </summary>
		double Value { get; set; }
	}
}