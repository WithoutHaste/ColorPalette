using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary> Error related to the format of a file.</summary>
	public class FileFormatException : Exception
	{
		/// <summary></summary>
		public FileFormatException(string message) : base(message)
		{
		}
	}
}
