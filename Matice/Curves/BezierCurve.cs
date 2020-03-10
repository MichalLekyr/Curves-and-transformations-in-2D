using ComputerGraphics2D.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphics2D.Curves
{
	public class BezierCurve: IDrawable2D
	{
		private Vertex startVertex;
		private Vertex endVertex; 
		private List<Vertex> controlPoints;

		/// <summary>
		/// Constructor
		/// </summary>
		public BezierCurve()
		{
			controlPoints = new List<Vertex>(); 
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public BezierCurve(Vertex inStartVertex, Vertex inEndVertex): this()
		{
			startVertex = inStartVertex;
			endVertex = inEndVertex; 
		}

		/// <summary>
		/// Add start vertex
		/// </summary>
		/// <param name="v">Start vertex</param>
		public void SetStartVertex(Vertex v)
		{
			startVertex = v; 
		}

		/// <summary>
		/// Add end vertex
		/// </summary>
		/// <param name="v">End vertex</param>
		public void SetEndVertex(Vertex v)
		{
			endVertex = v; 
		}

		/// <summary>
		/// Add control vertex
		/// </summary>
		/// <param name="v">Control vertex</param>
		public void AddControlVertex(Vertex v)
		{
			controlPoints.Add(v);
		}

		/// <summary>
		/// Get bezier point list
		/// </summary>
		/// <returns>Point list of bezier control points</returns>
		private List<Vertex> GetBezierPointList()
		{
			List<Vertex> curve = new List<Vertex>();
			curve.Add(startVertex);

			foreach (Vertex p in controlPoints)
				curve.Add(p);

			curve.Add(endVertex);

			return curve; 
		}

		/// <summary>
		/// Is point hit by U, V coordinates
		/// </summary>
		/// <returns></returns>
		private bool IsHitByUV(Vertex v, Point p)
		{
			Point s = Math2DTools.GetUV(v);
			Rectangle r = new Rectangle(new Point(s.X - 5, s.Y - 5), new Size(10, 10));
			return r.Contains(p);
		}

		/// <summary>
		/// Get vertex ID by U, V coordinates
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public int? GetVertexIDByUV(Point p)
		{
			int? returnValue = null;
			var bcc = GetBezierPointList();

			for (int i = 0; i < bcc.Count; i++)
			{
				if (IsHitByUV(bcc[i], p))
					return i; 
			}

			return returnValue; 
		}

		/// <summary>
		/// Draw method
		/// </summary>
		/// <param name="g">Grahpics context</param>
		public void Draw(Graphics g)
		{
			// get bezier point control vertices
			var bcc = GetBezierPointList();

			// draw the actual bezier curve points
			List<Vertex> bcp = DeCasteljau.Points(bcc, 0.02);

			if (bcp == null)
				return; 

			// draw interconnections between control points
			for (int i = 0; i < bcc.Count - 1; i++)
				g.DrawLine(Pens.Black, Math2DTools.GetUV(bcc[i]), Math2DTools.GetUV(bcc[i + 1]));

			// draw draw control points
			using (var f = new Font("Arial", 10))
			{
				Rectangle rect = new Rectangle(new Point(Math2DTools.GetUV(startVertex).X - 5, Math2DTools.GetUV(startVertex).Y - 5), new Size(10, 10));
				g.FillRectangle(Brushes.Green, rect);
				g.DrawRectangle(Pens.Black, rect);
				g.DrawString("V start", f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));

				rect = new Rectangle(new Point(Math2DTools.GetUV(endVertex).X - 5, Math2DTools.GetUV(endVertex).Y - 5), new Size(10, 10));
				g.FillRectangle(Brushes.Green, rect);
				g.DrawRectangle(Pens.Black, rect);
				g.DrawString("V end", f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));

				int i = 1; 
				foreach (var p in controlPoints)
				{
					rect = new Rectangle(new Point(Math2DTools.GetUV(p).X - 5, Math2DTools.GetUV(p).Y - 5), new Size(10, 10));
					g.FillRectangle(Brushes.DarkOrange, rect);
					g.DrawRectangle(Pens.Black, rect);
					g.DrawString("C" + i++.ToString(), f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
				}
			}

			// draw red dots of points of bezier curve
			foreach(var p in bcp)
			{
				var transformedPoint = Math2DTools.GetUV(p);
				g.FillRectangle(Brushes.Red, new Rectangle(transformedPoint.X, transformedPoint.Y, 2, 2));
			}
		}
	}
}
