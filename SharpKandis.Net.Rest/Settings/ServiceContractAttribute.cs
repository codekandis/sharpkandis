namespace SharpKandis.Net.Rest.Settings
{
  using System;

  /// <summary>Represents the attribute of all service contracts.</summary>
  [AttributeUsage( AttributeTargets.Interface )]
  public class ServiceContractAttribute :
    Attribute
  {
    #region Properties

    #region NameSpace

    /// <summary>Stores the namespace of the service contract.</summary>
    private string nameSpace = string.Empty;

    /// <summary>Gets / sets the namespace of the service contract.</summary>
    public virtual string NameSpace
    {
      get
      {
        return this.nameSpace;
      }
      private set
      {
        this.nameSpace = value;
      }
    }

    #endregion NameSpace

    #region Name

    /// <summary>Stores the name of the service contract.</summary>
    private string name = string.Empty;

    /// <summary>Gets / sets the name of the service contract.</summary>
    public virtual string Name
    {
      get
      {
        return this.name;
      }
      private set
      {
        this.name = value;
      }
    }

    #endregion Name

    #endregion Properties

    #region Constructors

    /// <summary>Constuctor method.</summary>
    /// <param name="nameSpace">Specifies the namespace of the service contract.</param>
    /// <param name="name">Specifies the name of the service contract.</param>
    public ServiceContractAttribute( string nameSpace, string name )
    {
      this.NameSpace = nameSpace;
      this.Name = name;
    }

    #endregion Constructors
  }
}