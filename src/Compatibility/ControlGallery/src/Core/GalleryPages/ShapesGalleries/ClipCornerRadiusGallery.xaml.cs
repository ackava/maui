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

namespace Microsoft.Maui.Controls.ControlGallery.GalleryPages.ShapesGalleries
{
	public partial class ClipCornerRadiusGallery : ContentPage
	{
		public ClipCornerRadiusGallery()
		{
			InitializeComponent();
		}

		void OnCornerChanged(object sender, ValueChangedEventArgs e)
		{
			RoundRectangleGeometry.CornerRadius = new CornerRadius(
				TopLeftCorner.Value,
				TopRightCorner.Value,
				BottomLeftCorner.Value,
				BottomRightCorner.Value);
		}
	}
}