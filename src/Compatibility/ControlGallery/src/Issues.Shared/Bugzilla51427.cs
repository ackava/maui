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

using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 51427, "Custom Font Not Working Inside NavigationPage", PlatformAffected.UWP)]
	public class Bugzilla51427 : TestNavigationPage
	{
		protected override void Init()
		{
			PushAsync(new TestFontPage());
		}
	}

	class TestFontPage : ContentPage
	{
		public TestFontPage()
		{
			var label = new Label
			{
				Text = "This Label should be using a custom font.",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontSize = 24,
				FontFamily = "Assets/Fonts/Lobster-Regular.ttf#Lobster"
			};

			Content = label;
		}
	}
}