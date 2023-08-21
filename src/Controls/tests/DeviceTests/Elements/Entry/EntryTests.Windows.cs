﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable enable
using System.Threading.Tasks;
using Microsoft.Maui.Handlers;
using Microsoft.UI.Xaml.Controls;

namespace Microsoft.Maui.DeviceTests
{
	public partial class EntryTests
	{
		static TextBox GetPlatformControl(EntryHandler handler) =>
			handler.PlatformView;

		static Task<string> GetPlatformText(EntryHandler handler)
		{
			return InvokeOnMainThreadAsync(() => GetPlatformControl(handler).Text);
		}

		static void SetPlatformText(EntryHandler entryHandler, string text) =>
			GetPlatformControl(entryHandler).Text = text;

		static int GetPlatformCursorPosition(EntryHandler entryHandler) =>
			GetPlatformControl(entryHandler).SelectionStart;

		static int GetPlatformSelectionLength(EntryHandler entryHandler) =>
			GetPlatformControl(entryHandler).SelectionLength;
	}
}
