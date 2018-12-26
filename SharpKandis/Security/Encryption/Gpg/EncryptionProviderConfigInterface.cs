namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents the interface of all GPG encryption provider configurations.
	/// </summary>
	public interface EncryptionProviderConfigInterface
	{
		/// <summary>
		/// Gets the path of the GPG binary.
		/// </summary>
		BinaryPath BinaryPath
		{
			get;
		}

		/// <summary>
		/// Gets the path of the user's GPG key ring.
		/// </summary>
		KeyRingPath KeyRingPath
		{
			get;
		}

		/// <summary>
		/// Gets the passphrase of the user's GPG private key.
		/// </summary>
		Passphrase Passphrase
		{
			get;
		}

		/// <summary>
		/// Gets the GPG user ID of the recipient of the message.
		/// </summary>
		Recipient Recipient
		{
			get;
		}

		/// <summary>
		/// Gets if the process warnings of the GPG binary should be ignored.
		/// </summary>
		IgnoreProcessWarnings IgnoreProcessWarnings
		{
			get;
		}

		/// <summary>
		/// Gets if the process errors of the GPG binary should be ignored.
		/// </summary>
		IgnoreProcessErrors IgnoreProcessErrors
		{
			get;
		}
	}
}
