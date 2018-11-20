using System;

namespace SharpKandis
{
	/// <summary>
	/// Represents an extension class of all <i>System.Exception</i> classes.
	/// </summary>
	public static class ExceptionXt
	{
		/// <summary>
		/// Gets the message of a specified <i>System.Exception</i> including the messages of its inner exceptions.
		/// </summary>
		/// <param name="reference">The <i>System.Exception</i> to get its message including the messages of its inner exceptions.</param>
		/// <returns>the message of a specified <i>System.Exception</i> including the messages of its inner exceptions.</returns>
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
