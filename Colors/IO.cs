using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
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
				throw new FileNotFoundException("File not found.", fullFilename);
			}

			string extension = Path.GetExtension(fullFilename);
			if(extension != ".aco")
			{
				throw new ExtensionNotSupportedException("File does not have .aco extension.", extension, ".aco");
			}

			byte[] fileBytes = File.ReadAllBytes(fullFilename);
			FormatACO aco = new FormatACO(fileBytes);
			return aco.ColorPalette;
		}

		public static void SaveACO(string fullFilename, ColorPalette palette)
		{
			throw new NotImplementedException("Todo: save .aco file format.");
		}
	}
}
