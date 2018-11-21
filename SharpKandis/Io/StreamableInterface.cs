using System.IO;

namespace SharpKandis.Io
{
	/// <summary>
	/// Represents the interface of all streamable classes.
	/// </summary>
	public interface StreamableInterface
	{
		/// <summary>
		/// Creates the stream of the object.
		/// </summary>
		/// <returns>The stream of the object.</returns>
		Stream ToStream( );
	}
}
