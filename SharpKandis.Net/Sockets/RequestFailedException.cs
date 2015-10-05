namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents the exception if a request has been failed.</summary>
  public class RequestFailedException :
    Exception
  {
    #region Constructors

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.RequestFailedException</i>.</summary>
    public RequestFailedException( ) :
      base( )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.RequestFailedException</i> with a specified exception message.</summary>
    /// <param name="message">The message that describes the exception.</param>
    public RequestFailedException( string message ) :
      base( message )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.RequestFailedException</i> with a specified message and a specified inner exception the exception depends on.</summary>
    /// <param name="message">The message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused the exception, or <i>null</i> if.</param>
    public RequestFailedException( string message, Exception innerException ) :
      base( message, innerException )
    {
    }

    #endregion Constructors
  }
}