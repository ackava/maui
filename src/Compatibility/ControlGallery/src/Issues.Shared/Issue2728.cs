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

#if UITEST
using NUnit.Framework;
using Xamarin.UITest;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Github5000)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 2728, "[macOS] Label FontAttributes Italic is not working")]
	public class Issue2728 : TestContentPage
	{
		const string _lblHome = "Hello Label";

		protected override void Init()
		{
			var label = new Label { Text = _lblHome, FontAttributes = FontAttributes.Italic };

			Content = new StackLayout
			{
				Children = {
					label
				}
			};
		}


#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void Issue2728TestsItalicLabel()
		{
			RunningApp.WaitForElement(q => q.Text(_lblHome));
			RunningApp.Screenshot("Label rendererd with italic font");
		}
#endif

	}
}
