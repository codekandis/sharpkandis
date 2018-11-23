using System;
using System.IO;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents an exception if the GPG binary cannot be found.
	/// </summary>
	public class BinaryNotFoundException:
		FileNotFoundException
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public BinaryNotFoundException( )
			: base( )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		public BinaryNotFoundException( string message )
			: base( message )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="innerException">The inner exception of the exception.</param>
		public BinaryNotFoundException( string message, Exception innerException )
			: base( message, innerException )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="binaryPath">The path of the GPG binary.</param>
		public BinaryNotFoundException( string message, string binaryPath )
			: base( message, binaryPath )
		{
		}

		/// <summary>
		/// Constructor method. 
		/// </summary>
		/// <param name="message">The message of the exception.</param>
		/// <param name="binaryPath">The path of the GPG binary.</param>
		/// <param name="innerException">The inner exception of the exception.</param>
		public BinaryNotFoundException( string message, string binaryPath, Exception innerException )
			: base( message, binaryPath, innerException )
		{
		}
	}
}
