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

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github5000)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 1399, "ActivityIndicator width is autosize in absolutelayout", PlatformAffected.UWP)]
	public class Issue1399 : TestContentPage
	{
		protected override void Init()
		{
			Content = new AbsoluteLayout()
			{
				Children = {
					new Label { Text = "cat", WidthRequest = 0},
					new Image { Source = "coffee.png", WidthRequest = 0},
					new ActivityIndicator { IsRunning = true }
				}
			};
		}
	}
}