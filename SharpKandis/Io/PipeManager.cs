﻿using System;
using System.Collections.Generic;

namespace SharpKandis.Io
{
	/// <summary>Represents a pipe manager.</summary>
	public class PipeManager
	{
		/// <summary>Gets the piped input from the standard input stream.</summary>
		/// <returns>The piped input from the standard input stream.</returns>
		public IList<string> InputGet( )
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
	}
}