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
using Microsoft.Maui.Controls.Xaml;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 5046, "CornerRadius doesn't work in explicit style when implicit style exists",
		   PlatformAffected.Android | PlatformAffected.iOS | PlatformAffected.UWP)]
#if APP
	[XamlCompilation(XamlCompilationOptions.Compile)]
#endif
	public partial class Issue5046 : ContentPage
	{
		public Issue5046()
		{
#if APP
			InitializeComponent();
#endif
		}

		void Button_Clicked(object sender, System.EventArgs e)
		{
#if APP
			this.DisplayAlert("CornerRadius", "CornerRadius = " + ((Button)sender).CornerRadius, "OK");
#endif
		}
	}
}