namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `string` value type.
	/// </summary>
	public class StringType:
		WrappedValueTypeAbstract<string>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public StringType( string value )
			: base( value )
		{
		}
	}
}
