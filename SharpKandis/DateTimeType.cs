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
	}
}
