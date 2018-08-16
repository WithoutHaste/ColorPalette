using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	public class ACOColorSpaceException : ACOFormatException
	{
		public readonly int ColorSpace;

		public ACOColorSpaceException(string message, int colorSpace) : base(message)
		{
			ColorSpace = colorSpace;
		}
	}
}
