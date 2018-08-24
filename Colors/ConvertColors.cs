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
		public static Color ColorFromRGB(int red, int green, int blue)
		{
			if(red < 0 || red > 255) throw new OutOfRangeException<int>("Red out of range.", "red", 0, 255, RangeType.II, red);
			if(green < 0 || green > 255) throw new OutOfRangeException<int>("Green out of range.", "green", 0, 255, RangeType.II, green);
			if(blue < 0 || blue > 255) throw new OutOfRangeException<int>("Blue out of range.", "blue", 0, 255, RangeType.II, blue);
			return Color.FromArgb(ALPHA_MAX, red, green, blue);
		}

		/// <param name="hue">Range [0, 360)</param>
		/// <param name="saturation">Range [0, 1]</param>
		/// <param name="value">Range [0, 1]</param>
		public static Color ColorFromHSV(float hue, float saturation, float value)
		{
			return ColorFromHSV(new HSV(hue, saturation, value));
		}

		public static Color ColorFromHSV(HSV hsv)
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
			int red = (int)(255 * (rPrime + m));
			int green = (int)(255 * (gPrime + m));
			int blue = (int)(255 * (bPrime + m));
			return ColorFromRGB(red, green, blue);
		}

		/// <summary>
		/// Converts RGB to HSV, ignoring Alpha
		/// </summary>
		public static HSV HSVFromColor(Color color)
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
		public static Color ColorFromCMYK(float cyan, float magenta, float yellow, float black)
		{
			if(cyan < 0 || cyan > 1) throw new OutOfRangeException<float>("Cyan out of range.", "cyan", 0, 1, RangeType.II, cyan);
			if(magenta < 0 || magenta > 1) throw new OutOfRangeException<float>("Magenta out of range.", "magenta", 0, 1, RangeType.II, magenta);
			if(yellow < 0 || yellow > 1) throw new OutOfRangeException<float>("Yellow out of range.", "yellow", 0, 1, RangeType.II, yellow);
			if(black < 0 || black > 1) throw new OutOfRangeException<float>("Black out of range.", "black", 0, 1, RangeType.II, black);
			int red = (int)(255 * (1 - cyan) * (1 - black));
			int green = (int)(255 * (1 - magenta) * (1 - black));
			int blue = (int)(255 * (1 - yellow) * (1 - black));
			return ColorFromRGB(red, green, blue);
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
