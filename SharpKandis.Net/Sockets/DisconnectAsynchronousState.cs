namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents an asynchronous state of an asynchronous disconnect.</summary>
  public class DisconnectAsynchronousState
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI the disconnect asynchronous state depends on.</summary>
    private Uri uri = null;

    /// <summary>Gets / sets the URI the disconnect asynchronous state depends on.</summary>
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

    /// <summary>Stores the socket the disconnect asynchronous state depends on.</summary>
    private Socket socket = null;

    /// <summary>Gets / sets the socket the disconnect asynchronous state depends on.</summary>
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

    #endregion Properties

    #region Constructors

    /// <summary>Initializes the instance of <i>DisconnectAsynchronousState</i> depending on the socket and the URI.</summary>
    /// <param name="uri">The URI of the disconnect asynchronous state.</param>
    /// <param name="socket">The socket of the disconnect asynchronous state.</param>
    public DisconnectAsynchronousState( Uri uri, Socket socket )
    {
      this.Uri = uri;
      this.Socket = socket;
    }

    #endregion Constructors
  }
}