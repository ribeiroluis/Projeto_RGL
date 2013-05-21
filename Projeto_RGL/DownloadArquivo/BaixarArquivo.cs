using System.Net;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using Projeto_RGL.ViewModel;
using Projeto_RGL.ContextoDados;


namespace Projeto_RGL.BaixarArquivos
{
       
    public class BaixarArquivoProdutos
    {
        public class ProdutoXML
        {
            public int idProduto;
            public string nome;
            public string codbarras;
        }
                        
        public List<ProdutoXML> Lista;

        public BaixarArquivoProdutos()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Produtos.txt"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal/Arquivos/Produtos."));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] result = (e.Result).Split('\n');
                Lista = RetornaListaPreenchida(result);
            }

        }

        private List<ProdutoXML> RetornaListaPreenchida(string[] Arquivo)
        {
            List<ProdutoXML> ListadeProdutos = new List<ProdutoXML>();

            ProdutoXML produto;

            for (int i = 0; i < Arquivo.Length-1; i++)
            {
                string[] aux = Arquivo[i].Split(';');

                produto = new ProdutoXML();
                produto.idProduto = int.Parse(aux[0]);
                produto.nome = aux[1];
                produto.codbarras = aux[2];

                ListadeProdutos.Add(produto);
            }
            //InsereProdutos(ListadeProdutos);
            BancodeDados bd = new BancodeDados(ListadeProdutos);            
            
            return ListadeProdutos;
        }

        public void InsereProdutos(List<ProdutoXML> ListaProdutos)
        {
            List<Produtos> Produtos = new List<Produtos>();
            foreach (var item in ListaProdutos)
            {
                Produtos.Add(new Produtos
                {
                    IDProduto = item.idProduto,
                    Nome = item.nome,
                });
            }

            DataContextBancodeDados SupermercadoDB = new DataContextBancodeDados();
            SupermercadoDB.Produtos.InsertAllOnSubmit<Produtos>(Produtos);
            SupermercadoDB.SubmitChanges();

        }
    }
}

        
        