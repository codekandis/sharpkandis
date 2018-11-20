namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `float` value type.
	/// </summary>
	public class FloatType:
		WrappedValueTypeAbstract<float>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public FloatType( float value )
			: base( value )
		{
		}
	}
}
