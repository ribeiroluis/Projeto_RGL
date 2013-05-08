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

namespace Projeto_RGL.LerXML
{
    public class ReadXML
    {
        public ReadXML()
        {
            
           
        }

        public string LerXML()
        { 
            try
            {                
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    IsolatedStorageFileStream isoFileStream = myIsolatedStorage.OpenFile("Lista.xml", FileMode.Open);
                    using (StreamReader reader = new StreamReader(isoFileStream))
                    {
                        var xml = reader.ReadToEnd();
                        return xml;
                    }
                }
            }
            catch
            {
                return "Não encontrato";
            }
 
        }
        
    }
}
