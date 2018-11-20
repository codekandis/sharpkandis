using System;

namespace SharpKandis
{
	/// <summary>
	/// Represents an extension class of all `System.Exception` classes.
	/// </summary>
	public static class ExceptionXt
	{
		/// <summary>
		/// Gets the message of a specified `System.Exception` including the messages of its inner exceptions.
		/// </summary>
		/// <param name="reference">The `System.Exception` to get its message including the messages of its inner exceptions.</param>
		/// <returns>the message of a specified `System.Exception` including the messages of its inner exceptions.</returns>
		public static string GetMessageRecursive( this Exception reference )
		{
			string messageRecursive = string.Empty;
			Exception innerException = reference;
			while ( null != innerException )
			{
				messageRecursive += Environment.NewLine + Environment.NewLine + innerException.Message;
				innerException = innerException.InnerException;
			}
			return messageRecursive;
		}
	}
}
