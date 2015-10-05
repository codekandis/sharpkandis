namespace SharpKandis.Windows.Forms
{
  using System.ComponentModel;
  using System.Runtime.CompilerServices;
  using System.Windows.Forms;
  using SharpKandis.ComponentModel;

  /// <summary>Represents the base class of all <i>UserControl</i> classes implementing <i>INotifyPropertyChanging</i> and <i>INotifyPropertyChanged</i>.</summary>
  public partial class NotifyPropertyUserControlAbstract:
    UserControl,
    NotifyPropertyInterface
  {
    #region Events

    #region Interface: INotifyPropertyChanging

    #region PropertyChanging

    /// <summary>Will be raised if a property of the element will be changing.</summary>
    public virtual event PropertyChangingEventHandler PropertyChanging = delegate
    {
    };

    #endregion PropertyChanging

    #endregion Interface: INotifyPropertyChanging

    #region Interface: INotifyPropertyChanged

    #region PropertyChanging

    /// <summary>Will be raised if a property of the element has been changed.</summary>
    public virtual event PropertyChangedEventHandler PropertyChanged = delegate
    {
    };

    #endregion PropertyChanging

    #endregion Interface: INotifyPropertyChanged

    #endregion Events

    #region Constructors

    /// <summary>Constructor method.</summary>
    public NotifyPropertyUserControlAbstract( )
    {
      this.InitializeComponent( );
      this.ParentChanged += this.ANotifyPropertyUserControl_ParentChanged;
      this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    }

    #endregion Constructors

    #region Methods

    #region Interface: NotifyPropertyInterface

    /// <summary>Raises the <i>PropertyChanging</i> event for a specific property specified by a passed property name.</summary>
    /// <param name="propertyName">The name of the property which is changing.</param>
    public virtual void PropertyChangingRaise( [CallerMemberName] string propertyName = "" )
    {
      PropertyChangingEventArgs propertyChangingEventArguments = new PropertyChangingEventArgs( propertyName );
      this.PropertyChanging( this, propertyChangingEventArguments );
    }

    /// <summary>Raises the <i>PropertyChanged</i> event for a specific property specified by a passed property name.</summary>
    /// <param name="propertyName">The name of the property which has been changed.</param>
    public virtual void PropertyChangedRaise( [CallerMemberName] string propertyName = "" )
    {
      PropertyChangedEventArgs propertyChangedEventArguments = new PropertyChangedEventArgs( propertyName );
      this.PropertyChanged( this, propertyChangedEventArguments );
    }

    #endregion Interface: NotifyPropertyInterface

    #endregion Methods

    #region EventHandler

    #region GUI

    private void ANotifyPropertyUserControl_ParentChanged( object sender, System.EventArgs e )
    {
      Control senderX = sender as Control;
      if ( null != senderX.Parent )
      {
        senderX.Size = senderX.Parent.Size;
      }
    }

    #endregion GUI

    #endregion EventHandler
  }
}