using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithoutHaste.Drawing.Colors
{
	/// <summary>
	/// Defines whether minimum and maximum values are included in the range.
	/// </summary>
	/// <remarks>
	/// I = Inclusive = Value included in range.
	/// E = Exclusive = Value excluded from range.
	/// </remarks>
	/// <example>IE: Minimum value included in range, Maximum value excluded from range.</example>
	public enum RangeType {
		/// <summary></summary>
		Invalid = 0,
		/// <summary>Min and max both included in range.</summary>
		II,
		/// <summary>Only min included in range.</summary>
		IE,
		/// <summary>Only max included in range.</summary>
		EI,
		/// <summary>Min and max not included in range.</summary>
		EE
	};

	/// <summary>Value was not in the expected range.</summary>
	public class OutOfRangeException<T> : ArgumentException
	{
		/// <summary>Range minimum.</summary>
		public readonly T Minimum;
		/// <summary>Range maximum.</summary>
		public readonly T Maximum;
		/// <summary>Type of range.</summary>
		public readonly RangeType Type;
		/// <summary>
		/// Value that was out of range.
		/// </summary>
		public readonly T Value;

		/// <summary></summary>
		public OutOfRangeException(string message, string paramName, T minimum, T maximum, RangeType type, T value) : base(message, paramName)
		{
			Minimum = minimum;
			Maximum = maximum;
			Type = type;
			Value = value;
		}
	}
}
