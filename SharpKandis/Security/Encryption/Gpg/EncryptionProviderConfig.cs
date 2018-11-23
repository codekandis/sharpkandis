namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a GPG encryption provider configuration.
	/// </summary>
	public class EncryptionProviderConfig:
		EncryptionProviderConfigInterface
	{
		/// <summary>
		/// Stores the path of the GPG binary.
		/// </summary>
		private BinaryPath binaryPath;

		/// <summary>
		/// Gets / sets the path of the GPG binary.
		/// </summary>
		public virtual BinaryPath BinaryPath
		{
			get
			{
				return this.binaryPath;
			}
			private set
			{
				this.binaryPath = value;
			}
		}

		/// <summary>
		/// Stores the path of the user's GPG key ring.
		/// </summary>
		private KeyRingPath keyRingPath;

		/// <summary>
		/// Gets / sets the path of the user's GPG key ring.
		/// </summary>
		public virtual KeyRingPath KeyRingPath
		{
			get
			{
				return this.keyRingPath;
			}
			private set
			{
				this.keyRingPath = value;
			}
		}

		/// <summary>
		/// Stores the passphrase of the user's GPG private key.
		/// </summary>
		private Passphrase passphrase;

		/// <summary>
		/// Gets / sets the passphrase of the user's GPG private key.
		/// </summary>
		public virtual Passphrase Passphrase
		{
			get
			{
				return this.passphrase;
			}
			private set
			{
				this.passphrase = value;
			}
		}

		/// <summary>
		/// Stores the GPG user ID of the recipient of the message.
		/// </summary>
		private Recipient recipient;

		/// <summary>
		/// Gets / sets the GPG user ID of the recipient of the message.
		/// </summary>
		public virtual Recipient Recipient
		{
			get
			{
				return this.recipient;
			}
			private set
			{
				this.recipient = value;
			}
		}

		/// <summary>
		/// Stores if the process warnings of the GPG binary should be ignored.
		/// </summary>
		private IgnoreProcessWarnings ignoreProcessWarnings;

		/// <summary>
		/// Gets / sets if the process warnings of the GPG binary should be ignored.
		/// </summary>
		public virtual IgnoreProcessWarnings IgnoreProcessWarnings
		{
			get
			{
				return this.ignoreProcessWarnings;
			}
			private set
			{
				this.ignoreProcessWarnings = value;
			}
		}

		/// <summary>
		/// Stores if the process errors of the GPG binary should be ignored.
		/// </summary>
		private IgnoreProcessErrors ignoreProcessErrors;

		/// <summary>
		/// Gets / sets if the process errors of the GPG binary should be ignored.
		/// </summary>
		public virtual IgnoreProcessErrors IgnoreProcessErrors
		{
			get
			{
				return this.ignoreProcessErrors;
			}
			private set
			{
				this.ignoreProcessErrors = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="binaryPath">The path of the GPG binary.</param>
		/// <param name="keyRingPath">The path of the user's GPG key ring.</param>
		/// <param name="passphrase">The passphrase of the user's GPG private key.</param>
		/// <param name="recipient">The GPG user ID of the recipient of the message.</param>
		/// <param name="ignoreProcessWarnings">Specifies if the process warnings of the GPG binary should be ignored.</param>
		/// <param name="ignoreProcessErrors">Specifies if the process errors of the GPG binary should be ignored.</param>
		public EncryptionProviderConfig( BinaryPath binaryPath, KeyRingPath keyRingPath, Passphrase passphrase, Recipient recipient, IgnoreProcessWarnings ignoreProcessWarnings, IgnoreProcessErrors ignoreProcessErrors )
		{
			this.BinaryPath = binaryPath;
			this.KeyRingPath = keyRingPath;
			this.Passphrase = passphrase;
			this.Recipient = recipient;
			this.IgnoreProcessWarnings = ignoreProcessWarnings;
			this.IgnoreProcessErrors = ignoreProcessErrors;
		}
	}
}
