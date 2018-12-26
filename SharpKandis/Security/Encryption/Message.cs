namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents a message.
	/// </summary>
	public class Message:
		StringType,
		MessageInterface
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="value">The initial wrapped message.</param>
		public Message( string value )
			: base( value )
		{
		}
	}
}
