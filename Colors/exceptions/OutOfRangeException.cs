using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>
	/// I: Inclusion
	/// E: Exclusion
	/// Example IE: Minimum value included in range, Maximum value excluded from range.
	/// </summary>
	public enum RangeType { Invalid = 0, II, IE, EI, EE };

	public class OutOfRangeException<T> : ArgumentException
	{
		public readonly T Minimum;
		public readonly T Maximum;
		public readonly RangeType Type;
		/// <summary>
		/// Value that was out of range.
		/// </summary>
		public readonly T Value;

		public OutOfRangeException(string message, string paramName, T minimum, T maximum, RangeType type, T value) : base(message, paramName)
		{
			Minimum = minimum;
			Maximum = maximum;
			Type = type;
			Value = value;
		}
	}
}
