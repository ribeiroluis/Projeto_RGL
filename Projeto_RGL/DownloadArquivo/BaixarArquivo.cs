using System.Net;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace Projeto_RGL.BaixarArquivos
{

    public class ProdutoXML
    {
        public string idProduto;
        public string nome;
        public string codbarras;
    }
    

    public class BaixarArquivoProdutos
    {
        DateTime hora1 = DateTime.Now;
        public List<ProdutoXML> Lista;

        public BaixarArquivoProdutos()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Produtos.txt"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal/Arquivos/Produtos.xml"));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            resultado r = new resultado();

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
                produto.idProduto = aux[0];
                produto.nome = aux[1];
                produto.codbarras = aux[2];

                ListadeProdutos.Add(produto);
            }

            DateTime hora2 = DateTime.Now;

            TimeSpan resultado = hora2 - hora1;

            return ListadeProdutos;
        }
    }
}

        
        