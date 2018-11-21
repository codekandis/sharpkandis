namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a signed message.
	/// </summary>
	public class SignedMessage:
		StringType,
		SignedMessageInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped signed message.</param>
		public SignedMessage( string value )
			: base( value )
		{
		}
	}
}
