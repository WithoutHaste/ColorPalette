using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Drawing.Colors;

namespace ColorsTest
{
	[TestClass]
	public class TestConvert
	{
		[TestMethod]
		public void ColorFromHSV_ColorLibrary()
		{
			foreach(ColorLibrary.Name name in ColorLibrary.Library.Keys)
			{
				//arrange
				TestColor testColor = ColorLibrary.Library[name];
				//act
				Color result = ConvertColors.ToColor(testColor.HSV);
				//assert
				Assert.AreEqual(testColor.Color.R, result.R);
				Assert.AreEqual(testColor.Color.G, result.G);
				Assert.AreEqual(testColor.Color.B, result.B);
			}
		}

		[TestMethod]
		public void HSVFromColor_ColorLibrary()
		{
			foreach(ColorLibrary.Name name in ColorLibrary.Library.Keys)
			{
				//arrange
				TestColor testColor = ColorLibrary.Library[name];
				//act
				HSV result = ConvertColors.ToHSV(testColor.Color);
				//assert
				Assert.AreEqual(testColor.HSV.Hue, result.Hue);
				Assert.AreEqual(testColor.HSV.Saturation, result.Saturation);
				Assert.AreEqual(testColor.HSV.Value, result.Value);
			}
		}

		[TestMethod]
		public void ColorFromHexadecimal_ColorLibrary()
		{
			foreach(ColorLibrary.Name name in ColorLibrary.Library.Keys)
			{
				//arrange
				TestColor testColor = ColorLibrary.Library[name];
				//act
				Color result = ConvertColors.HexadecimalToColor(testColor.Hexadecimal);
				//assert
				Assert.AreEqual(testColor.Color.R, result.R);
				Assert.AreEqual(testColor.Color.G, result.G);
				Assert.AreEqual(testColor.Color.B, result.B);
			}
		}

		[TestMethod]
		public void HexadecimalFromColor_ColorLibrary()
		{
			foreach(ColorLibrary.Name name in ColorLibrary.Library.Keys)
			{
				//arrange
				TestColor testColor = ColorLibrary.Library[name];
				//act
				string result = ConvertColors.ToHexadecimal(testColor.Color);
				//assert
				Assert.AreEqual(testColor.Hexadecimal, result);
			}
		}

		[TestMethod]
		public void TryParseRGB_255_255_25()
		{
			//arrange
			int red = 255;
			int green = 255;
			int blue = 25;
			string text = String.Format("{0},{1},{2}", red, green, blue);
			Color color = Color.Black;
			//act
			ConvertColors.TryParseRGB(text, out color);
			//assert
			Assert.AreEqual(red, color.R);
			Assert.AreEqual(green, color.G);
			Assert.AreEqual(blue, color.B);
		}
	}
}
