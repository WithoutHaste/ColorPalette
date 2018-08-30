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
	/// GIMP *.gpl color palette file format.
	/// </summary>
	public class FormatGPL : IPaletteFormat
	{
		private ColorPalette colorPalette;
		/// <summary></summary>
		public ColorPalette ColorPalette { get { return colorPalette; } }

		/// <summary></summary>
		public string Header { get; protected set; }
		/// <summary></summary>
		public string Name { get; protected set; }

		/// <summary>Load color palette from file.</summary>
		/// <param name="fullFilename">Path + filename + extension.</param>
		public FormatGPL(string fullFilename)
		{
			colorPalette = new ColorPalette();
			IO.ValidateFilename(fullFilename, ".gpl");
			string[] fileLines = File.ReadAllLines(fullFilename);
			Load(fileLines);
		}

		private string[] RemoveComments(string[] fileLines)
		{
			return fileLines.Where(line => !(line.StartsWith("#"))).ToArray();
		}

		/// <summary>Load and return color palette from file.</summary>
		/// <param name="fullFilename">Path + filename + extension.</param>
		public static ColorPalette Load(string fullFilename)
		{
			FormatGPL gpl = new FormatGPL(fullFilename);
			return gpl.ColorPalette;
		}

		/// <summary>Save color palette in standard .gpl format</summary>
		/// <param name="fullFilename">Path + filename + extension.</param>
		public static void Save(string fullFilename, ColorPalette palette)
		{
			string[] fileLines = ConvertToFileLines(palette);
			File.WriteAllLines(fullFilename, fileLines);
		}

		/// <summary>Save color palette in standard .gpl format</summary>
		/// <param name="fullFilename">Path + filename + extension.</param>
		public void Save(string fullFilename)
		{
			Save(fullFilename, ColorPalette);
		}

		private void Load(string[] fileLines)
		{
			colorPalette.Clear();

			if(fileLines.Length <= 3)
				return;

			fileLines = RemoveComments(fileLines);

			colorPalette = new ColorPalette();
			Header = fileLines[0]; //GIMP Palette
			Name = fileLines[1]; //Name: name of palette
			string columns = fileLines[2];

			for(int i = 3; i < fileLines.Length; i++)
			{
				string line = fileLines[i].Replace('\t', ' ').Trim();
				while(line.IndexOf("  ") > -1)
				{
					line = line.Replace("  ", " ");
				}
				string[] fields = line.Split(' ');
				if(fields.Length < 3)
					continue; //just skip badly formatted lines
				int red;
				int green;
				int blue;
				if(!Int32.TryParse(fields[0].Trim(), out red))
					continue; //just skip badly formatted lines
				if(!Int32.TryParse(fields[1].Trim(), out green))
					continue; //just skip badly formatted lines
				if(!Int32.TryParse(fields[2].Trim(), out blue))
					continue; //just skip badly formatted lines
				colorPalette.Add(ConvertColors.RGBToColor(red, green, blue));
			}
		}

		private static string[] ConvertToFileLines(ColorPalette palette)
		{
			List<string> fileLines = new List<string>();
			fileLines.Add("GIMP Palette"); //header
			fileLines.Add("Name: "); //name
			fileLines.Add("Columns: 8"); //?
			foreach(Color color in palette.Colors)
			{
				fileLines.Add(String.Format("{0} {1} {2}", color.R.ToString().PadLeft(3), color.G.ToString().PadLeft(3), color.B.ToString().PadLeft(3)));
			}
			return fileLines.ToArray();
		}
	}
}
