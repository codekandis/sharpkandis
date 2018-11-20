namespace SharpKandis.Io
{
	/// <summary>
	/// Represents the event handler of all file access events.
	/// </summary>
	/// <param name="sender">The object which raised the event.</param>
	/// <param name="eventArguments">The event arguments of the raised event.</param>
	public delegate void FileAccessEventHandler( object sender, FileAccessEventArguments eventArguments );
}
