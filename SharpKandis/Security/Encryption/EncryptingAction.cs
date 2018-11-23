using System.IO;
using System.Text;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents an encrypting action.
	/// </summary>
	public class EncryptingAction:
		EncryptionProviderActionAbstract,
		EncryptingActionInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="encryptionProviderBuilder">The encryption provider builder of the underlying encryption provider.</param>
		public EncryptingAction( EncryptionProviderBuilderInterface encryptionProviderBuilder )
			: base( encryptionProviderBuilder )
		{
		}

		/// <summary>
		/// Encrypts a message.
		/// </summary>
		/// <param name="message">The message to encrypt.</param>
		/// <returns>The encrypted message.</returns>
		public virtual EncryptedMessageInterface Encrypt( MessageInterface message )
		{
			byte[ ] messageBytes = Encoding.UTF8.GetBytes( message.Value );
			using ( MemoryStream messageStream = new MemoryStream( messageBytes, false ) )
			using ( MemoryStream encryptedMessageStream = new MemoryStream( ) )
			{
				EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
				encryptionProvider.Encrypt( messageStream, encryptedMessageStream );
				byte[ ] encryptedMessageBytes = encryptedMessageStream.ToArray( );
				string encryptedMessageString = Encoding.UTF8.GetString( encryptedMessageBytes );
				return new EncryptedMessage( encryptedMessageString );
			}
		}

		/// <summary>
		/// Encrypts a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to encrypt.</param>
		/// <param name="outputStream">The output stream with the encrypted message.</param>
		public virtual void Encrypt( Stream inputStream, Stream outputStream )
		{
			EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
			encryptionProvider.Encrypt( inputStream, outputStream );
		}
	}
}
