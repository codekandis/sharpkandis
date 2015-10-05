namespace SharpKandis.Net.Sockets
{
  /// <summary>Represents an event handler delegate of the <i>DisconnectFailed</i> event.</summary>
  /// <param name="sender">The object which raised the <i>DisconnectFailed</i> event.</param>
  /// <param name="eventArguments">The event arguments of the <i>DisconnectFailed</i> event.</param>
  public delegate void DisconnectFailedEventHandler( object sender, DisconnectFailedEventArguments eventArguments );
}