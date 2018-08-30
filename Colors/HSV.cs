using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>
	/// Color represented as Hue, Saturation, Value.
	/// </summary>
	public struct HSV
	{
		/// <summary>
		/// Hue range [0, 360)
		/// </summary>
		public float Hue;
		/// <summary>
		/// Saturation range [0, 1]
		/// </summary>
		public float Saturation;
		/// <summary>
		/// Value range [0,1]
		/// </summary>
		public float Value;

		/// <summary></summary>
		/// <param name="hue">range [0, 360)</param>
		/// <param name="saturation">range [0, 1]</param>
		/// <param name="value">range [0,1]</param>
		public HSV(float hue, float saturation, float value)
		{
			if(hue < 0 || hue >= 360) throw new OutOfRangeException<float>("Hue out of range.", "hue", 0, 360, RangeType.IE, hue);
			if(saturation < 0 || saturation > 1) throw new OutOfRangeException<float>("Saturation out of range.", "saturation", 0, 1, RangeType.II, saturation);
			if(value < 0 || value > 1) throw new OutOfRangeException<float>("Value out of range.", "value", 0, 1, RangeType.II, value);

			Hue = hue;
			Saturation = saturation;
			Value = value;
		}

		/// <summary></summary>
		public override string ToString()
		{
			return String.Format("({0},{1},{2})", Hue, Saturation, Value);
		}
	}
}
