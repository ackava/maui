//using System;
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
using System.Threading.Tasks;
using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 57749, "After enabling a disabled button it is not clickable", PlatformAffected.UWP)]
	public class Bugzilla57749 : TestContentPage
	{
		protected override void Init()
		{
			button1.Text = "Click me";
			button1.AutomationId = "btnClick";
			button1.IsEnabled = false;
			button1.Clicked += Button1_Clicked1;
			this.Content = button1;
		}
		Button button1 = new Button();

		private void Button1_Clicked1(object sender, EventArgs e)
		{
			this.DisplayAlert("Button test", "Button was clicked", "Ok");
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await Task.Delay(100);
			button1.IsEnabled = true;
		}

#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public async Task Bugzilla57749Test()
		{
			await Task.Delay(500);
			RunningApp.Tap(c => c.Marked("btnClick"));
			RunningApp.WaitForElement (q => q.Marked ("Button was clicked"));
			RunningApp.Tap("Ok");
		}
#endif
	}
}