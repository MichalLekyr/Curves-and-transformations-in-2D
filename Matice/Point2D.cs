using ComputerGraphics2D.Interfaces;
using System;
using System.Drawing;

namespace ComputerGraphics2D
{
	public class Point2D : IDrawable2D
	{
		public Vector1x3 position;

		/// <summary>
		/// Konstruktor
		/// </summary>
		public Point2D(Vector1x3 inPosition)
		{
			position = inPosition;
		}

		/// <summary>
		/// Draw
		/// </summary>
		public void Draw(Graphics g)
		{
			Point p = Math2DTools.GetUV(position);
			PointF pF = Math2DTools.GetUVF(position);

			float dX = Math.Abs(pF.X - (float)Math.Truncate(pF.X));
			float dY = Math.Abs(pF.Y - (float)Math.Truncate(pF.Y));

			using (SolidBrush brush = new SolidBrush(Color.FromArgb(0,0,0)))
			{
				// zakladny stredny bod
				g.FillRectangle(brush, new Rectangle(p.X, p.Y, 1, 1));

				// lavy horny bod
				int alpha = (int)((1-((1 - dX) * (1 - dY))) * 255);
				brush.Color = Color.FromArgb(alpha, alpha, alpha);
				g.FillRectangle(brush, new Rectangle(p.X-1, p.Y-1, 1, 1));
			}
		}

		/// <summary>
		/// Move
		/// </summary>
		public void Move(Matrix3x3 t)
		{
			position = position * t; 
		}
	}
}
