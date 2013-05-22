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
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_RGL.Controles
{
    public class ModeloVisao
    {
        private DataContextBancodeDados SupermercadoDB;


        #region Propriedades
        private List<ProdutoTabela> produtos;
        public List<ProdutoTabela> Produtos
        {
            get
            {
                if (produtos == null)
                {
                    produtos = new List<ProdutoTabela>();
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

        private List<PrecoProdutoSupermercado> preco;
        public List<PrecoProdutoSupermercado> PrecoProdutoSupermercado
        {
            get
            {
                if (preco == null)
                {
                    preco = new List<PrecoProdutoSupermercado>();
                }
                return preco;
            }
           
        }

        #endregion

        public void CriarBD()
        {
            SupermercadoDB = new DataContextBancodeDados();

            if (SupermercadoDB.DatabaseExists())
            {
                SupermercadoDB.DeleteDatabase();
                SupermercadoDB.CreateDatabase();
            }
            else
                SupermercadoDB.CreateDatabase();
        }

        public void InsereProdutos(List<BaixarArquivoProdutos.ProdutoXML> _listProdutos)
        {
            
            foreach (var item in _listProdutos)
            {
                Produtos.Add(new ProdutoTabela { IDProduto = item.idProduto, Nome = item.nome, CodigoBarras = item.codbarras });
            }

            SupermercadoDB.Produto.InsertAllOnSubmit<ProdutoTabela>(Produtos);
            SupermercadoDB.SubmitChanges();
        }

        
        
        /// <summary>
        /// Metodo para ler os dados, retornando ok, falta vizualizar os dados 
        /// </summary>
        public List<BaixarArquivoProdutos.ProdutoXML> LoadData()
        {
            SupermercadoDB = new DataContextBancodeDados();

            List<BaixarArquivoProdutos.ProdutoXML> lista = new List<BaixarArquivoProdutos.ProdutoXML>();
            BaixarArquivoProdutos.ProdutoXML p;

            var queryListaProdutos = from r in SupermercadoDB.Produto select new { r.Nome };
            
            var Query = from m in SupermercadoDB.Produto                         
                         orderby m.Nome
                         select m;

            foreach (var item in Query)
            {
                p = new BaixarArquivoProdutos.ProdutoXML();
                p.nome = item.Nome;
                lista.Add(p);
            }

            return lista;
        }
    }
}
