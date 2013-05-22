using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Xml.Linq;
using System.Threading;
using System.IO;

namespace GetXML
{
    public partial class Form1 : Form
    {
        WebClient wc = new WebClient();        
        ManualResetEvent handle = new ManualResetEvent(true);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"Lista.xml"))
            {
                File.Delete(@"Lista.xml");
            }

            //var proxy = Proxy();
            //wc.Proxy = proxy;
            
            wc.DownloadProgressChanged += WcOnDownloadProgressChanged;
            wc.DownloadFileCompleted += WcOnDownloadFileCompleted;
            wc.DownloadFileAsync(new Uri(@"http://alcsistemas.heliohost.org/Arquivos/Lista.xml"), @"Lista.xml");
            handle.WaitOne(); // wait for the async event to complete
        }
        
        void WcOnDownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (!e.Cancelled && e.Error == null)
            {
                //async download completed successfully
            }
            else
                MessageBox.Show(e.Error.ToString());
            handle.Set(); // in both the case let the void main() know that async event had finished so that i can quit
        }

        void WcOnDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // handle the progres in case of async
            //e.ProgressPercentage
            progressBar1.Value = e.ProgressPercentage;
        }

        private WebProxy Proxy()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.pucminas.br");

            IWebProxy proxy = request.Proxy;
            if (proxy != null)
            {
                MessageBox.Show("Proxy: " +  proxy.GetProxy(request.RequestUri).ToString());
            }
            else
            {
                Console.WriteLine("Proxy is null; no proxy will be used");
            }

            WebProxy myProxy = new WebProxy();
            Uri newUri = new Uri(proxy.GetProxy(request.RequestUri).ToString());
            // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
            myProxy.Address = newUri;
            // Create a NetworkCredential object and associate it with the 
            // Proxy property of request object.

            login log = new login();
            log.ShowDialog();
            

            myProxy.Credentials = new NetworkCredential(log.txUsuario.Text, log.txSenha.Text);
            request.Proxy = myProxy;
            if (myProxy.Credentials == null)
                return null;
            else
                return myProxy;
        }
    }
}
            