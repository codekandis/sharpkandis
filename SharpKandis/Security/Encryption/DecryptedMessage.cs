namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a decrypted message.
	/// </summary>
	public class DecryptedMessage:
		StringType,
		DecryptedMessageInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped decrypted message.</param>
		public DecryptedMessage( string value )
			: base( value )
		{
		}
	}
}
