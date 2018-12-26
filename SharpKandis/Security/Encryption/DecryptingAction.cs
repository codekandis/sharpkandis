using System.IO;
using System.Text;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a decrypting action.
	/// </summary>
	public class DecryptingAction:
		EncryptionProviderActionAbstract,
		DecryptingActionInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="encryptionProviderBuilder">The encryption provider builder of the underlying encryption provider.</param>
		public DecryptingAction( EncryptionProviderBuilderInterface encryptionProviderBuilder )
			: base( encryptionProviderBuilder )
		{
		}

		/// <summary>
		/// Decrypts a message.
		/// </summary>
		/// <param name="message">The message to decrypt.</param>
		/// <returns>The decrypted message.</returns>
		public virtual DecryptedMessageInterface Decrypt( EncryptedMessageInterface message )
		{
			byte[ ] messageBytes = Encoding.UTF8.GetBytes( message.Value );
			using ( MemoryStream messageStream = new MemoryStream( messageBytes, false ) )
			using ( MemoryStream decryptedMessageStream = new MemoryStream( ) )
			{
				EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
				encryptionProvider.Decrypt( messageStream, decryptedMessageStream );
				byte[ ] decryptedMessageBytes = decryptedMessageStream.ToArray( );
				string decryptedMessageString = Encoding.UTF8.GetString( decryptedMessageBytes );
				return new DecryptedMessage( decryptedMessageString );
			}
		}

		/// <summary>
		/// Decrypts a stream with an decrypted message.
		/// </summary>
		/// <param name="inputStream">The input stream with the decrypted message to decrypt.</param>
		/// <param name="outputStream">The output stream with the decrypted message.</param>
		public virtual void Decrypt( Stream inputStream, Stream outputStream )
		{
			EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
			encryptionProvider.Decrypt( inputStream, outputStream );
		}
	}
}
