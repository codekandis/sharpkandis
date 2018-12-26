using System;
using System.IO;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all encryption providers.
	/// </summary>
	public interface EncryptionProviderInterface
	{
		/// <summary>
		/// Will be raised if a process error occures.
		/// </summary>
		event EventHandler<ProcessErrorEventArguments> ProcessError;

		/// <summary>
		/// Signs a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to sign.</param>
		/// <param name="signedMessageStream">The stream of the signed message.</param>
		void Sign( Stream messageStream, Stream signedMessageStream );

		/// <summary>
		/// Encrypts a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to encrypt.</param>
		/// <param name="encryptedMessageStream">The stream of the encrypted message.</param>
		void Encrypt( Stream messageStream, Stream encryptedMessageStream );

		/// <summary>
		/// Signs and encrypts a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to sign and encrypt.</param>
		/// <param name="encryptedMessageStream">The signed and encrypted message.</param>
		void SignAndEncrypt( Stream messageStream, Stream signedAndEncryptedMessageStream );

		/// <summary>
		/// Decrypts a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to decrypt.</param>
		/// <param name="decryptedMessageStream">The stream of the decrypted message.</param>
		void Decrypt( Stream encryptedMessageStream, Stream decryptedMessageStream );
	}
}
