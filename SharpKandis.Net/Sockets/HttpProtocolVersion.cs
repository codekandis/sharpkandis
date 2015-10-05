namespace SharpKandis.Net.Sockets
{
  using System.ComponentModel;

  /// <summary>Represents an enumeration of HTTP protocol versions. The versions are ordered descending to ensure the latest version as default value.</summary>
  public enum HttpProtocolVersion
  {
    [DescriptionAttribute( "1.1" )]
    V_1_1,
    [DescriptionAttribute( "1.0" )]
    V_1_0
  }
}