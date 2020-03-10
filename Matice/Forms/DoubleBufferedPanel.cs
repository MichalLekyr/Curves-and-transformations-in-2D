using System.Windows.Forms;

namespace ComputerGraphics2D
{
	public class DoubleBufferedPanel : Panel
	{
		public DoubleBufferedPanel()
		{
			SetStyle(ControlStyles.AllPaintingInWmPaint | 
					 ControlStyles.OptimizedDoubleBuffer | 
					 ControlStyles.UserPaint, true);
		}
	}
}
