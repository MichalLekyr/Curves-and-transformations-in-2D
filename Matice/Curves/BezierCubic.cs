using ComputerGraphics2D.Interfaces;
using System.Drawing;

namespace ComputerGraphics2D.Curves
{
	public class BezierCubic: IDrawable2D
	{
		private BezierCurve bezierCurve;

		/// <summary>
		/// Constructors
		/// </summary>
		/// <param name="start">Starting point</param>
		/// <param name="end">End point</param>
		/// <param name="control1">Control point 1</param>
		/// <param name="control2">Control point 2</param>
		public BezierCubic(Vertex start, Vertex end, Vertex control1, Vertex control2)
		{
			bezierCurve = new BezierCurve();

			bezierCurve.SetStartVertex(start);
			bezierCurve.SetEndVertex(end);
			bezierCurve.AddControlVertex(control1);
			bezierCurve.AddControlVertex(control2);
		}

		/// <summary>
		/// Draw method
		/// </summary>
		/// <param name="g">Grahpics context</param>
		public void Draw(Graphics g)
		{
			bezierCurve.Draw(g);
		}
	}
}
