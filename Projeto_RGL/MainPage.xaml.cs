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
using Projeto_RGL.DownloadXML;
using Projeto_RGL.LerXML;


namespace Projeto_RGL
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BaixarXML baixa = new BaixarXML();
                MessageBox.Show("Baixado com sucesso");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);                
            }
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadXML ler = new ReadXML();
                scrollViewer1.
                txBoxXML.Text = ler.LerXML();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);
            }
        }
        
    }
}