using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	internal static class IO
	{
		public static uint[] LoadBinaryMacFile(string fullFilename)
		{
			byte[] fileBytes = File.ReadAllBytes(fullFilename);
			return Utilities.BreakIntoWords(fileBytes)
				.Select(word => word.ConvertBetweenBigEndianAndLittleEndian())
				.Select(word => word.ToUInt()).ToArray();
		}

		public static ColorPalette LoadACO(string fullFilename)
		{
			if(!File.Exists(fullFilename))
			{
				throw new ArgumentException(ErrorMessages.FileNotFound);
			}

			if(Path.GetExtension(fullFilename) != ".aco")
			{
				throw new ArgumentException(ErrorMessages.FileWrongExtensionACO);
			}

			byte[] fileBytes = File.ReadAllBytes(fullFilename);
			FormatACO aco = new FormatACO(fileBytes);
			return aco.ColorPalette;
		}

		public static void SaveACO(string fullFilename, ColorPalette palette)
		{
		}
	}
}
