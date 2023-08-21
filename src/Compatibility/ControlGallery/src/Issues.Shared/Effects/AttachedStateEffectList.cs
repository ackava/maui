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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Internals;

namespace Microsoft.Maui.Controls.ControlGallery.Effects
{
	[Preserve(AllMembers = true)]
	public class AttachedStateEffectList : ObservableCollection<AttachedStateEffect>
	{
		public event EventHandler AllEventsAttached;
		public event EventHandler AllEventsDetached;

		public AttachedStateEffectList()
		{

		}

		public void Add(Element element)
		{
			var effect = new AttachedStateEffect(element);
			element.Effects.Add(effect);
			this.Add(effect);
		}

		protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			base.OnCollectionChanged(e);
			if (e.NewItems != null)
			{
				foreach (AttachedStateEffect item in e.NewItems)
				{
					item.StateChanged += AttachedStateEffectStateChanged;
				}
			}

			if (e.OldItems != null)
			{
				foreach (AttachedStateEffect item in e.OldItems)
				{
					item.StateChanged -= AttachedStateEffectStateChanged;
				}
			}
		}

		private async void AttachedStateEffectStateChanged(object sender, EventArgs e)
		{
			if (Count == 0)
				return;

			bool allAttached = true;
			bool allDetached = true;
			foreach (AttachedStateEffect item in this)
			{
				allAttached &= item.State == AttachedStateEffect.AttachedState.Attached;

				if (item.State != AttachedStateEffect.AttachedState.Unknown)
					allDetached &= item.State == AttachedStateEffect.AttachedState.Detached;
			}

			if (allAttached)
			{
				await Task.Delay(10);
				AllEventsAttached?.Invoke(this, EventArgs.Empty);
			}

			if (allDetached)
			{
				await Task.Delay(10);
				AllEventsDetached?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
