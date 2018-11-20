namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `short` value type.
	/// </summary>
	public class ShortType:
		WrappedValueTypeAbstract<short>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public ShortType( short value )
			: base( value )
		{
		}
	}
}
