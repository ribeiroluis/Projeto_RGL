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
        public Table<CategoriaTabela> Categoria;
        public Table<SupermercadoTabela> Supermercado;
        public Table<PrecoProdutoTabela> PrecoProduto;

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
    public class SupermercadoTabela
    {
   
        private int _idsupermercado;
        private string _nome;
        private string _endereco;
        private int _numero;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _telefone;

        public SupermercadoTabela()
        {
        }
        
        [Column(Name = "Telefone", DbType = "NVARCHAR(200)")]
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
        public int IdSupermercado
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

    }

    [Table(Name = "PrecoProdutoSupermercado")]
    public class PrecoProdutoTabela
    {

        public PrecoProdutoTabela()
        {

        }

        private int _idTabela;
        [Column(Name="ID", IsPrimaryKey = true, IsDbGenerated = true,DbType = "INT NOT NULL Identity", CanBeNull = false,AutoSync = AutoSync.OnInsert)]
        public int ID
        {
            get { return _idTabela; }
            set 
            { 
                if (_idTabela != value)
                    _idTabela = value; 
            }
        }
        
        private int _idproduto;
        [Column(Name = "ProdutoID", DbType = "INT NOT NULL", CanBeNull = false)]
        public int ProdutoID
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
        [Column(Name="SupermercadoID", DbType = "INT NOT NULL", CanBeNull = false)]
        public int SupermercadoID
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

        private double preco;
        [Column(Name = "Preco", DbType = "FLOAT NOT NULL", CanBeNull = false)]
        public double Preco
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
        
    }
}


    
