using System;
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

namespace Projeto_RGL.DownloadXML
{
    public class BaixarXML
    {
        
        
        public BaixarXML()
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();
            WebClient client = new WebClient();
            file.CreateDirectory("Listas");
            client.OpenReadCompleted += new OpenReadCompletedEventHandler(client_OpenReadCompleted);
            client.OpenReadAsync(new Uri("http://alcsistemas.heliohost.org/Arquivos/Lista.xml"));
        }
        void client_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();

            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("Lista.xml", FileMode.Create, file))
            {
                byte[] buffer = new byte[1024];
                while (e.Result.Read(buffer, 0, buffer.Length) > 0)
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
        }
    }
}
