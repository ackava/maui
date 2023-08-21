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
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Maui.Controls.ControlGallery
{
	//Issue 465
	public class Issue465Page : TabbedPage
	{
		public Issue465Page()
		{
			var popModalButton = new Button
			{
				Text = "PopModalAsync",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			var splashPage = new ContentPage { Content = popModalButton };

			Navigation.PushModalAsync(splashPage);

			popModalButton.Clicked += (s, e) => Navigation.PopModalAsync();

		}
	}
}