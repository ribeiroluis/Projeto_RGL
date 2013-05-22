using System;
using System.Windows.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Net;
using System.Windows;
using System.Collections.Generic;

namespace Projeto_RGL
{
    public class DataContextBancodeDados : DataContext
    {
        public DataContextBancodeDados()
            : base(@"Data Source=isostore:/Supermercados.sdf") { }

        public Table<ProdutoTabela> Produto;
        //public Table<Categoria> Categoria;
        //public Table<Supermercado> Supermercado;
        //public Table<PrecoProdutoSupermercado> PrecoProdutoSupermercado;

    }

    [Table(Name = "Produtos")]
    public class ProdutoTabela
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
    }

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
    }
    
    [Table(Name = "PrecoProdutoSupermercado")]
    public class PrecoProdutoSupermercado
    {
        private int _idproduto;
        private int _idsupermercado;
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


    }
}


    