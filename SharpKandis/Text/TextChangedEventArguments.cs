﻿using System;

namespace SharpKandis.Text
{
	/// <summary>Represents the event arguments of the <i>TextChanged</i> event.</summary>
	public class TextChangedEventArguments:
		EventArgs
	{
		/// <summary>Stores the text that has been changed.</summary>
		private string _text = string.Empty;

		/// <summary>Gets / sets the text that has been changed.</summary>
		public virtual string Text
		{
			get
			{
				return this._text;
			}
			private set
			{
				this._text = value;
			}
		}

		/// <summary>Constructor method.</summary>
		/// <param name="text">The text that has been changed.</param>
		public TextChangedEventArguments( string text )
		{
			this.Text = text;
		}
	}
}