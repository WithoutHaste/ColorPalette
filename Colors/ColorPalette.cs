using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
		/// Load a color palette from file. Supported file formats: .aco, .pal
		/// </summary>
		public static ColorPalette Load(string fullFilename)
		{
			switch(Path.GetExtension(fullFilename).ToLower())
			{
				case ".aco":
					return FormatACO.Load(fullFilename);
				case ".pal":
					return FormatPAL.Load(fullFilename);
				default:
					throw new NotImplementedException("Palette format not supported.");
			}
		}

		/// <summary>
		/// Save a color palette to file. Supported file formats: .aco, .pal
		/// </summary>
		public void Save(string fullFilename)
		{
			switch(Path.GetExtension(fullFilename).ToLower())
			{
				case ".aco":
					FormatACO.Save(fullFilename, this);
					break;
				case ".pal":
					FormatPAL.Save(fullFilename, this);
					break;
				default:
					throw new NotImplementedException("Palette format not supported.");
			}
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

		/// <summary>
		/// Remove all colors from palette.
		/// </summary>
		public void Clear()
		{
			colors.Clear();
		}
	}
}
