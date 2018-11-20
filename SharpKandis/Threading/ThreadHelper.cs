using System.Threading;

namespace SharpKandis.Threading
{
	/// <summary>
	/// Represents an helper class for all threading purposes.
	/// </summary>
	public static class ThreadHelper
	{
		/// <summary>
		/// Starts a thread directly without the creation of a `System.Threading.ThreadStart` and a `System.Threading.Thread` instance.
		/// </summary>
		/// <param name="threadStart">The delegate to be invoked while the thread starts.</param>
		/// <returns>The started thread.</returns>
		public static Thread StartDirect( ThreadStart threadStart )
		{
			Thread thread = new Thread( threadStart );
			thread.Start( );
			return thread;
		}

		/// <summary>
		/// Starts a thread directly without the creation of a `System.Threading.ThreadStart` and a `System.Threading.Thread` instance.
		/// </summary>
		/// <param name="parameterizedThreadStart">The delegate to be invoked while the thread starts.</param>
		/// <returns>The started thread.</returns>
		public static Thread StartDirect( ParameterizedThreadStart parameterizedThreadStart )
		{
			Thread thread = new Thread( parameterizedThreadStart );
			thread.Start( );
			return thread;
		}
	}
}
