using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	public class ACOFormatException : FileFormatException
	{
		public ACOFormatException(string message) : base(message)
		{
		}
	}
}
