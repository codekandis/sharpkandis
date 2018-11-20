using System.Windows.Forms;

namespace SharpKandis.Windows.Forms
{
	/// <summary>
	/// Represents a text box handling the select all shortcut.
	/// </summary>
	public partial class TextBoxSelectable:
		TextBox
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public TextBoxSelectable( )
			: base( )
		{
			this.KeyDown += this.TextBoxSelectable_KeyDown;
		}

		/// <summary>
		/// Will be invoked if the `TextBoxSelectable_KeyDown` event of the `TextBoxSelectable` has been raised.
		/// </summary>
		/// <param name="sender">The object which raised the `TextBoxSelectable_KeyDown` event.</param>
		/// <param name="eventArguments">The event arguments of the `TextBoxSelectable_KeyDown` event.</param>
		private void TextBoxSelectable_KeyDown( object sender, KeyEventArgs eventArguments )
		{
			TextBox senderX = sender as TextBox;
			switch ( eventArguments.KeyData )
			{
				case Keys.Control | Keys.A:
					{
						senderX.SelectAll( );
						break;
					}
			}
		}
	}
}
