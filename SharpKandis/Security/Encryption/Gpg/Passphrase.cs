namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a passphrase of the users GPG private key.
	/// </summary>
	public class Passphrase:
		StringType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial passphrase of the users GPG private key.</param>
		public Passphrase( string value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `string` value to a `Passphrase`.
		/// </summary>
		/// <param name="value">The `string` value to convert.</param>
		public static explicit operator Passphrase( string value )
		{
			Passphrase wrappedValueType = new Passphrase( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from a `Passphrase` to a `string` value.
		/// </summary>
		/// <param name="value">The `Passphrase` to convert.</param>
		public static implicit operator string( Passphrase wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
