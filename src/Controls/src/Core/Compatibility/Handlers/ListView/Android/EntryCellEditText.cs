// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
using System;
using Android.Content;
using Android.Views;
using AndroidX.AppCompat.Widget;
using ARect = Android.Graphics.Rect;

namespace Microsoft.Maui.Controls.Handlers.Compatibility
{
	public sealed class EntryCellEditText : AppCompatEditText
	{
		SoftInput _startingMode;

		public EntryCellEditText(Context context) : base(context)
		{
		}

		public override bool OnKeyPreIme(Keycode keyCode, KeyEvent e)
		{
			if (keyCode == Keycode.Back && e.Action == KeyEventActions.Down)
			{
				EventHandler handler = BackButtonPressed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
			return base.OnKeyPreIme(keyCode, e);
		}

		protected override void OnFocusChanged(bool gainFocus, FocusSearchDirection direction, ARect previouslyFocusedRect)
		{
			var window = Context.GetActivity().Window;
			if (gainFocus)
			{
				_startingMode = window.Attributes.SoftInputMode;
				window.SetSoftInputMode(SoftInput.AdjustPan);
			}
			else
				window.SetSoftInputMode(_startingMode);

			base.OnFocusChanged(gainFocus, direction, previouslyFocusedRect);
		}

		internal event EventHandler BackButtonPressed;
	}
}