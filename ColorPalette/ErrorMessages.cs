using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	public static class ErrorMessages
	{
		public const string FileNotFound = "File not found.";
		public const string FileWrongExtensionACO = "File does not have .aco extension.";

		public const string ACOFormatColorSpace7NotSupported = "Color space 7 in .aco format not supported.";
		public const string ACOFormatColorSpace8NotSupported = "Color space 8 in .aco format not supported.";
		public const string ACOFormatColorSpace9NotSupported = "Color space 9 in .aco format not supported.";
		public const string ACOFormatColorSpaceUnknown = "Unknown color space in .aco format.";

		//public const string RoundingNoneInvalid = "None is an invalid Rounding selection for this function.";
		//public const string RoundingUnknownType = "Unknown rounding type specified.";

		public const string RedOutOfRange = "Red is out of [0, 255] range.";
		public const string GreenOutOfRange = "Green is out of [0, 255] range.";
		public const string BlueOutOfRange = "Blue is out of [0, 255] range.";
		public const string HueOutOfRange = "Hue is out of [0, 360) range.";
		public const string SaturationOutOfRange = "Saturation is out of [0, 1] range.";
		public const string ValueOutOfRange = "Value is out of [0, 1] range.";
		public const string CyanOutOfRange = "Cyan is out of [0, 1] range.";
		public const string MagentaOutOfRange = "Magenta is out of [0, 1] range.";
		public const string YellowOutOfRange = "Yellow is out of [0, 1] range.";
		public const string BlackOutOfRange = "Black is out of [0, 1] range.";
	}
}
