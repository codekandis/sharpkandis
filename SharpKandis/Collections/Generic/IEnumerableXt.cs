using System.Collections.Generic;
using System.Linq;

namespace SharpKandis.Collections.Generic
{
	/// <summary>
	/// Represents an extension class for all generic <i>System.Collections.Generic.IEnumerable&lt;T&gt;</i> classes.
	/// </summary>
	public static class IEnumerableXt
	{
		/// <summary>
		/// Defines the ForEach callback delegate providing the fetched element.
		/// </summary>
		/// <typeparam name="TElementFetched">The type of the fetched element.</typeparam>
		/// <param name="elementFetched">The fetched element.</param>
		public delegate void ForEachDelegateFetched<TElementFetched>( TElementFetched elementFetched );

		/// <summary>
		/// Defines the ForEach callback delegate providing the index of the fetched element and the fetched element itself.
		/// </summary>
		/// <typeparam name="TElementIndex">The type of the index of the fetched element.</typeparam>
		/// <typeparam name="TElementFetched">The type of the fetched element.</typeparam>
		/// <param name="elementIndex">The index of the fetched element.</param>
		/// <param name="elementFetched">The fetched element.</param>
		public delegate void ForEachDelegateIndexFetched<TElementIndex, TElementFetched>( TElementIndex elementIndex, TElementFetched elementFetched );

		/// <summary>
		/// Invokes a specified callback on any element of a specified generic enumerable.
		/// </summary>
		/// <typeparam name="TElement">The type of all elements of the generic enumerable passed in the argument <i>reference</i>.</typeparam>
		/// <param name="reference">The generic enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
		/// <param name="callback">The callback to invoke on any element of the generic enumerable passed in the argument <i>reference</i>. The callback provides the fetched element itself.</param>
		public static void ForEach<TElement>( this IEnumerable<TElement> reference, ForEachDelegateFetched<TElement> callback )
		{
			foreach ( TElement referenceFetched in reference )
			{
				callback( referenceFetched );
			}
		}

		/// <summary>
		/// Invokes a specified callback on any element of a specified generic enumerable.
		/// </summary>
		/// <typeparam name="TElement">The type of all elements of the generic enumerable passed in the argument <i>reference</i>.</typeparam>
		/// <param name="reference">The generic enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
		/// <param name="callback">The callback to invoke on any element of the generic enumerable passed in the argument <i>reference</i>. The callback provides the index of the fetched element and the fetched element itself.</param>
		public static void ForEach<TElement>( this IEnumerable<TElement> reference, ForEachDelegateIndexFetched<int, TElement> callback )
		{
			for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count( ); referenceFetchedIndex++ )
			{
				TElement referenceFetched = reference.ElementAt( referenceFetchedIndex );
				callback( referenceFetchedIndex, referenceFetched );
			}
		}

		/// <summary>
		/// Invokes a specified callback on any element of a specified generic enumerable.
		/// </summary>
		/// <typeparam name="TElement">The type of all elements of the generic enumerable passed in the argument <i>reference</i>.</typeparam>
		/// <param name="reference">The generic enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
		/// <param name="callbacks">The list of callbacks to invoke on any element of the generic enumerable passed in the argument <i>reference</i>. Each callback provides the the fetched element itself.</param>
		public static void ForEach<TElement>( this IEnumerable<TElement> reference, IEnumerable<ForEachDelegateFetched<TElement>> callbacks )
		{
			foreach ( TElement referenceFetched in reference )
			{
				callbacks.ForEach(
					( ForEachDelegateFetched<TElement> callbackFetched ) =>
					{
						callbackFetched( referenceFetched );
					}
				);
			}
		}

		/// <summary>
		/// Invokes a specified callback on any element of a specified generic enumerable.
		/// </summary>
		/// <typeparam name="TElement">The type of all elements of the generic enumerable passed in the argument <i>reference</i>.</typeparam>
		/// <param name="reference">The generic enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
		/// <param name="callbacks">The list of callbacks to invoke on any element of the generic enumerable passed in the argument <i>reference</i>. Each callback provides the index of the fetched element and the fetched element itself.</param>
		public static void ForEach<TElement>( this IEnumerable<TElement> reference, IEnumerable<ForEachDelegateIndexFetched<int, TElement>> callbacks )
		{
			for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count( ); referenceFetchedIndex++ )
			{
				callbacks.ForEach(
					( ForEachDelegateIndexFetched<int, TElement> callbackFetched ) =>
					{
						TElement referenceFetched = reference.ElementAt( referenceFetchedIndex );
						callbackFetched( referenceFetchedIndex, referenceFetched );
					}
				);
			}
		}
	}
}
