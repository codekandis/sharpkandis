using System.Linq;
using SharpKandis.Collections.Generic;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all generic <i>System.Array</i> classes.</summary>
	public static class ArrayXt
	{
		/// <summary>Concatenates a various amount of specified generic arrays into one generic array.</summary>
		/// <typeparam name="TElement">The type of the elements of the generic arrays to concatenate.</typeparam>
		/// <param name="reference">The generic array to concatenate the generic arrays passed in the argument <i>arrays</i> with.</param>
		/// <param name="arrays">The generic arrays to be concatenated with the generic array passed in the argument <i>reference</i>.</param>
		/// <returns>The concatenated generic arrays.</returns>
		public static TElement[ ] ConcatAll<TElement>( this TElement[ ] reference, params TElement[ ][ ] arrays )
		{
			TElement[ ] concatenated = reference;
			arrays.ForEach(
				( TElement[ ] elementFetched ) =>
				{
					concatenated = concatenated.Concat( elementFetched ).ToArray( );
				}
			);
			return concatenated;
		}

		/// <summary>Gets a slice of a specified generic array.</summary>
		/// <typeparam name="TElement">The type of the elements of the generic array to get the slice from.</typeparam>
		/// <param name="reference">The generic array to get the slice from.</param>
		/// <param name="offset">The offset to start getting the slice from.</param>
		/// <param name="count">The length of the slice to get.</param>
		/// <returns>The slice from the generic array.</returns>
		public static TElement[ ] Slice<TElement>( this TElement[ ] reference, int offset, int count )
		{
			return reference.Skip( offset ).Take( count ).ToArray( );
		}
	}
}
