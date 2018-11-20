using System.Text;

namespace SharpKandis
{
	/// <summary>
	/// Represents an extension class of all `System.String` classes.
	/// </summary>
	public static class StringXt
	{
		/// <summary>
		/// Determines if the `string` is `null` or empty.
		/// </summary>
		/// <param name="reference">The `string` to determine if it is `null` or empty.</param>
		/// <returns>`true` if the string is `null` or `empty`, `false` otherwise.</returns>
		public static bool IsNullOrEmpty( this string reference )
		{
			return string.IsNullOrEmpty( reference );
		}

		/// <summary>
		/// Converts the `string` into a `byte` array depending on a specified encoding.
		/// </summary>
		/// <param name="reference">The `string` to convert into a <b>byte array</b>.</param>
		/// <param name="encoding">The encoding to use to convert the `string` into a `byte` array.</param>
		/// <returns>The converted `byte` array of the string.</returns>
		public static byte[ ] ToBytes( this string reference, Encoding encoding )
		{
			return encoding.GetBytes( reference );
		}

		/// <summary>
		/// Converts the `string` into a `byte` array depending on the `System.Text.Encoding.UTF8` encoding.
		/// </summary>
		/// <param name="reference">The `string` to convert into a <b>byte array</b>.</param>
		/// <returns>The converted `byte` array of the `string`.</returns>
		public static byte[ ] ToBytes( this string reference )
		{
			return reference.ToBytes( Encoding.UTF8 );
		}
	}
}
