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
using System.Xml;
using System.IO.IsolatedStorage;
using System.IO;
using System.Diagnostics;
using System.Text;

namespace Projeto_RGL.LerArquivo
{
    public class ReadArquivo
    {
        public ReadArquivo()
        {
            LerArquivo();
           
        }

        public string [] LerArquivo()
        {
            var file = IsolatedStorageFile.GetUserStoreForApplication();
            string[] _Arquivo = { "Não encontrado" };            
            try
            {
                using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(@"Produto.txt", FileMode.Open, file))
                {
                    long length = stream.Length;
                    byte[] decoded = new byte[length];
                    stream.Read(decoded, 0, (int)length);
                    Debug.WriteLine(Encoding.UTF8.GetString(decoded, 0, (int)length));
                    return _Arquivo;
                }
            }
            catch
            {
                return _Arquivo;
            }
 
        }
        
    }
}
