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
using System.Text;

namespace Projeto_RGL.Controles
{
    public class PrecosPesquisados
    {
        public string produto { get; set; }
        public string preco { get; set; }
        public string  supermercadonome { get; set; }
        public string  supermercadoendereco { get; set; }
        public string supermercadotelefone { get; set; }
    }


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
        
        private List<CategoriaTabela> categoria;
        public List<CategoriaTabela> Categoria
        {
            get
            {
                if (categoria == null)
                {
                    categoria = new List<CategoriaTabela>();
                }
                return categoria;
            }

        }

        private List<SupermercadoTabela> supermercado;
        public List<SupermercadoTabela> Supermercado
        {
            get
            {
                if (supermercado == null)
                {
                    supermercado = new List<SupermercadoTabela>();
                }
                return supermercado;
            }
            
        }

        private List<PrecoProdutoTabela> preco;
        public List<PrecoProdutoTabela> PrecoProduto
        {
            get
            {
                if (preco == null)
                {
                    preco = new List<PrecoProdutoTabela>();
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

        public void InsereProdutos(List<BaixarArquivoProduto.ProdutoTXT> _listProdutos)
        {
            
            foreach (var item in _listProdutos)
            {
                Produtos.Add(new ProdutoTabela { Id = item.idProduto, Nome = item.nome, CodigoBarras = item.codbarras });
            }

            SupermercadoDB.Produto.InsertAllOnSubmit<ProdutoTabela>(Produtos);
            SupermercadoDB.SubmitChanges();
            MessageBox.Show("Banco de dados Produto atualizado!");
        }

        public void InsereSupermercados(List<BaixarArquivoSupermercado.SupermercadoTXT> _listSupermercado)
        {
            foreach (var item in _listSupermercado)
            {
                Encoding d = Encoding.UTF8;


                Supermercado.Add(new SupermercadoTabela { IdSupermercado = item.idSupermercado, Nome = item.nome, Endereco = item.endereco, Telefone = item.telefone, Bairro = item.bairro, Numero = int.Parse(item.numero) });
            }

            SupermercadoDB.Supermercado.InsertAllOnSubmit<SupermercadoTabela>(Supermercado);
            SupermercadoDB.SubmitChanges();
            MessageBox.Show("Banco de dados Supermercado atualizado!");
        }

        public void InserePreco(List<BaixarArquivoPreco.PrecoTXT> _listPreco)
        {
            foreach (var item in _listPreco)
            {
                PrecoProduto.Add(new PrecoProdutoTabela { SupermercadoID = item.idSupermercado, ProdutoID = item.idProduto, Preco = item.preco });
            }

            SupermercadoDB.PrecoProduto.InsertAllOnSubmit<PrecoProdutoTabela>(PrecoProduto);
            SupermercadoDB.SubmitChanges();
            MessageBox.Show("Banco de dados Preços atualizado!");            
        }
        
        /// <summary>
        /// Metodo para ler os dados, retornando ok, falta vizualizar os dados 
        /// </summary>
        public List<BaixarArquivoProduto.ProdutoTXT> RetornaProdutos()
        {
            SupermercadoDB = new DataContextBancodeDados();

            List<BaixarArquivoProduto.ProdutoTXT> lista = new List<BaixarArquivoProduto.ProdutoTXT>();
            BaixarArquivoProduto.ProdutoTXT p;

            var queryListaProdutos = from r in SupermercadoDB.Produto select new { r.Nome };
            
            var Query = from m in SupermercadoDB.Produto                         
                         orderby m.Nome
                         select m;

            foreach (var item in Query)
            {
                p = new BaixarArquivoProduto.ProdutoTXT();
                p.nome = item.Nome;
                lista.Add(p);
            }

            return lista;
        }     
        
        public List<BaixarArquivoProduto.ProdutoTXT> PesquisaProduto(string Nome)
        {
            List<BaixarArquivoProduto.ProdutoTXT> list = new List<BaixarArquivoProduto.ProdutoTXT>();
            BaixarArquivoProduto.ProdutoTXT p;


            var produto = from pr in SupermercadoDB.Produto
                          where pr.Nome.Contains(Nome)
                          select pr;
            foreach (var item in produto)
            {
                p = new BaixarArquivoProduto.ProdutoTXT();
                p.nome = item.Nome;
                list.Add(p);
            }

            return list;
        }

        public List<PrecosPesquisados> PesquisaPreço(string NomeProd)
        {
            string aux = "";

            foreach (var item in NomeProd)
            {
                if (!item.Equals('\n'))
                    aux += item;
                else
                    aux += ' ';
            }
            string auxprod = NomeProd;
            NomeProd = aux;

            var querypreco = from pre in SupermercadoDB.PrecoProduto
                        join prod in SupermercadoDB.Produto on pre.ProdutoID equals prod.Id
                        join sup in SupermercadoDB.Supermercado on pre.SupermercadoID equals sup.IdSupermercado
                        where prod.Nome == NomeProd
                        orderby pre.Preco
                        select new { nome = prod.Nome, preco = (pre.Preco), SupNome = sup.Nome, SupEndereco = sup.Endereco,
                            SupNumero = sup.Numero,SupBairro = sup.Bairro, Suptelefone = sup.Telefone };


            List<PrecosPesquisados> lista = new List<PrecosPesquisados>();
            PrecosPesquisados p;

            foreach (var item in querypreco)
            {
                p = new PrecosPesquisados();
                p.supermercadonome = item.SupNome;
                p.supermercadoendereco = item.SupEndereco;
                p.supermercadotelefone = item.Suptelefone;
                p.supermercadoendereco = item.SupEndereco + ", " + item.SupNumero + "\n" + item.SupBairro;
                p.preco = (item.preco).ToString("c");
                p.produto = item.nome;
                lista.Add(p);
                
                //s += s + preco + "Produto:" + item.nome + "\nPreço" + item.preco + "\nSupermercado:" + item.Spmercado + "\n\n";                               
            }

            return lista;
            
            
        }
    }

    
}
