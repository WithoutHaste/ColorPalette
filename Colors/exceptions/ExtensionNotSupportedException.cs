using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>File extension is not supported.</summary>
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

		/// <summary></summary>
		public ExtensionNotSupportedException(string message, string extension, string supportedExtensions) : base(message)
		{
			Extension = extension;
			SupportedExtensions = supportedExtensions;
		}
	}
}
