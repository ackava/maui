// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using Microsoft.Maui.Controls.Core.UnitTests;
using NUnit.Framework;

namespace Microsoft.Maui.Controls.Xaml.UnitTests
{
	public class TargetPropertyExtension : IMarkupExtension
	{
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			var targetProperty = (serviceProvider?.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget)?.TargetProperty;
			return (targetProperty as BindableProperty)?.PropertyName ?? (targetProperty as PropertyInfo)?.Name;
		}
	}

	public partial class Bz53275 : ContentPage
	{
		public Bz53275()
		{
			InitializeComponent();
		}

		public Bz53275(bool useCompiledXaml)
		{
			//this stub will be replaced at compile time
		}

		public string ANonBindableProperty { get; set; }

		[TestFixture]
		class Tests
		{
			[TestCase(true)]
			[TestCase(false)]
			public void TargetPropertyIsSetOnMarkups(bool useCompiledXaml)
			{
				var page = new Bz53275(useCompiledXaml);
				Assert.AreEqual("ANonBindableProperty", page.ANonBindableProperty);
				var l0 = page.label;
				Assert.AreEqual("Text", l0.Text);
			}
		}
	}
}