using System.IO;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all decrypting actions.
	/// </summary>
	public interface DecryptingActionInterface
	{
		/// <summary>
		/// Decrypts an encrypted message.
		/// </summary>
		/// <param name="message">The encrypted message to decrypt.</param>
		/// <returns>The decrypted message.</returns>
		DecryptedMessageInterface Decrypt( EncryptedMessageInterface encryptedMessage );

		/// <summary>
		/// Decrypts a stream with an encrypted message.
		/// </summary>
		/// <param name="inputStream">The input stream with the encrypted message to decrypt.</param>
		/// <param name="outputStream">The output stream with the decrypted message.</param>
		void Decrypt( Stream inputStream, Stream outputStream );
	}
}
