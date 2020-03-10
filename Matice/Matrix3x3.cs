using System;

namespace ComputerGraphics2D
{
    public class Matrix3x3
    {
        private float _11;
        private float _12;
        private float _13;
        private float _21;
        private float _22;
        private float _23;
        private float _31;
        private float _32;
        private float _33;

		/// <summary>
		/// Matrix3x3
		/// </summary>
		/// <param name="ln1"></param>
		/// <param name="ln2"></param>
		/// <param name="ln3"></param>
		public Matrix3x3(Vector1x3 ln1, Vector1x3 ln2, Vector1x3 ln3)
        {
            _11 = ln1._11;
            _21 = ln1._12;
            _31 = ln1._13;

            _12 = ln1._11;
            _22 = ln1._12;
            _32 = ln1._13;

            _13 = ln1._11;
            _23 = ln1._12;
            _33 = ln1._13;
        }

		/// <summary>
		/// Matrix3x3
		/// </summary>
		public Matrix3x3()
        {
            _11 = 1;
            _21 = 0;
            _31 = 0;

            _12 = 0;
            _22 = 1;
            _32 = 0;

            _13 = 0;
            _23 = 0;
            _33 = 1;
        }

		/// <summary>
		/// Matrix3x3
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Matrix3x3 operator *(Matrix3x3 a, Matrix3x3 b)
        {
            Matrix3x3 c = new Matrix3x3();
			
            c._11 = (a._11 * b._11 + a._12 * b._21 + a._13 * b._31);
            c._12 = (a._11 * b._12 + a._12 * b._22 + a._13 * b._32);
            c._13 = (a._11 * b._13 + a._12 * b._23 + a._13 * b._33);

            c._21 = (a._21 * b._11 + a._22 * b._21 + a._23 * b._31);
            c._22 = (a._21 * b._12 + a._22 * b._22 + a._23 * b._32);
            c._23 = (a._21 * b._13 + a._22 * b._23 + a._23 * b._33);

            c._31 = (a._31 * b._11 + a._32 * b._21 + a._33 * b._31);
            c._32 = (a._31 * b._12 + a._32 * b._22 + a._33 * b._32);
            c._33 = (a._31 * b._13 + a._32 * b._23 + a._33 * b._33);

            return c;
        }

		/// <summary>
		/// Vector3x1
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public static Vector1x3 operator *(Vector1x3 a, Matrix3x3 b)
        {
            Vector1x3 v = new Vector1x3(0, 0);

            v._11 = (a._11 * b._11 + a._12 * b._21 + a._13 * b._31);
            v._12 = (a._11 * b._12 + a._12 * b._22 + a._13 * b._32);
			v._13 = (a._11 * b._13 + a._12 * b._23 + a._13 * b._33); 

            return v;
        }

		/// <summary>
		/// SetTranslation
		/// </summary>
		/// <param name="dX"></param>
		/// <param name="dY"></param>
		/// <returns></returns>
		public void SetTranslation(float dX, float dY)
        {
            _31 = dX;
            _32 = dY;
        }

		/// <summary>
		/// SetRotation
		/// </summary>
		/// <param name="alpha">Rotation in degrees</param>
		/// <returns></returns>
		public void SetRotation(float rotationDegrees)
        {
			//float angleRadians = (float)(Math.PI * rotationDegrees / 180.0);
			float angleRadians = rotationDegrees;

			_11 = (float)Math.Cos(angleRadians);
            _21 = -(float)Math.Sin(angleRadians);
            _12 = (float)Math.Sin(angleRadians);
            _22 = (float)Math.Cos(angleRadians);
        }

		/// <summary>
		/// SetScale
		/// </summary>
		/// <param name="kX"></param>
		/// <param name="kY"></param>
		/// <returns></returns>
		public void SetScale(float kX, float kY)
        {
            _11 = kX;
            _22 = kY;
        }

		/// <summary>
		/// ToString
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
            string s = "Matrix3x3:\r\n";
			s += string.Format("{0,10:0.0000}", _11, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _12, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _13, 4) + "\r\n";
			s += string.Format("{0,10:0.0000}", _21, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _22, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _23, 4) + "\r\n";
			s += string.Format("{0,10:0.0000}", _31, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _32, 4) + "\t";
			s += string.Format("{0,10:0.0000}", _33, 4) + "\r\n";
			return s;
        }
    }
}
