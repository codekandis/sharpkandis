using System.Text.RegularExpressions;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a process standard error output errors parser. 
	/// </summary>
	public class ProcessErrorsParser:
		ProcessStandardErrorOutputParserInterface
	{
		/// <summary>
		/// Parses a line of the process's standard error output.
		/// </summary>
		/// <param name="line">The line to parse.</param>
		public virtual void Parse( string line )
		{
			if ( true == Regex.IsMatch( line, @"^gpg: .+ failed: Bad passphrase$" ) )
			{
				throw new BadPassphraseException( "The passphrase of the user's GPG private key is bad." );
			}
			if ( true == Regex.IsMatch( line, @"^gpg: (.+): skipped: No public key$" ) ||
				 true == Regex.IsMatch( line, @"^gpg: error retrieving '(.+)' via WKD: No data$" ) )
			{
				throw new RecipientNotFoundException( "The recipient cannot be found in the key ring." );
			}
		}
	}
}
