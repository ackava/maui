﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
namespace Microsoft.Maui
{
	public interface IFileImageSource : IImageSource
	{
		string File { get; }
	}
}