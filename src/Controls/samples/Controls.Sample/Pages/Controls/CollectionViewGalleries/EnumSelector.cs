﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample.Pages.CollectionViewGalleries
{
	internal class EnumSelector<T> : ContentView where T : struct
	{
		readonly Action<T> _setValue;

		readonly Picker _picker;

		public EnumSelector(Func<T> getValue, Action<T> setValue, string automationId = "")
		{
			_setValue = setValue;

			var layout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.Fill
			};

			var label = new Label { Text = $"{typeof(T).Name}:", VerticalTextAlignment = TextAlignment.Center };

			var source = Enum.GetNames(typeof(T));

			_picker = new Picker
			{
				WidthRequest = 200,
				ItemsSource = source,
				SelectedItem = getValue().ToString(),
				AutomationId = automationId
			};

			_picker.SelectedIndexChanged += PickerOnSelectedIndexChanged;

			layout.Children.Add(label);
			layout.Children.Add(_picker);

			Content = layout;
		}

		void PickerOnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (Enum.TryParse(_picker.SelectedItem.ToString(), true, out T enumValue))
			{
				_setValue(enumValue);
			}
		}
	}
}