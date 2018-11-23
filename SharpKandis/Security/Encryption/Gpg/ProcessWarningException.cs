using System;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an exception if a process warning of the GPG binary has been occured.
	/// </summary>
	public class ProcessWarningException:
		Exception
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public ProcessWarningException( )
			: base( )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		public ProcessWarningException( string message )
			: base( message )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="innerException">The inner exception of the exception.</param>
		public ProcessWarningException( string message, Exception innerException )
			: base( message, innerException )
		{
		}
	}
}
