using SharpKandis.Collections.Generic;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all <i>System.byte[ ]</i> classes.</summary>
	public static class ByteArrayXt
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
	}
}
