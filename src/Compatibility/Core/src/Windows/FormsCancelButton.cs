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
using Microsoft.UI.Xaml.Controls;
using WBorder = Microsoft.UI.Xaml.Controls.Border;
using WBrush = Microsoft.UI.Xaml.Media.Brush;

namespace Microsoft.Maui.Controls.Compatibility.Platform.UWP
{
	internal class FormsCancelButton : Microsoft.UI.Xaml.Controls.Button
	{
		TextBlock _cancelButtonGlyph;
		WBorder _cancelButtonBackground;

		public WBrush ForegroundBrush
		{
			get => _cancelButtonGlyph.Foreground;
			set => _cancelButtonGlyph.Foreground = value;
		}

		public WBrush BackgroundBrush
		{
			get => _cancelButtonBackground.Background;
			set => _cancelButtonBackground.Background = value;
		}

		public bool IsReady { get; private set; }

		public event EventHandler ReadyChanged;

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_cancelButtonGlyph = (TextBlock)GetTemplateChild("GlyphElement");
			_cancelButtonBackground = (WBorder)GetTemplateChild("BorderElement");

			if (_cancelButtonGlyph != null && _cancelButtonBackground != null)
			{
				// The SearchBarRenderer needs to be able to check whether we're ready to have the colors set
				// (we won't be until the first time the button actually appears, which requires the search bar
				// to be focused and have text in it)
				IsReady = true;

				// And we need to inform the SearchBarRenderer of this so it can run the button color update method
				OnReadyChanged();
			}
		}

		protected virtual void OnReadyChanged()
		{
			ReadyChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}