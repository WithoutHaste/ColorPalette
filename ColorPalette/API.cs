using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	public static class API
	{
		public static ColorPalette LoadACO(string fullFilename)
		{
			return IO.LoadACO(fullFilename);
		}

		public static void SaveACO(string fullFilename, ColorPalette palette)
		{
			IO.SaveACO(fullFilename, palette);
		}
	}
}
