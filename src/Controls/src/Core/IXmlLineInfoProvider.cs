// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
using System.Xml;

namespace Microsoft.Maui.Controls.Xaml
{
	public interface IXmlLineInfoProvider
	{
		IXmlLineInfo XmlLineInfo { get; }
	}
}