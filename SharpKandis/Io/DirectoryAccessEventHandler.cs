namespace SharpKandis.Io
{
	/// <summary>Represents the event handler of all directory access events.</summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The event arguments of the raised event.</param>
	public delegate void DirectoryAccessEventHandler( object sender, DirectoryAccessEventArguments eventArguments );
}
