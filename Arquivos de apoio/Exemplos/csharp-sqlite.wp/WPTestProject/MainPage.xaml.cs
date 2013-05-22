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
using Community.CsharpSqlite; 

namespace WPTestProject
{
    public partial class MainPage : PhoneApplicationPage
    {       
        public MainPage()
        {
            InitializeComponent();

            SupportedOrientations = SupportedPageOrientation.Portrait | SupportedPageOrientation.Landscape;
        }

        private string fileName = "Test.DB";
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {            
            int rc;
            string errMsg = string.Empty;
            if (db == null)
                if (!OpenDB())
                    return;
            rc = Sqlite3.sqlite3_exec(db, btnCreate.Content.ToString().Substring(2), (Sqlite3.dxCallback)this.callback, null, ref errMsg);
            if (rc != Sqlite3.SQLITE_OK)            
                lbOutput.Text += "\nError: " + Sqlite3.sqlite3_errmsg(db);            
            else
                lbOutput.Text += "\nCommand completed successfully";
        }

        int callback(object pArg, System.Int64 nArg, object azArgs, object azCols)
        {
            int i;
            string[] azArg = (string[])azArgs;
            string[] azCol = (string[])azCols;
            String sb="";// = new String();
            for (i = 0; i < nArg; i++)            
                sb+=azCol[i] + " = " + azArg[i] + "\n";            
            lbOutput.Text += ("\n" + sb.ToString());
            return 0;
        }

        private void btnDrop_Click(object sender, RoutedEventArgs e)
        {
            int rc;
            string errMsg = string.Empty;
            if (db == null)
                if (!OpenDB())
                    return;
            rc = Sqlite3.sqlite3_exec(db, btnDrop.Content.ToString().Substring(2), (Sqlite3.dxCallback)this.callback, null, ref errMsg);
            if (rc != Sqlite3.SQLITE_OK)           
                lbOutput.Text += "\nError: " + Sqlite3.sqlite3_errmsg(db);  
            else                      
                lbOutput.Text += "\nCommand completed successfully";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            int rc;
            string errMsg = string.Empty;
            if (db == null)
                if (!OpenDB())
                    return;
            rc = Sqlite3.sqlite3_exec(db, btnInsert.Content.ToString().Substring(2), (Sqlite3.dxCallback)this.callback, null, ref errMsg);
            if (rc != Sqlite3.SQLITE_OK)           
                lbOutput.Text += "\nError: " + Sqlite3.sqlite3_errmsg(db);    
            else         
                lbOutput.Text += "\nCommand completed successfully";
        }
        Sqlite3.sqlite3 db=null;
        public bool OpenDB()
        {
            int rc;
            db = new Sqlite3.sqlite3();
            rc = Sqlite3.sqlite3_open(fileName, ref db);
            if (rc != 0)
            {
                lbOutput.Text += "\nCannot open database: " + Sqlite3.sqlite3_errmsg(db);
                db = null;
                return false;
            }
            lbOutput.Text += "\nDatabase opened.";
            return true;
        }
        public bool CloseDB()
        {
            int rc;
            if (db != null)
            {
                rc = Sqlite3.sqlite3_close(db);
                if (rc != 0)
                {
                    lbOutput.Text += "\nCannot close database: " + Sqlite3.sqlite3_errmsg(db);
                    db = null;
                    return false;
                }
            }
            lbOutput.Text += "\nDatabase closed.";
            return true;
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (OpenDB())
            {
                btnCreate.IsEnabled = true;
                btnDrop.IsEnabled = true;
                btnInsert.IsEnabled = true;
                btnClose.IsEnabled = true;
                btnOpen.IsEnabled = false;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (CloseDB())
            {
                btnCreate.IsEnabled = false;
                btnDrop.IsEnabled = false;
                btnInsert.IsEnabled = false;
                btnOpen.IsEnabled = true;
                btnClose.IsEnabled = false;
            }

        }   
    }
}