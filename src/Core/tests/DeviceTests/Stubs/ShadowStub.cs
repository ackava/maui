﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public class ShadowStub : IShadow
	{
		public float Radius { get; set; }

		public float Opacity { get; set; }

		public Paint Paint { get; set; }

		public Point Offset { get; set; }
	}
}
