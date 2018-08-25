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
		public ColorPalette ColorPalette { get { return colorPalette; } }

		public string Header { get; protected set; }
		public string Name { get; protected set; }

		public FormatGPL(string[] fileLines)
		{
			if(fileLines.Length <= 3)
				return;

			fileLines = RemoveComments(fileLines);

			colorPalette = new ColorPalette();
			Header = fileLines[0]; //GIMP Palette
			Name = fileLines[1]; //Name: name of palette
			string columns = fileLines[2];
			Load(fileLines);
		}

		private string[] RemoveComments(string[] fileLines)
		{
			return fileLines.Where(line => !(line.StartsWith("#"))).ToArray();
		}

		public static ColorPalette Load(string fullFilename)
		{
			IO.ValidateFilename(fullFilename, ".gpl");
			string[] lines = File.ReadAllLines(fullFilename);
			FormatGPL gpl = new FormatGPL(lines);
			return gpl.ColorPalette;
		}

		/// <summary>
		/// Save color palette in Version 0100 .pal format
		/// </summary>
		public static void Save(string fullFilename, ColorPalette palette)
		{
			string[] fileLines = Save(palette);
			File.WriteAllLines(fullFilename, fileLines);
		}

		private void Load(string[] fileLines)
		{
			colorPalette.Clear();
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
				colorPalette.Add(ConvertColors.ColorFromRGB(red, green, blue));
			}
		}

		private static string[] Save(ColorPalette palette)
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
