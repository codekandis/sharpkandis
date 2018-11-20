using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all <i>System.Enum</i> classes.</summary>
	public static class EnumXt
	{
		/// <summary>Gets the <i>string</i> counterparts of of an enumeration member considering the <i>System.ComponentModel.DescriptionAttribute</i> providing an user defined name.</summary>
		/// <typeparam name="TEnumeration">The type of the enumeration member passed in the argument <i>enumerationMember</i> to gets its name.</typeparam>
		/// <param name="reference">The enumeration member to gets its name.</param>
		/// <returns>The name of the enumeration member passed in the argument <i>enumerationMember</i>.</returns>
		public static string ToStringUser<TEnumeration>( this TEnumeration reference )
			where TEnumeration : struct
		{
			string enumerationMemberName = null;
			Type typeEnumeration = typeof( TEnumeration );
			if ( false == typeEnumeration.IsEnum )
			{
				throw new ArgumentException( "The value passed in type must be of type", "enumeration" );
			}
			string enumerationMemberNameOrigin = reference.ToString( );
			IEnumerable<MemberInfo> enumerationMemberInformations =
				from
					MemberInfo enumerationMemberInfoFetched
				in
					typeEnumeration.GetMember( enumerationMemberNameOrigin )
				select
					enumerationMemberInfoFetched;
			if ( 0 < enumerationMemberInformations.Count( ) )
			{
				IEnumerable<DescriptionAttribute> enumerationMemberAttributes =
					from
						DescriptionAttribute enumerationMemberAttributeFetched
					in
						enumerationMemberInformations.ElementAt( 0 ).GetCustomAttributes( typeof( DescriptionAttribute ), false )
					select
						enumerationMemberAttributeFetched;
				if ( 0 == enumerationMemberAttributes.Count( ) )
				{
					enumerationMemberName = reference.ToString( );
				}
				else
				{
					enumerationMemberName = enumerationMemberAttributes.First( ).Description;
				}
			}
			return enumerationMemberName;
		}
	}
}
