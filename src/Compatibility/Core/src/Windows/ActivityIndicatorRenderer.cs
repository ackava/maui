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

using System.ComponentModel;
using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Graphics;
using Microsoft.UI.Xaml;

namespace Microsoft.Maui.Controls.Compatibility.Platform.UWP
{
	[System.Obsolete(Compatibility.Hosting.MauiAppBuilderExtensions.UseMapperInstead)]
	public class ActivityIndicatorRenderer : ViewRenderer<ActivityIndicator, FormsProgressBar>
	{
		object _foregroundDefault;

		protected override void OnElementChanged(ElementChangedEventArgs<ActivityIndicator> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				if (Control == null)
				{
					SetNativeControl(new FormsProgressBar
					{
						IsIndeterminate = true,
						// TODO WINUI for some reason FormsProgressBarStyle won't load
						//Style = Microsoft.UI.Xaml.Application.Current.Resources["FormsProgressBarStyle"] as Microsoft.UI.Xaml.Style 
					});

					Control.Loaded += OnControlLoaded;
				}

				// UpdateColor() called when loaded to ensure we can cache dynamic default colors
				UpdateIsRunning();
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == ActivityIndicator.IsRunningProperty.PropertyName || e.PropertyName == VisualElement.OpacityProperty.PropertyName)
				UpdateIsRunning();
			else if (e.PropertyName == ActivityIndicator.ColorProperty.PropertyName)
				UpdateColor();
		}

		void OnControlLoaded(object sender, RoutedEventArgs routedEventArgs)
		{
			_foregroundDefault = Control.GetForegroundCache();
			UpdateColor();
		}

		[PortHandler]
		void UpdateColor()
		{
			Color color = Element.Color;

			if (color.IsDefault())
			{
				Control.RestoreForegroundCache(_foregroundDefault);
			}
			else
			{
				Control.Foreground = color.ToPlatform();
			}
		}

		[PortHandler]
		void UpdateIsRunning()
		{
			Control.ElementOpacity = Element.IsRunning ? Element.Opacity : 0;
		}
	}
}