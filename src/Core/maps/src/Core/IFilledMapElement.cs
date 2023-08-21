﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.Maps
{
	public interface IFilledMapElement : IMapElement
	{
		Paint? Fill { get; }
	}
}
