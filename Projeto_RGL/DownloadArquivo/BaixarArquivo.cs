﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using System.IO.IsolatedStorage;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Projeto_RGL.BaixarArquivo
{
    public class BaixarArquivo
    {
        
        
        public BaixarArquivo()
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();
            WebClient client = new WebClient();
            file.CreateDirectory("Arquivos");            
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Precos.txt"));
            MessageBox.Show("Baixado com sucesso");
        }

        void baixarProdutos()
        {
            
        }


        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Protudos.txt", FileMode.Create, file))
            {
                byte[] buffer = new byte[1024];
                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                    Debug.WriteLine(Encoding.UTF8.GetString(buffer, 0, buffer.Length));
                }
            }
        }
    }
}