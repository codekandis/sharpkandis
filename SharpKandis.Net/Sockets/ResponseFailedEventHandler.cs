namespace SharpKandis.Net.Sockets
{
  /// <summary>Represents an event handler delegate of the <i>ResponseFailed</i> event.</summary>
  /// <param name="sender">The object which raised the <i>ResponseFailed</i> event.</param>
  /// <param name="eventArguments">The event arguments of the <i>ResponseFailed</i> event.</param>
  public delegate void ResponseFailedEventHandler( object sender, ResponseFailedEventArguments eventArguments );
}