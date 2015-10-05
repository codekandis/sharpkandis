namespace SharpKandis.Windows.Forms
{
  using System;
  using System.Drawing;

  /// <summary>Represents the event arguments of the <i>ColorChanged</i> event.</summary>
  public class ColorChangedEventArguments :
    EventArgs
  {
    #region Properties

    #region Color

    /// <summary>Stores the color that has been changed.</summary>
    private Color _color = default( Color );

    /// <summary>Gets / sets the color that has been changed.</summary>
    public virtual Color Color
    {
      get
      {
        return this._color;
      }
      private set
      {
        this._color = value;
      }
    }

    #endregion Color

    #endregion Properties

    #region Constructors

    /// <summary>Constructor method.</summary>
    /// <param name="color">The color that has been changed.</param>
    public ColorChangedEventArguments( Color color )
    {
      this.Color = color;
    }

    #endregion Constructors
  }
}