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
		internal static uint[] LoadBinaryMacFile(string fullFilename)
		{
			byte[] fileBytes = File.ReadAllBytes(fullFilename);
			return BreakIntoWords(fileBytes)
				.Select(word => word.ConvertBetweenBigEndianAndLittleEndian())
				.Select(word => word.ToUInt()).ToArray();
		}

		internal static Word[] BreakIntoWords(byte[] bytes)
		{
			List<Word> words = new List<Word>();
			for(int i = 0; i < bytes.Length - 1; i += 2)
			{
				words.Add(new Word(bytes[i], bytes[i + 1]));
			}
			return words.ToArray();
		}

		internal static byte[] BreakIntoBytes(Word[] words)
		{
			List<byte> bytes = new List<byte>();
			foreach(Word word in words)
			{
				bytes.Add(word.First);
				bytes.Add(word.Second);
			}
			return bytes.ToArray();
		}

		/// <param name="fullFilename"></param>
		/// <param name="expectedExtension">Include the dot</param>
		internal static void ValidateFilename(string fullFilename, string expectedExtension)
		{
			if(!File.Exists(fullFilename))
			{
				throw new FileNotFoundException("File not found.", fullFilename);
			}

			string extension = Path.GetExtension(fullFilename);
			if(extension.ToLower() != expectedExtension.ToLower())
			{
				throw new ExtensionNotSupportedException("File does not have "+expectedExtension+" extension.", extension, expectedExtension);
			}
		}
	}
}
