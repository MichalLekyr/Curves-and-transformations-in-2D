using System;
using System.Drawing;

namespace ComputerGraphics2D
{
	public static class Math2DTools
	{
		public const float Xmax = 100.0f;
		public const float Ymax = 100.0f;

		public const int Umax = 599;
		public const int Vmax = 599;

		/// <summary>
		/// GetUV
		/// </summary>
		/// <param name="v">Vertex</param>
		/// <returns></returns>
		public static Point GetUV(Vertex v)
		{
			return new Point((int)Math.Round(v.X / Xmax * Umax), (int)Math.Round(Vmax-(v.Y / Ymax * Vmax)));
		}

		/// <summary>
		/// GetUV
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static Point GetUV(Vector1x3 v)
		{
			return new Point((int)Math.Round(v._11 / Xmax * Umax), (int)Math.Round(Vmax - (v._12 / Ymax * Vmax)));
		}

		/// <summary>
		/// GetUV
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public static PointF GetUVF(Vector1x3 v)
		{
			return new PointF(v._11 / Xmax * Umax, Vmax - (v._12 / Ymax * Vmax));
		}

		/// <summary>
		/// GetUV
		/// </summary>
		/// <param name="p">Point</param>
		/// <returns></returns>
		public static Point GetUV(Point p)
		{
			return new Point((int)Math.Round(p.X / Xmax * Umax), (int)Math.Round(Vmax - (p.Y / Ymax * Vmax)));
		}

		/// <summary>
		/// Get world coordinates X,Y from U,V
		/// </summary>
		/// <param name="p">U,V coordinates</param>
		/// <returns></returns>
		public static Vertex GetXY(Point p)
		{
			return new Vertex(p.X / (float)Umax * Xmax, Ymax - (p.Y / (float)Vmax * Ymax));
		}

		/// <summary>
		/// ApplyTransform
		/// </summary>
		/// <param name="vertexBufferOrig"></param>
		/// <param name="transformMatrix"></param>
		public static Vertex[] ApplyTransform(ref Vertex[] vertexBufferOrig, Matrix3x3 transformMatrix)
		{
			if (transformMatrix == null)
				throw new Exception("Matrix is null");

			if (vertexBufferOrig  == null)
				throw new Exception("Vertex buffer is null");

			Vertex[] retBuffer = new Vertex[vertexBufferOrig.Length];
			
			for (int i = 0; i < retBuffer.Length; i++)
			{
				var v = (new Vector1x3(vertexBufferOrig[i].X, vertexBufferOrig[i].Y) * transformMatrix);
				retBuffer[i] = new Vertex(v._11, v._12);
			}

			return retBuffer; 
		}
	}
}
