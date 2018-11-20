using System;
using System.Drawing;

namespace SharpKandis.Windows.Forms
{
	/// <summary>
	/// Represents the event arguments of the `ColorChanged` event.
	/// </summary>
	public class ColorChangedEventArguments:
		EventArgs
	{
		/// <summary>
		/// Stores the color that has been changed.
		/// </summary>
		private Color color = default( Color );

		/// <summary>
		/// Gets / sets the color that has been changed.
		/// </summary>
		public virtual Color Color
		{
			get
			{
				return this.color;
			}
			private set
			{
				this.color = value;
			}
		}

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="color">The color that has been changed.</param>
		public ColorChangedEventArguments( Color color )
		{
			this.Color = color;
		}
	}
}
