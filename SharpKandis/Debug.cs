using System.Collections.Generic;
using System.IO;

/// <summary>Represents a class for debugging purposes.</summary>
static public class Debug
{
	/// <summary>Stores the list of <i>TextWriter</i> instances of the logger.</summary>
	static private IList<TextWriter> textWriters = null;

	/// <summary>Gets the list of <i>TextWriter</i> instances of the logger.</summary>
	static private IList<TextWriter> TextWriters
	{
		get
		{
			if ( null == Debug.textWriters )
			{
				Debug.textWriters = new List<TextWriter>( );
			}
			return Debug.textWriters;
		}
	}

	/// <summary>Stores the <i>Stream</i> instances of the logger.</summary>
	static private IList<Stream> streams = null;

	/// <summary>Gets the <i>Stream</i> instances of the logger.</summary>
	static private IList<Stream> Streams
	{
		get
		{
			if ( null == Debug.streams )
			{
				Debug.streams = new List<Stream>( );
			}
			return Debug.streams;
		}
	}

	/// <summary>Adds a <i>TextWriter</i> instance to the logger.</summary>
	/// <param name="textWriter">The <i>TextWriter</i> instance to add.</param>
	static public void AddTextWriter( TextWriter textWriter )
	{
		Debug.TextWriters.Add( textWriter );
	}

	/// <summary>Removes a <i>TextWriter</i> instance from the logger.</summary>
	/// <param name="textWriter">The <i>TextWriter</i> instance to remove.</param>
	static public void RemoveTextWriter( TextWriter textWriter )
	{
		Debug.TextWriters.Remove( textWriter );
	}

	/// <summary>Adds a <i>Stream</i> instance to the logger.</summary>
	/// <param name="textWriter">The <i>Stream</i> instance to add.</param>
	static public void AddStream( Stream stream )
	{
		Debug.Streams.Add( stream );
	}

	/// <summary>Removes a <i>Stream</i> instance from the logger.</summary>
	/// <param name="textWriter">The <i>Stream</i> instance to remove.</param>
	static public void RemoveStream( Stream stream )
	{
		Debug.Streams.Remove( stream );
	}

	/// <summary>Logs a message with specified values to the registered <i>TextWriter</i> and <i>Stream</i> instances.</summary>
	/// <param name="reference">The reference of the log.</param>
	/// <param name="values">The values to log.</param>
	static public void Log( object reference, params object[ ] values )
	{
#if false == DEBUG
#else
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
