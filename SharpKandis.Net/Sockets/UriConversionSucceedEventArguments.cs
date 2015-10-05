namespace SharpKandis.Net.Sockets
{
  using System;
  using System.Net;

  /// <summary>Represents the event arguments of a <i>UriConversionSucceed</i> event.</summary>
  public class UriConversionSucceedEventArguments :
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

    /// <summary>Initializes the instance of <i>UriConversionSucceedEventArguments</i> depending on a specified socket.</summary>
    /// <param name="uri">The URI the event arguments depending on.</param>
    /// <param name="socket">The socket the event arguments depending on.</param>
    public UriConversionSucceedEventArguments( Uri uri, Socket socket )
    {
      this.Uri = uri;
      this.Socket = socket;
    }

    #endregion Constructors
  }
}