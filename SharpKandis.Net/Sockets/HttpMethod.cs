namespace SharpKandis.Net.Sockets
{
  using System.ComponentModel;

  /// <summary>Represents an enumeration of HTTP methods.</summary>
  public enum HttpMethod
  {
    OPTIONS,
    HEAD,
    GET,
    POST,
    PUT,
    DELETE,
    TRACE,
    CONNECT,
    PROPFIND,
    PROPPATCH,
    MKCOL,
    COPY,
    MOVE,
    LOCK,
    UNLOCK,
    [DescriptionAttribute( "VERSION-CONTROL" )]
    VERSION_CONTROL,
    REPORT,
    CHECKOUT,
    CHECKIN,
    UNCHECKOUT,
    MKWORKSPACE,
    UPDATE,
    LABEL,
    MERGE,
    [DescriptionAttribute( "BASELINE-CONTROL" )]
    BASELINE_CONTROL,
    MKACTIVITY,
    ORDERPATCH,
    ACL,
    PATCH,
    SEARCH
  }
}