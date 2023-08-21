// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;
using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.Handlers.Benchmarks
{
	class ApplicationStub : IApplication
	{
		readonly List<IWindow> _windows = new List<IWindow>();

		public IElementHandler Handler { get; set; }

		public IElement Parent { get; set; }

		public IReadOnlyList<IWindow> Windows => _windows.AsReadOnly();

		public AppTheme UserAppTheme { get; set; }

		public IWindow CreateWindow(IActivationState state)
		{
			_windows.Add(new WindowStub());

			return _windows[0];
		}

		public void OpenWindow(IWindow window)
		{
			_windows.Add(window);
		}

		public void CloseWindow(IWindow window)
		{
			_windows.Remove(window);
		}

		public void ThemeChanged() { }
	}
}