// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
namespace Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific
{
	using FormsElement = Maui.Controls.Page;

	/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/Page.xml" path="Type[@FullName='Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific.Page']/Docs/*" />
	public static class Page
	{
		#region BreadCrumbName
		/// <summary>Bindable property for attached property <c>BreadCrumb</c>.</summary>
		public static readonly BindableProperty BreadCrumbProperty
			= BindableProperty.CreateAttached("BreadCrumb", typeof(string), typeof(FormsElement), default(string));

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/Page.xml" path="//Member[@MemberName='GetBreadCrumb'][1]/Docs/*" />
		public static string GetBreadCrumb(BindableObject page)
		{
			return (string)page.GetValue(BreadCrumbProperty);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/Page.xml" path="//Member[@MemberName='SetBreadCrumb'][1]/Docs/*" />
		public static void SetBreadCrumb(BindableObject page, string value)
		{
			page.SetValue(BreadCrumbProperty, value);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/Page.xml" path="//Member[@MemberName='GetBreadCrumb'][2]/Docs/*" />
		public static string GetBreadCrumb(this IPlatformElementConfiguration<Tizen, FormsElement> config)
		{
			return GetBreadCrumb(config.Element);
		}

		/// <include file="../../../../docs/Microsoft.Maui.Controls.PlatformConfiguration.TizenSpecific/Page.xml" path="//Member[@MemberName='SetBreadCrumb'][2]/Docs/*" />
		public static IPlatformElementConfiguration<Tizen, FormsElement> SetBreadCrumb(this IPlatformElementConfiguration<Tizen, FormsElement> config, string value)
		{
			SetBreadCrumb(config.Element, value);
			return config;
		}
		#endregion
	}
}
