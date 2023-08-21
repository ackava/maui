// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui
{
	/// <summary>
	/// Enumerates values that determine the text transformation on an element.
	/// </summary>
	public enum TextTransform
	{
		/// <summary>
		/// No text transformation is applied.
		/// </summary>
		None = 0,

		/// <summary>
		/// The default text transformation is applied.
		/// </summary>
		Default,

		/// <summary>
		/// The text will be transformed into lowercase.
		/// </summary>
		Lowercase,

		/// <summary>
		/// The text will be transformed into uppercase.
		/// </summary>
		Uppercase
	}
}