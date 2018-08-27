using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	public static class ConvertColors
	{
		internal const int ALPHA_MAX = 255;

		/// <param name="red">Range [0, 255]</param>
		/// <param name="green">Range [0, 255]</param>
		/// <param name="blue">Range [0, 255]</param>
		public static Color RGBToColor(int red, int green, int blue)
		{
			if(red < 0 || red > 255) throw new OutOfRangeException<int>("Red out of range.", "red", 0, 255, RangeType.II, red);
			if(green < 0 || green > 255) throw new OutOfRangeException<int>("Green out of range.", "green", 0, 255, RangeType.II, green);
			if(blue < 0 || blue > 255) throw new OutOfRangeException<int>("Blue out of range.", "blue", 0, 255, RangeType.II, blue);
			return Color.FromArgb(ALPHA_MAX, red, green, blue);
		}

		/// <param name="hue">Range [0, 360)</param>
		/// <param name="saturation">Range [0, 1]</param>
		/// <param name="value">Range [0, 1]</param>
		public static Color HSVToColor(float hue, float saturation, float value)
		{
			return ToColor(new HSV(hue, saturation, value));
		}

		public static Color ToColor(HSV hsv)
		{
			float c = hsv.Value * hsv.Saturation;
			float x = c * (1 - Math.Abs((hsv.Hue / 60) % 2 - 1));
			float m = hsv.Value - c;
			float rPrime = 0;
			float gPrime = 0;
			float bPrime = 0;
			if(hsv.Hue < 60)
			{
				rPrime = c;
				gPrime = x;
			}
			else if(hsv.Hue < 120)
			{
				rPrime = x;
				gPrime = c;
			}
			else if(hsv.Hue < 180)
			{
				gPrime = c;
				bPrime = x;
			}
			else if(hsv.Hue < 240)
			{
				gPrime = x;
				bPrime = c;
			}
			else if(hsv.Hue < 300)
			{
				rPrime = x;
				bPrime = c;
			}
			else
			{
				rPrime = c;
				bPrime = x;
			}
			int red = (int)Math.Round((255 * (rPrime + m)), 0, MidpointRounding.AwayFromZero);
			int green = (int)Math.Round((255 * (gPrime + m)), 0, MidpointRounding.AwayFromZero);
			int blue = (int)Math.Round((255 * (bPrime + m)), 0, MidpointRounding.AwayFromZero);
			return RGBToColor(red, green, blue);
		}

		/// <summary>
		/// Converts RGB to HSV, ignoring Alpha
		/// </summary>
		public static HSV ToHSV(Color color)
		{
			float rPrime = color.R / 255f;
			float gPrime = color.G / 255f;
			float bPrime = color.B / 255f;
			float cMax = Math.Max(Math.Max(rPrime, gPrime), bPrime);
			float cMin = Math.Min(Math.Min(rPrime, gPrime), bPrime);
			float delta = cMax - cMin;
			float hue = 0;
			if(delta == 0)
			{
				hue = 0;
			}
			else if(cMax == rPrime)
			{
				hue = 60 * PositiveMod((gPrime - bPrime) / delta, 6);
			}
			else if(cMax == gPrime)
			{
				hue = 60 * (((bPrime - rPrime) / delta) + 2);
			}
			else //cMax == bPrime
			{
				hue = 60 * (((rPrime - gPrime) / delta) + 4);
			}
			hue = (int)hue;
			float saturation = (cMax == 0) ? 0 : (delta / cMax);
			saturation = RoundTo2Decimals(saturation);
			float value = cMax;
			value = RoundTo2Decimals(value);
			return new HSV(hue, saturation, value);
		}

		/// <param name="cyan">Range [0, 1]</param>
		/// <param name="magenta">Range [0, 1]</param>
		/// <param name="yellow">Range [0, 1]</param>
		/// <param name="black">Range [0, 1]</param>
		public static Color CMYKToColor(float cyan, float magenta, float yellow, float black)
		{
			if(cyan < 0 || cyan > 1) throw new OutOfRangeException<float>("Cyan out of range.", "cyan", 0, 1, RangeType.II, cyan);
			if(magenta < 0 || magenta > 1) throw new OutOfRangeException<float>("Magenta out of range.", "magenta", 0, 1, RangeType.II, magenta);
			if(yellow < 0 || yellow > 1) throw new OutOfRangeException<float>("Yellow out of range.", "yellow", 0, 1, RangeType.II, yellow);
			if(black < 0 || black > 1) throw new OutOfRangeException<float>("Black out of range.", "black", 0, 1, RangeType.II, black);
			int red = (int)(255 * (1 - cyan) * (1 - black));
			int green = (int)(255 * (1 - magenta) * (1 - black));
			int blue = (int)(255 * (1 - yellow) * (1 - black));
			return RGBToColor(red, green, blue);
		}

		/// <returns>Format #RRGGBB</returns>
		public static string ToHexadecimal(Color color)
		{
			string red = color.R.ToString("X2");
			string green = color.G.ToString("X2");
			string blue = color.B.ToString("X2");
			return String.Format("#{0}{1}{2}", red, green, blue);
		}

		public static Color HexadecimalToColor(string hexadecimal)
		{
			if(hexadecimal.StartsWith("#"))
			{
				hexadecimal = hexadecimal.Substring(1);
			}
			if(hexadecimal.Length != 6)
				throw new ArgumentException("Hexadecimal format expected: RRGGBB or #RRGGBB"); //todo specific exception

			int red = Convert.ToInt32(hexadecimal.Substring(0, 2), 16);
			int green = Convert.ToInt32(hexadecimal.Substring(2, 2), 16);
			int blue = Convert.ToInt32(hexadecimal.Substring(4, 2), 16);
			return Color.FromArgb(ALPHA_MAX, red, green, blue);
		}

		/// <summary>
		/// Supported formats:
		///		#RRGGBB
		///		RRGGBB
		///	Returns true if parse is successful.
		public static bool TryParseHexadecimal(string text, out Color color)
		{
			try
			{
				color = HexadecimalToColor(text);
				return true;
			}
			catch(Exception)
			{
				color = System.Drawing.Color.Black;
				return false;
			}
		}

		/// <summary>
		/// Supported formats:
		///		rgb(R,G,B)
		///		(R,G,B)
		///		R,G,B
		///	Returns true if parse is successful.
		public static bool TryParseRGB(string text, out Color color)
		{
			try
			{
				text = text.ToLower();
				if(text.StartsWith("rgb"))
					text = text.Substring(3);
				text = text.Replace("(", "").Replace(")", "").Replace(" ", "");
				string[] fields = text.Split(',');
				color = RGBToColor(Int32.Parse(fields[0]), Int32.Parse(fields[1]), Int32.Parse(fields[2]));
				return true;
			}
			catch(Exception)
			{
				color = System.Drawing.Color.Black;
				return false;
			}
		}

		/// <summary>
		/// Supported formats:
		///		hsv(H,S,V)
		///		(H,S,V)
		///		H,S,V
		///	Returns true if parse is successful.
		public static bool TryParseHSV(string text, out Color color)
		{
			try
			{
				text = text.ToLower();
				if(text.StartsWith("hsv"))
					text = text.Substring(3);
				text = text.Replace("(", "").Replace(")", "").Replace(" ", "");
				string[] fields = text.Split(',');
				color = HSVToColor((float)Double.Parse(fields[0]), (float)Double.Parse(fields[1]), (float)Double.Parse(fields[2]));
				return true;
			}
			catch(Exception)
			{
				color = System.Drawing.Color.Black;
				return false;
			}
		}

		internal static int PositiveMod(int number, int modulus)
		{
			number = number % modulus;
			while(number < 0)
			{
				number += modulus;
			}
			return number;
		}

		internal static float PositiveMod(float number, int modulus)
		{
			while(number < 0)
			{
				number += modulus;
			}
			while(number >= modulus)
			{
				number -= modulus;
			}
			return number;
		}

		internal static float RoundTo2Decimals(float number)
		{
			return (float)(Math.Round((double)number, 2));
		}
	}
}
