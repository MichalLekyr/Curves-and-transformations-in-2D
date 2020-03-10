namespace ComputerGraphics2D
{
    public class Vector1x3
    {
        public float _11;
        public float _12;
        public float _13;

		/// <summary>
		/// Vector3x1
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public Vector1x3(float x, float y)
        {
            _11 = x;
            _12 = y;
            _13 = 1;
        }

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string s = "Vector1x3:\r\n";
			s += string.Format("{0,10:0.0000}", _11, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _12, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _13, 4) + "\r\n";
			return s; 
		}
	}
}
