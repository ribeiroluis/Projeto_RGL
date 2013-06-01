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
using System.ComponentModel;
using System.Windows.Controls.Primitives;

namespace Projeto_RGL
{
    public partial class ResultadoPrecos : PhoneApplicationPage
    {
        string nomePoduto;
        Popup my_popup_cs = new Popup();

        public ResultadoPrecos()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            listDados.Items.Clear();
            var app = (Application.Current as App);
            nomePoduto = app.ParametroProduto;
            base.OnNavigatedTo(e);
            MessageBox.Show(nomePoduto);
            PageTitle.Text = nomePoduto;

            var lista = App.Visao.PesquisaPreço(nomePoduto);

            foreach (var item in lista)
            {
                string nome = item.preco + "\n" + item.supermercadonome + "\n" + item.supermercadoendereco + "\n" + item.supermercadotelefone + "\n";
                listDados.Items.Add(nome);
            }
        }

        public void display_cspopup(string sup)
        {
            Border border = new Border();                                                     // to create green color border
            border.BorderBrush = new SolidColorBrush(Colors.Black);
            border.BorderThickness = new Thickness(2);
            border.Margin = new Thickness(10, 10, 10, 10);

            StackPanel skt_pnl_outter = new StackPanel();                             // stack panel 
            skt_pnl_outter.Background = new SolidColorBrush(Colors.White);
            skt_pnl_outter.Orientation = System.Windows.Controls.Orientation.Vertical;

            TextBlock txt_blk2 = new TextBlock();                                      // Textblock 2
            txt_blk2.Text = sup;
            txt_blk2.TextAlignment = TextAlignment.Center;
            txt_blk2.FontSize = 24;
            txt_blk2.Margin = new Thickness(10, 0, 10, 0);
            txt_blk2.Foreground = new SolidColorBrush(Colors.Blue);


            //Adding control to stack panel            
            skt_pnl_outter.Children.Add(txt_blk2);

            StackPanel skt_pnl_inner = new StackPanel();
            skt_pnl_inner.Orientation = System.Windows.Controls.Orientation.Horizontal;            

            Button btn_cancel = new Button();                                           // Button cancel                                     
            btn_cancel.Content = "ok";
            btn_cancel.Width = 100;
            btn_cancel.Foreground = new SolidColorBrush(Colors.Blue);
            btn_cancel.Click += new RoutedEventHandler(btn_cancel_Click);

            skt_pnl_inner.Children.Add(btn_cancel);


            skt_pnl_outter.Children.Add(skt_pnl_inner);

            // Adding stackpanel  to border
            border.Child = skt_pnl_outter;

            // Adding border to pup-up
            my_popup_cs.Child = border;

            my_popup_cs.VerticalOffset = 400;
            my_popup_cs.HorizontalOffset = 10;

            my_popup_cs.IsOpen = true;
        }

        private void btn_continue_Click(object sender, RoutedEventArgs e)
        {            
            if (my_popup_cs.IsOpen)
            {
                my_popup_cs.IsOpen = false;
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if (my_popup_cs.IsOpen)
            {
                my_popup_cs.IsOpen = false;
            }
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            if (this.my_popup_cs.IsOpen)
            {
                my_popup_cs.IsOpen = false;
                e.Cancel = true;
            }            
        }

        private void listDados_Tap(object sender, GestureEventArgs e)
        {
            string select = listDados.SelectedItem.ToString();
            string aux = "";

            foreach (var item in select.Split('\n'))
            {
                if (!item.StartsWith("R$"))
                    aux += item + "\n";
            }



            display_cspopup(aux);
        }
    }
}