using System;
using System.Windows.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using Projeto_RGL.BaixarArquivos;

namespace Projeto_RGL.ContextoDados
{
    public class DataContextBancodeDados : DataContext
    {
        public DataContextBancodeDados()
            : base(@"Data Source=isostore:/Supermercados.sdf") { }

        public Table<Produtos> Produtos;
        //public Table<Categoria> Categoria;
        //public Table<Supermercado> Supermercado;
        //public Table<PrecoProtutoSupermercado> PrecoProdutoSupermercado;

    }

   
    #region Tabela Produtos
    [Table(Name = "Produtos")]
    public class Produtos
    {
        private int idproduto;
        private string codbarras;
        private string nome;

        [Column(Name = "Nome", CanBeNull = false, DbType = "NVARCHAR(200)")]
        public string Nome
        {
            get { return nome; }
            set
            {
                if (nome != value)
                {
                    nome = value;
                }
            }
        }
        
        [Column(DbType = "NVARCHAR(20)", Name = "CodBarras")]
        public string CodigoBarras
        {
            get { return codbarras; }
            set
            {
                if (codbarras != value)
                {
                    codbarras = value;
                }
            }
        }

        [Column(Name = "IDProduto", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int IDProduto
        {
            get { return idproduto; }
            set
            {
                if (idproduto != value)
                {
                    idproduto = value;
                }
            }
        }

        /*private EntitySet<PrecoProtutoSupermercado> refIDProduto = new EntitySet<PrecoProtutoSupermercado>();
        [Association(Name = "FK_Protudo_PrecoProdutoSupermercado", Storage = "refIDProduto", ThisKey = "IDProduto", OtherKey = "idProdutoProduto")]
        public EntitySet<PrecoProtutoSupermercado> FKIDProduto
        {
            get
            {
                return this.refIDProduto;
            }
        }*/

        

    }
    #endregion 

    
    #region fazer depois
    
    /*#region Tabela Catetoria
    [Table(Name = "Categoria")]
    public class Categoria
    {
        private int idcategoria;
        private string nome;

        [Column(Name = "Nome", DbType = "NVARCHAR(100)")]
        public string None
        {
            get { return nome; }
            set
            {
                if (nome != value)
                {
                    nome = value;
                }
            }
        }

        [Column(Name = "IDCategoria", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int IDCategoria
        {
            get { return idcategoria; }
            set
            {
                if (idcategoria != value)
                {
                    idcategoria = value;
                }
            }
        }

    }
    #endregion
     */
    
    
    /*#region Tabela Supermercado
    [Table(Name = "Supermercado")]
    public class Supermercado
    {
        private int idsupermercado;
        private string nome;
        private string endereco;
        private int numero;
        private string bairro;
        private string cidade;
        private string uf;
        private string telefone;


        [Column(Name = "Telefone", DbType = "NVARCHAR(10)")]
        public string Telefone
        {
            get { return telefone; }
            set
            {
                if (telefone != value)
                {
                    telefone = value;
                }
            }
        }

        [Column(Name = "UF", DbType = "NVARCHAR(2)")]
        public string UF
        {
            get { return uf; }
            set
            {
                if (uf != value)
                {
                    uf = value;
                }
            }
        }

        [Column(Name = "Cidade", DbType = "NVARCHAR(50)")]
        public string Cidade
        {
            get { return cidade; }
            set
            {
                if (cidade != value)
                {
                    cidade = value;
                }
            }
        }

        [Column(Name = "Bairro", DbType = "NVARCHAR(50)")]
        public string Bairro
        {
            get { return bairro; }
            set
            {
                if (bairro != value)
                {
                    bairro = value;
                }
            }
        }

        [Column(Name = "Numero", DbType = "INT")]
        public int Numero
        {
            get { return numero; }
            set
            {
                if (numero != value)
                {
                    numero = value;
                }
            }
        }

        [Column(Name = "Endereco", DbType = "NVARCHAR(200)")]
        public string Endereco
        {
            get { return endereco; }
            set
            {
                if (endereco != value)
                {
                    endereco = value;
                }
            }
        }

        [Column(Name = "Nome", DbType = "NVARCHAR(200)")]
        public string Nome
        {
            get { return nome; }
            set
            {
                if (nome != value)
                {
                    nome = value;
                }
            }
        }

        [Column(Name = "IDSupermercado", IsPrimaryKey = true, DbType = "INT NOT NULL", CanBeNull = false)]
        public int IDSupermercado
        {
            get { return idsupermercado; }
            set
            {
                if (idsupermercado != value)
                {
                    idsupermercado = value;
                }
            }
        }

        /*private EntitySet<PrecoProtutoSupermercado> refIDSupermercado;
        [Association(Name = "FK_Supermercado_PrecoProdutoSupermercado", Storage = "refIDSupermercado", ThisKey = "IDSupermercado", OtherKey = "idSupermercadoSupermercado")]
        public EntitySet<PrecoProtutoSupermercado> FKIDSupermercado
        {
            get
            {
                return this.refIDSupermercado;
            }
        }

    }
    #endregion
     */
    
    /*#region Tabela PrecoProdutoSupermercado
    [Table(Name = "PrecoProdutoSupermercado")]
    public class PrecoProtutoSupermercado
    {
        private int _idproduto;
        private int _idsupermercado;
        private double preco;
        
        [Column(Name= "Preco",DbType = "DOUBLE NOT NULL", CanBeNull = false)]
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
        
        [Column(Name = "idSupermercadoSupermercado", DbType = "INT NOT NULL", CanBeNull = false)]
        public int idSupermercadoSupermercado
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

        #region Associações

        /*private EntityRef<Produtos> idproduto;
        [Association(ThisKey = "idProdutoProduto", OtherKey = "IDProduto", Storage = "idproduto")]
        public Produtos _Produtos 
        { 
            get { return idproduto.Entity; } 
            set { idproduto.Entity = value; } 
        }

        private EntityRef<Supermercado> idsupermercado;
        [Association(ThisKey = "idSupermercadoSupermercado", OtherKey = "IDSupermercado", Storage = "idsupermercado")]
        public Supermercado _Supermercados
        {
            get { return idsupermercado.Entity; }
            set { idsupermercado.Entity = value; }
        }

         * Uma associação representa um relacionamento um-para-muitos em um banco de dados, 
         * e é representado em LINQ to SQL por duas classes especiais - o EntityRef, 
         * que define o lado "um" da equação e do EntitySet que define o lado "muitos". 
         * No nosso exemplo, um PRECOPRODUTO pode ser atribuída um SUPERMERCADO, mas cada 
         * SUPERMERCADO pode conhecer vários PRECOPRODUTO. 
         * A maneira que nós representamos isso em nosso modelo de dados é definir uma propriedade 
         * EntityRef na classe PRECOPRODUTO, e uma propriedade EntitySet na classe SUPERMERCATO.       

        #endregion Associações
    }
    #endregion
     */

    #endregion
    
}