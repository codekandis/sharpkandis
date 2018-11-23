namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an ignore process errors flag.
	/// </summary>
	public class IgnoreProcessErrors:
		BoolType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial wrapped ignore process errors flag.</param>
		public IgnoreProcessErrors( bool value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `bool` value to an `IgnoreProcessErrors`.
		/// </summary>
		/// <param name="value">The `bool` value to convert.</param>
		public static explicit operator IgnoreProcessErrors( bool value )
		{
			IgnoreProcessErrors wrappedValueType = new IgnoreProcessErrors( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from an `IgnoreProcessErrors` to a `bool` value.
		/// </summary>
		/// <param name="value">The `IgnoreProcessErrors` to convert.</param>
		public static implicit operator bool( IgnoreProcessErrors wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
