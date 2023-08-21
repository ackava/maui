// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Diagnostics;

namespace Microsoft.Maui.Controls.CustomAttributes
{
	[Conditional("DEBUG")]
	[AttributeUsage(
		AttributeTargets.Class |
		AttributeTargets.Event |
		AttributeTargets.Property |
		AttributeTargets.Method |
		AttributeTargets.Delegate,
		AllowMultiple = true
		)]
	public class UiTestAttribute : Attribute
	{
		public UiTestAttribute(Type formsType)
		{
			Type = formsType;
			MemberName = "";
		}

		public UiTestAttribute(Type formsType, string memberName)
		{
			Type = formsType;
			MemberName = memberName;
		}

		public Type Type { get; }

		public string MemberName { get; }
	}
}
