using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.ColorPalette
{
	internal static class Utilities
	{
		public static Word[] BreakIntoWords(byte[] bytes)
		{
			List<Word> words = new List<Word>();
			for(int i=0; i<bytes.Length-1; i+=2)
			{
				words.Add(new Word(bytes[i], bytes[i+1]));
			}
			return words.ToArray();
		}

		/// <param name="red">Range [0, 255]</param>
		/// <param name="green">Range [0, 255]</param>
		/// <param name="blue">Range [0, 255]</param>
		public static Color ColorFromRGB(int red, int green, int blue)
		{
			if(red < 0 || red > 255) throw new ArgumentException(ErrorMessages.RedOutOfRange, new Exception("Red: " + red));
			if(green < 0 || green > 255) throw new ArgumentException(ErrorMessages.GreenOutOfRange, new Exception("Green: " + green));
			if(blue < 0 || blue > 255) throw new ArgumentException(ErrorMessages.BlueOutOfRange, new Exception("Blue: " + blue));
			return Color.FromArgb(1, red, green, blue);
		}

		/// <param name="hue">Range [0, 360)</param>
		/// <param name="saturation">Range [0, 1]</param>
		/// <param name="value">Range [0, 1]</param>
		public static Color ColorFromHSV(float hue, float saturation, float value)
		{
			if(hue < 0 || hue >= 360) throw new ArgumentException(ErrorMessages.HueOutOfRange, new Exception("Hue: " + hue));
			if(saturation < 0 || saturation > 1) throw new ArgumentException(ErrorMessages.SaturationOutOfRange, new Exception("Saturation: " + saturation));
			if(value < 0 || value > 1) throw new ArgumentException(ErrorMessages.ValueOutOfRange, new Exception("Value: " + value));

			float c = value * saturation;
			float x = c * (1 - Math.Abs((hue / 60) % 2 - 1));
			float m = value - c;
			float rPrime = 0;
			float gPrime = 0;
			float bPrime = 0;
			if(hue < 60)
			{
				rPrime = c;
				gPrime = x;
			}
			else if(hue < 120)
			{
				rPrime = x;
				gPrime = c;
			}
			else if(hue < 180)
			{
				gPrime = c;
				bPrime = x;
			}
			else if(hue < 240)
			{
				gPrime = x;
				bPrime = c;
			}
			else if(hue < 300)
			{
				rPrime = x;
				bPrime = c;
			}
			else
			{
				rPrime = c;
				bPrime = x;
			}
			int red = (int)(255 * (rPrime + m));
			int green = (int)(255 * (gPrime + m));
			int blue = (int)(255 * (bPrime + m));
			return ColorFromRGB(red, green, blue);
		}

		/// <param name="cyan">Range [0, 1]</param>
		/// <param name="magenta">Range [0, 1]</param>
		/// <param name="yellow">Range [0, 1]</param>
		/// <param name="black">Range [0, 1]</param>
		public static Color ColorFromCMYK(float cyan, float magenta, float yellow, float black)
		{
			if(cyan < 0 || cyan > 1) throw new ArgumentException(ErrorMessages.CyanOutOfRange, new Exception("Cyan: " + cyan));
			if(magenta < 0 || magenta > 1) throw new ArgumentException(ErrorMessages.MagentaOutOfRange, new Exception("Magenta: " + magenta));
			if(yellow < 0 || yellow > 1) throw new ArgumentException(ErrorMessages.YellowOutOfRange, new Exception("Yellow: " + yellow));
			if(black < 0 || black > 1) throw new ArgumentException(ErrorMessages.BlackOutOfRange, new Exception("Black: " + black));
			int red = (int)(255 * (1 - cyan) * (1 - black));
			int green = (int)(255 * (1 - magenta) * (1 - black));
			int blue = (int)(255 * (1 - yellow) * (1 - black));
			return ColorFromRGB(red, green, blue);
		}
	}
}
