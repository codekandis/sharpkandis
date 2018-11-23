using System;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an exception if the recipient cannot be found in the key ring.
	/// </summary>
	public class RecipientNotFoundException:
		Exception
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public RecipientNotFoundException( )
			: base( )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		public RecipientNotFoundException( string message )
			: base( message )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="innerException">The inner exception of the exception.</param>
		public RecipientNotFoundException( string message, Exception innerException )
			: base( message, innerException )
		{
		}
	}
}
