﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui.DeviceTests
{
	public partial class BorderHandlerTests
	{
		ContentPanel GetNativeBorder(BorderHandler borderHandler) =>
			borderHandler.PlatformView;
	}
}