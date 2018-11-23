using System;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the interface of all encryption provider builders.
	/// </summary>
	public interface EncryptionProviderBuilderInterface
	{
		/// <summary>
		/// Will be raised if a process error occures.
		/// </summary>
		event EventHandler<ProcessErrorEventArguments> ProcessError;

		/// <summary>
		/// Builds an encryption provider.
		/// </summary>
		/// <returns>The build encryption provider.</returns>
		EncryptionProviderInterface BuildEncryptionProvider( );
	}
}
