using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using SharpKandis.ComponentModel;

namespace SharpKandis.Windows.Forms
{
	/// <summary>
	/// Represents the base class of all <i>UserControl</i> classes implementing <i>INotifyPropertyChanging</i> and <i>INotifyPropertyChanged</i>.
	/// </summary>
	public partial class NotifyPropertyUserControlAbstract:
		UserControl,
		NotifyPropertyInterface
	{
		/// <summary>
		/// Will be raised if a property of the element will be changing.
		/// </summary>
		public virtual event PropertyChangingEventHandler PropertyChanging =
			delegate
			{
			};

		/// <summary>
		/// Will be raised if a property of the element has been changed.
		/// </summary>
		public virtual event PropertyChangedEventHandler PropertyChanged =
			delegate
			{
			};

		/// <summary>
		/// Constructor method.
		/// </summary>
		public NotifyPropertyUserControlAbstract( )
		{
			this.InitializeComponent( );
			this.ParentChanged += this.NotifyPropertyUserControlAbstract_ParentChanged;
			this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
		}

		/// <summary>
		/// Raises the <i>PropertyChanging</i> event for a specific property specified by a passed property name.
		/// </summary>
		/// <param name="propertyName">The name of the property which is changing.</param>
		public virtual void PropertyChangingRaise( [CallerMemberName] string propertyName = "" )
		{
			PropertyChangingEventArgs propertyChangingEventArguments = new PropertyChangingEventArgs( propertyName );
			this.PropertyChanging( this, propertyChangingEventArguments );
		}

		/// <summary>
		/// Raises the <i>PropertyChanged</i> event for a specific property specified by a passed property name.
		/// </summary>
		/// <param name="propertyName">The name of the property which has been changed.</param>
		public virtual void PropertyChangedRaise( [CallerMemberName] string propertyName = "" )
		{
			PropertyChangedEventArgs propertyChangedEventArguments = new PropertyChangedEventArgs( propertyName );
			this.PropertyChanged( this, propertyChangedEventArguments );
		}

		/// <summary>
		/// Will be invoked if the <i>ParentChanged</i> event of the <i>UserControl</i> has been raised.
		/// </summary>
		/// <param name="sender">The object which raised the <i>ParentChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>ParentChanged</i> event.</param>
		private void NotifyPropertyUserControlAbstract_ParentChanged( object sender, System.EventArgs eventArguments )
		{
			Control senderX = sender as Control;
			if ( null != senderX.Parent )
			{
				senderX.Size = senderX.Parent.Size;
			}
		}
	}
}
