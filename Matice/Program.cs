using System;

using System.Windows.Forms;

namespace ComputerGraphics2D
{
	static class Program
	{
		public static Form MainForm; 

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			MainForm = new FormMatrices();

			Application.Run(MainForm);
		}
	}
}
