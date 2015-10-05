namespace SharpKandis.Windows.Forms
{
  using System;

  /// <summary>Represents the event arguments of the <i>VisibleChanged</i> event.</summary>
  public class VisibleChangedEventArguments :
    EventArgs
  {
    #region Properties

    #region Visible

    /// <summary>Stores the visible state that has been changed.</summary>
    private bool _visible = false;

    /// <summary>Gets / sets the visible state that has been changed.</summary>
    public virtual bool Visible
    {
      get
      {
        return this._visible;
      }
      private set
      {
        this._visible = value;
      }
    }

    #endregion Visible

    #endregion Properties

    #region Constructors

    /// <summary>Constructor method.</summary>
    /// <param name="visible">The visible state that has been changed.</param>
    public VisibleChangedEventArguments( bool visible )
    {
      this.Visible = visible;
    }

    #endregion Constructors
  }
}