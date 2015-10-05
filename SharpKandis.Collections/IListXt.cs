namespace SharpKandis.Collections.Generic
{
  using System;
  using System.Collections;
  using System.Collections.Generic;

  /// <summary>Represents an extension class for all <i>System.Collections.IList</i> classes.</summary>
  public static class IListXt
  {
    #region Methods

    /// <summary>Invokes a specified callback on any element of a specified list.</summary>
    /// <param name="reference">The list to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callback">The callback to invoke on any element of the list passed in the argument <i>reference</i>. The callback provides the fetched element itself.</param>
    public static void ForEach( this IList reference, Action<object> callback )
    {
      foreach ( object referenceFetched in reference )
      {
        callback( referenceFetched );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified list.</summary>
    /// <param name="reference">The list to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callback">The callback to invoke on any element of the list passed in the argument <i>reference</i>. The callback provides the index of the fetched element and the fetched element itself.</param>
    public static void ForEach( this IList reference, Action<int, object> callback )
    {
      for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count; referenceFetchedIndex++ )
      {
        object referenceFetched = reference[ referenceFetchedIndex ];
        callback( referenceFetchedIndex, referenceFetched );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified list.</summary>
    /// <param name="reference">The list to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callbacks">The enumerable of callbacks to invoke on any element of the list passed in the argument <i>reference</i>. Each callback provides the fetched element itself.</param>
    public static void ForEach( this IList reference, IEnumerable<Action<object>> callbacks )
    {
      foreach ( object referenceFetched in reference )
      {
        callbacks.ForEach(
          ( Action<object> callbackFetched ) =>
          {
            callbackFetched( referenceFetched );
          }
        );
      }
    }

    /// <summary>Invokes a specified callback on any element of a specified list.</summary>
    /// <param name="reference">The list to invoke the callback passed in the argument <i>callback</i> on any element.</param>
    /// <param name="callbacks">The enumerable of callbacks to invoke on any element of the list passed in the argument <i>reference</i>. Each callback provides the index of the fetched element and the fetched element itself.</param>
    public static void ForEach( this IList reference, IEnumerable<Action<int, object>> callbacks )
    {
      for ( int referenceFetchedIndex = 0; referenceFetchedIndex < reference.Count; referenceFetchedIndex++ )
      {
        callbacks.ForEach(
          ( Action<int, object> callbackFetched ) =>
          {
            object referenceFetched = reference[ referenceFetchedIndex ];
            callbackFetched( referenceFetchedIndex, referenceFetched );
          }
        );
      }
    }

    #endregion Methods
  }
}