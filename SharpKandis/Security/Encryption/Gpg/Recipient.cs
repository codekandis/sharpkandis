namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents the GPG user ID of the recipient of the message.
	/// </summary>
	public class Recipient:
		StringType
	{
		/// <summary>
		/// Conststructor method.
		/// </summary>
		/// <param name="value">The initial wrapped GPG user ID of the recipient of the message.</param>
		public Recipient( string value )
			: base( value )
		{
		}

		/// <summary>
		/// Defines the explicit type conversion from a `string` value to a `Recipient`.
		/// </summary>
		/// <param name="value">The `string` value to convert.</param>
		public static explicit operator Recipient( string value )
		{
			Recipient wrappedValueType = new Recipient( value );
			return wrappedValueType;
		}

		/// <summary>
		/// Defines the explicit type conversion from a `Recipient` to a `string` value.
		/// </summary>
		/// <param name="value">The `Recipient` to convert.</param>
		public static implicit operator string( Recipient wrappedValueType )
		{
			return wrappedValueType.Value;
		}
	}
}
