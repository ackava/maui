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

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[NUnit.Framework.Category(Compatibility.UITests.UITestCategories.Bugzilla)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Bugzilla, 21780, "Windows Phone Editor control has black background with black text, background turns to white when editing", PlatformAffected.WinPhone)]
	public class Bugzilla21780 : ContentPage
	{
		public Bugzilla21780()
		{
			var label = new Label() { Text = "If text is visible in the editor below, this test has passed." };
			var editor = new Editor() { Text = "This text should be visible even if the editor does not have focus" };

			Content = new StackLayout()
			{
				Children = { label, editor }
			};
		}
	}
}
