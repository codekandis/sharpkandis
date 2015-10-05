namespace SharpKandis.Collections.Generic
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>Represents an extension class for all <i>System.Collections.Generic.IEnumerable&lt;T&gt;</i> classes.</summary>
  public static class IEnumerableXt
  {
    #region Methods

    /// <summary>Invokes a specified callback on any element of a specified enumerable.</summary>
    /// <param name="reference">The enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callback">The callback to invoke on any element of the enumerable passed in the argument <i>reference</i>.</param>
    public static void ForEach<TElement>( this IEnumerable<TElement> reference, Action<TElement> callback )
    {
      foreach ( TElement referenceFetched in reference )
      {
        callback( referenceFetched );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified enumerable.</summary>
    /// <param name="reference">The enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callback">The callback to invoke on any element of the enumerable passed in the argument <i>reference</i>.</param>
    public static void ForEach<TElement>( this IEnumerable<TElement> reference, Action<int, TElement> callback )
    {
      for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count( ); referenceFetchedIndex++ )
      {
        TElement referenceFetched = reference.ElementAt( referenceFetchedIndex );
        callback( referenceFetchedIndex, referenceFetched );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified enumerable.</summary>
    /// <param name="reference">The enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callbacks">The list of callbacks to invoke on any element of the enumerable passed in the argument <i>reference</i>.</param>
    public static void ForEach<TElement>( this IEnumerable<TElement> reference, IEnumerable<Action<TElement>> callbacks )
    {
      foreach ( TElement referenceFetched in reference )
      {
        callbacks.ForEach(
          ( Action<TElement> callbackFetched ) =>
          {
            callbackFetched( referenceFetched );
          }
        );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified enumerable.</summary>
    /// <param name="reference">The enumerable to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callbacks">The list of callbacks to invoke on any element of the enumerable passed in the argument <i>reference</i>.</param>
    public static void ForEach<TElement>( this IEnumerable<TElement> reference, IEnumerable<Action<int, TElement>> callbacks )
    {
      for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count( ); referenceFetchedIndex++ )
      {
        callbacks.ForEach(
          ( Action<int, TElement> callbackFetched ) =>
          {
            TElement referenceFetched = reference.ElementAt( referenceFetchedIndex );
            callbackFetched( referenceFetchedIndex, referenceFetched );
          }
        );
      }
    }

    #endregion Methods
  }
}