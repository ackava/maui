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

namespace Microsoft.Maui.Controls.ControlGallery
{
	public static class GridExtension
	{
		public static void AddChild(this Grid grid, View view, int column, int row, int columnspan = 1, int rowspan = 1)
		{
			if (row < 0)
			{
				throw new ArgumentOutOfRangeException("row");
			}
			if (column < 0)
			{
				throw new ArgumentOutOfRangeException("column");
			}
			if (rowspan <= 0)
			{
				throw new ArgumentOutOfRangeException("rowspan");
			}
			if (columnspan <= 0)
			{
				throw new ArgumentOutOfRangeException("columnspan");
			}
			if (view == null)
			{
				throw new ArgumentNullException("view");
			}

			Grid.SetRow(view, row);
			Grid.SetRowSpan(view, rowspan);
			Grid.SetColumn(view, column);
			Grid.SetColumnSpan(view, columnspan);
			grid.Children.Add(view);
		}
	}
}
