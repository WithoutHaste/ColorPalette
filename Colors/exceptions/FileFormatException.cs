using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	public class FileFormatException : Exception
	{
		public FileFormatException(string message) : base(message)
		{
		}
	}
}
