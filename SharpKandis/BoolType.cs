namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `bool` value type.
	/// </summary>
	public class BoolType:
		WrappedValueTypeAbstract<bool>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public BoolType( bool value )
			: base( value )
		{
		}
	}
}
