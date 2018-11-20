namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `sbyte` value type.
	/// </summary>
	public class SByteType:
		WrappedValueTypeAbstract<sbyte>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public SByteType( sbyte value )
			: base( value )
		{
		}
	}
}
