using System;
using System.Windows.Forms;

namespace SharpKandis.Windows.Forms
{
	/// <summary>Represents an extension class of all <i>System.Windows.Forms.Control</i> classes.</summary>
	public static class ControlXt
	{
		/// <summary>Invokes an action on a specified control.</summary>
		/// <param name="control">The control to invoke the action passed in the argument <i>action</i>.</param>
		/// <param name="action">The action to invoke on the control passed in the argument <i>control</i>.</param>
		/// <returns>The return value of the action if the action returns one, <i>null</i> otherwise.</returns>
		public static object Invoke( this Control control, Action action )
		{
			object result = control.Invoke( action );
			return result;
		}

		/// <summary>Invokes an action on a specified control.</summary>
		/// <param name="control">The control to invoke the action passed in the argument <i>action</i>.</param>
		/// <param name="action">The action to invoke on the control passed in the argument <i>control</i>.</param>
		/// <param name="arguments">The arguments to be passed to the action passed in the argument <i>action</i>.</param>
		/// <returns>The return value of the action if the action returns one, <i>null</i> otherwise.</returns>
		public static object Invoke( this Control control, Action action, params object[ ] arguments )
		{
			object result = control.Invoke( action, ( object ) arguments );
			return result;
		}
	}
}
