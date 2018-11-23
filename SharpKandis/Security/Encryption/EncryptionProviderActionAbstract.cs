namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the base class of all encryption provider actions.
	/// </summary>
	public abstract class EncryptionProviderActionAbstract
	{
		/// <summary>
		/// Stores the encryption provider builder of the underlying encryption provider.
		/// </summary>
		private EncryptionProviderBuilderInterface encryptionProviderBuilder;

		/// <summary>
		/// Gets / sets the encryption provider builder of the underlying encryption provider.
		/// </summary>
		protected virtual EncryptionProviderBuilderInterface EncryptionProviderBuilder
		{
			get
			{
				return this.encryptionProviderBuilder;
			}
			private set
			{
				this.encryptionProviderBuilder = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="encryptionProviderBuilder">The encryption provider builder of the underlying encryption provider.</param>
		public EncryptionProviderActionAbstract( EncryptionProviderBuilderInterface encryptionProviderBuilder )
		{
			this.EncryptionProviderBuilder = encryptionProviderBuilder;
		}
	}
}
