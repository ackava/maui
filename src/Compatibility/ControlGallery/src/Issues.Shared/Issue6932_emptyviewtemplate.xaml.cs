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

using Microsoft.Maui.Controls.CustomAttributes;
using Microsoft.Maui.Controls.Internals;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
using Microsoft.Maui.Controls.Compatibility.UITests;
#endif

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if UITEST
	[Category(UITestCategories.Layout)]
#endif
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 6932, "EmptyView for BindableLayout (template)", PlatformAffected.All, issueTestNumber: 1)]
	public partial class Issue6932_emptyviewtemplate : TestContentPage
	{
		readonly Page6932ViewModel _viewModel = new Page6932ViewModel();

		public Issue6932_emptyviewtemplate()
		{
#if APP

			InitializeComponent();
			BindingContext = _viewModel;
#endif
		}

		protected override void Init()
		{

		}

#if UITEST
		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void EmptyViewTemplateBecomesVisibleWhenItemsSourceIsCleared()
		{
			RunningApp.Screenshot("Screen opens, items are shown");

			RunningApp.WaitForElement(_viewModel.LayoutAutomationId);
			RunningApp.Tap(_viewModel.ClearAutomationId);
			RunningApp.WaitForElement(_viewModel.EmptyTemplateAutomationId);

			RunningApp.Screenshot("Empty view is visible");
		}

		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void EmptyViewTemplateBecomesVisibleWhenItemsSourceIsEmptiedOneByOne()
		{
			RunningApp.Screenshot("Screen opens, items are shown");

			RunningApp.WaitForElement(_viewModel.LayoutAutomationId);

			for (var i = 0; i < _viewModel.ItemsSource.Count; i++)
				RunningApp.Tap(_viewModel.RemoveAutomationId);

			RunningApp.WaitForElement(_viewModel.EmptyTemplateAutomationId);

			RunningApp.Screenshot("Empty view is visible");
		}

		[Test]
		[Compatibility.UITests.FailsOnMauiIOS]
		public void EmptyViewTemplateHidesWhenItemsSourceIsFilled()
		{
			RunningApp.Screenshot("Screen opens, items are shown");

			RunningApp.WaitForElement(_viewModel.LayoutAutomationId);
			RunningApp.Tap(_viewModel.ClearAutomationId);
			RunningApp.WaitForElement(_viewModel.EmptyTemplateAutomationId);

			RunningApp.Screenshot("Items are cleared, empty view visible");

			RunningApp.Tap(_viewModel.AddAutomationId);
			RunningApp.WaitForNoElement(_viewModel.EmptyTemplateAutomationId);

			RunningApp.Screenshot("Item is added, empty view is not visible");
		}
#endif
	}
}