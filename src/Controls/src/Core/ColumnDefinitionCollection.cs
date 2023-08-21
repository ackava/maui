// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#nullable disable
namespace Microsoft.Maui.Controls
{
	/// <include file="../../docs/Microsoft.Maui.Controls/ColumnDefinitionCollection.xml" path="Type[@FullName='Microsoft.Maui.Controls.ColumnDefinitionCollection']/Docs/*" />
	public sealed class ColumnDefinitionCollection : DefinitionCollection<ColumnDefinition>
	{
		public ColumnDefinitionCollection() : base()
		{
		}

		public ColumnDefinitionCollection(params ColumnDefinition[] definitions) : base(definitions)
		{
		}
	}
}
