namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents the interface of all process standard error output parsers.
	/// </summary>
	public interface ProcessStandardErrorOutputParserInterface
	{
		/// <summary>
		/// Parses a line of the process's standard error output.
		/// </summary>
		/// <param name="line">The line to parse.</param>
		void Parse( string line );
	}
}
