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
using System.ComponentModel;
using Microsoft.Phone.Shell;

namespace Projeto_RGL
{
    public partial class MainPage : PhoneApplicationPage
    {

        // Constructor
        public MainPage()
        {
            if (Verificaconexao())
            {
                InitializeComponent();
                App.Visao.CriarBD();
                App.DownloadProdutos.Baixar();
                App.DownloadSupermercado.Baixar();
                App.DownloadPrecos.Baixar();                
            }
            else
            {
                MessageBox.Show("Você necessita de conexão para utilizar esta aplicação");                
            }
        }

        private bool Verificaconexao()
        {
            var testa = NetworkInterface.GetIsNetworkAvailable();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                return true;
            }
            else
                return false;
        }

       
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            listview.Items.Clear();

            var lista = App.Visao.PesquisaPreco(txNomeProduto.Text);

            foreach (var item in lista)
            {
                bool parada = false;
                string aux = "";
                for (int i = 0; i < item.nome.Length; i++)
                {
                    if (i > 20 && item.nome[i].Equals(' ') && parada == false)
                    {
                        aux += "\n";
                        parada = true;
                    }
                    else
                        aux += item.nome[i];

                }

                aux += "\n";


                listview.Items.Add(aux);
            }
        }

    }
}