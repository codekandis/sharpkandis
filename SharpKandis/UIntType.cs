namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `uint` value type.
	/// </summary>
	public class UIntType:
		WrappedValueTypeAbstract<uint>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public UIntType( uint value )
			: base( value )
		{
		}
	}
}
