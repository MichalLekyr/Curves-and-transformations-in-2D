namespace ComputerGraphics2D
{
	class AbscissaIndices
	{
		public int PointStartID;
		public int PointEndID;

		/// <summary>
		/// AbscissaIndices
		/// </summary>
		public AbscissaIndices()
		{
			PointStartID = 0;
			PointEndID = 0;
		}

		/// <summary>
		/// AbscissaIndices
		/// </summary>
		/// <param name="pointStartID"></param>
		/// <param name="pointEndID"></param>
		public AbscissaIndices(int pointStartID, int pointEndID)
		{
			PointStartID = pointStartID;
			PointEndID = pointEndID; 
		}
	}
}
