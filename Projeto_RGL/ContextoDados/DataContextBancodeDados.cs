using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Projeto_RGL.ContextoDados
{
    public class DataContextBancodeDados : DataContext
    {
        public DataContextBancodeDados()
            : base(@"Data Source=isostore:/Supermercados.sdf") { }
    }

    [Table(Name = "Produtos")]
    public class Produtos
    {
        private int idproduto;
        private string codbarras;
        private string nome;
        
        [Column]
        internal int IDCategoria;

        private EntityRef<Catgoria> _idcategoria;

        [Association(Storage = "_idcatergoria", ThisKey = "IDCategoria", 


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

        [Column(Name = "IDProduto", IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", CanBeNull = false, AutoSync = AutoSync.OnInsert)]
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
    }


    [Table(Name = "Categoria")]
    public class Catgoria
    {
        private int idcategoria;

        [Column(Name = "IDCategoria",IsPrimaryKey = true, DbType = "INT NOT NULL Identity", CanBeNull = false)]
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
}