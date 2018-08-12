using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithoutHaste.Drawing.ColorPalette;

namespace ColorPaletteTest
{
	public struct TestColor
	{
		public Color Color;
		public HSV HSV;

		public TestColor(Color color, HSV hsv)
		{
			Color = color;
			HSV = hsv;
		}
	}
}
