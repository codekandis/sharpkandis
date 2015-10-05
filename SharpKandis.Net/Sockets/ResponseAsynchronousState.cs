namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents an asynchronous state of an asynchronous response.</summary>
  public class ResponseAsynchronousState
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI the response asynchronous state depends on.</summary>
    private Uri uri = null;

    /// <summary>Gets / sets the URI the response asynchronous state depends on.</summary>
    public virtual Uri Uri
    {
      get
      {
        return this.uri;
      }
      private set
      {
        this.uri = value;
      }
    }

    #endregion Uri

    #region Socket

    /// <summary>Stores the socket the response asynchronous state depends on.</summary>
    private Socket socket = null;

    /// <summary>Gets / sets the socket the response asynchronous state depends on.</summary>
    public virtual Socket Socket
    {
      get
      {
        return this.socket;
      }
      private set
      {
        this.socket = value;
      }
    }

    #endregion Socket

    #region Buffer

    /// <summary>Stores the buffer of the socket of the response asynchronous state.</summary>
    private byte[ ] buffer = null;

    /// <summary>Gets / sets the buffer of the socket of the response asynchronous state.</summary>
    public virtual byte[ ] Buffer
    {
      get
      {
        if ( null == this.buffer )
        {
          this.buffer = new byte[ this.Socket.BufferSize ];
        }
        return this.buffer;
      }
      private set
      {
        this.buffer = value;
      }
    }

    #endregion Buffer

    #endregion Properties

    #region Constructors

    /// <summary>Initializes the instance of <i>ResponseAsynchronousState</i> depending on the socket and the URI.</summary>
    /// <param name="uri">The URI of the response asynchronous state.</param>
    /// <param name="socket">The socket of the response asynchronous state.</param>
    public ResponseAsynchronousState( Uri uri, Socket socket )
    {
      this.Uri = uri;
      this.Socket = socket;
    }

    #endregion Constructors
  }
}