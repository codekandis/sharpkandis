using System.IO;
using System.Text;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a signing and ecrypting action.
	/// </summary>
	public class SigningAndEncryptingAction:
		EncryptionProviderActionAbstract,
		SigningAndEncryptingActionInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="encryptionProviderBuilder">The encryption provider builder of the underlying encryption provider.</param>
		public SigningAndEncryptingAction( EncryptionProviderBuilderInterface encryptionProviderBuilder )
			: base( encryptionProviderBuilder )
		{
		}

		/// <summary>
		/// Signs and encrypts a message.
		/// </summary>
		/// <param name="message">The message to sign and encrypt.</param>
		/// <returns>The signed and encrypted message.</returns>
		public virtual EncryptedMessageInterface SignAndEncrypt( MessageInterface message )
		{
			byte[ ] messageBytes = Encoding.UTF8.GetBytes( message.Value );
			using ( MemoryStream messageStream = new MemoryStream( messageBytes, false ) )
			using ( MemoryStream signedAndEncryptedMessageStream = new MemoryStream( ) )
			{
				EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
				encryptionProvider.Sign( messageStream, signedAndEncryptedMessageStream );
				byte[ ] signedAndEncryptedMessageBytes = signedAndEncryptedMessageStream.ToArray( );
				string signedAndEncryptedMessageString = Encoding.UTF8.GetString( signedAndEncryptedMessageBytes );
				return new EncryptedMessage( signedAndEncryptedMessageString );
			}
		}

		/// <summary>
		/// Signs end encrypts a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to sign and encrypt.</param>
		/// <param name="outputStream">The output stream with the signed and encrypted message.</param>
		public virtual void SignAndEncrypt( Stream inputStream, Stream outputStream )
		{
			EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
			encryptionProvider.SignAndEncrypt( inputStream, outputStream );
		}
	}
}
