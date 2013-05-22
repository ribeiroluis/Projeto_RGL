using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Projeto_RGL.ContextoDados;
using Projeto_RGL.BaixarArquivos;
using System.Data.Linq;
using Community.CsharpSqlite.SQLiteClient;

namespace Projeto_RGL.ViewModel
{
    public class ModelodeVisao
    {
        private DataContextBancodeDados SupermercadoDB;


        /*#region Propriendes
        private List<Produtos> produtos;
        public List<Produtos> Produtos
        {
            get
            {
                if (produtos == null)
                {
                    produtos = new List<Produtos>();
                }
                return produtos;
            }

        }

        
        private List<Categoria> categoria;
        public List<Categoria> Categoria
        {
            get
            {
                if (categoria == null)
                {
                    categoria = new List<Categoria>();
                }
                return categoria;
            }

        }

        private List<Supermercado> supermercado;
        public List<Supermercado> Supermercado
        {
            get
            {
                if (supermercado == null)
                {
                    supermercado = new List<Supermercado>();
                }
                return supermercado;
            }
            
        }

        private List<PrecoProtutoSupermercado> preco;
        public List<PrecoProtutoSupermercado> PrecoProdutoSupermercado
        {
            get
            {
                if (preco == null)
                {
                    preco = new List<PrecoProtutoSupermercado>();
                }
                return preco;
            }
           
        }
         
        
        #endregion*/ 

        public void CriarBD()
        {
            SupermercadoDB = new DataContextBancodeDados();
            if (!SupermercadoDB.DatabaseExists())
            {
                SupermercadoDB.CreateDatabase();
            }
        }

        public void CarregarDados()
        {   
        }

        
    }
}
