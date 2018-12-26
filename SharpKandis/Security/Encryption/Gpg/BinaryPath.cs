namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a GPG binary path.
	/// </summary>
	public class BinaryPath:
		StringType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial wrapped GPG binary path.</param>
		public BinaryPath( string value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `string` value to a `BinaryPath`.
		/// </summary>
		/// <param name="value">The `string` value to convert.</param>
		public static explicit operator BinaryPath( string value )
		{
			BinaryPath wrappedValueType = new BinaryPath( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from a `BinaryPath` to a `string` value.
		/// </summary>
		/// <param name="value">The `BinaryPath` to convert.</param>
		public static implicit operator string( BinaryPath wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
