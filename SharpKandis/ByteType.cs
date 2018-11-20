namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `byte` value type.
	/// </summary>
	public class ByteType:
		WrappedValueTypeAbstract<byte>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public ByteType( byte value )
			: base( value )
		{
		}
	}
}
