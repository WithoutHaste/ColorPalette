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

		public int Count {
			get {
				return colors.Count;
			}
		}

		public ColorPalette()
		{
		}

		/// <summary>
		/// Add color to end of list.
		/// </summary>
		/// <returns>Index of added color.</returns>
		public int Add(Color color)
		{
			colors.Add(color);
			return colors.Count - 1;
		}

		public void Insert(Color color, int index)
		{
			colors.Insert(index, color);
		}

		public void Remove(Color color)
		{
			colors.Remove(color);
		}

		public void RemoveAt(int index)
		{
			if(index < 0 || index >= colors.Count)
				throw new IndexOutOfRangeException("Index out of range in color palette.");
			colors.RemoveAt(index);
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

		public void ReplaceAt(int index, Color newColor)
		{
			if(index < 0 || index >= colors.Count)
				throw new IndexOutOfRangeException("Index out of range in color palette.");
			colors[index] = newColor;
		}
	}
}
