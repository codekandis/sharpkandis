using System.Collections.Generic;
using System.IO;

/// <summary>Represents a class for debugging purposes.</summary>
public static class Debug
{
	/// <summary>Stores the list of <i>TextWriter</i> instances of the logger.</summary>
	private static IList<TextWriter> textWriters = null;

	/// <summary>Gets the list of <i>TextWriter</i> instances of the logger.</summary>
	private static IList<TextWriter> TextWriters
	{
		get
		{
			return Debug.textWriters ?? ( Debug.textWriters = new List<TextWriter>( ) );
		}
	}

	/// <summary>Stores the <i>Stream</i> instances of the logger.</summary>
	private static IList<Stream> streams = null;

	/// <summary>Gets the <i>Stream</i> instances of the logger.</summary>
	private static IList<Stream> Streams
	{
		get
		{
			return Debug.streams ?? ( Debug.streams = new List<Stream>( ) );
		}
	}

	/// <summary>Adds a <i>TextWriter</i> instance to the logger.</summary>
	/// <param name="textWriter">The <i>TextWriter</i> instance to add.</param>
	public static void AddTextWriter( TextWriter textWriter )
	{
		Debug.TextWriters.Add( textWriter );
	}

	/// <summary>Removes a <i>TextWriter</i> instance from the logger.</summary>
	/// <param name="textWriter">The <i>TextWriter</i> instance to remove.</param>
	public static void RemoveTextWriter( TextWriter textWriter )
	{
		Debug.TextWriters.Remove( textWriter );
	}

	/// <summary>Adds a <i>Stream</i> instance to the logger.</summary>
	/// <param name="textWriter">The <i>Stream</i> instance to add.</param>
	public static void AddStream( Stream stream )
	{
		Debug.Streams.Add( stream );
	}

	/// <summary>Removes a <i>Stream</i> instance from the logger.</summary>
	/// <param name="textWriter">The <i>Stream</i> instance to remove.</param>
	public static void RemoveStream( Stream stream )
	{
		Debug.Streams.Remove( stream );
	}

	/// <summary>Logs a message with specified values to the registered <i>TextWriter</i> and <i>Stream</i> instances.</summary>
	/// <param name="reference">The reference of the log.</param>
	/// <param name="values">The values to log.</param>
	public static void Log( object reference, params object[ ] values )
	{
#if true == DEBUG
		string valuesJoined = string.Join( " :: ", values );
		string bufferString = string.Format( "[{0}] {1}",
											 reference,
											 valuesJoined );
		foreach ( TextWriter textWriter in Debug.TextWriters )
		{
			textWriter.WriteLine( bufferString );
		}
		foreach ( Stream stream in Debug.Streams )
		{
			TextWriter textWriter = new StreamWriter( stream );
			textWriter.WriteLine( bufferString );
		}
#endif
	}
}
