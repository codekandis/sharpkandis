namespace SharpKandis.Net.Sockets
{
  /// <summary>Represents an event handler delegate of the <i>RequestFailed</i> event.</summary>
  /// <param name="sender">The object which raised the <i>RequestFailed</i> event.</param>
  /// <param name="eventArguments">The event arguments of the <i>RequestFailed</i> event.</param>
  public delegate void RequestFailedEventHandler( object sender, RequestFailedEventArguments eventArguments );
}