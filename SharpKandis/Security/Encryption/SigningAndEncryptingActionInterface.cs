using System.IO;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all signing and encrypting actions.
	/// </summary>
	public interface SigningAndEncryptingActionInterface
	{
		/// <summary>
		/// Signs and encrypts a message.
		/// </summary>
		/// <param name="message">The message to sign and encrypt.</param>
		/// <returns>The signed and encrypted message.</returns>
		EncryptedMessageInterface SignAndEncrypt( MessageInterface message );

		/// <summary>
		/// Signs and encrypts a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to sign and encrypt.</param>
		/// <param name="outputStream">The output stream with the signed and encrypted message.</param>
		void SignAndEncrypt( Stream inputStream, Stream outputStream );
	}
}
