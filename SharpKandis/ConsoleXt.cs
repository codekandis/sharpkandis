using System;
using System.Collections.Generic;
using System.Linq;
using SharpKandis.Collections.Generic;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all <i>System.Console</i> classes.</summary>
	public static class ConsoleXt
	{
		/// <summary>Gets the concatenated <i>string</i> representation of each element of the generic array.</summary>
		/// <param name="reference">The generic array to get the concatenated <i>string</i> representation of each element.</param>
		/// <returns>The concatenated <i>string</i> representation of each element of the generic array.</returns>
		public static string ToStringAll( this byte[ ] reference )
		{
			string stringAll = string.Empty;
			reference.ForEach(
				( byte elementFetched ) =>
				{
					stringAll += ( ( char ) elementFetched ).ToString( );
				}
			);
			return stringAll;
		}

		public static char Read( char[ ] charactersAllowed, bool caseSensitive )
		{
			char input = default( char );
			if ( null != charactersAllowed && 0 != charactersAllowed.Length )
			{
				if ( false == caseSensitive )
				{
					IEnumerable<char> charactersAllowedLower =
						(
						from
							char characterAllowedFetched
						in
							charactersAllowed
						select
							char.ToLower( characterAllowedFetched )
						)
						.Distinct( );
					charactersAllowed = charactersAllowedLower.ToArray( );
				}
				bool inputMatched = false;
				do
				{
					input = Console.ReadKey( true ).KeyChar;
					if ( false == caseSensitive )
					{
						input = char.ToLower( input );
					}
					inputMatched = charactersAllowed.Contains( input );
				}
				while ( false == inputMatched );
				Console.Write( input );
			}
			return input;
		}

		public static char Read( char[ ] charactersAllowed )
		{
			char input = ConsoleXt.Read( charactersAllowed, false );
			return input;
		}
	}
}
