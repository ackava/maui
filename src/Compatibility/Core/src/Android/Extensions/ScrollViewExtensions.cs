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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Microsoft.Maui.Controls.Compatibility.Platform.Android
{
	internal static class ScrollViewExtensions
	{
		internal static void HandleScrollBarVisibilityChange(this IScrollView scrollView)
		{
			// According to the Android Documentation
			// * <p>AwakenScrollBars method should be invoked every time a subclass directly updates
			// *the scroll parameters.</ p >

			// If AwakenScrollBars is never called there are cases where the ScrollDrawable is never called
			// which causes a crash during draw

			if (scrollView.ScrollBarsInitialized)
				scrollView.AwakenScrollBars();

			// The scrollbar drawable won't initialize if ScrollbarFadingEnabled == false
			if (!scrollView.ScrollbarFadingEnabled)
			{
				scrollView.ScrollbarFadingEnabled = true;
				scrollView.AwakenScrollBars();
				scrollView.ScrollbarFadingEnabled = false;
			}
			else
			{
				scrollView.AwakenScrollBars();
			}

			scrollView.ScrollBarsInitialized = true;
		}
	}
}