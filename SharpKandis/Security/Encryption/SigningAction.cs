using System.IO;
using System.Text;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a signing action.
	/// </summary>
	public class SigningAction:
		EncryptionProviderActionAbstract,
		SigningActionInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="encryptionProviderBuilder">The encryption provider builder of the underlying encryption provider.</param>
		public SigningAction( EncryptionProviderBuilderInterface encryptionProviderBuilder )
			: base( encryptionProviderBuilder )
		{
		}

		/// <summary>
		/// Signs a message.
		/// </summary>
		/// <param name="message">The message to sign.</param>
		/// <returns>The signed message.</returns>
		public virtual SignedMessageInterface Sign( MessageInterface message )
		{
			byte[ ] messageBytes = Encoding.UTF8.GetBytes( message.Value );
			using ( MemoryStream messageStream = new MemoryStream( messageBytes, false ) )
			using ( MemoryStream signedMessageStream = new MemoryStream( ) )
			{
				EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
				encryptionProvider.Sign( messageStream, signedMessageStream );
				byte[ ] signedMessageBytes = signedMessageStream.ToArray( );
				string signedMessageString = Encoding.UTF8.GetString( signedMessageBytes );
				return new SignedMessage( signedMessageString );
			}
		}

		/// <summary>
		/// Signs a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to sign.</param>
		/// <param name="outputStream">The output stream with the signed message.</param>
		public virtual void Sign( Stream inputStream, Stream outputStream )
		{
			EncryptionProviderInterface encryptionProvider = this.EncryptionProviderBuilder.BuildEncryptionProvider( );
			encryptionProvider.Sign( inputStream, outputStream );
		}
	}
}
