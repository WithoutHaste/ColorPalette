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
			{ Name.Black, new TestColor(Color.FromArgb(255, 0, 0, 0), new HSV(0, 0, 0), "#000000") },
			{ Name.White, new TestColor(Color.FromArgb(255, 255, 255, 255), new HSV(0, 0, 1), "#FFFFFF") },
			{ Name.Red, new TestColor(Color.FromArgb(255, 255, 0, 0), new HSV(0, 1, 1), "#FF0000") },
			{ Name.Green, new TestColor(Color.FromArgb(255, 0, 255, 0), new HSV(120, 1, 1), "#00FF00") },
			{ Name.Blue, new TestColor(Color.FromArgb(255, 0, 0, 255), new HSV(240, 1, 1), "#0000FF") },
			{ Name.Yellow, new TestColor(Color.FromArgb(255, 255, 255, 0), new HSV(60, 1, 1), "#FFFF00") },
			{ Name.Cyan, new TestColor(Color.FromArgb(255, 0, 255, 255), new HSV(180, 1, 1), "#00FFFF") },
			{ Name.Magenta, new TestColor(Color.FromArgb(255, 255, 0, 255), new HSV(300, 1, 1), "#FF00FF") },
			{ Name.Gray75, new TestColor(Color.FromArgb(255, 191, 191, 191), new HSV(0, 0, 0.75f), "#BFBFBF") },
			{ Name.Gray50, new TestColor(Color.FromArgb(255, 127, 127, 127), new HSV(0, 0, 0.50f), "#7F7F7F") },
			{ Name.Red50, new TestColor(Color.FromArgb(255, 127, 0, 0), new HSV(0, 1, 0.50f), "#7F0000") },
			{ Name.Yellow50, new TestColor(Color.FromArgb(255, 127, 127, 0), new HSV(60, 1, 0.50f), "#7F7F00") },
			{ Name.Green50, new TestColor(Color.FromArgb(255, 0, 127, 0), new HSV(120, 1, 0.50f), "#007F00") },
			{ Name.Magenta50, new TestColor(Color.FromArgb(255, 127, 0, 127), new HSV(300, 1, 0.50f), "#7F007F") },
			{ Name.Cyan50, new TestColor(Color.FromArgb(255, 0, 127, 127), new HSV(180, 1, 0.50f), "#007F7F") },
			{ Name.Blue50, new TestColor(Color.FromArgb(255, 0, 0, 127), new HSV(240, 1, 0.50f), "#00007F") },
			//todo not getting reliable hsv/rgb back and forth conversion on orange
			{ Name.Orange, new TestColor(Color.FromArgb(255, 255, 123, 0), new HSV(28, 1, 1), "#FF7B00") },
		};
	}
}
