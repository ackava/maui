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
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Compatibility.UITests
{
	[TestFixture]
	[Category(UITestCategories.Switch)]
	internal class SwitchUITests : _ViewUITests
	{
		public SwitchUITests()
		{
			PlatformViewType = Views.Switch;
		}

		protected override void NavigateToGallery()
		{
			App.NavigateToGallery(GalleryQueries.SwitchGallery);
		}

		[UiTestExempt(ExemptReason.CannotTest, "Invalid interaction")]
		public override void _Focus()
		{
		}

		// TODO
		public override void _GestureRecognizers()
		{
		}

		[UiTestExempt(ExemptReason.CannotTest, "Invalid interaction")]
		public override void _IsFocused()
		{
		}

		[UiTestExempt(ExemptReason.CannotTest, "Invalid interaction")]
		public override void _UnFocus()
		{
		}

		// TODO
		// Implement control specific ui tests
		protected override void FixtureTeardown()
		{
			App.NavigateBack();
			base.FixtureTeardown();
		}

#if __ANDROID__ || __IOS__
		[Ignore("This is covered by the platform opacity tests")]
		public override void _Opacity() { }
#endif

#if __ANDROID__ || __IOS__ || WINDOWS
		[Ignore("This is covered by the platform tests")]
		public override void _IsEnabled() { }
#endif

#if __ANDROID__ || __IOS__ || WINDOWS
		[Ignore("This is covered by the platform tests")]
		public override void _Rotation() { }

		[Ignore("This is covered by the platform tests")]
		public override void _RotationX() { }

		[Ignore("This is covered by the platform tests")]
		public override void _RotationY() { }
#endif

#if __ANDROID__
		[Ignore("This is covered by the platform tests")]
		public override void _TranslationX() { }

		[Ignore("This is covered by the platform tests")]
		public override void _TranslationY() { }
#endif

#if __IOS__ || WINDOWS
		[Ignore("This is covered by the platform tests")]
		public override void _Scale() { }
#endif

#if __ANDROID__ || __IOS__
		[Ignore("This is covered by the platform tests")]
		public override void _IsVisible() { }
#endif
	}
}