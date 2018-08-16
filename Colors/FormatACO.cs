using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>
	/// Photoshop *.aco color palette file format.
	/// </summary>
	public class FormatACO
	{
//		private static Rounding PHOTOSHOP_ROUNDING = Rounding.Down;

		private ColorPalette colorPalette;
		public ColorPalette ColorPalette { get { return colorPalette; } }

		private Word[] words;

		public FormatACO(byte[] bytes)
		{
			words = IO.BreakIntoWords(bytes).Select(word => word.ConvertBetweenBigEndianAndLittleEndian()).ToArray();
			int version = words[0].ToInt();
			int colorCount = words[1].ToInt();
			int index = 2;
			if(version == 1)
			{
				index = LoadVersion1(colorCount, index);
			}
			if(EndOfFile(index)) return;

			version = words[index].ToInt();
			index++;
			colorCount = words[index].ToInt();
			index++;
			if(version == 2)
			{
				index = LoadVersion2(colorCount, index);
			}

		}

		public static ColorPalette Load(string fullFilename)
		{
			IO.ValidateFilename(fullFilename, ".aco");
			byte[] fileBytes = File.ReadAllBytes(fullFilename);
			FormatACO aco = new FormatACO(fileBytes);
			return aco.ColorPalette;
		}

		public static void Save(string fullFilename, ColorPalette palette)
		{
			throw new NotImplementedException("Todo: save .aco file format.");
		}

		/// <summary>
		/// Load version 1 data.
		/// </summary>
		/// <param name="index">Starting words[index] after the color count.</param>
		/// <returns>Starting index of next section of the file.</returns>
		private int LoadVersion1(int colorCount, int index)
		{
			colorPalette = new ColorPalette();
			for(int i=0; i<colorCount; i++)
			{
				int colorSpace = (int)words[index].ToUInt();
				int w = (int)words[index+1].ToUInt();
				int x = (int)words[index+2].ToUInt();
				int y = (int)words[index+3].ToUInt();
				int z = (int)words[index+4].ToUInt();
				switch(colorSpace)
				{
					case 0: ConvertColorSpace0(w, x, y); break;
					case 1: ConvertColorSpace1(w, x, y); break;
					case 2: ConvertColorSpace2(w, x, y, z); break;
					case 7: throw new NotImplementedException("Todo: convert color space 7 in .aco format.");
					case 8: throw new NotImplementedException("Todo: convert color space 8 in .aco format.");
					case 9: throw new NotImplementedException("Todo: convert color space 9 in .aco format.");
					default: throw new ACOColorSpaceException("Unknown color space in .aco format.", colorSpace);
				}
				index += 5;
			}
			return index;
		}

		/// <summary>
		/// Load version 2 data.
		/// </summary>
		/// <param name="index">Starting words[index] after the color count.</param>
		/// <returns>Starting index of next section of the file.</returns>
		private int LoadVersion2(int colorCount, int index)
		{
			colorPalette = new ColorPalette();
			for(int i = 0; i < colorCount; i++)
			{
				int colorSpace = (int)words[index].ToUInt();
				int w = (int)words[index + 1].ToUInt();
				int x = (int)words[index + 2].ToUInt();
				int y = (int)words[index + 3].ToUInt();
				int z = (int)words[index + 4].ToUInt();
				switch(colorSpace)
				{
					case 0: ConvertColorSpace0(w, x, y); break;
					case 1: ConvertColorSpace1(w, x, y); break;
					case 2: ConvertColorSpace2(w, x, y, z); break;
					case 7: throw new NotImplementedException("Todo: convert color space 7 in .aco format.");
					case 8: throw new NotImplementedException("Todo: convert color space 8 in .aco format.");
					case 9: throw new NotImplementedException("Todo: convert color space 9 in .aco format.");
					default: throw new ACOColorSpaceException("Unknown color space in .aco format.", colorSpace);
				}
				index += 5;
				index++; //skip zero
				int nameLength = ((int)words[index].ToUInt()) - 1;
				index++; //skip nameLength
				index += nameLength; //skip name
				index++; //skip zero
			}
			return index;
		}

		private void ConvertColorSpace0(int w, int x, int y)
		{
			w = (int)Math.Floor((decimal)(w / 256));
			x = (int)Math.Floor((decimal)(x / 256));
			y = (int)Math.Floor((decimal)(y / 256));
			colorPalette.Add(ConvertColors.ColorFromRGB(w, x, y));
		}

		private void ConvertColorSpace1(int w, int x, int y)
		{
			w = (int)Math.Floor((decimal)(w / 182.04));
			x = (int)Math.Floor((decimal)(x / 655.35));
			y = (int)Math.Floor((decimal)(y / 655.35));
			colorPalette.Add(ConvertColors.ColorFromHSV(w, x / 100, y / 100));
		}

		private void ConvertColorSpace2(int w, int x, int y, int z)
		{
			w = (int)Math.Floor((decimal)((100 - w) / 655.35));
			x = (int)Math.Floor((decimal)((100 - x) / 655.35));
			y = (int)Math.Floor((decimal)((100 - y) / 655.35));
			z = (int)Math.Floor((decimal)((100 - z) / 655.35));
			colorPalette.Add(ConvertColors.ColorFromCMYK(w / 100, x / 100, y / 100, z / 100));
		}

		private bool EndOfFile(int index)
		{
			return (index >= words.Length);
		}
	}
}
