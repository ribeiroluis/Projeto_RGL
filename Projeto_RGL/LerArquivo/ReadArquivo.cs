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
using System.Collections.Generic;

namespace Projeto_RGL.LerArquivo
{
    public class ReadArquivo
    {
        public ReadArquivo()
        {

        }
        /*public List<Task> GetTasks()
        {
            var tasks = new List<Task>();
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (store.FileExists(XmlFile))
                {
                    //store.DeleteFile(XmlFile);
                    //XDocument doc = XDocument.Load(store.OpenFile(XmlFile, FileMode.Open));
                    using (var sr = new StreamReader(new IsolatedStorageFileStream(XmlFile, FileMode.Open, store)))
                    {
                        XDocument doc = XDocument.Load(sr);
                        tasks = (from d in doc.Descendants("task")
                                 select new Task
                                 {
                                     Category = (string)d.Attribute("category"),
                                     Id = (string)d.Attribute("id"),
                                     Name = (string)d.Element("name"),
                                     CreateDate = (DateTime)d.Element("createdate"),
                                     DueDate = (DateTime)d.Element("duedate"),
                                     IsComplete = (bool)d.Element("isComplete")
                                 }).ToList<Task>();
                    }
                }
            }
            return tasks;
        }
        */
    }
}

        
