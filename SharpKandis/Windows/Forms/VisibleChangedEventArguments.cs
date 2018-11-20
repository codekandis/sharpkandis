using System;

namespace SharpKandis.Windows.Forms
{
	/// <summary>
	/// Represents the event arguments of the `VisibleChanged` event.
	/// </summary>
	public class VisibleChangedEventArguments:
		EventArgs
	{
		/// <summary>
		/// Stores the visible state that has been changed.
		/// </summary>
		private bool visible = false;

		/// <summary>
		/// Gets / sets the visible state that has been changed.
		/// </summary>
		public virtual bool Visible
		{
			get
			{
				return this.visible;
			}
			private set
			{
				this.visible = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="visible">The visible state that has been changed.</param>
		public VisibleChangedEventArguments( bool visible )
		{
			this.Visible = visible;
		}
	}
}
