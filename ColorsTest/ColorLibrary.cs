using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WithoutHaste.Drawing.Colors;

namespace ColorsTest
{
	public static class ColorLibrary
	{
		public enum Name { Black, White, Red, Green, Blue, Yellow, Cyan, Magenta, Gray75, Gray50,
		Red50, Yellow50, Green50, Magenta50, Cyan50, Blue50, Orange };

		public static readonly Dictionary<Name, TestColor> Library = new Dictionary<Name, TestColor>() {
			{ Name.Black, new TestColor(Color.FromArgb(255, 0, 0, 0), new HSV(0, 0, 0)) },
			{ Name.White, new TestColor(Color.FromArgb(255, 255, 255, 255), new HSV(0, 0, 1)) },
			{ Name.Red, new TestColor(Color.FromArgb(255, 255, 0, 0), new HSV(0, 1, 1)) },
			{ Name.Green, new TestColor(Color.FromArgb(255, 0, 255, 0), new HSV(120, 1, 1)) },
			{ Name.Blue, new TestColor(Color.FromArgb(255, 0, 0, 255), new HSV(240, 1, 1)) },
			{ Name.Yellow, new TestColor(Color.FromArgb(255, 255, 255, 0), new HSV(60, 1, 1)) },
			{ Name.Cyan, new TestColor(Color.FromArgb(255, 0, 255, 255), new HSV(180, 1, 1)) },
			{ Name.Magenta, new TestColor(Color.FromArgb(255, 255, 0, 255), new HSV(300, 1, 1)) },
			{ Name.Gray75, new TestColor(Color.FromArgb(255, 191, 191, 191), new HSV(0, 0, 0.75f)) },
			{ Name.Gray50, new TestColor(Color.FromArgb(255, 127, 127, 127), new HSV(0, 0, 0.50f)) },
			{ Name.Red50, new TestColor(Color.FromArgb(255, 127, 0, 0), new HSV(0, 1, 0.50f)) },
			{ Name.Yellow50, new TestColor(Color.FromArgb(255, 127, 127, 0), new HSV(60, 1, 0.50f)) },
			{ Name.Green50, new TestColor(Color.FromArgb(255, 0, 127, 0), new HSV(120, 1, 0.50f)) },
			{ Name.Magenta50, new TestColor(Color.FromArgb(255, 127, 0, 127), new HSV(300, 1, 0.50f)) },
			{ Name.Cyan50, new TestColor(Color.FromArgb(255, 0, 127, 127), new HSV(180, 1, 0.50f)) },
			{ Name.Blue50, new TestColor(Color.FromArgb(255, 0, 0, 127), new HSV(240, 1, 0.50f)) },
			{ Name.Orange, new TestColor(Color.FromArgb(255, 255, 123, 0), new HSV(29, 1, 1)) },
		};
	}
}
