// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Controls.Core.UnitTests;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public class AccessModifiersControl : View
	{
		public static BindableProperty PublicFooProperty = BindableProperty.Create("PublicFoo",
			typeof(string),
			typeof(AccessModifiersControl),
			"");

		public string PublicFoo
		{
			get => (string)GetValue(PublicFooProperty);
			set => SetValue(PublicFooProperty, value);
		}

		internal static BindableProperty InternalBarProperty = BindableProperty.Create("InternalBar",
			typeof(string),
			typeof(AccessModifiersControl),
			"");

		public string InternalBar
		{
			get => (string)GetValue(InternalBarProperty);
			set => SetValue(InternalBarProperty, value);
		}
	}

	public partial class BindablePropertiesAccessModifiers : ContentPage
	{
		class Data
		{
			public string Foo => "Foo";
			public string Bar => "Bar";
		}

		public BindablePropertiesAccessModifiers()
		{
			InitializeComponent();
		}

		public BindablePropertiesAccessModifiers(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		[TestFixture]
		public class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void BindProperties(bool useCompiledXaml)
			{
				var page = new BindablePropertiesAccessModifiers(useCompiledXaml);
				page.BindingContext = new Data();
				Assert.AreEqual("Bar", page.AMC.GetValue(AccessModifiersControl.InternalBarProperty));
				Assert.AreEqual("Foo", page.AMC.GetValue(AccessModifiersControl.PublicFooProperty));
			}
		}
	}
}