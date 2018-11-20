namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `decimal` value type.
	/// </summary>
	public class DecimalType:
		WrappedValueTypeAbstract<decimal>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public DecimalType( decimal value )
			: base( value )
		{
		}
	}
}
