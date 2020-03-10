using System.Collections.Generic;

namespace ComputerGraphics2D.Curves
{
	public static class DeCasteljau
	{
		/// <summary>
		/// Return point for the Decasteljau recursion
		/// </summary>
		/// <param name="r">Point index</param>
		/// <param name="i">Point index</param>
		/// <param name="t">Time parameter</param>
		/// <returns>Final point on a curve</returns>
		private static Vertex GetDeCasteljauPoint(ref List<Vertex> p, int r, int i, double t)
		{
			if (r == 0)
				return p[i];

			Vertex p1 = GetDeCasteljauPoint(ref p, r - 1, i, t);
			Vertex p2 = GetDeCasteljauPoint(ref p, r - 1, i + 1, t);

			return new Vertex((float)((1 - t) * p1.X + t * p2.X), (float)((1 - t) * p1.Y + t * p2.Y));
		}

		/// <summary>
		/// Returns final points for a curve
		/// </summary>
		/// <param name="inBaseControlPoints">Input control points</param>
		/// <param name="inTimeInterval">Time step</param>
		/// <returns>Point list of the final curve points</returns>
		public static List<Vertex> Points(List<Vertex> inBaseControlPoints, double inTimeInterval)
		{
			// check the time interval
			if (!(inTimeInterval > 0.0 && inTimeInterval <= 1.0))
				return null;

			// check points 
			if (inBaseControlPoints == null || inBaseControlPoints.Count < 4)
				return null;

			List <Vertex> resultPoints = new List<Vertex>(); 

			// get for each step new point
			for (double t = 0; t <= 1; t += inTimeInterval)
			{
				resultPoints.Add(GetDeCasteljauPoint(ref inBaseControlPoints, inBaseControlPoints.Count - 1, 0, t));
			}

			return resultPoints;
		}
	}
}
