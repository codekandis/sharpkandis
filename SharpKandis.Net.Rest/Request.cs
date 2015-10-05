namespace SharpKandis.Net.Rest
{
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Net;
  using System.Reflection;
  using System.Runtime.Serialization;
  using System.Runtime.Serialization.Json;
  using SharpKandis.Net.Rest.Settings;

  /// <summary>Represents the class for all REST client requests.</summary>
  /// <typeparam name="TServiceContract">The type of the service contract.</typeparam>
  public class Request<TServiceContract>
    where TServiceContract : class
  {
    #region Properties

    #region MessageFormatterRegistered

    /// <summary>Stores the registered message formatter to format the request and response streams of the request.</summary>
    private IDictionary<MessageFormat, Type> messageFormatterRegistered = new Dictionary<MessageFormat, Type>
    {
      { MessageFormat.None, null },
      { MessageFormat.Json, typeof( DataContractJsonSerializer ) },
      { MessageFormat.Xml, typeof( DataContractSerializer ) }
    };

    /// <summary>Gets the registered message formatter to format the request and response streams of the request.</summary>
    private IDictionary<MessageFormat, Type> MessageFormatterRegistered
    {
      get
      {
        return this.messageFormatterRegistered;
      }
    }

    #endregion MessageFormatterRegistered

    #region ServiceContractType

    /// <summary>Stores the type of the service contract.</summary>
    private Type serviceContractType = null;

    /// <summary>Gets the type of the service contract.</summary>
    public virtual Type ServiceContractType
    {
      get
      {
        if ( null == this.serviceContractType )
        {
          this.serviceContractType = typeof( TServiceContract );
        }
        return this.serviceContractType;
      }
    }

    #endregion ServiceContractType

    #region ServiceUriBase

    /// <summary>Stores the base URI of the REST service.</summary>
    private Uri serviceUriBase = null;

    /// <summary>Gets / sets the base URI of the REST service.</summary>
    public virtual Uri ServiceUriBase
    {
      get
      {
        return this.serviceUriBase;
      }
      private set
      {
        this.serviceUriBase = value;
      }
    }

    #endregion ServiceUriBase

    #region OperationContractAttributes

    /// <summary>Stores the operation contract attributes of the service contract.</summary>
    private IDictionary<string, OperationContractAttribute> operationContractAttributes = null;

    /// <summary>Gets the operation contract attributes of the service contract.</summary>
    public virtual IDictionary<string, OperationContractAttribute> OperationContractAttributes
    {
      get
      {
        if ( null == this.operationContractAttributes )
        {
          this.operationContractAttributes = new Dictionary<string, OperationContractAttribute>( );
        }
        return this.operationContractAttributes;
      }
    }

    #endregion OperationContractAttributes

    #endregion Properties

    #region Constructors

    /// <summary>Constructor method.</summary>
    /// <param name="serviceUriBase">Specifies the base URI of the REST service.</param>
    public Request( Uri serviceUriBase )
    {
      this.ServiceUriBase = serviceUriBase;
    }

    #endregion Constructors

    #region Methods

    /// <summary>Gets the operation contract attribute of a specified method.</summary>
    /// <param name="methodName">Specifies the name of the method to get its operation contract attribute.</param>
    /// <returns>The operation contract attribute of the specified method.</returns>
    private OperationContractAttribute OperationContractAttributeGet( string methodName )
    {
      OperationContractAttribute operationContractAttribute = null;
      if ( false == this.OperationContractAttributes.Keys.Contains( methodName ) )
      {
        MethodInfo methodInformation = this.ServiceContractType.GetMethod( methodName );
        operationContractAttribute = methodInformation.GetCustomAttribute( typeof( OperationContractAttribute ) ) as OperationContractAttribute;
        if ( null != operationContractAttribute )
        {
          this.OperationContractAttributes.Add( methodName, operationContractAttribute );
        }
      }
      else
      {
        operationContractAttribute = this.OperationContractAttributes[ methodName ];
      }
      return operationContractAttribute;
    }

    private Type MethodReturnTypeGet( string methodName )
    {
      Type methodReturnType = this.ServiceContractType.GetMethod( methodName ).ReturnType;
      return methodReturnType;
    }

    /// <summary>Invokes a method of the service contract.</summary>
    /// <param name="methodName">Specifies the name of the method of the service contract to invoke.</param>
    /// <param name="arguments">Specifies the arguments to pass to the method invocation.</param>
    /// <returns>The response of the request.</returns>
    public virtual object Invoke( string methodName, params object[ ] arguments )
    {
      Console.WriteLine( "ServiceInvoke :: {0}", methodName );
      OperationContractAttribute operationContractAttribute = this.OperationContractAttributeGet( methodName );
      Uri uri = new Uri( this.ServiceUriBase, operationContractAttribute.UriTemplate );
      HttpWebRequest webRequest = WebRequest.Create( uri ) as HttpWebRequest;
      webRequest.Method = operationContractAttribute.HttpMethod.ToString( );
      HttpWebResponse webResponse = webRequest.GetResponse( ) as HttpWebResponse;
      object responseObject = null;
      using ( Stream webResponseStream = webResponse.GetResponseStream( ) )
      {
        Type methodReturnType = this.MethodReturnTypeGet( methodName );
        if ( typeof( void ) != methodReturnType )
        {
          if ( null == this.MessageFormatterRegistered[ operationContractAttribute.ResponseFormat ] )
          {
            using ( StreamReader webResponseStreamReader = new StreamReader( webResponseStream ) )
            {
              responseObject = webResponseStreamReader.ReadToEnd( );
              webResponseStreamReader.Close( );
            }
          }
          else
          {
            using ( StreamReader webResponseStreamReader = new StreamReader( webResponseStream ) )
            {
              XmlObjectSerializer messageFormatter = Activator.CreateInstance( MessageFormatterRegistered[ operationContractAttribute.ResponseFormat ], methodReturnType ) as XmlObjectSerializer;
              responseObject = messageFormatter.ReadObject( webResponseStreamReader.BaseStream );
            }
          }
        }
        webResponseStream.Close( );
      }
      return responseObject;
    }

    #endregion Methods
  }
}