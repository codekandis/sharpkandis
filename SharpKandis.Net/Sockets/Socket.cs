namespace SharpKandis.Net.Sockets
{
  using System;
  using System.IO;
  using System.Net;
  using System.Net.Sockets;
  using System.Text;
  using SharpKandis.Threading;

  using X_Socket = System.Net.Sockets.Socket;

  /// <summary>Represents an enhanced socket with implemented automatic request and response functionality, easy request and response access and notifications by events.</summary>
  public class Socket :
    X_Socket
  {
    #region Properties

    #region BufferSize

    /// <summary>Stores the buffer size of the request and response of the socket.</summary>
    private int bufferSize = 512;

    /// <summary>Gets / sets the buffer siz of the request and response of the socket.</summary>
    public virtual int BufferSize
    {
      get
      {
        return this.bufferSize;
      }
      set
      {
        this.bufferSize = value;
      }
    }

    #endregion BufferSize

    #region Encoding

    /// <summary>Stores the encoding the data stream conversion of the socket depends on.</summary>
    private Encoding encoding = Encoding.UTF8;

    /// <summary>Gets / sets the encoding the data stream conversion of the socket depends on.</summary>
    public Encoding Encoding
    {
      get
      {
        return this.encoding;
      }
      private set
      {
        this.encoding = value;
      }
    }

    #endregion Encoding

    #region RequestDataStreamInternal

    /// <summary>Stores the internal request data as a <i>Stream</i>.</summary>
    private Stream requestDataStreamInternal = null;

    /// <summary>Gets the internal request data as a <i>Stream</i>.</summary>
    protected virtual Stream RequestDataStreamInternal
    {
      get
      {
        if ( null == this.requestDataStreamInternal )
        {
          this.requestDataStreamInternal = new MemoryStream( );
          this.RequestDataStream.CopyTo( this.requestDataStreamInternal );
        }
        return this.requestDataStreamInternal;
      }
    }

    #endregion RequestDataStreamInternal

    #region RequestDataBytesInternal

    /// <summary>Gets / sets the internal request data as a <i>byte</i> <i>Array</i>.</summary>
    public virtual byte[ ] RequestDataBytesInternal
    {
      get
      {
        byte[ ] requestDataBytesInternal = new byte[ this.RequestDataStreamInternal.Length ];
        long position = this.RequestDataStreamInternal.Position;
        this.RequestDataStreamInternal.Position = 0;
        this.RequestDataStreamInternal.Read( requestDataBytesInternal, 0, ( int ) this.RequestDataStreamInternal.Length );
        this.RequestDataStreamInternal.Position = position;
        return requestDataBytesInternal;
      }
      set
      {
        this.RequestDataStreamInternal.SetLength( value.Length );
        this.RequestDataStreamInternal.Position = 0;
        this.RequestDataStreamInternal.Write( value, 0, value.Length );
      }
    }

    #endregion RequestDataBytesInternal

    #region RequestDataStringInternal

    /// <summary>Gets / sets the internal request data as a <i>string</i>.</summary>
    public virtual string RequestDataStringInternal
    {
      get
      {
        string dataStringInternal = this.Encoding.GetString( this.RequestDataBytesInternal );
        return dataStringInternal;
      }
      set
      {
        this.RequestDataBytesInternal = this.Encoding.GetBytes( value );
      }
    }

    #endregion RequestDataStringInternal

    #region RequestDataStream

    /// <summary>Stores the request data as a <i>Stream</i>.</summary>
    private Stream requestDataStream = null;

    /// <summary>Gets the request data as a <i>Stream</i>.</summary>
    public virtual Stream RequestDataStream
    {
      get
      {
        if ( null == this.requestDataStream )
        {
          this.requestDataStream = new MemoryStream( );
        }
        return this.requestDataStream;
      }
    }

    #endregion RequestDataStream

    #region RequestDataBytes

    /// <summary>Gets / sets the request data as a <i>byte</i> array.</summary>
    public virtual byte[ ] RequestDataBytes
    {
      get
      {
        byte[ ] requestDataBytes = new byte[ this.RequestDataStream.Length ];
        long position = this.RequestDataStream.Position;
        this.RequestDataStream.Position = 0;
        this.RequestDataStream.Read( requestDataBytes, 0, ( int ) this.RequestDataStream.Length );
        this.RequestDataStream.Position = position;
        return requestDataBytes;
      }
      set
      {
        this.RequestDataStream.SetLength( value.Length );
        this.RequestDataStream.Position = 0;
        this.RequestDataStream.Write( value, 0, value.Length );
      }
    }

    #endregion RequestDataBytes

    #region RequestDataString

    /// <summary>Gets / sets the request data as a <i>string</i>.</summary>
    public virtual string RequestDataString
    {
      get
      {
        string dataString = this.Encoding.GetString( this.RequestDataBytes );
        return dataString;
      }
      set
      {
        this.RequestDataBytes = this.Encoding.GetBytes( value );
      }
    }

    #endregion RequestDataString

    #region ResponseDataStream

    /// <summary>Stores the response data as a <i>Stream</i>.</summary>
    private Stream responseDataStream = null;

    /// <summary>Gets the response data as a <i>Stream</i>.</summary>
    public virtual Stream ResponseDataStream
    {
      get
      {
        if ( null == this.responseDataStream )
        {
          this.responseDataStream = new MemoryStream( );
        }
        return this.responseDataStream;
      }
    }

    #endregion ResponseDataStream

    #region ResponseDataBytes

    /// <summary>Gets / sets the response data as a <i>byte</i> array.</summary>
    public virtual byte[ ] ResponseDataBytes
    {
      get
      {
        byte[ ] responseDataBytes = new byte[ this.ResponseDataStream.Length ];
        long position = this.ResponseDataStream.Position;
        this.ResponseDataStream.Position = 0;
        this.ResponseDataStream.Read( responseDataBytes, 0, ( int ) this.ResponseDataStream.Length );
        this.ResponseDataStream.Position = position;
        return responseDataBytes;
      }
      set
      {
        this.ResponseDataStream.SetLength( value.Length );
        this.ResponseDataStream.Position = 0;
        this.ResponseDataStream.Write( value, 0, value.Length );
      }
    }

    #endregion ResponseDataBytes

    #region ResponseDataString

    /// <summary>Gets / sets the response data as a <i>string</i>.</summary>
    public virtual string ResponseDataString
    {
      get
      {
        string dataString = this.Encoding.GetString( this.ResponseDataBytes );
        return dataString;
      }
      set
      {
        this.ResponseDataBytes = this.Encoding.GetBytes( value );
      }
    }

    #endregion ResponseDataString

    #endregion Properties

    #region Events

    #region Uri

    /// <summary>Will be raised if the URI conversion was successful.</summary>
    public virtual event UriConversionSucceedEventHandler UriConversionSucceed = delegate
    {
    };

    /// <summary>Will be raised if the URI conversion has been failed.</summary>
    public virtual event UriConversionFailedEventHandler UriConversionFailed = delegate
    {
    };

    #endregion Uri

    #region EndPoint

    /// <summary>Will be raised if the endpoint conversion was successful.</summary>
    public virtual event EndPointConversionSucceedEventHandler EndPointConversionSucceed = delegate
    {
    };

    /// <summary>Will be raised if the endpoint conversion has been failed.</summary>
    public virtual event EndPointConversionFailedEventHandler EndPointConversionFailed = delegate
    {
    };

    #endregion EndPoint

    #region Connect

    /// <summary>Will be raised if the connect was successful.</summary>
    public virtual event ConnectSucceedEventHandler ConnectSucceed = delegate
    {
    };

    /// <summary>Will be raised if the connect has been failed.</summary>
    public virtual event ConnectFailedEventHandler ConnectFailed = delegate
    {
    };

    #endregion Connect

    #region Disconnect

    /// <summary>Will be raised if the disconnect was successful.</summary>
    public virtual event DisconnectSucceedEventHandler DisconnectSucceed = delegate
    {
    };

    /// <summary>Will be raised if the disconnect has been failed.</summary>
    public virtual event DisconnectFailedEventHandler DisconnectFailed = delegate
    {
    };

    #endregion Disconnect

    #region Request

    /// <summary>Will be raised if the request was successful.</summary>
    public virtual event RequestSucceedEventHandler RequestSucceed = delegate
    {
    };

    /// <summary>Will be raised if the request has been failed.</summary>
    public virtual event RequestFailedEventHandler RequestFailed = delegate
    {
    };

    #endregion Request

    #region Response

    /// <summary>Will be raised if the response was successful.</summary>
    public virtual event ResponseSucceedEventHandler ResponseSucceed = delegate
    {
    };

    /// <summary>Will be raised if the response has been failed.</summary>
    public virtual event ResponseFailedEventHandler ResponseFailed = delegate
    {
    };

    #endregion Response

    #endregion Events

    #region Constructors

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Socket</i> with a specified value returned by <i>System.Net.Sockets.Socket.DuplicateAndClose( System.Int32 )</i>.</summary>
    /// <param name="socketInformation">The socket informations returned by <i>System.Net.Sockets.Socket.DuplicateAndClose( System.Int32 )</i>.</param>
    public Socket( SocketInformation socketInformation ) :
      base( socketInformation )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Socket</i> with a specified value returned by <i>System.Net.Sockets.Socket.DuplicateAndClose( System.Int32 )</i> and depending on a specified encoding.</summary>
    /// <param name="socketInformation">The socket informations returned by <i>System.Net.Sockets.Socket.DuplicateAndClose( System.Int32 )</i>.</param>
    /// <param name="encoding">The encoding the data stream conversion of the socket depends on.</param>
    public Socket( SocketInformation socketInformation, Encoding encoding ) :
      base( socketInformation )
    {
      this.Encoding = encoding;
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Socket</i> depending on a specified address family, a specified socket type and a specified protocol tpye.</summary>
    /// <param name="addressFamily">The address family the socket depends on.</param>
    /// <param name="socketType">The socket type the socket depends on.</param>
    /// <param name="protocolType">The protocol type the socket depends on.</param>
    /// <exception cref="System.Net.Sockets.SocketException">The combination of address family, socket type and protocol type causes an invalid socket.</exception>
    public Socket( AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType )
      : base( addressFamily, socketType, protocolType )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Socket</i> depending on a specified address family, a specified socket type, a specified protocol tpye and a specified encoding.</summary>
    /// <param name="addressFamily">The address family the socket depends on.</param>
    /// <param name="socketType">The socket type the socket depends on.</param>
    /// <param name="protocolType">The protocol type the socket depends on.</param>
    /// <param name="encoding">The encoding the data stream conversion of the socket depends on.</param>
    /// <exception cref="System.Net.Sockets.SocketException">The combination of address family, socket type and protocol type causes an invalid socket.</exception>
    public Socket( AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType, Encoding encoding )
      : base( addressFamily, socketType, protocolType )
    {
      this.Encoding = encoding;
    }

    #endregion Constructors

    #region Methods

    #region UriConversion

    /// <summary>Raises the <i>UriConversionSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI succeed to convert.</param>
    /// <param name="socket">The socket raising its <i>UriConversionSucceed</i> event.</param>
    private void UriConversionSucceedRaise( Uri uri, Socket socket )
    {
      UriConversionSucceedEventArguments eventArguments = new UriConversionSucceedEventArguments( uri, socket );
      socket.UriConversionSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>UriConversionFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to convert.</param>
    /// <param name="socket">The socket raising its <i>UriConversionFailed</i> event.</param>
    /// <param name="innerException">The URI of the <i>ConnectFailed</i> event.</param>
    private void UriConversionFailedRaise( string uri, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to convert the URI '{0}'." + Environment.NewLine + Environment.NewLine + "{1}",
                                        uri,
                                        innerException.GetMessageRecursive( ) );
        throw new UriConversionFailedException( message, innerException );
      }
      catch ( UriConversionFailedException exception )
      {
        UriConversionFailedEventArguments eventArguments = new UriConversionFailedEventArguments( uri, socket, exception );
        socket.UriConversionFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>UriConversionFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to convert.</param>
    /// <param name="socket">The socket raising its <i>UriConversionFailed</i> event.</param>
    private void UriConversionFailedRaise( string uri, Socket socket )
    {
      socket.UriConversionFailedRaise( uri, socket, null );
    }

    #endregion UriConversion

    #region EndPointConversion

    /// <summary>Raises the <i>EndPointConversionSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The endpoint succeed to convert.</param>
    /// <param name="endPoint">The endpoint succeed to convert.</param>
    /// <param name="socket">The socket raising its <i>EndPointConversionSucceed</i> event.</param>
    private void EndPointConversionSucceedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      EndPointConversionSucceedEventArguments eventArguments = new EndPointConversionSucceedEventArguments( uri, endPoint, socket );
      socket.EndPointConversionSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>EndPointConversionFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The endpoint failed to convert.</param>
    /// <param name="socket">The socket raising its <i>EndPointConversionFailed</i> event.</param>
    /// <param name="innerException">The endpoint of the <i>ConnectFailed</i> event.</param>
    private void EndPointConversionFailedRaise( Uri uri, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to convert the URI '{0}' to an endpoint." + Environment.NewLine + Environment.NewLine + "{1}",
                                        uri,
                                        innerException.GetMessageRecursive( ) );
        throw new EndPointConversionFailedException( message, innerException );
      }
      catch ( EndPointConversionFailedException exception )
      {
        EndPointConversionFailedEventArguments eventArguments = new EndPointConversionFailedEventArguments( uri, socket, exception );
        socket.EndPointConversionFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>EndPointConversionFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The endpoint failed to convert.</param>
    /// <param name="socket">The socket raising its <i>EndPointConversionFailed</i> event.</param>
    private void EndPointConversionFailedRaise( Uri uri, Socket socket )
    {
      socket.EndPointConversionFailedRaise( uri, socket, null );
    }

    #endregion EndPointConversion

    #region Connect

    /// <summary>Raises the <i>ConnectSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI succeed to connect to.</param>
    /// <param name="endPoint">The URI succeed to connect to.</param>
    /// <param name="socket">The socket raising its <i>ConnectSucceed</i> event.</param>
    private void ConnectSucceedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      ConnectSucceedEventArguments eventArguments = new ConnectSucceedEventArguments( uri, endPoint, socket );
      socket.ConnectSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>ConnectFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to connect to.</param>
    /// <param name="endPoint">The URI failed to connect to.</param>
    /// <param name="socket">The socket raising its <i>ConnectFailed</i> event.</param>
    /// <param name="innerException">The inner exception of the <i>ConnectFailed</i> event.</param>
    private void ConnectFailedRaise( Uri uri, EndPoint endPoint, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to connect to the endpoint '{0}'." + Environment.NewLine + Environment.NewLine + "{1}",
                                        this.EndPointGetString( endPoint ),
                                        innerException.GetMessageRecursive( ) );
        throw new ConnectFailedException( message, innerException );
      }
      catch ( ConnectFailedException exception )
      {
        ConnectFailedEventArguments eventArguments = new ConnectFailedEventArguments( uri, endPoint, socket, exception );
        socket.ConnectFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>ConnectFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to connect to.</param>
    /// <param name="endPoint">The URI failed to connect to.</param>
    /// <param name="socket">The socket raising its <i>ConnectFailed</i> event.</param>
    private void ConnectFailedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      socket.ConnectFailedRaise( uri, endPoint, socket, null );
    }

    #endregion Connect

    #region Disconnect

    /// <summary>Raises the <i>DisconnectSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI succeed to disconnect from.</param>
    /// <param name="endPoint">The URI succeed to disconnect from.</param>
    /// <param name="socket">The socket raising its <i>DisconnectSucceed</i> event.</param>
    private void DisconnectSucceedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      DisconnectSucceedEventArguments eventArguments = new DisconnectSucceedEventArguments( uri, endPoint, socket );
      socket.DisconnectSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>DisconnectFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to disconnect from.</param>
    /// <param name="endPoint">The URI failed to disconnect from.</param>
    /// <param name="socket">The socket raising its <i>DisconnectFailed</i> event.</param>
    /// <param name="innerException">The inner exception of the <i>DisconnectFailed</i> event.</param>
    private void DisconnectFailedRaise( Uri uri, EndPoint endPoint, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to disconnect from the endpoint '{0}'." + Environment.NewLine + Environment.NewLine + "{1}",
                                        this.EndPointGetString( endPoint ),
                                        innerException.GetMessageRecursive( ) );
        throw new DisconnectFailedException( message, innerException );
      }
      catch ( DisconnectFailedException exception )
      {
        DisconnectFailedEventArguments eventArguments = new DisconnectFailedEventArguments( uri, endPoint, socket, exception );
        socket.DisconnectFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>DisconnectFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to disconnect from.</param>
    /// <param name="endPoint">The URI failed to disconnect from.</param>
    /// <param name="socket">The socket raising its <i>DisconnectFailed</i> event.</param>
    private void DisconnectFailedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      socket.DisconnectFailedRaise( uri, endPoint, socket, null );
    }

    #endregion Disconnect

    #region Request

    /// <summary>Raises the <i>RequestSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI succeed to send the request to.</param>
    /// <param name="endPoint">The URI succeed to send the request to.</param>
    /// <param name="socket">The socket raising its <i>RequestSucceed</i> event.</param>
    private void RequestSucceedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      RequestSucceedEventArguments eventArguments = new RequestSucceedEventArguments( uri, endPoint, socket );
      socket.RequestSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>RequestFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to send the request to.</param>
    /// <param name="endPoint">The URI failed to send the request to.</param>
    /// <param name="socket">The socket raising its <i>RequestFailed</i> event.</param>
    /// <param name="innerException">The inner exception of the <i>RequestFailed</i> event.</param>
    private void RequestFailedRaise( Uri uri, EndPoint endPoint, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to send the request to the endpoint '{0}'." + Environment.NewLine + Environment.NewLine + "{1}",
                                        this.EndPointGetString( endPoint ),
                                        innerException.GetMessageRecursive( ) );
        throw new RequestFailedException( message, innerException );
      }
      catch ( RequestFailedException exception )
      {
        RequestFailedEventArguments eventArguments = new RequestFailedEventArguments( uri, endPoint, socket, exception );
        socket.RequestFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>RequestFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to send the request to.</param>
    /// <param name="endPoint">The URI failed to send the request to.</param>
    /// <param name="socket">The socket raising its <i>RequestFailed</i> event.</param>
    private void RequestFailedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      socket.RequestFailedRaise( uri, endPoint, socket, null );
    }

    #endregion Request

    #region Response

    /// <summary>Raises the <i>ResponseSucceed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI succeed to get its response from.</param>
    /// <param name="endPoint">The URI succeed to get its response from.</param>
    /// <param name="socket">The socket raising its <i>ResponseSucceed</i> event.</param>
    /// <param name="innerException">The inner exception of the <i>ResponseSucceed</i> event.</param>
    private void ResponseSucceedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      ResponseSucceedEventArguments eventArguments = new ResponseSucceedEventArguments( uri, endPoint, socket );
      socket.ResponseSucceed( socket, eventArguments );
    }

    /// <summary>Raises the <i>ResponseFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to get its response from.</param>
    /// <param name="endPoint">The URI failed to get its response from.</param>
    /// <param name="socket">The socket raising its <i>ResponseFailed</i> event.</param>
    /// <param name="innerException">The inner exception of the <i>ResponseFailed</i> event.</param>
    private void ResponseFailedRaise( Uri uri, EndPoint endPoint, Socket socket, Exception innerException )
    {
      try
      {
        string message = string.Format( "The socket has been failed to receive the response from the endpoint '{0}'." + Environment.NewLine + Environment.NewLine + "{1}",
                                        this.EndPointGetString( endPoint ),
                                        innerException.GetMessageRecursive( ) );
        throw new ResponseFailedException( message, innerException );
      }
      catch ( ResponseFailedException exception )
      {
        ResponseFailedEventArguments eventArguments = new ResponseFailedEventArguments( uri, endPoint, socket, exception );
        socket.ResponseFailed( socket, eventArguments );
      }
    }

    /// <summary>Raises the <i>ResponseFailed</i> event of a specified socket.</summary>
    /// <param name="uri">The URI failed to get its response from.</param>
    /// <param name="endPoint">The URI failed to get its response from.</param>
    /// <param name="socket">The socket raising its <i>ResponseFailed</i> event.</param>
    private void ResponseFailedRaise( Uri uri, EndPoint endPoint, Socket socket )
    {
      socket.ResponseFailedRaise( uri, endPoint, socket, null );
    }

    #endregion Response

    #region Main

    private string EndPointGetString( EndPoint endPoint )
    {
      string endPointString = "n/a";
      if ( endPoint is IPEndPoint )
      {
        IPEndPoint ipEndPoint = ( endPoint as IPEndPoint );
        endPointString = string.Format( "{0}:{1}",
                                        ipEndPoint.Address,
                                        ipEndPoint.Port );
      }
      if ( endPoint is DnsEndPoint )
      {
        DnsEndPoint dnsEndPoint = ( endPoint as DnsEndPoint );
        endPointString = string.Format( "{0}:{1}",
                                        dnsEndPoint.Host,
                                        dnsEndPoint.Port );
      }
      return endPointString;
    }

    /// <summary>Sends a request to a specified URI and / or endpoint.</summary>
    /// <param name="uri">The URI to send the request to.</param>
    /// <param name="endPoint">The endpoint to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycle( Uri uri, EndPoint endPoint, bool keepAlive )
    {
      try
      {
        if ( false == this.Connected )
        {
          this.Connect( endPoint );
        }
        if ( false == this.Connected )
        {
          this.ConnectFailedRaise( uri, endPoint, this );
        }
        else
        {
          this.ConnectSucceedRaise( uri, endPoint, this );
          try
          {
            int requestOffset = 0;
            int bufferSize = 0;
            int bufferSizeWritten = 0;
            do
            {
              bufferSize = this.BufferSize > this.RequestDataStreamInternal.Length - requestOffset
                         ? ( int ) this.RequestDataStreamInternal.Length - requestOffset
                         : this.BufferSize;
              if ( 0 < bufferSize )
              {
                bufferSizeWritten = this.Send( this.RequestDataBytesInternal, requestOffset, bufferSize, SocketFlags.None );
                requestOffset += bufferSizeWritten;
                Console.WriteLine( "Write::{0}::{1}::{2}", bufferSizeWritten, bufferSize, this.RequestDataStreamInternal.Length );
              }
            }
            while ( 0 < bufferSize
                    || bufferSizeWritten < bufferSize );
            this.RequestSucceedRaise( uri, endPoint, this );
            try
            {
              this.ResponseDataStream.SetLength( 0 );
              byte[ ] buffer = new byte[ this.BufferSize ];
              int bufferSizeRead = 0;
              do
              {
                bufferSizeRead = this.Receive( buffer, 0, this.BufferSize, SocketFlags.None );
                if ( 0 < bufferSizeRead )
                {
                  this.ResponseDataStream.Write( buffer, 0, bufferSizeRead );
                  Console.WriteLine( "Read::" + bufferSizeRead );
                }
              }
              while ( 0 < bufferSizeRead );
              this.ResponseSucceedRaise( uri, endPoint, this );
              if ( false == keepAlive )
              {
                Console.WriteLine( "KeepAlive" );
                try
                {
                  this.Close( );
                  this.DisconnectSucceedRaise( uri, endPoint, this );
                }
                catch ( Exception exception )
                {
                  this.DisconnectFailedRaise( uri, endPoint, this, exception );
                }
              }
            }
            catch ( Exception exception )
            {
              this.ResponseFailedRaise( uri, endPoint, this, exception );
            }
          }
          catch ( Exception exception )
          {
            this.RequestFailedRaise( uri, endPoint, this, exception );
          }
        }
      }
      catch ( Exception exception )
      {
        this.ConnectFailedRaise( uri, endPoint, this, exception );
      }
    }

    /// <summary>Sends a request to a specified endpoint.</summary>
    /// <param name="endPoint">The endpoint to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycle( EndPoint endPoint, bool keepAlive )
    {
      this.RequestCycle( null, endPoint, keepAlive );
    }

    /// <summary>Sends a request to a specified URI.</summary>
    /// <param name="uri">The URI to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycle( Uri uri, bool keepAlive )
    {
      EndPoint endPoint = null;
      try
      {
        endPoint = uri.EndPointGet( this.AddressFamily, 0 );
        this.EndPointConversionSucceedRaise( uri, endPoint, this );
      }
      catch ( Exception exception )
      {
        this.EndPointConversionFailedRaise( uri, this, exception );
      }
      this.RequestCycle( uri, endPoint, keepAlive );
    }

    /// <summary>Sends a request to a specified URI.</summary>
    /// <param name="uri">The URI to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycle( string uri, bool keepAlive )
    {
      Uri uriConverted = null;
      try
      {
        uriConverted = new Uri( uri );
        this.UriConversionSucceedRaise( uriConverted, this );
      }
      catch ( Exception exception )
      {
        this.UriConversionFailedRaise( uri, this, exception );
      }
      this.RequestCycle( uriConverted, keepAlive );
    }

    /// <summary>Send a request to the last used connection.</summary>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycle( bool keepAlive )
    {
      this.RequestCycle( null, null, keepAlive );
    }

    /// <summary>Sends a request asynchronously to a specified endpoint.</summary>
    /// <param name="endPoint">The endpoint to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public void RequestCycleAsync( EndPoint endPoint, bool keepAlive )
    {
      ThreadHelper.StartDirect(
        ( ) =>
        {
          this.RequestCycle( endPoint, keepAlive );
        }
      );
    }

    /// <summary>Sends a request asynchronously to a specified URI.</summary>
    /// <param name="uri">The URI to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public void RequestCycleAsync( Uri uri, bool keepAlive )
    {
      ThreadHelper.StartDirect(
        ( ) =>
        {
          this.RequestCycle( uri, keepAlive );
        }
      );
    }

    /// <summary>Sends a request asynchronously to a specified URI.</summary>
    /// <param name="uri">The URI to send the request to.</param>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public void RequestCycleAsync( string uri, bool keepAlive )
    {
      ThreadHelper.StartDirect(
        ( ) =>
        {
          this.RequestCycle( uri, keepAlive );
        }
      );
    }

    /// <summary>Send a request asynchronously to the last used connection.</summary>
    /// <param name="keepAlive">Forces the socket to keep the connection alive for further requests.</param>
    public virtual void RequestCycleAsynch( bool keepAlive )
    {
      ThreadHelper.StartDirect(
        ( ) =>
        {
          this.RequestCycle( keepAlive );
        }
      );
    }

    #endregion Main

    #endregion Methods
  }
}