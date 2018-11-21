using System.IO;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all signing actions.
	/// </summary>
	public interface SigningActionInterface
	{
		/// <summary>
		/// Signs a message.
		/// </summary>
		/// <param name="message">The message to sign.</param>
		/// <returns>The signed message.</returns>
		SignedMessageInterface Sign( MessageInterface message );

		/// <summary>
		/// Signs a stream with a message.
		/// </summary>
		/// <param name="inputStream">The input stream with the message to sign.</param>
		/// <param name="outputStream">The output stream with the signed message.</param>
		void Sign( Stream inputStream, Stream outputStream );
	}
}
