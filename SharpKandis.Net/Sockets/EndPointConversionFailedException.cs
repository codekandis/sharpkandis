namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents the exception if an endpoint conversion has been failed.</summary>
  public class EndPointConversionFailedException :
    Exception
  {
    #region Constructors

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.EndPointConversionFailedException</i>.</summary>
    public EndPointConversionFailedException( ) :
      base( )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.EndPointConversionFailedException</i> with a specified exception message.</summary>
    /// <param name="message">The message that describes the exception.</param>
    public EndPointConversionFailedException( string message ) :
      base( message )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.EndPointConversionFailedException</i> with a specified message and a specified inner exception the exception depends on.</summary>
    /// <param name="message">The message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused the exception, or <i>null</i> if.</param>
    public EndPointConversionFailedException( string message, Exception innerException ) :
      base( message, innerException )
    {
    }

    #endregion Constructors
  }
}