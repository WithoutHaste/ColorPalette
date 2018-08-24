using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	public class ColorPalette
    {
		private List<Color> colors = new List<Color>();
		public Color[] Colors {
			get {
				return colors.ToArray();
			}
		}

		public ColorPalette()
		{
		}

		public void Add(Color color)
		{
			colors.Add(color);
		}

		public void Remove(Color color)
		{
			colors.Remove(color);
		}

		public void Replace(Color oldColor, Color newColor)
		{
			for(int i = 0; i < colors.Count; i++)
			{
				if(colors[i] == oldColor)
				{
					colors[i] = newColor;
				}
			}
		}
    }
}
