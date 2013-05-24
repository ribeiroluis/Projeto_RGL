using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;


namespace Projeto_RGL
{

    public class BaixarArquivoProduto
    {
        public class ProdutoTXT
        {
            public int idProduto;
            public string nome;
            public string codbarras;
        }

        public List<ProdutoTXT> Lista;        
        
        public void Baixar()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Produtos.txt"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal/Arquivos/Produtos.txt"));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] result = (e.Result).Split('\n');
                Lista = RetornaListaPreenchida(result);
                App.Visao.InsereProdutos(Lista);
            }

        }

        private List<ProdutoTXT> RetornaListaPreenchida(string[] Arquivo)
        {
            List<ProdutoTXT> ListadeProdutos = new List<ProdutoTXT>();

            ProdutoTXT produto;

            for (int i = 0; i < Arquivo.Length - 1; i++)
            {
                string[] aux = Arquivo[i].Split(';');

                produto = new ProdutoTXT();
                produto.idProduto = int.Parse(aux[0]);
                produto.nome = aux[1];
                produto.codbarras = aux[2];
                ListadeProdutos.Add(produto);
            }
            return ListadeProdutos;
        }
        
    }
}


        
        