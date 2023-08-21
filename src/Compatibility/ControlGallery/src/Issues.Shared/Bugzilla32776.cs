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

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maui.Controls.CustomAttributes;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Issue(IssueTracker.Bugzilla, 32776, "FlyoutPage - page title not showing for Windows Phone 8.1 (any orientation) or in Windows 8.1 (portrait orientation).", PlatformAffected.WinRT, NavigationBehavior.PushModalAsync)]
	public class Bugzilla32776
		: FlyoutPage
	{
		public Bugzilla32776()
		{
			Flyout = new ContentPage { Title = "Content page" };
			Detail = new NavigationPage(new ContentPage
			{
				Title = "Test"
			});
		}
	}
}
