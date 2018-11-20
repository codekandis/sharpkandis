using System;
using System.Drawing;

namespace SharpKandis.Windows.Forms
{
	/// <summary>Represents the event arguments of the <i>ColorChanged</i> event.</summary>
	public class ColorChangedEventArguments:
		EventArgs
	{
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

		/// <summary>Constructor method.</summary>
		/// <param name="color">The color that has been changed.</param>
		public ColorChangedEventArguments( Color color )
		{
			this.Color = color;
		}
	}
}
