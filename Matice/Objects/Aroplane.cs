using ComputerGraphics2D;
using ComputerGraphics2D.Interfaces;
using System.Drawing;

namespace Matice.Objects
{
	public class Aroplane: IDrawable2D
	{
		private Vertex[] vertexBufferOrig;
		private Vertex[] vertexBuffer;
		private AbscissaIndices[] indexBuffer;

		public Aroplane()
		{
			vertexBufferOrig = new Vertex[]
				{
				new Vertex(-1,8),			// V1
				new Vertex(1,8),			// V2
				new Vertex(2,1),			// V3
				new Vertex(4,1),			// V4
				new Vertex(5,1),			// V5
				new Vertex(5,-1),			// V6
				new Vertex(4,-1),			// V7
				new Vertex(2,-1),			// V8
				new Vertex(1,-8),			// V9
				new Vertex(-1,-8),			// V10
				new Vertex(-2,-1),			// V11
				new Vertex(-5,-1),			// V12
				new Vertex(-5,-3),			// V13
				new Vertex(-6,-3),			// V14
				new Vertex(-6, 3),			// V15
				new Vertex(-5, 3),			// V16
				new Vertex(-5, 1),			// V17
				new Vertex(-2, 1)           // V18
				};

			vertexBuffer = vertexBufferOrig;

			indexBuffer = new AbscissaIndices[]
			{
				new AbscissaIndices(0,1),	//U1
				new AbscissaIndices(1,2),	//U2
				new AbscissaIndices(2,3),	//U3
				new AbscissaIndices(3,4),	//U4
				new AbscissaIndices(4,5),	//U5
				new AbscissaIndices(5,6),	//U6
				new AbscissaIndices(3,6),	//U7
				new AbscissaIndices(6,7),	//U8
				new AbscissaIndices(7,8),	//U9
				new AbscissaIndices(8,9),	//U10
				new AbscissaIndices(9,10),	//U11
				new AbscissaIndices(10,11),	//U12
				new AbscissaIndices(11,12),	//U13
				new AbscissaIndices(12,13),	//U14
				new AbscissaIndices(13,14),	//U15
				new AbscissaIndices(14,15),	//U16
				new AbscissaIndices(15,16),	//U17
				new AbscissaIndices(16,17),	//U18
				new AbscissaIndices(17,0),	//U19
			};
		}

		/// <summary>
		/// Apply transformation matrices
		/// </summary>
		public void ApplyTransformations(Matrix3x3 t)
		{
			vertexBuffer = Math2DTools.ApplyTransform(ref vertexBufferOrig, t);
		}

		/// <summary>
		/// Draw
		/// </summary>
		/// <param name="g">Graphics object</param>
		public void Draw(Graphics g)
		{
			bool first = true;

			foreach (var abscissa in indexBuffer)
			{
				using (Pen p = new Pen(Color.Red, 2))
				{
					var pStart = Math2DTools.GetUV(vertexBuffer[abscissa.PointStartID]);
					var pEnd = Math2DTools.GetUV(vertexBuffer[abscissa.PointEndID]);

					if (first)
					{
						first = false;
						g.DrawLine(p, pStart, pEnd);
					}
					else
					{
						p.Color = Color.Black;
						g.DrawLine(p, pStart, pEnd);
					}
				}
			}
		}
	}
}
