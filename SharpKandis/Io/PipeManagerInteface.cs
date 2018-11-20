using System.Collections.Generic;

namespace SharpKandis.Io
{
	/// <summary>Represents the interface of all pipe managers.</summary>
	public interface PipeManagerInterface
	{
		/// <summary>Gets the piped input from the standard input stream.</summary>
		/// <returns>The piped input from the standard input stream.</returns>
		IList<string> InputGet( );
	}
}
