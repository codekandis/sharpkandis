namespace SharpKandis.ComponentModel
{
  using System.ComponentModel;
  using System.Runtime.CompilerServices;

  /// <summary>Represents the base class of all classes implementing <i>INotifyPropertyChanging</i> and <i>INotifyPropertyChanged</i>.</summary>
  abstract public class NotifyPropertyAbstract:
    NotifyPropertyInterface
  {
    #region Events

    #region Interface: INotifyPropertyChanging

    #region PropertyChanging

    /// <summary>Will be raised if a property of the element will be changing.</summary>
    public virtual event PropertyChangingEventHandler PropertyChanging =
      delegate
      {
      };

    #endregion PropertyChanging

    #endregion Interface: INotifyPropertyChanging

    #region Interface: INotifyPropertyChanged

    #region PropertyChanged

    /// <summary>Will be raised if a property of the element has been changed.</summary>
    public virtual event PropertyChangedEventHandler PropertyChanged =
      delegate
      {
      };

    #endregion PropertyChanged

    #endregion Interface: INotifyPropertyChanged

    #endregion Events

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
  }
}