using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithoutHaste.Drawing.Colors;

namespace ColorsTest
{
	public struct TestColor
	{
		public Color Color;
		public HSV HSV;
		public string Hexadecimal;

		public TestColor(Color color, HSV hsv, string hexadecimal)
		{
			Color = color;
			HSV = hsv;
			Hexadecimal = hexadecimal;
		}
	}
}
