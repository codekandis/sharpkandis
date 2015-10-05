namespace SharpKandis.Net.Rest.Settings
{
  using System;

  /// <summary>Represents the attribute of all operation contracts.</summary>
  [AttributeUsage(
    AttributeTargets.Method
  )]
  public class OperationContractAttribute :
    Attribute
  {
    #region Properties

    #region Name

    /// <summary>Stores the name of the operation contract.</summary>
    private string name = string.Empty;

    /// <summary>Gets / sets the name of the operation contract.</summary>
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

    #region UriTemplate

    /// <summary>Stores the uri template of the operation.</summary>
    private string uriTemplate = string.Empty;

    /// <summary>Gets / sets the uri template of the operation.</summary>
    public virtual string UriTemplate
    {
      get
      {
        return this.uriTemplate;
      }
      private set
      {
        this.uriTemplate = value;
      }
    }

    #endregion UriTemplate

    #region HttpMethod

    /// <summary>Stores the http method of the operation.</summary>
    private HttpMethod httpMethod = HttpMethod.Get;

    /// <summary>Gets / sets the http method of the operation.</summary>
    public virtual HttpMethod HttpMethod
    {
      get
      {
        return this.httpMethod;
      }
      set
      {
        this.httpMethod = value;
      }
    }

    #endregion HttpMethod

    #region RequestFormat

    /// <summary>Stores the format of the request of the operation.</summary>
    private MessageFormat requestFormat = MessageFormat.None;

    /// <summary>Gets / sets the request format of the request of the operation.</summary>
    public virtual MessageFormat RequestFormat
    {
      get
      {
        return this.requestFormat;
      }
      set
      {
        this.requestFormat = value;
      }
    }

    #endregion RequestFormat

    #region ResponseFormat

    /// <summary>Stores the format of the response of the operation.</summary>
    private MessageFormat responseFormat = MessageFormat.None;

    /// <summary>Gets / sets the response format of the response of the operation.</summary>
    public virtual MessageFormat ResponseFormat
    {
      get
      {
        return this.responseFormat;
      }
      set
      {
        this.responseFormat = value;
      }
    }

    #endregion ResponseFormat

    #endregion Properties

    #region Constructors

    /// <summary>Constuctor method.</summary>
    /// <param name="name">Specifies the name of the operation contract.</param>
    /// <param name="uriTemplate">Specifies the URI template of the operation.</param>
    public OperationContractAttribute( string name, string uriTemplate )
    {
      this.Name = name;
      this.UriTemplate = uriTemplate;
    }

    #endregion Constructors
  }
}