﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.Maui.Controls;

namespace Maui.Controls.Sample
{
	public class GenericValueConverter : IValueConverter
	{
		Func<object, object> _convert;
		Func<object, object> _back;
		public GenericValueConverter(Func<object, object> convert, Func<object, object> back = null)
		{
			_convert = convert;
			_back = back;
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return _convert(value);
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return _back(value);
		}
	}
}