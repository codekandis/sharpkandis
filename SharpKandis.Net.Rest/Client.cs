namespace SharpKandis.Net.Rest
{
  using System;
  using System.CodeDom.Compiler;
  using System.Collections.Generic;
  using System.IO;
  using System.Reflection;
  using Microsoft.CSharp;
  using SharpKandis;
  using SharpKandis.Collections;
  using SharpKandis.Collections.Generic;

  /// <summary>Represents a REST client based on a service contract.</summary>
  /// <typeparam name="TServiceContract">The type of the service contract.</typeparam>
  public class Client<TServiceContract>
    where TServiceContract : class
  {
    #region Properties

    #region ServiceContractType

    /// <summary>Stores the type of the service contract.</summary>
    private Type serviceContractType = null;

    /// <summary>Gets the type of the service contract.</summary>
    public virtual Type ServiceContractType
    {
      get
      {
        if ( null == this.serviceContractType )
        {
          this.serviceContractType = typeof( TServiceContract );
        }
        return this.serviceContractType;
      }
    }

    #endregion ServiceContractType

    #region ServiceUriBase

    /// <summary>Stores the base URI of the REST service.</summary>
    private Uri serviceUriBase = null;

    /// <summary>Gets / sets the base URI of the REST service.</summary>
    public virtual Uri ServiceUriBase
    {
      get
      {
        return this.serviceUriBase;
      }
      private set
      {
        this.serviceUriBase = value;
      }
    }

    #endregion ServiceUriBase

    #region ChannelNamespace

    /// <summary>Stores the namespace of the dynamic runtime channel of the REST client.</summary>
    private string channelNamespace = typeof( Client<TServiceContract> ).Namespace + ".SharpKandis.Net.Rest.Clients.Channels";

    public virtual string ChannelNamespace
    {
      get
      {
        return this.channelNamespace;
      }
    }

    #endregion ChannelNamespace

    #endregion Properties

    #region Constructors

    /// <summary>Constructor method.</summary>
    /// <param name="serviceUriBase">Specifies the base URI of the REST service.</param>
    public Client( Uri serviceUriBase )
    {
      this.ServiceUriBase = serviceUriBase;
    }

    /// <summary>Constructor method.</summary>
    /// <param name="serviceUriBase">Specifies the base URI of the REST service.</param>
    public Client( string serviceUriBase )
      : this( new Uri( serviceUriBase, UriKind.Absolute ) )
    {
    }

    #endregion Constructors

    #region Methods

    /// <summary>Adds an needed assembly to the list of needed assemblies.</summary>
    /// <param name="assembliesNeeded">Specifies the list of needed assemblies to add the needed assembly to.</param>
    /// <param name="assemblyNeeded">Specifies the needed assembly to add to the list of needed assemblies.</param>
    private void AssemblyNeededAdd( IDictionary<string, string> assembliesNeeded, string assemblyNeeded )
    {
      string assemblyNeededFileName = Path.GetFileName( assemblyNeeded );
      if ( false == assembliesNeeded.Keys.Contains( assemblyNeededFileName ) )
      {
        assembliesNeeded.Add( assemblyNeededFileName, assemblyNeeded );
      }
    }

    /// <summary>Gets the method wrappers of the service contract mapped client.</summary>
    /// <returns>The class wrapper of the service contract mapped client.</returns>
    private string MethodWrappersGet( IDictionary<string, string> assembliesNeeded )
    {
      string methodWrappers = string.Empty;
      MethodInfo[ ] methodInformations = this.ServiceContractType.GetMethods( );
      foreach ( MethodInfo methodInformation in methodInformations )
      {
        string staticKeyword = string.Empty;
        string abstractKeyword = string.Empty;
        string accessorKeyword = "public virtual";
        if ( false == this.ServiceContractType.IsInterface )
        {
          if ( true == methodInformation.IsStatic )
          {
            staticKeyword = "static";
          }
          if ( true == methodInformation.IsAbstract )
          {
            abstractKeyword = "abstract";
          }
          if ( true == methodInformation.IsPrivate )
          {
            accessorKeyword = "private";
          }
          if ( false == methodInformation.IsPrivate
               && false == methodInformation.IsPublic )
          {
            accessorKeyword = "protected";
          }
        }
        this.AssemblyNeededAdd( assembliesNeeded, methodInformation.ReturnType.Assembly.Location );
        string returnType = methodInformation.ReturnType.GetProcessedNameGenericFull( );
        string methodName = methodInformation.Name;
        List<string> argumentsTypedList = new List<string>( );
        List<string> argumentsUntypedList = new List<string>( );
        argumentsUntypedList.Add( "\"" + methodName + "\"" );
        ParameterInfo[ ] parameterInformations = methodInformation.GetParameters( );
        foreach ( ParameterInfo parameterInformation in parameterInformations )
        {
          this.AssemblyNeededAdd( assembliesNeeded, parameterInformation.ParameterType.Assembly.Location );
          string argumentTyped = string.Format(
                                   "{0} {1}",
                                   parameterInformation.ParameterType.GetProcessedNameGenericFull( ),
                                   parameterInformation.Name
                                 );
          argumentsTypedList.Add( argumentTyped );
          string argumentUntyped = string.Format(
                                     "{0}",
                                     parameterInformation.Name
                                   );
          argumentsUntypedList.Add( argumentUntyped );
        }
        string argumentsTyped = string.Join( ",", argumentsTypedList.ToArray( ) );
        string argumentsUntyped = string.Join( ",", argumentsUntypedList.ToArray( ) );
        string returnValueDefinition = typeof( void ) == methodInformation.ReturnType
                                     ? string.Empty
                                     : returnType + " requestResult = ";
        string returnTypeConversion = typeof( void ) == methodInformation.ReturnType
                                    ? string.Empty
                                    : " as " + returnType;
        string returnValue = typeof( void ) == methodInformation.ReturnType
                           ? string.Empty
                           : "return requestResult;";
        string methodWrapper = string.Format(
                                 "{0} {1} {2} {3} {4}( {5} )"
                                 + "{{"
                                 + "  {6} this.Request.Invoke( {7} ){8};"
                                 + "  {9}"
                                 + "}}",
                                 staticKeyword,
                                 abstractKeyword,
                                 accessorKeyword,
                                 returnType,
                                 methodName,
                                 argumentsTyped,
                                 returnValueDefinition,
                                 argumentsUntyped,
                                 returnTypeConversion,
                                 returnValue
                               );
        methodWrappers += methodWrapper;
      }
      return methodWrappers;
    }

    /// <summary>Gets the class wrapper of the service contract mapped client.</summary>
    /// <returns>The class wrapper of the service contract mapped client.</returns>
    private string ClassWrapperGet( IDictionary<string, string> assembliesNeeded )
    {
      this.AssemblyNeededAdd( assembliesNeeded, "System.dll" );
      this.AssemblyNeededAdd( assembliesNeeded, this.GetType( ).Assembly.Location );
      string classWrapper = string.Format(
                              "namespace {0}"
                              + "{{"
                              + "  using System;"
                              + "  using SharpKandis.Net.Rest;"
                              + "  public class {1} : {2}"
                              + "  {{"
                              + "    private Uri serviceUriBase = null;"
                              + "    public virtual Uri ServiceUriBase"
                              + "    {{"
                              + "      get"
                              + "      {{"
                              + "        return this.serviceUriBase;"
                              + "      }}"
                              + "      private set"
                              + "      {{"
                              + "        this.serviceUriBase = value;"
                              + "      }}"
                              + "    }}"
                              + "    private Request<{2}> request = null;"
                              + "    private Request<{2}> Request"
                              + "    {{"
                              + "      get"
                              + "      {{"
                              + "        if ( null == this.request )"
                              + "        {{"
                              + "          this.request = new Request<{2}>( this.ServiceUriBase );"
                              + "        }}"
                              + "        return this.request;"
                              + "      }}"
                              + "    }}"
                              + "    public {1}( Uri serviceUriBase )"
                              + "    {{"
                              + "      this.ServiceUriBase = serviceUriBase;"
                              + "    }}"
                              + "    {3}"
                              + "  }}"
                              + "}}",
                              this.ChannelNamespace,
                              this.ServiceContractType.GetProcessedName( ) + "ServiceChannel",
                              this.ServiceContractType.GetProcessedNameGenericFull( ),
                              this.MethodWrappersGet( assembliesNeeded )
                            );
      return classWrapper;
    }

    /// <summary>Gets the compiled script of the service contract mapped client.</summary>
    /// <param name="classWrapper">Specifies the class representing the service contract mapped client.</param>
    /// <returns>The compiled script of the service contract mapped client.</returns>
    private TServiceContract ServiceContractClientGet( string classWrapper, Dictionary<string, string> assembliesNeeded )
    {
      CompilerParameters compilerParameters = new CompilerParameters( );
      compilerParameters.GenerateExecutable = false;
      compilerParameters.GenerateInMemory = true;
      compilerParameters.IncludeDebugInformation = false;
      assembliesNeeded.Values.ForEach(
        ( string valueFetched ) =>
        {
          compilerParameters.ReferencedAssemblies.Add( valueFetched );
        }
      );
      CodeDomProvider codeDomProvider = CSharpCodeProvider.CreateProvider( "CSharp" );
      CompilerResults compilerResults = codeDomProvider.CompileAssemblyFromSource( compilerParameters, classWrapper );
      if ( true == compilerResults.Errors.HasErrors )
      {
        compilerResults.Errors.ForEach(
          ( CompilerError compilerError ) =>
          {
            Console.WriteLine( "Error :: " + compilerError.ErrorText );
          }
        );
        throw new InvalidOperationException( "ClassWrapper has a syntax error." );
      }
      Assembly assembly = compilerResults.CompiledAssembly;
      Type serviceContractType = assembly.GetType( this.ChannelNamespace + "." + this.ServiceContractType.GetProcessedName( ) + "ServiceChannel" );
      object instance = null;
      try
      {
        instance = Activator.CreateInstance( serviceContractType, new object[ ] { this.ServiceUriBase } );
      }
      catch ( Exception exception )
      {
        Console.WriteLine( "Exception :: " + exception.Message );
      }
      TServiceContract serviceContract = instance as TServiceContract;
      return serviceContract;
    }

    /// <summary>Creates a new channel of the service client.</summary>
    /// <returns>The new channel of the service client.</returns>
    public virtual TServiceContract ChannelCreate( )
    {
      Dictionary<string, string> assembliesNeeded = new Dictionary<string, string>( );
      string classWrapper = this.ClassWrapperGet( assembliesNeeded );
      System.IO.File.WriteAllText( "D:\\Development - C#\\Projects\\WcfClone\\WcfClone\\CodeFile1.cs", classWrapper );
      TServiceContract serviceContract = this.ServiceContractClientGet( classWrapper, assembliesNeeded );
      return serviceContract;
    }

    #endregion Methods
  }
}