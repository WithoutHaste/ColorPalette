using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>Error related to .aco file format.</summary>
	public class ACOFormatException : FileFormatException
	{
		/// <summary></summary>
		public ACOFormatException(string message) : base(message)
		{
		}
	}
}
