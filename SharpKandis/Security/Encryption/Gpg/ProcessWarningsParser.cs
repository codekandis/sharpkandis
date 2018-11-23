using System.Text.RegularExpressions;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a process standard error output warnings parser. 
	/// </summary>
	public class ProcessWarningsParser:
		ProcessStandardErrorOutputParserInterface
	{
		/// <summary>
		/// Parses a line of the process's standard error output.
		/// </summary>
		/// <param name="line">The line to parse.</param>
		public virtual void Parse( string line )
		{
			Match match = Regex.Match( line, @"^gpg: WARNING: (.+)$" );
			if ( true == match.Success )
			{
				string exceptionMessage = match.Groups[ 1 ].Value;
				throw new ProcessWarningException( exceptionMessage );
			}
		}
	}
}
