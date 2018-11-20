namespace SharpKandis
{
	/// <summary>
	/// Represents the base class of all wrappe value types.
	/// </summary>
	/// <typeparam name="TWrappedValueType">Specifies the wrapped type.</typeparam>
	public abstract class WrappedValueTypeAbstract<TWrappedValueType>:
		WrappedValueTypeInterface<TWrappedValueType>
	{
		/// <summary>
		/// Stores the value of the wrapped value type.
		/// </summary>
		private TWrappedValueType value;

		/// <summary>
		/// Gets / sets the value of the wrapped value type.
		/// </summary>
		public virtual TWrappedValueType Value
		{
			get
			{
				return this.value;
			}
			private set
			{
				this.value = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped value.</param>
		public WrappedValueTypeAbstract( TWrappedValueType value )
		{
			this.Value = value;
		}
	}
}
