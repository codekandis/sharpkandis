﻿namespace SharpKandis.Windows.Forms
{
  using System.Windows.Forms;

  /// <summary>Represents a text box handling the select all shortcut.</summary>
  public partial class TextBoxSelectable:
    TextBox
  {
    #region Constructors

    /// <summary>Constructor method.</summary>
    public TextBoxSelectable( )
      : base( )
    {
      this.KeyDown += this.TextBoxSelectable_KeyDown;
    }

    #endregion Constructors

    #region EventHandlers

    #region GUI

    /// <summary>Will be invoked if the <i>TextBoxSelectable_KeyDown</i> event of the <i>TextBoxSelectable</i> has been raised.</summary>
    /// <param name="sender">The object which raised the <i>TextBoxSelectable_KeyDown</i> event.</param>
    /// <param name="eventArguments">The event arguments of the <i>TextBoxSelectable_KeyDown</i> event.</param>
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

    #endregion GUI

    #endregion EventHandlers
  }
}