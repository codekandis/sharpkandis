namespace SharpKandis.Net.Sockets
{
  using System;
  using System.Net;

  /// <summary>Represents the event arguments of a <i>EndPointConversionSucceed</i> event.</summary>
  public class EndPointConversionSucceedEventArguments :
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

    #endregion Properties

    #region Constructors

    /// <summary>Initializes the instance of <i>EndPointConversionSucceedEventArguments</i> depending on a specified socket.</summary>
    /// <param name="uri">The URI the event arguments depending on.</param>
    /// <param name="endPoint">The endpoint the event arguments depending on.</param>
    /// <param name="socket">The socket the event arguments depending on.</param>
    public EndPointConversionSucceedEventArguments( Uri uri, EndPoint endPoint, Socket socket )
    {
      this.Uri = uri;
      this.EndPoint = endPoint;
      this.Socket = socket;
    }

    #endregion Constructors
  }
}