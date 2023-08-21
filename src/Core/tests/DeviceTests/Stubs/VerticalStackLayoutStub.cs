﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Layouts;

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public class VerticalStackLayoutStub : LayoutStub, IStackLayout
	{
		public double Spacing => 0;

		protected override ILayoutManager CreateLayoutManager()
		{
			return new VerticalStackLayoutManager(this);
		}
	}
}
