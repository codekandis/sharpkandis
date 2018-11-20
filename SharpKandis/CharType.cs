namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `char` value type.
	/// </summary>
	public class CharType:
		WrappedValueTypeAbstract<char>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public CharType( char value )
			: base( value )
		{
		}
	}
}
