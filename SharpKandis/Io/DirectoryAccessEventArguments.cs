using System;
using System.IO;

namespace SharpKandis.Io
{
	/// <summary>
	/// Represents the event arguments of a directory access event.
	/// </summary>
	public class DirectoryAccessEventArguments:
		EventArgs
	{
		/// <summary>
		/// Stores the name of the accessed directory.
		/// </summary>
		private string directoryName = null;

		/// <summary>
		/// Gets / sets the name of the accessed directory.
		/// </summary>
		public virtual string DirectoryName
		{
			get
			{
				return this.directoryName;
			}
			private set
			{
				this.directoryName = value;
			}
		}

		/// <summary>
		/// Stores the directory information object of the accessed file.
		/// </summary>
		private DirectoryInfo directoryInformation = null;

		/// <summary>
		/// Gets the directory information object of the accessed file.
		/// </summary>
		public virtual DirectoryInfo DirectoryInformation
		{
			get
			{
				return this.directoryInformation ?? ( this.directoryInformation = new DirectoryInfo( this.DirectoryName ) );
			}
		}

		/// <summary>
		/// Stores if the file access was successful.
		/// </summary>
		private bool successful = false;

		/// <summary>
		/// Gets / sets if the file access was successful.
		/// </summary>
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

		/// <summary>
		/// Stores the exception that may occured if the file access failed.
		/// </summary>
		private Exception exception = null;

		/// <summary>
		/// Gets / sets the exception that may occured if the file access failed.
		/// </summary>
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

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="directoryName">The name of the accessed directory.</param>
		/// <param name="successful"><i>true</i> if the directory access was successful, <i>false</i> otherwise.</param>
		/// <param name="exception">The exception that occured during directory access.</param>
		public DirectoryAccessEventArguments( string directoryName, bool successful, Exception exception )
		{
			this.DirectoryName = directoryName;
			this.Successful = successful;
			this.Exception = exception;
		}
	}
}
