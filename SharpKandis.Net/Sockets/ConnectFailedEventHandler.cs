namespace SharpKandis.Net.Sockets
{
  /// <summary>Represents an event handler delegate of the <i>ConnectFailed</i> event.</summary>
  /// <param name="sender">The object which raised the <i>ConnectFailed</i> event.</param>
  /// <param name="eventArguments">The event arguments of the <i>ConnectFailed</i> event.</param>
  public delegate void ConnectFailedEventHandler( object sender, ConnectFailedEventArguments eventArguments );
}