namespace SharpKandis
{
	/// <summary>
	/// Represents a wrapped `ushort` value type.
	/// </summary>
	public class UShortType:
		WrappedValueTypeAbstract<ushort>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public UShortType( ushort value )
			: base( value )
		{
		}
	}
}
