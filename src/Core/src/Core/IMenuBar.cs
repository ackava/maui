﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Microsoft.Maui
{
	/// <summary>
	/// Represents a specialized container that presents a set of menus in a horizontal row, 
	/// typically at the top of an app window.
	/// </summary>
	public interface IMenuBar : IList<IMenuBarItem>, IElement
	{
		/// <summary>
		/// Gets a value indicating whether this View is enabled in the user interface. 
		/// </summary>
		bool IsEnabled { get; }
	}
}
