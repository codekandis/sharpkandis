namespace SharpKandis.Net.Sockets
{
  using System;

  /// <summary>Represents the exception if an URI conversion has been failed.</summary>
  public class UriConversionFailedException:
    Exception
  {
    #region Constructors

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.UriConversionFailedException</i>.</summary>
    public UriConversionFailedException( ) :
      base( )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.UriConversionFailedException</i> with a specified exception message.</summary>
    /// <param name="message">The message that describes the exception.</param>
    public UriConversionFailedException( string message ) :
      base( message )
    {
    }

    /// <summary>Initializes a new instance of <i>SharpKandis.Net.Sockets.UriConversionFailedException</i> with a specified message and a specified inner exception the exception depends on.</summary>
    /// <param name="message">The message that describes the exception.</param>
    /// <param name="innerException">The inner exception that caused the exception, or <i>null</i> if none exists.</param>
    public UriConversionFailedException( string message, Exception innerException ) :
      base( message, innerException )
    {
    }

    #endregion Constructors
  }
}