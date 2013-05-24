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

        private void button1_Click(object sender, RoutedEventArgs e)
        {

            var lista = App.Visao.RetornaProdutos();
            
            foreach (var item in lista)
            {
                listview.Items.Add(item.nome);
            }
            
        }
    }
}