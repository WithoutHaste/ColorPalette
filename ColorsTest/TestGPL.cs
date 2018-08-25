using System;
using System.Drawing;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Drawing.Colors;

namespace ColorsTest
{
	[TestClass]
	public class TestGPL
	{
		[TestMethod]
		public void LoadGPL()
		{
			//arrange
			string filename = "../../../testData/Crayola.gpl";
			//act
			ColorPalette palette = FormatGPL.Load(filename);
			//assert
			Assert.AreEqual(128, palette.Colors.Length);
		}
	}
}
