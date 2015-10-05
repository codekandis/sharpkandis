namespace SharpKandis.Windows.Forms
{
  using System.Windows.Forms;

  /// <summary>Represents a text box handling the select all shortcut.</summary>
  public partial class TextBoxXt:
    TextBox
  {
    #region Constructors

    /// <summary>Constructor method.</summary>
    public TextBoxXt( )
      : base( )
    {
      this.KeyDown += this.TextBoxXt_KeyDown;
    }

    #endregion Constructors

    #region EventHandler

    #region GUI

    /// <summary>Will be invoked if the <i>KeyDown</i> event has been raised.</summary>
    /// <param name="sender">The object raising the <i>KeyDown</i> event.</param>
    /// <param name="eventArguments">The event arguments passed to the <i>KeyDown</i> event.</param>
    private void TextBoxXt_KeyDown( object sender, KeyEventArgs eventArguments )
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

    #endregion GUI

    #endregion EventHandler
  }
}