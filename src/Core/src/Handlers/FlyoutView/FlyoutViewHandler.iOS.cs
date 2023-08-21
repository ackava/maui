﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

namespace Microsoft.Maui.Handlers
{
	public partial class FlyoutViewHandler : ViewHandler<IFlyoutView, UIKit.UIView>
	{
		protected override UIKit.UIView CreatePlatformView()
		{
			throw new System.NotImplementedException();
		}
	}
}
