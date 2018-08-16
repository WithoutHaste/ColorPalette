using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WithoutHaste.Drawing.Colors;

namespace ColorsTest
{
	[TestClass]
	public class TestIO
	{
		[TestMethod]
		public void LoadBinaryMacFile()
		{
			//arrange
			string filename = "../../../testData/Bright-colors.aco";
			//act
			uint[] words = IO.LoadBinaryMacFile(filename);
			//assert - not a test - just viewing file data
		}
	}
}
