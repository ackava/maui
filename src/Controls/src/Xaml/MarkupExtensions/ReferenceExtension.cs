// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Controls.Internals;
using Microsoft.Maui.Controls.Xaml.Internals;

namespace Microsoft.Maui.Controls.Xaml
{
	[ContentProperty(nameof(Name))]
	public class ReferenceExtension : IMarkupExtension
	{
		public string Name { get; set; }

		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (serviceProvider == null)
				throw new ArgumentNullException(nameof(serviceProvider));
			var referenceProvider = serviceProvider.GetService<IReferenceProvider>();
			var value = referenceProvider?.FindByName(Name);
			if (value != null)
				return value;

			//fallback
			var valueProvider = serviceProvider.GetService<IProvideValueTarget>() as IProvideParentValues
								   ?? throw new ArgumentException("serviceProvider does not provide an IProvideValueTarget");
			foreach (var target in valueProvider.ParentObjects)
			{
				if (!(target is BindableObject bo))
					continue;
				if (!(NameScope.GetNameScope(bo) is INameScope ns))
					continue;
				value = ns.FindByName(Name);
				if (value != null)
					return value;
			}

			throw new XamlParseException($"Can not find the object referenced by `{Name}`", serviceProvider);
		}
	}
}
