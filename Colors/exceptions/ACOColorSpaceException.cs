﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>Error related to .aco file format, and a specific color space.</summary>
	public class ACOColorSpaceException : ACOFormatException
	{
		/// <summary></summary>
		public readonly int ColorSpace;

		/// <summary></summary>
		public ACOColorSpaceException(string message, int colorSpace) : base(message)
		{
			ColorSpace = colorSpace;
		}
	}
}
