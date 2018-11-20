using System.Text;

namespace SharpKandis
{
	/// <summary>Represents an extension class of all <i>System.String</i> classes.</summary>
	public static class StringXt
	{
		/// <summary>Determines if the <i>string</i> is <i>null</i> or empty.</summary>
		/// <param name="reference">The <i>string</i> to determine if it is <i>null</i> or empty.</param>
		/// <returns><i>true</i> if the string is <i>null</i> or <i>empty</i>, <i>false</i> otherwise.</returns>
		public static bool IsNullOrEmpty( this string reference )
		{
			return string.IsNullOrEmpty( reference );
		}

		/// <summary>Converts the <i>string</i> into a <i>byte</i> array depending on a specified encoding.</summary>
		/// <param name="reference">The <i>string</i> to convert into a <b>byte array</b>.</param>
		/// <param name="encoding">The encoding to use to convert the <i>string</i> into a <i>byte</i> array.</param>
		/// <returns>The converted <i>byte</i> array of the string.</returns>
		public static byte[ ] ToBytes( this string reference, Encoding encoding )
		{
			return encoding.GetBytes( reference );
		}

		/// <summary>Converts the <i>string</i> into a <i>byte</i> array depending on the <i>System.Text.Encoding.UTF8</i> encoding.</summary>
		/// <param name="reference">The <i>string</i> to convert into a <b>byte array</b>.</param>
		/// <returns>The converted <i>byte</i> array of the <i>string</i>.</returns>
		public static byte[ ] ToBytes( this string reference )
		{
			return reference.ToBytes( Encoding.UTF8 );
		}
	}
}
