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

using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml;

namespace Microsoft.Maui.Controls.ControlGallery.GalleryPages.SwipeViewGalleries
{
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Skip)]
	public partial class SwipeViewBindingContextGallery : ContentPage
	{
		public SwipeViewBindingContextGallery()
		{
			InitializeComponent();
		}
	}

	[Preserve(AllMembers = true)]
	public class SwipeViewBindingContextGalleryModel : BindableObject
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
	}

	[Preserve(AllMembers = true)]
	public class SwipeViewBindingContextGalleryViewModel : BindableObject
	{
		ObservableCollection<SwipeViewBindingContextGalleryModel> _items;
		SwipeViewBindingContextGalleryModel _tappedItem;

		public SwipeViewBindingContextGalleryViewModel()
		{
			Items = new ObservableCollection<SwipeViewBindingContextGalleryModel>();
			LoadItems();
		}

		public ObservableCollection<SwipeViewBindingContextGalleryModel> Items
		{
			get { return _items; }
			set
			{
				_items = value;
				OnPropertyChanged();
			}
		}

		public SwipeViewBindingContextGalleryModel TappedItem
		{
			get { return _tappedItem; }
			set
			{
				_tappedItem = value;
				OnPropertyChanged();
			}
		}

		public ICommand SwipeItemTapCommand => new Command<object>(SwipeItemTap);

		void LoadItems()
		{
			for (int i = 0; i < 100; i++)
			{
				Items.Add(new SwipeViewBindingContextGalleryModel
				{
					Title = $"Lorem ipsum {i + 1}",
					SubTitle = "Lorem ipsum dolor sit amet"
				});
			}
		}

		void SwipeItemTap(object parameter)
		{
			TappedItem = parameter as SwipeViewBindingContextGalleryModel;
		}
	}
}