namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `double` value type.
	/// </summary>
	public class DoubleType:
		WrappedValueTypeAbstract<double>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public DoubleType( double value )
			: base( value )
		{
		}
	}
}
