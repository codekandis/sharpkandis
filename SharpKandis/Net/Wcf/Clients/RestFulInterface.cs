using System;

namespace SharpKandis.Net.Wcf.Clients
{
	/// <summary>
	/// Represents the interface of all WCF RESTFul clients.
	/// </summary>
	/// <typeparam name="TServiceContract">The type of the WCF RESTFul service contract.</typeparam>
	public interface RestFulInterface<TServiceContract>
		where TServiceContract : class
	{
		/// <summary>
		/// Gets the base API URI of the WCF RESTFul client.
		/// </summary>
		Uri UriApi
		{
			get;
		}

		/// <summary>
		/// Invokes an action with a passed channel of the service contract on the WCF RESTful client an securely closes the used channel after invocation or on occuring exception.
		/// </summary>
		/// <param name="action">The action to invoke on the service contract.</param>
		void Invoke( Action<TServiceContract> action );
	}
}
