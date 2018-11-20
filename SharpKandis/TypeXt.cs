using System;
using System.Collections.Generic;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all <i>System.Type</i> classes.</summary>
	public static class TypeXt
	{
		/// <summary>Removes the generic dimension from the type name.</summary>
		/// <param name="name">The name of the type.</param>
		/// <returns>The name of the type without the generic dimension.</returns>
		private static string RemoveGenericDimension( string name )
		{
			string processedName = name;
			if ( processedName.Contains( "`" ) )
			{
				processedName = processedName.Substring( 0, processedName.IndexOf( '`' ) );
			}
			return processedName;
		}

		/// <summary>Gets the name of the type without assembly information and without a generic dimension.</summary>
		/// <param name="reference">The type to get its name.</param>
		/// <returns>The name of the type without assembly information and without a generic dimension.</returns>
		public static string GetProcessedName( this Type reference )
		{
			string processedName = typeof( void ) == reference
								   ? "void"
								   : TypeXt.RemoveGenericDimension( reference.Name );
			return processedName;
		}

		/// <summary>Gets the full name of the type including the namespace, without assembly information and without a generic dimension.</summary>
		/// <param name="reference">The type to get its full name.</param>
		/// <returns>The full name of the type including the namespace, without assembly information and without a generic dimension.</returns>
		public static string GetProcessedNameFull( this Type reference )
		{
			string processedNameFull = typeof( void ) == reference
									   ? "void"
									   : reference.Namespace + '.' + reference.GetProcessedName( );
			return processedNameFull;
		}

		/// <summary>Gets the name of the generic type without assembly information and without a generic dimension.</summary>
		/// <param name="reference">The generic type to get its name.</param>
		/// <returns>The name of the generic type without assembly information and without a generic dimension.</returns>
		public static string GetProcessedNameGeneric( this Type reference )
		{
			string processedNameGeneric = reference.GetProcessedName( );
			if ( true == reference.IsGenericType )
			{
				processedNameGeneric += '<';
				List<string> processedNamesGenericArguments = new List<string>( );
				foreach ( Type typeGeneric in reference.GetGenericArguments( ) )
				{
					string processedNameGenericArgument = typeGeneric.GetProcessedNameGeneric( );
					processedNamesGenericArguments.Add( processedNameGenericArgument );
				}
				processedNameGeneric += string.Join( ",", processedNamesGenericArguments );
				processedNameGeneric += '>';
			}
			return processedNameGeneric;
		}

		/// <summary>Gets the full name of the generic type including the namespace, without assembly information and without a generic dimension.</summary>
		/// <param name="reference">The generic type to get its full name.</param>
		/// <returns>The full name of the generic type including the namespace, without assembly information and without a generic dimension.</returns>
		public static string GetProcessedNameGenericFull( this Type reference )
		{
			string processedNameGenericFull = reference.GetProcessedNameFull( );
			if ( true == reference.IsGenericType )
			{
				processedNameGenericFull += '<';
				List<string> processedNamesGenericFullArguments = new List<string>( );
				foreach ( Type typeGeneric in reference.GetGenericArguments( ) )
				{
					string processedNameGenericFullArgument = typeGeneric.GetProcessedNameGenericFull( );
					processedNamesGenericFullArguments.Add( processedNameGenericFullArgument );
				}
				processedNameGenericFull += string.Join( ",", processedNamesGenericFullArguments );
				processedNameGenericFull += '>';
			}
			return processedNameGenericFull;
		}
	}
}
