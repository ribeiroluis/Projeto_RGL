#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:2.0.50727.6400
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



public partial class Supermercado : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertProdutoTabela(ProdutoTabela instance);
  partial void UpdateProdutoTabela(ProdutoTabela instance);
  partial void DeleteProdutoTabela(ProdutoTabela instance);
  partial void InsertSupermercadoTabela(SupermercadoTabela instance);
  partial void UpdateSupermercadoTabela(SupermercadoTabela instance);
  partial void DeleteSupermercadoTabela(SupermercadoTabela instance);
  #endregion
	
	public Supermercado(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
//	public Supermercado(System.Data.IDbConnection connection) : 
//			base(connection, mappingSource)
//	{
//		OnCreated();
//	}
	
//	public Supermercado(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
//			base(connection, mappingSource)
//	{
//		OnCreated();
//	}
	
//	public Supermercado(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
//			base(connection, mappingSource)
//	{
//		OnCreated();
//	}
	
	public System.Data.Linq.Table<ProdutoSupermercado> ProdutoSupermercado
	{
		get
		{
			return this.GetTable<ProdutoSupermercado>();
		}
	}
	
	public System.Data.Linq.Table<ProdutoTabela> ProdutoTabela
	{
		get
		{
			return this.GetTable<ProdutoTabela>();
		}
	}
	
	public System.Data.Linq.Table<SupermercadoTabela> SupermercadoTabela
	{
		get
		{
			return this.GetTable<SupermercadoTabela>();
		}
	}
}

[Table()]
public partial class ProdutoSupermercado
{
	
	private System.Nullable<long> _ProdutoId;
	
	private System.Nullable<long> _SupermercadoId;
	
	private System.Nullable<double> _Preco;
	
	public ProdutoSupermercado()
	{
	}
	
	[Column(Storage="_ProdutoId", DbType="BigInt")]
	public System.Nullable<long> ProdutoId
	{
		get
		{
			return this._ProdutoId;
		}
		set
		{
			if ((this._ProdutoId != value))
			{
				this._ProdutoId = value;
			}
		}
	}
	
	[Column(Storage="_SupermercadoId", DbType="BigInt")]
	public System.Nullable<long> SupermercadoId
	{
		get
		{
			return this._SupermercadoId;
		}
		set
		{
			if ((this._SupermercadoId != value))
			{
				this._SupermercadoId = value;
			}
		}
	}
	
	[Column(Storage="_Preco", DbType="Float")]
	public System.Nullable<double> Preco
	{
		get
		{
			return this._Preco;
		}
		set
		{
			if ((this._Preco != value))
			{
				this._Preco = value;
			}
		}
	}
}

[Table()]
public partial class ProdutoTabela : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private long _Id;
	
	private string _Nome;
	
	private string _CodBaras;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnCodBarasChanging(string value);
    partial void OnCodBarasChanged();
    #endregion
	
	public ProdutoTabela()
	{
		OnCreated();
	}
	
	[Column(Name="id", Storage="_Id", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
	public long Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[Column(Storage="_Nome", DbType="NVarChar(500)")]
	public string Nome
	{
		get
		{
			return this._Nome;
		}
		set
		{
			if ((this._Nome != value))
			{
				this.OnNomeChanging(value);
				this.SendPropertyChanging();
				this._Nome = value;
				this.SendPropertyChanged("Nome");
				this.OnNomeChanged();
			}
		}
	}
	
	[Column(Storage="_CodBaras", DbType="NVarChar(500)")]
	public string CodBaras
	{
		get
		{
			return this._CodBaras;
		}
		set
		{
			if ((this._CodBaras != value))
			{
				this.OnCodBarasChanging(value);
				this.SendPropertyChanging();
				this._CodBaras = value;
				this.SendPropertyChanged("CodBaras");
				this.OnCodBarasChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table()]
public partial class SupermercadoTabela : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private long _Id;
	
	private string _Nome;
	
	private string _Endereco;
	
	private System.Nullable<long> _Numero;
	
	private string _Bairro;
	
	private string _Cidade;
	
	private string _UF;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnNomeChanging(string value);
    partial void OnNomeChanged();
    partial void OnEnderecoChanging(string value);
    partial void OnEnderecoChanged();
    partial void OnNumeroChanging(System.Nullable<long> value);
    partial void OnNumeroChanged();
    partial void OnBairroChanging(string value);
    partial void OnBairroChanged();
    partial void OnCidadeChanging(string value);
    partial void OnCidadeChanged();
    partial void OnUFChanging(string value);
    partial void OnUFChanged();
    #endregion
	
	public SupermercadoTabela()
	{
		OnCreated();
	}
	
	[Column(Name="id", Storage="_Id", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
	public long Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[Column(Storage="_Nome", DbType="NVarChar(500)")]
	public string Nome
	{
		get
		{
			return this._Nome;
		}
		set
		{
			if ((this._Nome != value))
			{
				this.OnNomeChanging(value);
				this.SendPropertyChanging();
				this._Nome = value;
				this.SendPropertyChanged("Nome");
				this.OnNomeChanged();
			}
		}
	}
	
	[Column(Storage="_Endereco", DbType="NVarChar(500)")]
	public string Endereco
	{
		get
		{
			return this._Endereco;
		}
		set
		{
			if ((this._Endereco != value))
			{
				this.OnEnderecoChanging(value);
				this.SendPropertyChanging();
				this._Endereco = value;
				this.SendPropertyChanged("Endereco");
				this.OnEnderecoChanged();
			}
		}
	}
	
	[Column(Storage="_Numero", DbType="BigInt")]
	public System.Nullable<long> Numero
	{
		get
		{
			return this._Numero;
		}
		set
		{
			if ((this._Numero != value))
			{
				this.OnNumeroChanging(value);
				this.SendPropertyChanging();
				this._Numero = value;
				this.SendPropertyChanged("Numero");
				this.OnNumeroChanged();
			}
		}
	}
	
	[Column(Storage="_Bairro", DbType="NVarChar(500)")]
	public string Bairro
	{
		get
		{
			return this._Bairro;
		}
		set
		{
			if ((this._Bairro != value))
			{
				this.OnBairroChanging(value);
				this.SendPropertyChanging();
				this._Bairro = value;
				this.SendPropertyChanged("Bairro");
				this.OnBairroChanged();
			}
		}
	}
	
	[Column(Storage="_Cidade", DbType="NVarChar(500)")]
	public string Cidade
	{
		get
		{
			return this._Cidade;
		}
		set
		{
			if ((this._Cidade != value))
			{
				this.OnCidadeChanging(value);
				this.SendPropertyChanging();
				this._Cidade = value;
				this.SendPropertyChanged("Cidade");
				this.OnCidadeChanged();
			}
		}
	}
	
	[Column(Storage="_UF", DbType="NVarChar(500)")]
	public string UF
	{
		get
		{
			return this._UF;
		}
		set
		{
			if ((this._UF != value))
			{
				this.OnUFChanging(value);
				this.SendPropertyChanging();
				this._UF = value;
				this.SendPropertyChanged("UF");
				this.OnUFChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
