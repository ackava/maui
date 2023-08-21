// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
namespace Microsoft.Maui.Controls
{
	static class PaddingElement
	{
		/// <summary>Bindable property for <see cref="IPaddingElement.Padding"/>.</summary>
		public static readonly BindableProperty PaddingProperty =
			BindableProperty.Create(nameof(IPaddingElement.Padding), typeof(Thickness), typeof(IPaddingElement), default(Thickness),
									propertyChanged: OnPaddingPropertyChanged,
									defaultValueCreator: PaddingDefaultValueCreator);

		static void OnPaddingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			((IPaddingElement)bindable).OnPaddingPropertyChanged((Thickness)oldValue, (Thickness)newValue);
		}

		static object PaddingDefaultValueCreator(BindableObject bindable)
		{
			return ((IPaddingElement)bindable).PaddingDefaultValueCreator();
		}

		/// <summary>Bindable property for attached property <c>PaddingLeft</c>.</summary>
		public static readonly BindableProperty PaddingLeftProperty =
			BindableProperty.Create("PaddingLeft", typeof(double), typeof(IPaddingElement), default(double),
									propertyChanged: OnPaddingLeftChanged);

		static void OnPaddingLeftChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var padding = (Thickness)bindable.GetValue(PaddingProperty);
			padding.Left = (double)newValue;
			bindable.SetValue(PaddingProperty, padding);
		}

		/// <summary>Bindable property for attached property <c>PaddingTop</c>.</summary>
		public static readonly BindableProperty PaddingTopProperty =
			BindableProperty.Create("PaddingTop", typeof(double), typeof(IPaddingElement), default(double),
									propertyChanged: OnPaddingTopChanged);

		static void OnPaddingTopChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var padding = (Thickness)bindable.GetValue(PaddingProperty);
			padding.Top = (double)newValue;
			bindable.SetValue(PaddingProperty, padding);
		}

		/// <summary>Bindable property for attached property <c>PaddingRight</c>.</summary>
		public static readonly BindableProperty PaddingRightProperty =
			BindableProperty.Create("PaddingRight", typeof(double), typeof(IPaddingElement), default(double),
									propertyChanged: OnPaddingRightChanged);

		static void OnPaddingRightChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var padding = (Thickness)bindable.GetValue(PaddingProperty);
			padding.Right = (double)newValue;
			bindable.SetValue(PaddingProperty, padding);
		}

		/// <summary>Bindable property for attached property <c>PaddingBottom</c>.</summary>
		public static readonly BindableProperty PaddingBottomProperty =
			BindableProperty.Create("PaddingBottom", typeof(double), typeof(IPaddingElement), default(double),
									propertyChanged: OnPaddingBottomChanged);

		static void OnPaddingBottomChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var padding = (Thickness)bindable.GetValue(PaddingProperty);
			padding.Bottom = (double)newValue;
			bindable.SetValue(PaddingProperty, padding);
		}
	}
}