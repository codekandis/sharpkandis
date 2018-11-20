using System;
using System.IO;

namespace SharpKandis.Io
{
	/// <summary>Represents the event arguments of a file access event.</summary>
	public class FileAccessEventArguments:
		EventArgs
	{
		/// <summary>Stores the name of the accessed file.</summary>
		private string fileName = null;

		/// <summary>Gets / sets the name of the accessed file.</summary>
		public virtual string FileName
		{
			get
			{
				return this.fileName;
			}
			private set
			{
				this.fileName = value;
			}
		}
		/// <summary>Stores the file information object of the accessed file.</summary>
		private FileInfo fileInformation = null;

		/// <summary>Gets the file information object of the accessed file.</summary>
		public virtual FileInfo FileInformation
		{
			get
			{
				if ( null == this.fileInformation )
				{
					this.fileInformation = new FileInfo( this.FileName );
				}
				return this.fileInformation;
			}
		}

		/// <summary>Stores if the file access was successful.</summary>
		private bool successful = false;

		/// <summary>Gets / sets if the file access was successful.</summary>
		public virtual bool Successful
		{
			get
			{
				return this.successful;
			}
			private set
			{
				this.successful = value;
			}
		}

		/// <summary>Stores the exception that may occured if the file access failed.</summary>
		private Exception exception = null;

		/// <summary>Gets / sets the exception that may occured if the file access failed.</summary>
		public virtual Exception Exception
		{
			get
			{
				return this.exception;
			}
			private set
			{
				this.exception = value;
			}
		}

		/// <summary>Constructor method.</summary>
		/// <param name="fileName">The name of the accessed file.</param>
		/// <param name="successful"><i>true</i> if the file access was successful, <i>false</i> otherwise.</param>
		/// <param name="exception">The exception that occured during file access.</param>
		public FileAccessEventArguments( string fileName, bool successful, Exception exception )
		{
			this.FileName = fileName;
			this.Successful = successful;
			this.Exception = exception;
		}
	}
}
