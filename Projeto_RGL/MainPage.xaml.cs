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
using Projeto_RGL.BaixarArquivoProdutos;
using Projeto_RGL.ContextoDados;
using Projeto_RGL.LerArquivo;


namespace Projeto_RGL
{

    class resultado
    {
        public string hora;
    }
    
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            resultado r = new resultado();
            DateTime hora = DateTime.Now;
            BaixarArquivoProdutos.BaixarArquivoProdutos b = new BaixarArquivoProdutos.BaixarArquivoProdutos();
            
            DateTime hora2 = DateTime.Now;
            TimeSpan result = hora2 - hora;
            r.hora = result.Milliseconds.ToString() + " milesegundos";
            List.Items.Add(r.hora);
        }
        
    }
}