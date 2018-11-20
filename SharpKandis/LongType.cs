namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `long` value type.
	/// </summary>
	public class LongType:
		WrappedValueTypeAbstract<long>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public LongType( long value )
			: base( value )
		{
		}
	}
}
