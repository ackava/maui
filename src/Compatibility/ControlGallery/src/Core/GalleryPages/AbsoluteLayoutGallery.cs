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
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Devices;
using Microsoft.Maui.Graphics;
using AbsoluteLayoutFlags = Microsoft.Maui.Layouts.AbsoluteLayoutFlags;

namespace Microsoft.Maui.Controls.ControlGallery
{
	[Preserve(AllMembers = true)]
	internal class AbsolutePositioningExplorationViewModel : INotifyPropertyChanged
	{
		double _rectangleX = 0.5;
		double _rectangleY = 0.5;
		double _rectangleWidth = 0.5;
		double _rectangleHeight = 0.5;

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}

		public double RectangleX
		{
			get { return _rectangleX; }
			set
			{
				if (_rectangleX == value)
					return;
				_rectangleX = value;
				OnPropertyChanged();
				OnPropertyChanged("Rectangle");
			}
		}

		public double RectangleY
		{
			get { return _rectangleY; }
			set
			{
				if (_rectangleY == value)
					return;
				_rectangleY = value;
				OnPropertyChanged();
				OnPropertyChanged("Rectangle");
			}
		}

		public double RectangleWidth
		{
			get { return _rectangleWidth; }
			set
			{
				if (_rectangleWidth == value)
					return;
				_rectangleWidth = value;
				OnPropertyChanged();
				OnPropertyChanged("Rectangle");
			}
		}

		public double RectangleHeight
		{
			get { return _rectangleHeight; }
			set
			{
				if (_rectangleHeight == value)
					return;
				_rectangleHeight = value;
				OnPropertyChanged();
				OnPropertyChanged("Rectangle");
			}
		}

		public Rect Rectangle
		{
			get { return new Rect(RectangleX, RectangleY, RectangleWidth, RectangleHeight); }
		}
	}
	public class AbsoluteLayoutGallery : ContentPage
	{
		public AbsoluteLayoutGallery()
		{
			if (DeviceInfo.Platform == DevicePlatform.iOS && DeviceInfo.Idiom == DeviceIdiom.Tablet)
				Padding = new Thickness(0, 0, 0, 60);

			BindingContext = new AbsolutePositioningExplorationViewModel();
			var absLayout = new AbsoluteLayout
			{
				BackgroundColor = Colors.Gray,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var rect = new BoxView { Color = Colors.Lime };

			var xSlider = new Slider();
			var ySlider = new Slider();
			var widthSlider = new Slider();
			var heightSlider = new Slider();

			var grid = new Grid
			{
				Padding = 10,
				RowSpacing = 0,
				ColumnDefinitions = {
					new ColumnDefinition {Width = GridLength.Auto},
					new ColumnDefinition {Width = new GridLength (1, GridUnitType.Star)}
				}
			};

			grid.Add(new Label { Text = "X:", VerticalTextAlignment = TextAlignment.Center }, 0, 0);
			grid.Add(xSlider, 1, 0);

			grid.Add(new Label { Text = "Y:", VerticalTextAlignment = TextAlignment.Center }, 0, 1);
			grid.Add(ySlider, 1, 1);

			grid.Add(new Label { Text = "Width:", VerticalTextAlignment = TextAlignment.Center }, 0, 2);
			grid.Add(widthSlider, 1, 2);

			grid.Add(new Label { Text = "Height:", VerticalTextAlignment = TextAlignment.Center }, 0, 3);
			grid.Add(heightSlider, 1, 3);

			absLayout.Children.Add(rect);

			var mainLayout = new StackLayout
			{
				Spacing = 0,
				Children = {
					absLayout,
					grid
				}
			};

			rect.SetBinding(AbsoluteLayout.LayoutBoundsProperty, "Rectangle");
			AbsoluteLayout.SetLayoutFlags(rect, AbsoluteLayoutFlags.All);

			xSlider.SetBinding(Slider.ValueProperty, new Binding("RectangleX", BindingMode.TwoWay));
			ySlider.SetBinding(Slider.ValueProperty, new Binding("RectangleY", BindingMode.TwoWay));
			widthSlider.SetBinding(Slider.ValueProperty, new Binding("RectangleWidth", BindingMode.TwoWay));
			heightSlider.SetBinding(Slider.ValueProperty, new Binding("RectangleHeight", BindingMode.TwoWay));

			//Content = new ScrollView {Content = mainLayout};
			Content = mainLayout;
		}
	}
}
