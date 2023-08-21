// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Collections.Generic;

namespace Microsoft.Maui.Graphics.Text
{
	public class MutableAttributedText : AbstractAttributedText
	{
		private List<IAttributedTextRun> _runs;

		public MutableAttributedText(string text)
		{
			Text = text;
		}

		public override string Text { get; }

		public override IReadOnlyList<IAttributedTextRun> Runs => _runs;

		public void AddRun(IAttributedTextRun run)
		{
			if (_runs == null)
			{
				_runs = new List<IAttributedTextRun> { run };
				return;
			}

			_runs.Add(run);
			_runs = this.OptimizeRuns();
		}
	}
}
