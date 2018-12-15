using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>
	/// An ordered list of colors.
	/// </summary>
	public class ColorPalette
    {
		private List<Color> colors = new List<Color>();
		/// <summary>Colors in palette.</summary>
		public Color[] Colors {
			get {
				return colors.ToArray();
			}
		}
		/// <summary>Length of palette.</summary>
		public int Count {
			get {
				return colors.Count;
			}
		}

		/// <summary>Initialize empty palette.</summary>
		public ColorPalette()
		{
		}

		/// <summary>Initialize palette with <paramref name='colors'/>.</summary>
		public ColorPalette(params Color[] colors)
		{
			this.colors = new List<Color>(colors);
		}

		/// <summary>Initialize palette with <paramref name='colors'/>.</summary>
		public ColorPalette(List<Color> colors)
		{
			this.colors = new List<Color>(colors);
		}

		/// <summary>
		/// Load a color palette from file. Supported file formats: .aco, .gpl, .pal.
		/// </summary>
		/// <exception cref='NotImplementedException'>Palette format not supported.</exception>
		public static ColorPalette Load(string fullFilename)
		{
			switch(Path.GetExtension(fullFilename).ToLower())
			{
				case ".aco":
					return FormatACO.Load(fullFilename);
				case ".gpl":
					return FormatGPL.Load(fullFilename);
				case ".pal":
					return FormatPAL.Load(fullFilename);
				default:
					throw new NotImplementedException("Palette format not supported.");
			}
		}

		/// <summary>
		/// Save a color palette to file. Supported file formats: .aco, .gpl, .pal.
		/// </summary>
		/// <exception cref='NotImplementedException'>Palette format not supported.</exception>
		public void Save(string fullFilename)
		{
			switch(Path.GetExtension(fullFilename).ToLower())
			{
				case ".aco":
					FormatACO.Save(fullFilename, this);
					break;
				case ".gpl":
					FormatGPL.Save(fullFilename, this);
					break;
				case ".pal":
					FormatPAL.Save(fullFilename, this);
					break;
				default:
					throw new NotImplementedException("Palette format not supported.");
			}
		}

		/// <summary>
		/// Add color to end of palette.
		/// </summary>
		/// <returns>Index of added color.</returns>
		public int Add(Color color)
		{
			colors.Add(color);
			return colors.Count - 1;
		}

		/// <summary>Insert color at a position in the palette.</summary>
		public void Insert(Color color, int index)
		{
			//todo what if index is below zero or way too high
			colors.Insert(index, color);
		}

		/// <summary>Remove all instances of color from the palette.</summary>
		public void Remove(Color color)
		{
			colors.RemoveAll((element => element == color));
		}

		/// <summary>Remove the color at a specific position in the palette.</summary>
		/// <exception cref="IndexOutOfRangeException">Index is too low or too high for palette.</exception>
		public void RemoveAt(int index)
		{
			if(index < 0 || index >= colors.Count)
				throw new IndexOutOfRangeException("Index out of range in color palette.");
			colors.RemoveAt(index);
		}

		/// <summary>Replace all instances of one color with another color.</summary>
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

		/// <summary>Replace the color at a specific position with another color.</summary>
		/// <exception cref="IndexOutOfRangeException">Index is too low or too high for palette.</exception>
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

		#region Low Level

		/// <duplicate cref="Equals(object)" />
		public static bool operator ==(ColorPalette a, ColorPalette b)
		{
			if(object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
				return true;
			if(object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
				return false;
			return a.Equals(b);
		}

		/// <duplicate cref="Equals(object)" />
		public static bool operator !=(ColorPalette a, ColorPalette b)
		{
			if(object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
				return false;
			if(object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
				return true;
			return !a.Equals(b);
		}

		/// <summary>
		/// Palettes are equal if they contain the same colors in the same order.
		/// Colors are compared by Alpha/Red/Blue/Green, not by Name.
		/// </summary>
		public override bool Equals(Object b)
		{
			if(!(b is ColorPalette))
				return false;
			if(object.ReferenceEquals(this, null) && object.ReferenceEquals(b, null))
				return true;
			if(object.ReferenceEquals(this, null) || object.ReferenceEquals(b, null))
				return false;

			ColorPalette other = (b as ColorPalette);
			if(this.colors.Count != other.colors.Count)
				return false;
			for(int i = 0; i < this.colors.Count; i++)
			{
				if(!ColorsMatch(this.colors[i], other.colors[i]))
					return false;
			}
			return true;
		}

		/// <summary></summary>
		public override int GetHashCode()
		{
			int hashCode = 0;
			foreach(Color color in colors)
			{
				hashCode = hashCode ^ color.GetHashCode();
			}
			return hashCode;
		}

		/// <summary>
		/// Returns true if both colors have the same Alpha/Red/Green/Blue values, 
		/// or if both colors are null.
		/// </summary>
		public static bool ColorsMatch(Color a, Color b)
		{
			if(object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null))
				return true;
			if(object.ReferenceEquals(a, null) || object.ReferenceEquals(b, null))
				return false;
			return (a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B);
		}

		#endregion
	}
}
