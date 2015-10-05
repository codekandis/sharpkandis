namespace SharpKandis.Net.Sockets
{
  using System;
  using System.Net;

  /// <summary>Represents the event arguments of a <i>UriConversionFailed</i> event.</summary>
  public class UriConversionFailedEventArguments :
    EventArgs
  {
    #region Properties

    #region Uri

    /// <summary>Stores the URI of the event arguments.</summary>
    private string uri = null;

    /// <summary>Gets / sets the URI of the event arguments.</summary>
    public virtual string Uri
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

    /// <summary>Initializes the instance of <i>UriConversionFailedEventArguments</i> depending on a specified socket and a specified exception.</summary>
    /// <param name="uri">The URI the event arguments depending on.</param>
    /// <param name="endPoint">The endpoint the event arguments depending on.</param>
    /// <param name="socket">The socket the event arguments depending on.</param>
    /// <param name="exception">The exception the event arguments depending on.</param>
    public UriConversionFailedEventArguments( string uri, Socket socket, Exception exception )
    {
      this.Uri = uri;
      this.Socket = socket;
      this.Exception = exception;
    }

    #endregion Constructors
  }
}