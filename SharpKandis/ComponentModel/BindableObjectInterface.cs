namespace SharpKandis.ComponentModel
{
	/// <summary>Represents the interface of all bindable objects.</summary>
	public interface BindableObjectInterface
	{
		/// <summary>Gets / sets the data source of the object.</summary>
		object DataSource
		{
			get;
			set;
		}
	}
}
