namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents an encrypted message.
	/// </summary>
	public class EncryptedMessage:
		StringType,
		EncryptedMessageInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped encrypted message.</param>
		public EncryptedMessage( string value )
			: base( value )
		{
		}
	}
}
