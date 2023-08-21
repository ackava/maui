﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Pages.SwipeViewGalleries
{
	public partial class SwipeItemViewPositionGallery : ContentPage
	{
		public SwipeItemViewPositionGallery()
		{
			InitializeComponent();
			ModePicker.SelectedIndex = 0;
		}

		void OnModePickerSelectedIndexChanged(object sender, EventArgs e)
		{
			LeftSwipeItems.Mode = TopSwipeItems.Mode = RightSwipeItems.Mode = BottomSwipeItems.Mode = ModePicker.SelectedIndex == 0 ? SwipeMode.Reveal : SwipeMode.Execute;
		}
	}
}