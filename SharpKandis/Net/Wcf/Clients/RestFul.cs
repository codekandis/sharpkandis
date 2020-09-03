using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;

namespace SharpKandis.Net.Wcf.Clients
{
	/// <summary>Represents a WCF RESTFul Client.</summary>
	/// <typeparam name="TServiceContract">The type of the WCF RESTFul service contract.</typeparam>
	public class RestFul<TServiceContract>
		where TServiceContract : class,
		RestFulInterface<TServiceContract>
	{
		/// <summary>Stores the base API URI of the WCF RESTFul client.</summary>
		private Uri uriApi = null;

		/// <summary>Gets / sets the base API URI of the WCF RESTFul client.</summary>
		public Uri UriApi
		{
			get
			{
				return this.uriApi;
			}
			private set
			{
				this.uriApi = value;
			}
		}

		/// <summary>Stores if HTTPS is used with the WCF RESTFul client.</summary>
		private bool httpsIs = false;

		/// <summary>Gets / sets if HTTPS is used with the WCF RESTFul client.</summary>
		public bool HttpsIs
		{
			get
			{
				return this.httpsIs;
			}
			private set
			{
				this.httpsIs = value;
			}
		}

		private WebContentTypeMapper contentTypeMapper = null;

		public WebContentTypeMapper ContentTypeMapper
		{
			get
			{
				return this.contentTypeMapper;
			}
			set
			{
				this.contentTypeMapper = value;
			}
		}

		/// <summary>Stores the service channel factory of the WCF RESTFul client.</summary>
		private ChannelFactory<TServiceContract> serviceChannelFactory = null;

		/// <summary>Gets / sets the service channel factory of the WCF RESTFul client.</summary>
		private ChannelFactory<TServiceContract> ServiceChannelFactory
		{
			get
			{
				if ( null == this.serviceChannelFactory )
				{
					//EndpointAddress endpointAddress = new EndpointAddress( this.UriApi );
					//WebHttpBinding webHttpBinding = new WebHttpBinding( );
					//webHttpBinding.TransferMode = TransferMode.Streamed;
					//WebHttpBehavior webHttpBehavior = new WebHttpBehavior( );
					//ChannelFactory<TServiceContract> serviceChannelFactory = new ChannelFactory<TServiceContract>( webHttpBinding, endpointAddress );
					//serviceChannelFactory.Endpoint.EndpointBehaviors.Add( webHttpBehavior );
					//this.ServiceChannelFactory = serviceChannelFactory;
					ChannelFactory<TServiceContract> serviceChannelFactory = new WebChannelFactory<TServiceContract>( this.UriApi );
					WebHttpBinding webHttpBinding = null;
					if ( false == this.HttpsIs )
					{
						webHttpBinding = new WebHttpBinding();
					}
					else
					{
						webHttpBinding = new WebHttpBinding( WebHttpSecurityMode.Transport );
					}
					if ( null != this.ContentTypeMapper )
					{
						webHttpBinding.ContentTypeMapper = this.ContentTypeMapper;
					}
					//webHttpBinding.TransferMode = TransferMode.Streamed;
					serviceChannelFactory.Endpoint.Binding = webHttpBinding;
					this.ServiceChannelFactory = serviceChannelFactory;
				}
				return this.serviceChannelFactory;
			}
			set
			{
				this.serviceChannelFactory = value;
			}
		}

		/// <summary>Gets / sets the service channel of the WCF RESTFul client.</summary>
		private TServiceContract ServiceChannel
		{
			get
			{
				TServiceContract serviceChannel = this.ServiceChannelFactory.CreateChannel();
				return serviceChannel;
			}
		}

		/// <summary>Creates a new instance of <i>RestFul</i>.</summary>
		/// <param name="uriApi">The base API URI of the WCF RESTFul client.</param>
		/// <param name="httpsIs"><i>true</i> if HTTPS is use, <i>false</i> otherwise.</param>
		public RestFul( Uri uriApi, bool httpsIs = false, Type contentTypeMapperType = null )
		{
			this.UriApi = uriApi;
			this.HttpsIs = httpsIs;
			if ( null != contentTypeMapperType )
			{
				this.ContentTypeMapper = ( WebContentTypeMapper ) Activator.CreateInstance( contentTypeMapperType );
			}
		}

		/// <summary>Creates a new instance of <i>RestFul</i>.</summary>
		/// <param name="uriApi">The base API URI of the WCF RESTFul client.</param>
		/// <param name="httpsIs"><i>true</i> if HTTPS is use, <i>false</i> otherwise.</param>
		public RestFul( string uriApi, bool httpsIs = false, Type contentTypeMapperType = null )
		  : this( new Uri( uriApi ), httpsIs, contentTypeMapperType )
		{
		}

		/// <summary>Invokes an action with a passed channel of the service contract on the WCF RESTful client an securely closes the used channel after invocation or on occuring exception.</summary>
		/// <param name="action">The action to invoke on the service contract.</param>
		public virtual void Invoke( Action<TServiceContract> action )
		{
			try
			{
				action( this.ServiceChannel );
			}
			catch ( Exception exception )
			{
				Console.WriteLine( "!! :: {0}", exception.Message );
				this.ServiceChannelFactory.Abort();
			}
			finally
			{
				this.ServiceChannelFactory.Close();
			}
		}
	}
}
