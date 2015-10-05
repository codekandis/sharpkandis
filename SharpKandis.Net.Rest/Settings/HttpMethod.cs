namespace SharpKandis.Net.Rest.Settings
{
  using System.ComponentModel;

  /// <summary>Represents the valid HTTP methods of the REST client.</summary>
  public enum HttpMethod
  {
    /// <summary>Determines which methods are available on a resource.</summary>
    [DescriptionAttribute(
      "OPTIONS"
    )]
    Options,
    /// <summary>Gets the meta data of a resource.</summary>
    [DescriptionAttribute(
      "HEAD"
    )]
    Head,
    /// <summary>Gets an existing resource.</summary>
    [DescriptionAttribute(
      "GET"
    )]
    Get,
    /// <summary>Inserts a new resource.</summary>
    [DescriptionAttribute(
      "POST"
    )]
    Post,
    /// <summary>Creates a new resource if it does not exist or updates it otherwise.</summary>
    [DescriptionAttribute(
      "PUT"
    )]
    Put,
    /// <summary>Deletes an existing resource.</summary>
    [DescriptionAttribute(
      "DELETE"
    )]
    Delete,
    /// <summary>Updates a specific part of an existing resource.</summary>
    [DescriptionAttribute(
      "PATCH"
    )]
    Patch
  }
}