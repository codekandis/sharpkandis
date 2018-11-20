namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `int` value type.
	/// </summary>
	public class IntType:
		WrappedValueTypeAbstract<int>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public IntType( int value )
			: base( value )
		{
		}
	}
}
