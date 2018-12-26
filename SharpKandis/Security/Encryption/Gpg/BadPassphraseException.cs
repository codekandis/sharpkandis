using System;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an exception if the passphrase of the user's GPG private key is bad.
	/// </summary>
	public class BadPassphraseException:
		Exception
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public BadPassphraseException( )
			: base( )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		public BadPassphraseException( string message )
			: base( message )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="innerException">The inner exception of the exception.</param>
		public BadPassphraseException( string message, Exception innerException )
			: base( message, innerException )
		{
		}
	}
}
