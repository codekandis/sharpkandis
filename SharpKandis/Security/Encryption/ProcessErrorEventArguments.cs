using System;

namespace SharpKandis.Security.Encryption
{
	/// <summary>
	/// Represents the event arguments of the `ErrorOccured` event.
	/// </summary>
	public class ProcessErrorEventArguments:
		EventArgs
	{
		/// <summary>
		/// Stores the error message of the occured error.
		/// </summary>
		private string message;

		/// <summary>
		/// Gets / sets the error messages of the occured error.
		/// </summary>
		public virtual string Message
		{
			get
			{
				return this.message;
			}
			private set
			{
				this.message = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="message">The error message of the occured error.</param>
		public ProcessErrorEventArguments( string message )
		{
			this.Message = message;
		}
	}
}
