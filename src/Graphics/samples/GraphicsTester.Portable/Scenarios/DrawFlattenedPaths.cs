// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.Maui.Graphics;

namespace GraphicsTester.Scenarios
{
	public class DrawFlattenedPaths : AbstractScenario
	{
		private float flatness = 0f;

		public DrawFlattenedPaths() : base(720, 1024)
		{
		}

		public override void Draw(ICanvas canvas)
		{
			flatness = 0;
			DrawLineSegment(canvas);
			DrawQuadraticSegment(canvas);
			DrawCubicSegment(canvas);
			DrawArcSegment(canvas);
			DrawPie(canvas);
			DrawCubicAndQuad(canvas);
			DrawSubPaths(canvas);

			canvas.Translate(0, 200);
			flatness = 1;

			DrawLineSegment(canvas);
			DrawQuadraticSegment(canvas);
			DrawCubicSegment(canvas);
			DrawArcSegment(canvas);
			DrawPie(canvas);
			DrawCubicAndQuad(canvas);
			DrawSubPaths(canvas);

			canvas.Translate(0, 200);
			flatness = 2;

			DrawLineSegment(canvas);
			DrawQuadraticSegment(canvas);
			DrawCubicSegment(canvas);
			DrawArcSegment(canvas);
			DrawPie(canvas);
			DrawCubicAndQuad(canvas);
			DrawSubPaths(canvas);
		}

		private void DrawLineSegment(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(50.5f, 50.5f, 50, 50);
			var path = new PathF(50.5f, 50.5f);
			path.LineTo(100.5f, 100.5f);
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawQuadraticSegment(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(150.5f, 50.5f, 50, 50);
			var path = new PathF(150.5f, 50.5f);
			path.QuadTo(150.5f, 100.5f, 200.5f, 100.5f);
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawCubicSegment(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(250.5f, 50.5f, 50, 50);
			var path = new PathF(250.5f, 50.5f);
			path.CurveTo(250.5f, 100.5f, 300.5f, 50.5f, 300.5f, 100.5f);
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawArcSegment(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(350.5f, 50.5f, 50, 50);
			var path = new PathF();
			path.AddArc(350.5f, 50.5f, 400.5f, 100.5f, 45f, 135, false);
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawPie(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(350.5f, 150.5f, 50, 50);
			var path = new PathF();
			path.AddArc(350.5f, 150.5f, 400.5f, 200.5f, 45f, 135, false);
			path.LineTo(375.5f, 200.5f);
			path.Close();
			canvas.StrokeColor = Colors.Black;
			canvas.StrokeDashPattern = DOTTED;
			DrawPath(canvas, path);
			canvas.StrokeDashPattern = null;
		}

		private void DrawCubicAndQuad(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(250.5f, 150.5f, 50, 50);
			var path = new PathF(250.5f, 150.5f);
			path.CurveTo(250.5f, 200.5f, 300.5f, 150.5f, 300.5f, 200.5f);
			path.QuadTo(300.5f, 150.5f, 250.5f, 150.5f);
			path.Close();
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawSubPaths(ICanvas canvas)
		{
			canvas.StrokeColor = Colors.LightGrey;
			canvas.DrawRectangle(150.5f, 150.5f, 50, 50);
			var path = new PathF();
			path.AppendRectangle(175.5f, 150.5f, 25, 50);
			path.AppendEllipse(175.5f, 150.5f, 25, 50);
			canvas.StrokeColor = Colors.Black;
			DrawPath(canvas, path);
		}

		private void DrawPath(ICanvas canvas, PathF path)
		{
			if (flatness > 0)
				path = path.GetFlattenedPath(flatness, true);

			canvas.DrawPath(path);
		}
	}
}
