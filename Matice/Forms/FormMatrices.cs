using ComputerGraphics2D.Curves;
using ComputerGraphics2D.Interfaces;
using Matice.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ComputerGraphics2D
{
	public partial class FormMatrices : Form
	{
		private float angleRotation = 0.0f;

		private List<IDrawable2D> drawableObjects; 
		private Aroplane aroplane;
		private BezierCubic bezierCubic;
		private BezierCurve bezierCurve; 

		Stopwatch stopWatch = new Stopwatch();
		
		public FormMatrices()
		{
			InitializeComponent();

			// ----------------------------------------------------------------------------- //
			// Bezier cubic
			// ----------------------------------------------------------------------------- //	
			bezierCubic = new BezierCubic(new Vertex(10, 10), new Vertex(90, 10), new Vertex(20, 90), new Vertex(80, 70));

			// ----------------------------------------------------------------------------- //
			// Bezier curve
			// ----------------------------------------------------------------------------- //	
			bezierCurve = new BezierCurve(new Vertex(20, 20), new Vertex(80, 20));
			bezierCurve.AddControlVertex(new Vertex(40, 20));
			bezierCurve.AddControlVertex(new Vertex(40, 40));
			bezierCurve.AddControlVertex(new Vertex(20, 40));
			bezierCurve.AddControlVertex(new Vertex(20, 80));
			bezierCurve.AddControlVertex(new Vertex(80, 80));

			// ----------------------------------------------------------------------------- //
			// Aroplane
			// ----------------------------------------------------------------------------- //	
			aroplane = new Aroplane();

			// start stopwatch
			stopWatch.Start();

			// set time interval for timer and enable it
			timer.Interval = 20;
			timer.Enabled = true; 
		}

		/// <summary>
		/// buttonRun_Click
		/// </summary>
		private void buttonRun_Click(object sender, EventArgs e)
		{
			Matrix3x3 s = new Matrix3x3();
			Matrix3x3 r = new Matrix3x3();
			Matrix3x3 t = new Matrix3x3();

			s.SetScale(2.5f, 5.0f);
			r.SetRotation(32.0f);
			t.SetTranslation(0.0f, 0.0f);

			richTextBoxText.AppendText(s.ToString());
			richTextBoxText.AppendText(r.ToString());
			richTextBoxText.AppendText(t.ToString());

			Matrix3x3 final = s * r;
			richTextBoxText.AppendText(final.ToString());
		}

		/// <summary>
		/// buttonClear_Click
		/// </summary>
		private void buttonClear_Click(object sender, EventArgs e)
		{
			richTextBoxText.Clear(); 
		}

		/// <summary>
		/// drawingPanel_Paint
		/// </summary>
		private void drawingPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.Clear(Color.White);

			// ----------------------------------------------------------------------------- //
			// Bezier curve
			// ----------------------------------------------------------------------------- //	
			//bezierCubic.Draw(g);

			// ----------------------------------------------------------------------------- //
			// Bezier curve vyssieho stupna
			// ----------------------------------------------------------------------------- //	
			bezierCurve.Draw(g);

			// ----------------------------------------------------------------------------- //
			// Aroplane
			// ----------------------------------------------------------------------------- //	
			//aroplane.ApplyTransformations(MoveObjectCircularMotion());
			//aroplane.Draw(g);
		}

		/// <summary>
		/// MoveObject
		/// </summary>
		private Matrix3x3 MoveObjectCircularMotion()
		{
			Matrix3x3 s = new Matrix3x3();
			s.SetScale(1.2f, 1f);

			Matrix3x3 r = new Matrix3x3();

			long duration = stopWatch.ElapsedMilliseconds;

			angleRotation = (float)duration / 1000 * 2 * (float)Math.PI / 5.0f;
			//richTextBoxText.AppendText(duration.ToString() + " ");

			r.SetRotation(angleRotation + (float)Math.PI/2.0f);

			Matrix3x3 t = new Matrix3x3();
			t.SetTranslation(30.0f * (float)Math.Cos(angleRotation) + 50.0f, 30.0f * (float)Math.Sin(angleRotation) + 50.0f);

			return s * r * t;
		}

		/// <summary>
		/// timer_Tick
		/// </summary>
		private void timer_Tick(object sender, EventArgs e)
		{
			drawingPanel.Invalidate(); 
		}

		/// <summary>
		/// drawingPanel_MouseDown
		/// </summary>
		private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
		{
			Vertex v = Math2DTools.GetXY(e.Location);
			int? index = bezierCurve.GetVertexIDByUV(e.Location);
			string indexString = "false";

			if (index != null)
				indexString = index.Value.ToString();

			richTextBoxText.AppendText("Mouse position: U=" + e.X.ToString() + "(X=" + v.X.ToString() + ")" +
										", V=" + e.Y.ToString() + "(Y=" + v.Y.ToString() + ")" + "Hit:" + indexString + "\r\n");
		}

		/// <summary>
		/// drawingPanel_MouseMove
		/// </summary>
		private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
		{

		}

		/// <summary>
		/// drawingPanel_MouseUp
		/// </summary>
		private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
		{

		}
	}
}
