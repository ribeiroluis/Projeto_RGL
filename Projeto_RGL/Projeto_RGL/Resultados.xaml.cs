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
using Projeto_RGL.Controles;

namespace Projeto_RGL
{
    public partial class Resultados : PhoneApplicationPage
    {

        string nomePoduto;
       

        public Resultados()
        {
            InitializeComponent();
            
                        
            
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            var app = (Application.Current as App);
            nomePoduto = app.ParametroProduto;
            base.OnNavigatedTo(e);
            MessageBox.Show(nomePoduto);
            var lista = App.Visao.PesquisaPreço(nomePoduto);


            foreach (var item in lista)
            {
                Menu.Items.Add(item.supermercadonome);
            }

        }
    }
}