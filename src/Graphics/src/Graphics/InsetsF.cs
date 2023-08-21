// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Globalization;

namespace Microsoft.Maui.Graphics
{
	public class InsetsF
	{
		private float _bottom;
		private float _left;
		private float _right;
		private float _top;

		public InsetsF(float top, float left, float bottom, float right)
		{
			_top = top;
			_left = left;
			_bottom = bottom;
			_right = right;
		}

		public InsetsF(InsetsF insets) : this(insets.Top, insets.Left, insets.Bottom, insets.Right)
		{
		}

		public float Top
		{
			get => _top;
			set => _top = value;
		}

		public float Left
		{
			get => _left;
			set => _left = value;
		}

		public float Bottom
		{
			get => _bottom;
			set => _bottom = value;
		}

		public float Right
		{
			get => _right;
			set => _right = value;
		}

		/// <summary>
		/// The sum of the left and right insets.
		/// </summary>
		public float Horizontal => _left + _right;

		/// <summary>
		/// The sum of the top and bottom insets.
		/// </summary>
		public float Vertical => _top + _bottom;

		public bool AllValuesAreEqualTo(float value)
		{
			return Math.Abs(_top - value) < GeometryUtil.Epsilon && Math.Abs(_left - value) < GeometryUtil.Epsilon && Math.Abs(_right - value) < GeometryUtil.Epsilon &&
				   Math.Abs(_bottom - value) < GeometryUtil.Epsilon;
		}

		public override bool Equals(object obj)
		{
			if (obj is InsetsF vCompareTo)
			{
				return Math.Abs(vCompareTo.Top - Top) < GeometryUtil.Epsilon && Math.Abs(vCompareTo.Left - Left) < GeometryUtil.Epsilon && Math.Abs(vCompareTo.Bottom - Bottom) < GeometryUtil.Epsilon &&
					   Math.Abs(vCompareTo.Right - Right) < GeometryUtil.Epsilon;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return (int)_top ^ (int)_left + (int)_bottom ^ (int)_right;
		}

		public string ToParsableString()
		{
			return _top.ToString(CultureInfo.InvariantCulture) + "," + _left.ToString(CultureInfo.InvariantCulture) + "," + _bottom.ToString(CultureInfo.InvariantCulture) + "," +
				   _right.ToString(CultureInfo.InvariantCulture);
		}

		public override string ToString()
		{
			return $"[Insets: Top={_top}, Left={_left}, Bottom={_bottom}, Right={_right}]";
		}

		public static InsetsF Parse(string value)
		{
			try
			{
				var values = value.Split(',');
				float top = float.Parse(values[0], CultureInfo.InvariantCulture);
				float left = float.Parse(values[1], CultureInfo.InvariantCulture);
				float bottom = float.Parse(values[2], CultureInfo.InvariantCulture);
				float right = float.Parse(values[3], CultureInfo.InvariantCulture);
				return new InsetsF(top, left, bottom, right);
			}
			catch (Exception exc)
			{
				System.Diagnostics.Debug.WriteLine(exc);
				return new InsetsF(0, 0, 0, 0);
			}
		}
	}
}
