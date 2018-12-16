using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	//todo: the meaning of FormatException does not match this use
	//but I don't want a dependency on WindowsBase.dll just for FileFormatException

	/// <summary>Error related to .aco file format.</summary>
	public class ACOFormatException : FormatException
	{
		/// <summary></summary>
		public ACOFormatException(string message) : base(message)
		{
		}
	}
}
