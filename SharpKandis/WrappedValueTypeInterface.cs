namespace SharpKandis
{
	/// <summary>
	/// Represents the interface of all wrapped value types.
	/// </summary>
	/// <typeparam name="TWrappedValueType">Specifies the wrapped type.</typeparam>
	public interface WrappedValueTypeInterface<TWrappedValueType>
	{
		/// <summary>
		/// Gets the value of the wrapped value type.
		/// </summary>
		TWrappedValueType Value
		{
			get;
		}
	}
}
