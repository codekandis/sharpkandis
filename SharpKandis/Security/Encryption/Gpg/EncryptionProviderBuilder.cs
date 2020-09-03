﻿using System;

namespace SharpKandis.Security.Encryption.Gpg
{
	/// <summary>
	/// Represents a GPG encryption provider builder.
	/// </summary>
	public class EncryptionProviderBuilder:
		EncryptionProviderBuilderInterface
	{
		/// <summary>
		/// Stores the GPG encryption provider configuration.
		/// </summary>
		private EncryptionProviderConfigInterface encryptionProviderConfig;

		/// <summary>
		/// Gets / sets the GPG encryption provider configuration.
		/// </summary>
		private EncryptionProviderConfigInterface EncryptionProviderConfig
		{
			get
			{
				return this.encryptionProviderConfig;
			}
			set
			{
				this.encryptionProviderConfig = value;
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
		/// <param name="encryptionProviderConfig">The GPG encryption provider configuration.</param>
		public EncryptionProviderBuilder( EncryptionProviderConfigInterface encryptionProviderConfig )
		{
			this.EncryptionProviderConfig = encryptionProviderConfig;
		}

		/// <summary>
		/// Builds a GPG encryption provider.
		/// </summary>
		/// <returns>The build GPG encryption provider.</returns>
		public virtual EncryptionProviderInterface BuildEncryptionProvider( )
		{
			EncryptionProvider encryptionProvider = new EncryptionProvider( this.EncryptionProviderConfig );
			encryptionProvider.ProcessError += this.EncryptionProvider_ProcessError;
			return encryptionProvider;
		}

		private void EncryptionProvider_ProcessError( object sender, ProcessErrorEventArguments eventArguments )
		{
			this.ProcessError( sender, eventArguments );
		}
	}
}