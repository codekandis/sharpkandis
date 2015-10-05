namespace SharpKandis.Io
{
  using System;
  using System.Collections.Generic;

  /// <summary>Represents a pipe manager.</summary>
  public static class PipeManager
  {
    #region Methods

    /// <summary>Gets the piped input from the StdIn stream.</summary>
    /// <returns>The piped input from the StdIn stream.</returns>
    public static IList<string> InputGet( )
    {
      IList<string> input = new List<string>( );
      if ( true == Console.IsInputRedirected )
      {
        string line = default( string );
        while ( null != ( line = Console.ReadLine( ) ) )
        {
          input.Add( line );
        }
      }
      return input;
    }

    #endregion Methods
  }
}