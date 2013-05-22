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
using SQLiteClient;

namespace WPSQLiteDemo
{
    public partial class MainPage : PhoneApplicationPage
    {
        SQLiteConnection mySQLiteDB = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            buttonOpen.IsEnabled = true;
            buttonClear.IsEnabled = false;
            buttonClose.IsEnabled = false;
            buttonPopulate.IsEnabled = false;
        }

        private void buttonOpen_Click(object sender, RoutedEventArgs e)
        {
            if (mySQLiteDB == null)
            {
                mySQLiteDB = new SQLiteConnection("MyTestDB");
                mySQLiteDB.Open();

                buttonOpen.IsEnabled = false;
                buttonClear.IsEnabled = false;
                buttonPopulate.IsEnabled = true;
                buttonClose.IsEnabled = true;
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            if (mySQLiteDB != null)
            {
                mySQLiteDB.Dispose();
                mySQLiteDB = null;
                buttonOpen.IsEnabled = true;
                buttonClear.IsEnabled = false;
                buttonPopulate.IsEnabled = false;
                buttonClose.IsEnabled = false;
            }

        }

        private void buttonPopulate_Click(object sender, RoutedEventArgs e)
        {
            SQLiteCommand cmd = mySQLiteDB.CreateCommand("Create table RegisteredStudents (id int primary key,name text,zipcode numeric(7))");
            int i = cmd.ExecuteNonQuery();
            int id = 0;
            string name = "Name" + id;
            int zipcode = 98000;
            for (int j = 0; j < 10; j++)
            {
                id++;
                name = "Name" + id;
                zipcode = 98000 + id;
                cmd.CommandText = " Insert into RegisteredStudents (id, name, zipcode) values (" + id + ",\"" + name + "\"," + zipcode + ")";
                i = cmd.ExecuteNonQuery();
            }
            buttonPopulate.IsEnabled = false;
            buttonClear.IsEnabled = true;
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            SQLiteCommand cmd = mySQLiteDB.CreateCommand("drop table RegisteredStudents");
            int i = cmd.ExecuteNonQuery();

            buttonPopulate.IsEnabled = true;
            buttonClear.IsEnabled = false;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            SQLiteCommand cmd = mySQLiteDB.CreateCommand("SELECT * FROM RegisteredStudents");
            cmd.ExecuteNonQuery();
            
        }
    }
}