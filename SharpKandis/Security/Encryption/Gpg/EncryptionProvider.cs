using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a GPG encryption provider.
	/// </summary>
	public class EncryptionProvider:
		EncryptionProviderInterface
	{
		/// <summary>
		/// Stores the configuration of the GPG encryption provider.
		/// </summary>
		private EncryptionProviderConfigInterface config;

		/// <summary>
		/// Gets / sets the configuration of the GPG encryption provider.
		/// </summary>
		private EncryptionProviderConfigInterface Config
		{
			get
			{
				return this.config;
			}
			set
			{
				this.config = value;
			}
		}

		/// <summary>
		/// Will be raised if a process error occures.
		/// </summary>
		public virtual event EventHandler<ProcessErrorEventArguments> ProcessError =
			delegate
			{
			};

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="config">The configuration of the GPG encryption provider.</param>
		public EncryptionProvider( EncryptionProviderConfigInterface config )
		{
			this.Config = config;
			this.CheckBinary( );
		}

		/// <summary>
		/// Determines if the GPG binary exists.
		/// </summary>
		private void CheckBinary( )
		{
			if ( false == File.Exists( this.Config.BinaryPath ) )
			{
				throw new BinaryNotFoundException( "The GPG binary cannot not be found.", ( string ) this.Config.BinaryPath );
			}
		}

		/// <summary>
		/// Creates the arguments string necessary for the invocation of the GPG library.
		/// </summary>
		/// <param name="processArguments">The custom arguments for the specific process to invoke.</param>
		/// <returns>The arguments string necessary for the invocation of the GPG library.</returns>
		private string CreateInvocationArguments( string[ ] processArguments )
		{
			List<string> invocationArgumentsList = new List<string>( processArguments );
			invocationArgumentsList.Add(
				string.Format( "--homedir \"{0}\"", ( string ) this.Config.KeyRingPath )
			);
			invocationArgumentsList.Add(
				string.Format( "--pinentry-mode loopback --passphrase \"{0}\"", ( string ) this.Config.Passphrase )
			);
			invocationArgumentsList.Add(
				string.Format( "--recipient \"{0}\"", ( string ) this.Config.Recipient )
			);
			string[ ] invocationArgumentsArray = invocationArgumentsList.ToArray( );
			return String.Join( " ", invocationArgumentsArray );
		}

		/// <summary>
		/// Creates the `ProcessStartInfo` object necessary to invoke the GPG binary.
		/// </summary>
		/// <param name="invocationArguments">The arguments string necessary for the invocation of the GPG library.</param>
		/// <returns>The `ProcessStartInfo` object necessary to invoke the GPG binary.</returns>
		private ProcessStartInfo CreateProcessStartInfo( string invocationArguments )
		{
			ProcessStartInfo processStartInfo = new ProcessStartInfo( );
			processStartInfo.FileName = this.Config.BinaryPath;
			processStartInfo.Arguments = invocationArguments;
			processStartInfo.RedirectStandardError = true;
			processStartInfo.RedirectStandardInput = true;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			return processStartInfo;
		}

		/// <summary>
		/// Parses the standard error output for warnings and errors.
		/// </summary>
		/// <param name="process">The process to parse its standard error output.</param>
		private void ParseStandardErrorOutput( Process process )
		{
			ProcessWarningsParser processWarningsParser = new ProcessWarningsParser( );
			ProcessErrorsParser processErrorsParser = new ProcessErrorsParser( );
			while ( false == process.StandardError.EndOfStream )
			{
				string processMessage = process.StandardError.ReadLine( );

				ProcessErrorEventArguments eventArguments = new ProcessErrorEventArguments( processMessage );
				this.ProcessError( this, eventArguments );

				if ( false == this.Config.IgnoreProcessWarnings )
				{
					processWarningsParser.Parse( processMessage );
				}
				if ( false == this.Config.IgnoreProcessErrors )
				{
					processErrorsParser.Parse( processMessage );
				}
			}
		}

		/// <summary>
		/// Invokes the GPG binary.
		/// </summary>
		/// <param name="processArguments">The custom arguments for the specific process to invoke.</param>
		/// <param name="inputStream">The input stream of the invoked GPG binary.</param>
		/// <param name="outputStream">The output stream of the invoked GPG binary.</param>
		private void Invoke( string[ ] processArguments, Stream inputStream, Stream outputStream )
		{
			string invocationArguments = this.CreateInvocationArguments( processArguments );
			ProcessStartInfo processStartInfo = this.CreateProcessStartInfo( invocationArguments );
			Process process = Process.Start( processStartInfo );
			inputStream.CopyTo( process.StandardInput.BaseStream );
			process.StandardInput.Close( );
			process.WaitForExit( );
			process.StandardOutput.BaseStream.CopyTo( outputStream );
			this.ParseStandardErrorOutput( process );
		}

		/// <summary>
		/// Signs a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to sign.</param>
		/// <param name="encryptedMessageStream">The signed message.</param>
		public virtual void Sign( Stream messageStream, Stream signedMessageStream )
		{
			string[ ] processArguments = new string[ ]
			{
				"--armor",
				"--sign"
			};
			this.Invoke( processArguments, messageStream, signedMessageStream );
		}

		/// <summary>
		/// Encrypts a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to encrypt.</param>
		/// <param name="encryptedMessageStream">The stream of the encrypted message.</param>
		public virtual void Encrypt( Stream messageStream, Stream encryptedMessageStream )
		{
			string[ ] processArguments = new string[ ]
			{
				"--armor",
				"--encrypt"
			};
			this.Invoke( processArguments, messageStream, encryptedMessageStream );
		}

		/// <summary>
		/// Signs and encrypts a message.
		/// </summary>
		/// <param name="messageStream">The stream of the message to sign and encrypt.</param>
		/// <param name="decryptedMessageStream">The stream of the signed and encrypted message.</param>
		public virtual void SignAndEncrypt( Stream messageStream, Stream signedAndEncryptedMessageStream )
		{
			string[ ] processArguments = new string[ ]
			{
				"--armor",
				"--sign",
				"--encrypt"
			};
			this.Invoke( processArguments, messageStream, signedAndEncryptedMessageStream );
		}

		/// <summary>
		/// Decrypts an encrypted message.
		/// </summary>
		/// <param name="messageStream">The stream of the encrypted message to decrypt.</param>
		/// <param name="signedMessageStream">The stream of the decrypted message.</param>
		public virtual void Decrypt( Stream encryptedMessageStream, Stream decryptedMessageStream )
		{
			string[ ] processArguments = new string[ ]
			{
				"--armor",
				"--decrypt"
			};
			this.Invoke( processArguments, encryptedMessageStream, decryptedMessageStream );
		}
	}
}
