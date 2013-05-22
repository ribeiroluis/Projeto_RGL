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
using Projeto_RGL.BaixarArquivos;
using Projeto_RGL.ContextoDados;
using System.Windows.Navigation;
using System.Diagnostics;
using Microsoft.Phone.Net.NetworkInformation;
using Projeto_RGL.ViewModel;
using Community.CsharpSqlite.SQLiteClient;


namespace Projeto_RGL
{
    public partial class MainPage : PhoneApplicationPage
    {

        /// <summary>
        /// Construtor 
        /// </summary>
        public MainPage()
        {
            if (Verificaconexao())
            {
                InitializeComponent();
            }
            else
            {
                MessageBox.Show("Você precisa de conexão a internet para utilizar o aplicativo.");
            }
        }

        /// <summary>
        /// Meodo para verificar conexao
        /// </summary>
        /// <returns>Boleano</returns>
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
            //ModelodeVisao db = new ModelodeVisao();
            //db.CriarBD();
            BaixarArquivoProdutos baixar = new BaixarArquivoProdutos();


        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            BancodeDadosProdutos bd = new BancodeDadosProdutos();
            List<BaixarArquivoProdutos.ProdutoXML> list = bd.PesquisaProduto();

            foreach (var item in list)
            {
                List.Items.Add(item.nome);
            }
        }
    }
}