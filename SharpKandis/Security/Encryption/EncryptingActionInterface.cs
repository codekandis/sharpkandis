using System.IO;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all encrypting actions.
	/// </summary>
	public interface EncryptingActionInterface
	{
		/// <summary>
		/// Encrypts a message.
		/// </summary>
		/// <param name="message">The message to encrypt.</param>
		/// <returns>The encrypted message.</returns>
		EncryptedMessageInterface Encrypt( MessageInterface message );

		/// <summary>
		/// Encrypts a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to encrypt.</param>
		/// <param name="outputStream">The output stream with the encrypted message.</param>
		void Encrypt( Stream inputStream, Stream outputStream );
	}
}
