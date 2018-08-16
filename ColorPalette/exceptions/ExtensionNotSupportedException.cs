using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	public class ExtensionNotSupportedException : IOException
	{
		/// <summary>
		/// The extension that is not supported.
		/// </summary>
		public readonly string Extension;
		/// <summary>
		/// Comma-delimited list of supported extensions.
		/// </summary>
		public readonly string SupportedExtensions;

		public ExtensionNotSupportedException(string message, string extension, string supportedExtensions) : base(message)
		{
			Extension = extension;
			SupportedExtensions = supportedExtensions;
		}
	}
}
