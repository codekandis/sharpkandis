namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents an asynchronous state of an asynchronous connect.</summary>
  public class ConnectAsynchronousState
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI the connect asynchronous state depends on.</summary>
    private Uri uri = null;

    /// <summary>Gets / sets the URI the connect asynchronous state depends on.</summary>
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

    /// <summary>Stores the socket the connect asynchronous state depends on.</summary>
    private Socket socket = null;

    /// <summary>Gets / sets the socket the connect asynchronous state depends on.</summary>
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

    /// <summary>Initializes the instance of <i>ConnectAsynchronousState</i> depending on the socket and the URI.</summary>
    /// <param name="uri">The URI of the connect asynchronous state.</param>
    /// <param name="socket">The socket of the connect asynchronous state.</param>
    public ConnectAsynchronousState( Uri uri, Socket socket )
    {
      this.Uri = uri;
      this.Socket = socket;
    }

    #endregion Constructors
  }
}