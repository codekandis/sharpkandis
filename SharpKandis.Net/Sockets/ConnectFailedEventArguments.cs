namespace SharpKandis.Net.Sockets
{
  using System;
  using System.Net;

  /// <summary>Represents the event arguments of a <i>ConnectFailed</i> event.</summary>
  public class ConnectFailedEventArguments :
    EventArgs
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI of the event arguments.</summary>
    private Uri uri = null;

    /// <summary>Gets / sets the URI of the event arguments.</summary>
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

    #region EndPoint

    /// <summary>Stores the endpoint of the event arguments.</summary>
    private EndPoint endPoint = null;

    /// <summary>Gets / sets the endpoint of the event arguments.</summary>
    public virtual EndPoint EndPoint
    {
      get
      {
        return this.endPoint;
      }
      private set
      {
        this.endPoint = value;
      }
    }

    #endregion EndPoint

    #region Socket

    /// <summary>Stores the socket of the event arguments.</summary>
    private Socket socket = null;

    /// <summary>Gets / sets the socket of the event arguments.</summary>
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

    #region Exception

    /// <summary>Stores the exception of the event arguments.</summary>
    private Exception exception = null;

    /// <summary>Gets / sets the exception of the event arguments.</summary>
    public virtual Exception Exception
    {
      get
      {
        return this.exception;
      }
      private set
      {
        this.exception = value;
      }
    }

    #endregion Exception

    #endregion Properties

    #region Constructors

    /// <summary>Initializes the instance of <i>ConnectFailedEventArguments</i> depending on a specified socket and a specified exception.</summary>
    /// <param name="uri">The URI the event arguments depending on.</param>
    /// <param name="endPoint">The endpoint the event arguments depending on.</param>
    /// <param name="socket">The socket the event arguments depending on.</param>
    /// <param name="exception">The exception the event arguments depending on.</param>
    public ConnectFailedEventArguments( Uri uri, EndPoint endPoint, Socket socket, Exception exception )
    {
      this.Uri = uri;
      this.EndPoint = endPoint;
      this.Socket = socket;
      this.Exception = exception;
    }

    #endregion Constructors
  }
}