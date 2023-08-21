﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.Content.PM;
//using Android.OS;
//using Android.Renderscripts;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Microsoft.Maui.Controls.ControlGallery.Issues;

using System.Collections.Generic;
using System.Reflection;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.ControlGallery.Tests;
using Microsoft.Maui.Controls.ControlGallery.WinUI.Tests;
using NUnit;

[assembly: Dependency(typeof(PlatformTestSettings))]
namespace Microsoft.Maui.Controls.ControlGallery.WinUI.Tests
{
	public class PlatformTestSettings : IPlatformTestSettings
	{
		public PlatformTestSettings()
		{
			TestRunSettings = new Dictionary<string, object>
			{
				{ FrameworkPackageSettings.RunOnMainThread, false }
			};
		}

		public Assembly Assembly { get => Assembly.Load("Xamarin.Forms.Platform.UAP.UnitTests, Version = 2.0.0.0, Culture = neutral, PublicKeyToken = null"); }
		public Dictionary<string, object> TestRunSettings { get; }
	}
}
