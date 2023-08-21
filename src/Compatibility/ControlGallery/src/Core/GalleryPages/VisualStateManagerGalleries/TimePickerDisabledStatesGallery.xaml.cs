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
using Microsoft.Maui.Controls.Xaml;

namespace Microsoft.Maui.Controls.ControlGallery.GalleryPages.VisualStateManagerGalleries
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePickerDisabledStatesGallery : ContentPage
	{
		public TimePickerDisabledStatesGallery()
		{
			InitializeComponent();

			Button0.Text = $"Toggle IsEnabled (Currently {Picker0.IsEnabled})";
			Button1.Text = $"Toggle IsEnabled (Currently {Picker1.IsEnabled})";
			Button2.Text = $"Toggle IsEnabled (Currently {Picker2.IsEnabled})";
			Button3.Text = $"Toggle IsEnabled (Currently {Picker3.IsEnabled})";
		}

		void Button0_OnClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			ToggleIsEnabled(Picker0, button);
		}

		void Button1_OnClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			ToggleIsEnabled(Picker1, button);
		}

		void Button2_OnClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			ToggleIsEnabled(Picker2, button);
		}

		void Button3_OnClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			ToggleIsEnabled(Picker3, button);
		}

		void ToggleIsEnabled(TimePicker picker, Button toggleButton)
		{
			picker.IsEnabled = !picker.IsEnabled;

			if (toggleButton != null)
			{
				toggleButton.Text = $"Toggle IsEnabled (Currently {picker.IsEnabled})";
			}
		}
	}
}