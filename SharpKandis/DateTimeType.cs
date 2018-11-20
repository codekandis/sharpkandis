using System;

namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `DateTime` value type.
	/// </summary>
	public class DateTimeType:
		WrappedValueTypeAbstract<DateTime>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public DateTimeType( DateTime value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `DateTime` value to a `DateTimeType`.
		/// </summary>
		/// <param name="value">The `DateTime` value to convert.</param>
		public static explicit operator DateTimeType( DateTime value )
		{
			DateTimeType wrappedValueType = new DateTimeType( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from a `DateTimeType` to a `DateTime` value.
		/// </summary>
		/// <param name="value">The `DateTimeType` to convert.</param>
		public static implicit operator DateTime( DateTimeType wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
