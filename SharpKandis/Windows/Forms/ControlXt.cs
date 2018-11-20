using System;
using System.Windows.Forms;

namespace SharpKandis.Windows.Forms
{
	/// <summary>
	/// Represents an extension class of all `System.Windows.Forms.Control` classes.
	/// </summary>
	public static class ControlXt
	{
		/// <summary>
		/// Invokes an action on a specified control.
		/// </summary>
		/// <param name="control">The control to invoke the action passed in the argument `action`.</param>
		/// <param name="action">The action to invoke on the control passed in the argument `control`.</param>
		/// <returns>The return value of the action if the action returns one, `null` otherwise.</returns>
		public static object Invoke( this Control control, Action action )
		{
			return control.Invoke( action );
		}

		/// <summary>
		/// Invokes an action on a specified control.
		/// </summary>
		/// <param name="control">The control to invoke the action passed in the argument `action`.</param>
		/// <param name="action">The action to invoke on the control passed in the argument `control`.</param>
		/// <param name="arguments">The arguments to be passed to the action passed in the argument `action`.</param>
		/// <returns>The return value of the action if the action returns one, `null` otherwise.</returns>
		public static object Invoke( this Control control, Action action, params object[ ] arguments )
		{
			return control.Invoke( action, ( object ) arguments );
		}
	}
}
