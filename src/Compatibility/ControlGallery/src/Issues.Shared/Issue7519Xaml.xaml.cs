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

using System.Collections.Generic;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml;

namespace Microsoft.Maui.Controls.ControlGallery.Issues
{
#if APP
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Issue7519Xaml : ContentPage
	{
		public Issue7519Xaml()
		{
			InitializeComponent();

			var items = new List<_7519ItemModel>()
			{
				new _7519ItemModel {Name = "Item 1"},
				new _7519ItemModel {Name = "Item 2"},
				new _7519ItemModel {Name = "Item 3"},
				new _7519ItemModel {Name = "Item 4"},
				new _7519ItemModel {Name = "Item 5"},
				new _7519ItemModel {Name = "Item 6"},
				new _7519ItemModel {Name = "Item 7"},
			};

			BindingContext = new _7519Model { Items = items };
		}
	}

	[Preserve(AllMembers = true)]
	public class _7519Model
	{
		public List<_7519ItemModel> Items { get; set; }
	}

	[Preserve(AllMembers = true)]
	public class _7519ItemModel
	{
		public string Name { get; set; }
	}

#endif
}