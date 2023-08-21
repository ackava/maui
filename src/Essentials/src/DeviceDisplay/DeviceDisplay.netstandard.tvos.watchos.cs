// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable

namespace Microsoft.Maui.Devices
{
	partial class DeviceDisplayImplementation
	{
		protected override bool GetKeepScreenOn() => false;

		protected override void SetKeepScreenOn(bool keepScreenOn) { }

		protected override DisplayInfo GetMainDisplayInfo() => default;

		protected override void StartScreenMetricsListeners() { }

		protected override void StopScreenMetricsListeners() { }
	}
}
