namespace SharpKandis.Net.Rest.Settings
{
  using System.ComponentModel;

  /// <summary>Represents the possible message formats of the request or response message.</summary>
  public enum MessageFormat
  {
    /// <summary>The message is not formatted.</summary>
    [DescriptionAttribute(
      "None"
    )]
    None,
    /// <summary>The message is JSON formatted.</summary>
    [DescriptionAttribute(
      "JSON"
    )]
    Json,
    /// <summary>The message is XML formatted.</summary>
    [DescriptionAttribute(
      "XML"
    )]
    Xml
  }
}