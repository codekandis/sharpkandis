namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a GPG key ring path.
	/// </summary>
	public class KeyRingPath:
		StringType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial wrapped GPG key ring path.</param>
		public KeyRingPath( string value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `string` value to a `KeyRingPath`.
		/// </summary>
		/// <param name="value">The `string` value to convert.</param>
		public static explicit operator KeyRingPath( string value )
		{
			KeyRingPath wrappedValueType = new KeyRingPath( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from a `KeyRingPath` to a `string` value.
		/// </summary>
		/// <param name="value">The `KeyRingPath` to convert.</param>
		public static implicit operator string( KeyRingPath wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
