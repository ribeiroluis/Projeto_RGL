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
    public class BaixarArquivoSupermercado
    {
        public class SupermercadoTXT
        {
            public int idSupermercado;
            public string nome;
            public string endereco;
            public string telefone;
        }

        public List<SupermercadoTXT> Lista;

        public void Baixar()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += RequestCompleted;
            webClient.DownloadStringAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Supermercado.txt"));
            //webClient.DownloadStringAsync(new Uri("http://localhost/SiteLocal//Arquivos/Supermercado.txt"));
        }

        private void RequestCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string[] result = (e.Result).Split('\n');
                Lista = RetornaListaPreenchida(result);
                App.Visao.InsereSupermercados(Lista);
            }

        }

        private List<SupermercadoTXT> RetornaListaPreenchida(string[] Arquivo)
        {
            List<SupermercadoTXT> Lista = new List<SupermercadoTXT>();

            SupermercadoTXT x;

            for (int i = 0; i < Arquivo.Length; i++)
            {
                string[] aux = Arquivo[i].Split(';');

                x = new SupermercadoTXT();
                x.idSupermercado = int.Parse(aux[0]);
                x.nome = aux[1];
                x.endereco = aux[2];
                x.telefone = aux[3];

                Lista.Add(x);
            }
            return Lista;
        }
    }
}
