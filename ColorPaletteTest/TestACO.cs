using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Drawing.ColorPalette;

namespace ColorPaletteTest
{
	[TestClass]
	public class TestACO
	{
		[TestMethod]
		[ExpectedException(typeof(FileNotFoundException))]
		public void LoadACO_FileDoesNotExist_FileNotFoundException()
		{
			//arrange
			string filename = "not a filename.aco";
			//act
			API.LoadACO(filename);
			//assert exception
		}

		[TestMethod]
		[ExpectedException(typeof(ExtensionNotSupportedException))]
		public void LoadACO_FileWrongExtension_ExtensionNotSupportedException()
		{
			//arrange
			string filename = "../../TestACO.cs";
			//act
			API.LoadACO(filename);
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
