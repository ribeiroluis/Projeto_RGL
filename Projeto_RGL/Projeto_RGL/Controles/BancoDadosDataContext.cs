using System;
using System.Windows.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;

namespace Projeto_RGL
{
    public class DataContextBancodeDados : DataContext
    {
        public DataContextBancodeDados()
            : base(@"Data Source=isostore:/Supermercados.sdf") { }

        public Table<ProdutoTabela> Produto;
        //public Table<Categoria> Categoria;
        public Table<SupermercadoTabela> Supermercado;
        public Table<PrecoProdutoSupermercado> PrecoProdutoSupermercado;

    }

    [Table(Name = "Produtos")]
    public class ProdutoTabela
    {
        private int _idproduto;
        private string _codbarras;
        private string _nome;

        [Column(Name = "Nome", CanBeNull = false, DbType = "NVARCHAR(200)")]
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                }
            }
        }

        [Column(DbType = "NVARCHAR(20)", Name = "CodBarras")]
        public string CodigoBarras
        {
            get { return _codbarras; }
            set
            {
                if (_codbarras != value)
                {
                    _codbarras = value;
                }
            }
        }

        [Column(Name = "ID", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int Id
        {
            get { return _idproduto; }
            set
            {
                if (_idproduto != value)
                {
                    _idproduto = value;
                }
            }
        }
    }

    [Table(Name = "Categoria")]
    public class CategoriaTabela
    {
        private int _id;
        private string _nome;

        [Column(Name = "Nome", DbType = "NVARCHAR(100)")]
        public string None
        {
            get { return _nome; }
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                }
            }
        }

        [Column(Name = "IDCategoria", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int IDCategoria
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
            }
        }

    }
    
    [Table(Name = "Supermercado")]
    public class SupermercadoTabela: INotifyPropertyChanged, INotifyPropertyChanging
    {
   
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        private int _idsupermercado;
        private string _nome;
        private string _endereco;
        private int _numero;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _telefone;
        private EntitySet<PrecoProdutoSupermercado> _PrecoProduto;

        public SupermercadoTabela()
        {
            this._PrecoProduto = new EntitySet<PrecoProdutoSupermercado>
                (new Action<PrecoProdutoSupermercado>(this.attach_Supermercado), 
                new Action<PrecoProdutoSupermercado>(this.detach_Supermercado));            
        }
        
        [Column(Name = "Telefone", DbType = "NVARCHAR(10)")]
        public string Telefone
        {
            get { return _telefone; }
            set
            {
                if (_telefone != value)
                {
                    _telefone = value;
                }
            }
        }

        [Column(Name = "UF", DbType = "NVARCHAR(2)")]
        public string UF
        {
            get { return _uf; }
            set
            {
                if (_uf != value)
                {
                    _uf = value;
                }
            }
        }

        [Column(Name = "Cidade", DbType = "NVARCHAR(50)")]
        public string Cidade
        {
            get { return _cidade; }
            set
            {
                if (_cidade != value)
                {
                    _cidade = value;
                }
            }
        }

        [Column(Name = "Bairro", DbType = "NVARCHAR(50)")]
        public string Bairro
        {
            get { return _bairro; }
            set
            {
                if (_bairro != value)
                {
                    _bairro = value;
                }
            }
        }

        [Column(Name = "Numero", DbType = "INT")]
        public int Numero
        {
            get { return _numero; }
            set
            {
                if (_numero != value)
                {
                    _numero = value;
                }
            }
        }

        [Column(Name = "Endereco", DbType = "NVARCHAR(200)")]
        public string Endereco
        {
            get { return _endereco; }
            set
            {
                if (_endereco != value)
                {
                    _endereco = value;
                }
            }
        }

        [Column(Name = "Nome", DbType = "NVARCHAR(200)")]
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                }
            }
        }

        [Column(Name = "ID", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int Id
        {
            get { return _idsupermercado; }
            set
            {
                if (_idsupermercado != value)
                {
                    _idsupermercado = value;
                }
            }
        }


        [Association(Name = "FKSupermercado", Storage = "_PrecoProduto", ThisKey = "Id", OtherKey = "SupermercadoId", DeleteRule = "NO ACTION")]
        public EntitySet<PrecoProdutoSupermercado> PrecoProduto
        {
            get
            {
                return this._PrecoProduto;
            }
            set
            {
                this._PrecoProduto.Assign(value);
            }
        }

        private void attach_Supermercado(PrecoProdutoSupermercado entidade)
        {
            this.SendPropertyChanging();
            entidade.Supermercado = this;
            
        }

        private void detach_Supermercado(PrecoProdutoSupermercado entidade)
        {
            this.SendPropertyChanging();
            entidade.Supermercado = null;
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
    
    [Table(Name = "PrecoProdutoSupermercado")]
    public class PrecoProdutoSupermercado
    {
        private EntityRef<SupermercadoTabela> _Supermercado;
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        
        
        public PrecoProdutoSupermercado()
        {

        }       
        
        private int _idproduto;
        [Column(Name = "idProdutoProduto", DbType = "INT NOT NULL", CanBeNull = false)]
        public int idProdutoProduto
        {
            get { return _idproduto; }
            set
            {
                if (_idproduto != value)
                {
                    _idproduto = value;
                }
            }
        }        
        
        private int _idsupermercado;
        [Column(DbType = "INT NOT NULL", CanBeNull = false)]
        public int SupermercadoId
        {
            get { return _idsupermercado; }
            set
            {
                if (_idsupermercado != value)
                {
                    _idsupermercado = value;
                }
            }
        }
        [Association(Name = "FKSupermercado", Storage = "_Supermercado", ThisKey = "SupermercadoID", OtherKey = "Id", IsForeignKey = true)]
        public SupermercadoTabela Supermercado
        {
            get
            {
                return this._Supermercado.Entity;
            }
            set
            {
                SupermercadoTabela previousValue = this._Supermercado.Entity;
                if (((previousValue != value)
                            || (this._Supermercado.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Supermercado.Entity = null;
                        previousValue.PrecoProduto.Remove(this);
                    }
                    this._Supermercado.Entity = value;
                    if ((value != null))
                    {
                        value.PrecoProduto.Add(this);
                        this._idsupermercado = value.Id;
                    }
                    else
                    {
                        this._idsupermercado = default(int);
                    }
                    this.SendPropertyChanged("Country");
                }
            }
        }


        private double preco;
        [Column(Name = "Preco", DbType = "DOUBLE NOT NULL", CanBeNull = false)]
        public double Valor
        {
            get { return preco; }
            set
            {
                if (preco != value)
                {
                    preco = value;
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
}


    
