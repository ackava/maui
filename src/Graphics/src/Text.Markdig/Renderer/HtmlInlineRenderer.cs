// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using Markdig.Syntax.Inlines;
using Microsoft.Maui.Graphics.Text;

namespace Microsoft.Maui.Graphics.Text.Renderer
{
	public class HtmlInlineRenderer : AttributedTextObjectRenderer<HtmlInline>
	{
		private Stack<SpanData> _spans = new Stack<SpanData>();

		protected override void Write(AttributedTextRenderer renderer, HtmlInline obj)
		{
			var tag = obj.Tag;
			if (tag.StartsWith("<span ", StringComparison.Ordinal)
				&& !tag.EndsWith("/>", StringComparison.Ordinal))
			{
				var styleIndex = tag.IndexOf("style", StringComparison.Ordinal);
				if (styleIndex >= 0)
				{
					var firstQuote = tag.IndexOf('"', styleIndex);
					if (firstQuote > styleIndex)
					{
						firstQuote += 1;
						var secondQuote = tag.IndexOf('"', firstQuote);
						if (secondQuote > firstQuote)
						{
							var style = tag.Substring(firstQuote, secondQuote - firstQuote);
							var start = renderer.Count;
							var spanData = new SpanData { Start = start, Style = style };
							_spans.Push(spanData);
						}
					}
				}
			}
			else if (tag.Equals("</span>", StringComparison.Ordinal))
			{
				if (_spans.Count > 0)
				{
					var span = _spans.Pop();
					var end = renderer.Count;
					var length = end - span.Start;

					var values = SimpleCssParser.Parse(span.Style);
					if (values != null)
					{
						var attributes = new TextAttributes();

						string color = null;
						if (values.TryGetValue("color", out color))
							attributes[TextAttribute.Color] = color;

						string background = null;
						if (values.TryGetValue("background", out background))
							attributes[TextAttribute.Background] = background;

						if (attributes.Count > 0)
							renderer.AddTextRun(span.Start, length, attributes);
					}
				}
			}
		}

		private class SpanData
		{
			public int Start { get; set; }
			public string Style { get; set; }
		}
	}
}
