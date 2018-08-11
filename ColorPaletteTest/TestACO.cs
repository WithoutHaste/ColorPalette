using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Drawing.ColorPalette;

namespace ColorPaletteTest
{
	[TestClass]
	public class TestACO
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void LoadACO_FileDoesNotExist_Exception()
		{
			//arrange
			string filename = "not a filename.aco";
			//act
			try
			{
				API.LoadACO(filename);
			}
			catch(ArgumentException exception)
			{
				Assert.AreEqual(ErrorMessages.FileNotFound, exception.Message);
				throw exception;
			}
			//assert exception
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void LoadACO_FileWrongExtension_Exception()
		{
			//arrange
			string filename = "../../TestACO.cs";
			//act
			try
			{
				API.LoadACO(filename);
			}
			catch(ArgumentException exception)
			{
				Assert.AreEqual(ErrorMessages.FileWrongExtensionACO, exception.Message);
				throw exception;
			}
			//assert exception
		}

		[TestMethod]
		public void LoadACO_Version2()
		{
			//arrange
			string filename = "../../../testData/Bright-colors.aco";
			//act
			ColorPalette palette = API.LoadACO(filename);
			//assert
			Assert.AreEqual(252, palette.Colors.Length);
		}

		[TestMethod]
		public void LoadACO_ColorSpace0()
		{
			//arrange
			string filename = "../../../testData/Bright-colors.aco";
			//act
			ColorPalette palette = API.LoadACO(filename);
			//assert
			Assert.AreEqual(252, palette.Colors.Length);
		}

		//[TestMethod]
		//public void SaveACO_Version2()
		//{
		//}
	}
}
