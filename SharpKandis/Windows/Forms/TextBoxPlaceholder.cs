using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SharpKandis.Text;

namespace SharpKandis.Windows.Forms
{
	/// <summary>Represents a text box with a placeholder.</summary>
	public partial class TextBoxPlaceholder:
		TextBoxSelectable
	{
		/// <summary>Stores the visibility of the placeholder.</summary>
		private bool placeholderVisible = true;

		/// <summary>Gets / sets the visibility of the placeholder.</summary>
		[Browsable( true )]
		[NotifyParentProperty( true )]
		[DefaultValue( true )]
		public virtual bool PlaceholderVisible
		{
			get
			{
				return this.placeholderVisible;
			}
			set
			{
				this.placeholderVisible = value;
				VisibleChangedEventArguments eventArguments = new VisibleChangedEventArguments( value );
				this.PlaceholderVisibleChanged( this, eventArguments );
			}
		}

		/// <summary>Stores the text of the placeholder.</summary>
		private string placeholderText = "";

		/// <summary>Gets / sets the text of the placeholder.</summary>
		[Browsable( true )]
		[NotifyParentProperty( true )]
		[DefaultValue( "" )]
		public virtual string PlaceholderText
		{
			get
			{
				return this.placeholderText;
			}
			set
			{
				this.placeholderText = value;
				TextChangedEventArguments eventArguments = new TextChangedEventArguments( value );
				this.PlaceholderTextChanged( this, eventArguments );
			}
		}

		/// <summary>Stores the fore color of the placeholder.</summary>
		private Color placeholderForeColor = Color.Silver;

		/// <summary>Gets / sets the fore color of the placeholder.</summary>
		[Browsable( true )]
		[NotifyParentProperty( true )]
		[DefaultValue( typeof( Color ), "Silver" )]
		public virtual Color PlaceholderForeColor
		{
			get
			{
				return this.placeholderForeColor;
			}
			set
			{
				this.placeholderForeColor = value;
				ColorChangedEventArguments eventArguments = new ColorChangedEventArguments( value );
				this.PlaceholderForeColorChanged( this, eventArguments );
			}
		}

		/// <summary>Stores the label showing the text of the placeholder.</summary>
		private Label placeholderLabel = null;

		/// <summary>Gets / sets the label showing the text of the placeholder.</summary>
		private Label PlaceholderLabel
		{
			get
			{
				return this.placeholderLabel;
			}
			set
			{
				this.placeholderLabel = value;
			}
		}

		/// <summary>Will be raised if the visibility of the placeholder has been changed.</summary>
		public virtual event VisibleChangedEventHandler PlaceholderVisibleChanged =
			delegate
			{
			};

		/// <summary>Will be raised if the text of the placeholder has been changed.</summary>
		public virtual event TextChangedEventHandler PlaceholderTextChanged =
			delegate
			{
			};

		/// <summary>Will be raised if the fore color of the placeholder has been changed.</summary>
		public virtual event ColorChangedEventHandler PlaceholderForeColorChanged =
			delegate
			{
			};

		/// <summary>Constructor method.</summary>
		public TextBoxPlaceholder( )
		{
			this.InitializeComponent( );
			this.ComponentInitialize( );
			this.EventHandlersSet( );
		}

		/// <summary>Initializes the custom components.</summary>
		private void ComponentInitialize( )
		{
			this.PlaceholderLabel = new Label( );
			this.PlaceholderLabel.SuspendLayout( );
			this.PlaceholderLabel.AutoSize = true;
			this.PlaceholderLabel.Margin = new Padding( 0 );
			this.PlaceholderLabel.Padding = new Padding( 0 );
			this.PlaceholderLabel.Location = new Point( -2, 1 );
			this.PlaceholderLabel.BackColor = Color.Empty;
			this.PlaceholderLabel.Visible = this.PlaceholderVisible;
			this.PlaceholderLabel.Text = this.PlaceholderText;
			this.PlaceholderLabel.ForeColor = this.PlaceholderForeColor;
			this.PlaceholderLabel.Parent = this;
			this.PlaceholderVisibilityRefresh( );
			this.PlaceholderLabel.ResumeLayout( );
		}

		/// <summary>Sets the event handlers of the control.</summary>
		private void EventHandlersSet( )
		{
			this.PlaceholderVisibleChanged += this.TextBoxPlaceholder_PlaceholderVisibleChanged;
			this.PlaceholderTextChanged += this.TextBoxPlaceholder_PlaceholderTextChanged;
			this.PlaceholderForeColorChanged += this.TextBoxPlaceholder_PlaceholderForeColorChanged;
			this.GotFocus += this.TextBoxPlaceholder_GotFocus;
			this.LostFocus += this.TextBoxPlaceholder_LostFocus;
			this.TextChanged += this.TextBoxPlaceholder_TextChanged;
			this.FontChanged += this.TextBoxPlaceholder_FontChanged;
		}

		/// <summary>Refreshes the state of the visibility of the placeholder.</summary>
		private void PlaceholderVisibilityRefresh( )
		{
			this.PlaceholderLabel.Visible = true == this.PlaceholderVisible
											&& false == this.Focused
											&& string.Empty == this.Text;
		}

		/// <summary>Will be invoked if the <i>PlaceholderVisibleChanged</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>PlaceholderVisibleChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>PlaceholderVisibleChanged</i> event.</param>
		private void TextBoxPlaceholder_PlaceholderVisibleChanged( object sender, VisibleChangedEventArguments eventArguments )
		{
			this.PlaceholderLabel.Visible = eventArguments.Visible;
			this.PlaceholderVisibilityRefresh( );
		}

		/// <summary>Will be invoked if the <i>PlaceholderTextChanged</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>PlaceholderTextChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>PlaceholderTextChanged</i> event.</param>
		private void TextBoxPlaceholder_PlaceholderTextChanged( object sender, TextChangedEventArguments eventArguments )
		{
			this.PlaceholderLabel.Text = eventArguments.Text;
		}

		/// <summary>Will be invoked if the <i>PlaceholderForeColorChanged</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>PlaceholderForeColorChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>PlaceholderForeColorChanged</i> event.</param>
		private void TextBoxPlaceholder_PlaceholderForeColorChanged( object sender, ColorChangedEventArguments eventArguments )
		{
			this.PlaceholderLabel.ForeColor = eventArguments.Color;
		}

		/// <summary>Will be invoked if the <i>GotFocus</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>GotFocus</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>GotFocus</i> event.</param>
		private void TextBoxPlaceholder_GotFocus( object sender, EventArgs eventArguments )
		{
			this.PlaceholderVisibilityRefresh( );
		}

		/// <summary>Will be invoked if the <i>LostFocus</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>LostFocus</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>LostFocus</i> event.</param>
		private void TextBoxPlaceholder_LostFocus( object sender, EventArgs eventArguments )
		{
			this.PlaceholderVisibilityRefresh( );
		}

		/// <summary>Will be invoked if the <i>TextChanged</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>TextChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>TextChanged</i> event.</param>
		private void TextBoxPlaceholder_TextChanged( object sender, EventArgs eventArguments )
		{
			this.PlaceholderVisibilityRefresh( );
		}

		/// <summary>Will be invoked if the <i>FontChanged</i> event of the <i>TextBoxPlaceholder</i> has been raised.</summary>
		/// <param name="sender">The object which raised the <i>FontChanged</i> event.</param>
		/// <param name="eventArguments">The event arguments of the <i>FontChanged</i> event.</param>
		private void TextBoxPlaceholder_FontChanged( object sender, EventArgs eventArguments )
		{
			this.PlaceholderLabel.Font = new Font( this.Font, this.Font.Style );
		}

		/// <summary>Will be invoked if the text box has been clicked.</summary>
		/// <param name="sender">The textbox that has been clicked.</param>
		/// <param name="eventArguments">The event arguments of the event.</param>
		private void TextBoxPlaceholder_PlaceholderClick( object sender, EventArgs eventArguments )
		{
			Control senderX = sender as Control;
			senderX.Hide( );
			this.InvokeOnClick( this, eventArguments );
		}
	}
}
