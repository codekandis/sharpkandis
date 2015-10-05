namespace SharpKandis.Net.Sockets
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Net;
  using System.Net.Sockets;
  using System.Text;
  using SharpKandis;
  using SharpKandis.Collections.Generic;

  /// <summary>Represents a HTTP socket implementation.</summary>
  public class SocketHttp:
    Socket
  {
    #region Properties

    #region HttpProtocolVersion

    /// <summary>Stores the HTTP protocol version of the HTTP socket.</summary>
    private HttpProtocolVersion protocolVersion = default( HttpProtocolVersion );

    /// <summary>Gets / sets the HTTP protocol version of the HTTP socket.</summary>
    public virtual HttpProtocolVersion HttpProtocolVersion
    {
      get
      {
        return this.protocolVersion;
      }
      set
      {
        this.protocolVersion = value;
      }
    }

    #endregion HttpProtocolVersion

    #region RequestMethod

    /// <summary>Stores the method of the HTTP request of the HTTP socket.</summary>
    private HttpMethod requestMethod = HttpMethod.POST;

    /// <summary>Gets / sets the method of the HTTP request of the HTTP socket.</summary>
    public virtual HttpMethod RequestMethod
    {
      get
      {
        return this.requestMethod;
      }
      set
      {
        this.requestMethod = value;
      }
    }

    #endregion RequestMethod

    #region RequestHeaders

    /// <summary>Stores the HTTP request headers of the HTTP socket.</summary>
    private WebHeaderCollection requestHeaders = null;

    /// <summary>Gets the HTTP request headers of the HTTP socket.</summary>
    public virtual WebHeaderCollection RequestHeaders
    {
      get
      {
        if ( null == this.requestHeaders )
        {
          this.requestHeaders = new WebHeaderCollection( );
        }
        return this.requestHeaders;
      }
    }

    #endregion RequestHeaders

    #region ResponseHeaders

    /// <summary>Stores the HTTP response headers of the HTTP socket.</summary>
    private WebHeaderCollection responseHeaders = null;

    /// <summary>Gets the HTTP response headers of the HTTP socket.</summary>
    public virtual WebHeaderCollection ResponseHeaders
    {
      get
      {
        if ( null == this.responseHeaders )
        {
          this.responseHeaders = new WebHeaderCollection( );
        }
        return this.responseHeaders;
      }
    }

    #endregion ResponseHeaders

    #endregion Properties

    #region Constructors

    /// <summary>Initializes a new instance of <i>SocketHttp</i>.</summary>
    public SocketHttp( ) :
      base( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp )
    {
    }

    /// <summary>Initializes a new instance of <i>SocketHttp</i>.</summary>
    /// <param name="encoding">The encoding the data stream conversion of the socket depends on.</param>
    public SocketHttp( Encoding encoding ) :
      base( AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp, encoding )
    {
    }

    #endregion Constructors

    #region Methods

    public override void RequestCycle( Uri uri, bool keepAlive )
    {
      Console.WriteLine( "request" );
      string requestHeadLine = string.Format( "{0} {1}{2} HTTP/{3}\r\n",
                                              this.RequestMethod.ToStringUser( ),
                                              uri.AbsolutePath,
                                              uri.Query,
                                              this.HttpProtocolVersion.ToStringUser( ) );
      this.RequestHeaders.Set( HttpRequestHeader.Host, uri.Host );
      byte[ ] requestHeaders = this.RequestHeaders.ToByteArray( );
      byte[ ] requestDataBytes = this.RequestDataBytes;
      this.RequestDataBytesInternal = requestHeaders.ConcatAll( requestHeadLine.ToBytes( ), requestHeaders, requestDataBytes );
      base.RequestCycle( uri, keepAlive );
    }

    #endregion Methods
  }
}