using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SharpKandis.ComponentModel
{
	/// <summary>
	/// Represents the interface of all classes implementing `INotifyPropertyChanging` and `INotifyPropertyChanged`.
	/// </summary>
	public interface NotifyPropertyInterface:
		INotifyPropertyChanging,
		INotifyPropertyChanged
	{
		/// <summary>
		/// Raises the `PropertyChanging` event for a specific property specified by a passed property name.
		/// </summary>
		/// <param name="propertyName">The name of the property which is changing.</param>
		void PropertyChangingRaise( [CallerMemberName] string propertyName = "" );

		/// <summary>
		/// Raises the `PropertyChanged` event for a specific property specified by a passed property name.
		/// </summary>
		/// <param name="propertyName">The name of the property which has been changed.</param>
		void PropertyChangedRaise( [CallerMemberName] string propertyName = "" );
	}
}
