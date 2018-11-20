namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `ulong` value type.
	/// </summary>
	public class ULongType:
		WrappedValueTypeAbstract<ulong>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public ULongType( ulong value )
			: base( value )
		{
		}
	}
}
