using ComputerGraphics2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ComputerGraphics2D.Curves
{
	public class BezierCurve: IDrawable2D
	{
		//private Vertex startVertex;
		//private Vertex endVertex; 
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
		public BezierCurve(Vertex v1, Vertex v2): this()
		{
			controlPoints.Insert(0, v1);
			controlPoints.Add(v2);
		}

		/// <summary>
		/// Add start vertex
		/// </summary>
		/// <param name="v">Start vertex</param>
		public void SetStartVertex(Vertex v)
		{
			controlPoints.Insert(0, v);
		}

		/// <summary>
		/// Add end vertex
		/// </summary>
		/// <param name="v">End vertex</param>
		public void SetEndVertex(Vertex v)
		{
			controlPoints.Add(v); 
		}

		/// <summary>
		/// Add control vertex
		/// </summary>
		/// <param name="v">Control vertex</param>
		public void AddControlVertex(Vertex v)
		{
			if (controlPoints.Count < 2)
				throw new Exception("Cannot add control points without start and end point");

			controlPoints.Insert(controlPoints.Count-1, v); 
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
			for (int i = 0; i < controlPoints.Count; i++)
			{
				if (IsHitByUV(controlPoints[i], p))
					return i;
			}
			return null; 
		}

		/// <summary>
		/// Move
		/// </summary>
		/// <param name="p"></param>
		public void Move(Point p, int? vID)
		{
			if (vID == null)
				return;

			controlPoints[vID.Value] = Math2DTools.GetXY(p);
		}

		/// <summary>
		/// Draw method
		/// </summary>
		/// <param name="g">Grahpics context</param>
		public void Draw(Graphics g)
		{
			// draw the actual bezier curve points
			List<Vertex> bcp = DeCasteljau.Points(controlPoints, 0.01);

			if (bcp == null)
				return; 

			// draw interconnections between control points
			for (int i = 0; i < controlPoints.Count - 1; i++)
				g.DrawLine(Pens.Black, Math2DTools.GetUV(controlPoints[i]), Math2DTools.GetUV(controlPoints[i + 1]));

			// draw draw control points
			using (var f = new Font("Arial", 10))
			{
				Rectangle rect = new Rectangle(new Point(Math2DTools.GetUV(controlPoints[0]).X - 5, Math2DTools.GetUV(controlPoints[0]).Y - 5), new Size(10, 10));
				g.FillRectangle(Brushes.Green, rect);
				g.DrawRectangle(Pens.Black, rect);
				g.DrawString("V start", f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));

				rect = new Rectangle(new Point(Math2DTools.GetUV(controlPoints[controlPoints.Count - 1]).X - 5, Math2DTools.GetUV(controlPoints[controlPoints.Count - 1]).Y - 5), new Size(10, 10));
				g.FillRectangle(Brushes.Green, rect);
				g.DrawRectangle(Pens.Black, rect);
				g.DrawString("V end", f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));

				for (int i = 1; i < controlPoints.Count-1; i++)
				{
					rect = new Rectangle(new Point(Math2DTools.GetUV(controlPoints[i]).X - 5, Math2DTools.GetUV(controlPoints[i]).Y - 5), new Size(10, 10));
					g.FillRectangle(Brushes.DarkOrange, rect);
					g.DrawRectangle(Pens.Black, rect);
					g.DrawString("C" + i.ToString(), f, Brushes.Black, new Point(rect.X + 10, rect.Y + 10));
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
