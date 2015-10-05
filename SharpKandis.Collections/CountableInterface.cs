namespace SharpKandis.Collections
{
  using System;

  /// <summary>Represents the interface of all objects with countable elements.</summary>
  public interface CountableInterface
  {
    #region Properties

    #region Count

    /// <summary>Gets the count of elements of the object.</summary>
    int Count
    {
      get;
    }

    #endregion Count

    #endregion Properties
  }
}