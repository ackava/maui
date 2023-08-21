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
using ObjCRuntime;
using UIKit;
using PointF = CoreGraphics.CGPoint;
using RectangleF = CoreGraphics.CGRect;

namespace Microsoft.Maui.Controls.Compatibility.Platform.iOS
{
	[Obsolete("Use Microsoft.Maui.Controls.Handlers.Compatibility.KeyboardInsetTracker instead")]
	internal class KeyboardInsetTracker : IDisposable
	{
		readonly Func<UIWindow> _fetchWindow;
		readonly Action<PointF> _setContentOffset;
		readonly Action<UIEdgeInsets> _setInsetAction;
		readonly UIScrollView _targetView;
		bool _disposed;
		UIEdgeInsets _currentInset;
		RectangleF _lastKeyboardRect;


		public KeyboardInsetTracker(UIScrollView targetView, Func<UIWindow> fetchWindow, Action<UIEdgeInsets> setInsetAction)
			: this(targetView, fetchWindow, setInsetAction, null)
		{
		}

		public KeyboardInsetTracker(UIScrollView targetView, Func<UIWindow> fetchWindow, Action<UIEdgeInsets> setInsetAction, Action<PointF> setContentOffset)
			 : this(targetView, fetchWindow, setInsetAction, setContentOffset, null)
		{
		}

		public KeyboardInsetTracker(UIScrollView targetView, Func<UIWindow> fetchWindow, Action<UIEdgeInsets> setInsetAction, Action<PointF> setContentOffset, IVisualElementRenderer renderer)
		{
			_setContentOffset = setContentOffset;
			_targetView = targetView;
			_fetchWindow = fetchWindow;
			_setInsetAction = setInsetAction;
			KeyboardObserver.KeyboardWillShow += OnKeyboardShown;
			KeyboardObserver.KeyboardWillHide += OnKeyboardHidden;
		}

		public void Dispose()
		{
			if (_disposed)
				return;

			_disposed = true;

			KeyboardObserver.KeyboardWillShow -= OnKeyboardShown;
			KeyboardObserver.KeyboardWillHide -= OnKeyboardHidden;
		}

		//This method allows us to update the insets if the Frame changes
		internal void UpdateInsets()
		{
			//being called from LayoutSubviews but keyboard wasn't shown yet
			if (_lastKeyboardRect.IsEmpty)
				return;

			var window = _fetchWindow();
			// Code left verbose to make its operation more obvious
			if (window == null)
			{
				// we are not currently displayed and can safely ignore this
				// most likely this renderer is on a page which is currently not displayed (e.g. in NavController)
				return;
			}

			var field = _targetView.FindFirstResponder();

			//the view that is triggering the keyboard is not inside our UITableView?
			//if (field == null)
			//	return;

			var boundsSize = _targetView.Frame.Size;

			//since our keyboard frame is RVC CoordinateSpace, lets convert it to our targetView CoordinateSpace
			var rect = _targetView.Superview.ConvertRectFromView(_lastKeyboardRect, null);
			//let's see how much does it cover our target view
			var overlay = RectangleF.Intersect(rect, _targetView.Frame);

			_currentInset = _targetView.ContentInset;
			_setInsetAction(new UIEdgeInsets(0, 0, overlay.Height, 0));

			if (field is UITextView && _setContentOffset != null)
			{
				var keyboardTop = boundsSize.Height - overlay.Height;
				var fieldPosition = field.ConvertPointToView(field.Frame.Location, _targetView.Superview);
				var fieldBottom = fieldPosition.Y + field.Frame.Height;
				var offset = fieldBottom - keyboardTop;
				if (offset > 0)
					_setContentOffset(new PointF(0, offset));
			}
		}

		void OnKeyboardHidden(object sender, UIKeyboardEventArgs args)
		{
			_setInsetAction(new UIEdgeInsets(0, 0, 0, 0));
			_lastKeyboardRect = RectangleF.Empty;
		}

		void OnKeyboardShown(object sender, UIKeyboardEventArgs args)
		{
			_lastKeyboardRect = args.FrameEnd;
			UpdateInsets();
		}
	}
}
