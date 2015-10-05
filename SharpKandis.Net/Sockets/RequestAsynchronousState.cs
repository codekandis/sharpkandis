namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents an asynchronous state of an asynchronous request.</summary>
  public class RequestAsynchronousState
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI the request asynchronous state depends on.</summary>
    private Uri uri = null;

    /// <summary>Gets / sets the URI the request asynchronous state depends on.</summary>
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

    /// <summary>Stores the socket the request asynchronous state depends on.</summary>
    private Socket socket = null;

    /// <summary>Gets / sets the socket the request asynchronous state depends on.</summary>
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

    #region BufferOffset

    /// <summary>Stores the offset of the buffer of the socket of the request asynchronous state.</summary>
    private int bufferOffset = 0;

    /// <summary>Gets / sets the offset of the buffer of the socket of the request asynchronous state.</summary>
    public virtual int BufferOffset
    {
      get
      {
        return this.bufferOffset;
      }
      private set
      {
        this.bufferOffset = value;
      }
    }

    #endregion BufferOffset

    #endregion Properties

    #region Constructors

    /// <summary>Initializes the instance of <i>RequestAsynchronousState</i> depending on the socket and the URI.</summary>
    /// <param name="uri">The URI of the request asynchronous state.</param>
    /// <param name="socket">The socket of the request asynchronous state.</param>
    /// <param name="bufferOffset">The offset of the buffer of the socket of the request asynchronous state to request.</param>
    public RequestAsynchronousState( Uri uri, Socket socket, int bufferOffset)
    {
      this.Uri = uri;
      this.Socket = socket;
      this.BufferOffset = bufferOffset;
    }

    #endregion Constructors
  }
}