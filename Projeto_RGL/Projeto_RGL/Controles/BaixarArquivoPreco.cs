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
using System.Collections.Generic;

namespace Projeto_RGL.Controles
{
    public class BaixarArquivoPreco
    {
        public class PrecoTXT
        {
            public int idSupermercado;
            public int idProduto;
            public float preco;
        }

        public List<PrecoTXT> Lista;

        public void Baixar()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Preco.txt"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal//Arquivos/Preco.txt"));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] result = (e.Result).Split('\n');
                Lista = RetornaListaPreenchida(result);
                App.Visao.InserePreco(Lista);
            }

        }

        private List<PrecoTXT> RetornaListaPreenchida(string[] Arquivo)
        {
            List<PrecoTXT> Lista = new List<PrecoTXT>();

            PrecoTXT x;

            for (int i = 0; i < Arquivo.Length-1; i++)
            {
                string[] aux = Arquivo[i].Split(';');

                x = new PrecoTXT();
                x.idSupermercado = int.Parse(aux[0]);
                x.idProduto = int.Parse(aux[1]);
                x.preco = float.Parse(aux[2]);

                Lista.Add(x);
            }
            return Lista;
        }
    }
}
