﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.Maui.DeviceTests.Stubs
{
	public partial class StepperStub : StubBase, IStepper
	{
		public double Interval { get; set; }

		public double Minimum { get; set; }

		public double Maximum { get; set; }

		public double Value { get; set; }
	}
}