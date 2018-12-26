namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an ignore process warnings flag.
	/// </summary>
	public class IgnoreProcessWarnings:
		BoolType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial wrapped ignore process warnings flag.</param>
		public IgnoreProcessWarnings( bool value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `bool` value to an `IgnoreProcessWarnings`.
		/// </summary>
		/// <param name="value">The `bool` value to convert.</param>
		public static explicit operator IgnoreProcessWarnings( bool value )
		{
			IgnoreProcessWarnings wrappedValueType = new IgnoreProcessWarnings( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from an `IgnoreProcessWarnings` to a `bool` value.
		/// </summary>
		/// <param name="value">The `IgnoreProcessWarnings` to convert.</param>
		public static implicit operator bool( IgnoreProcessWarnings wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
