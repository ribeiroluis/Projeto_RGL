using System.Net;
using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


namespace Projeto_RGL.BaixarArquivoProdutos
{

    public class ProdutoXML
    {
        public string idProduto;
        public string nome;
        public string codbarras;
    }


    public class BaixarArquivoProdutos
    {

        public BaixarArquivoProdutos()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Produtos.xml"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal/Arquivos/Produtos.xml"));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            resultado r = new resultado();

            if (e.Error == null)
            {
                var result = (e.Result);
                XDocument docxml = XDocument.Parse(result);
                List<ProdutoXML> Lista = RetornaListaPreenchida(docxml);
            }
        }

        private List<ProdutoXML> RetornaListaPreenchida(XDocument documentoxml)
        {
            List<ProdutoXML> ListadeProdutos = new List<ProdutoXML>();
            
            ProdutoXML produto;

            XElement docelement = XElement.Parse(documentoxml.ToString());

            var query = from p in documentoxml.Elements("Produto") select p;
            
            foreach (var e in query)
            {
                produto = new ProdutoXML();
                produto.idProduto = e.Element("idProduto").Value;
                produto.nome = e.Element("Nome").Value;
                produto.codbarras = e.Element("CodBaras").Value;
                
                ListadeProdutos.Add(produto);
            }
                

            return ListadeProdutos;
        }
    }
}

        
        