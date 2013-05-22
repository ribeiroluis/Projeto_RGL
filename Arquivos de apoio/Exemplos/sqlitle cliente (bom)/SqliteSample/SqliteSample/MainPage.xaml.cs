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
using System.Collections.ObjectModel;

namespace SqliteSample
{
    public partial class MainPage : PhoneApplicationPage
    {
        string str_update=null;
        public ObservableCollection<StudentList> student_oblist;
        List<StudentList> student_list;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            //for displaying list stored in database.........
            string str_create = "Create table if not exists Student_Table (StudentID Text,StudentName Text,StudentAddress Text)";
            (Application.Current as App).db.Create<StudentList>(str_create);            
            student_oblist = new ObservableCollection<StudentList>();
            string str_select = "SELECT * from Student_Table";
            student_oblist = (Application.Current as App).db.SelectObservableCollection<StudentList>(str_select);
            lst_student.ItemsSource = student_oblist;           
        }
        private void lst_student_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lst_student.SelectedIndex == -1)
                return;
            var selected = lst_student.SelectedItem as StudentList;
            str_update = selected.StudentID;
            txt_name.Text = selected.StudentName;
            lst_student.SelectedIndex = -1;
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            string str_create = "Create table if not exists Student_Table (StudentID Text,StudentName Text,StudentAddress Text)";
            (Application.Current as App).db.Create<StudentList>(str_create);            
        }

        private void btn_insert_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text != "" && txt_name.Text != "")
            {               
                int rec;
                student_list = new List<StudentList>();
                StudentList obj_list = new StudentList();
                obj_list.StudentID = txt_id.Text;
                obj_list.StudentName = txt_name.Text;
                obj_list.StudentAddress = txt_address.Text;
                student_list.Add(obj_list);
                string strInsert = "Insert into Student_Table (StudentID,StudentName,StudentAddress) values (@StudentID,@StudentName,@StudentAddress)";
                foreach (StudentList list in student_list)
                {
                    rec = (Application.Current as App).db.Insert<StudentList>(list, strInsert);
                }
                txt_id.Text="";
                txt_name.Text = "";
                txt_address.Text = "";
                MessageBox.Show("Record Inserted successfully.Please click to show students button to show records.");
            }
            else
            {
                MessageBox.Show("Please insert StudentID and StudentName");
            }
        }

        private void btn_select_Click(object sender, RoutedEventArgs e)
        {
            student_oblist = new ObservableCollection<StudentList>();
            string str_select = "SELECT * from Student_Table";
            student_oblist = (Application.Current as App).db.SelectObservableCollection<StudentList>(str_select);
            lst_student.ItemsSource = student_oblist;
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            string str_delete = "Delete from Student_Table";
            (Application.Current as App).db.Create<StudentList>(str_delete);
        }
    

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            // Update query for updating studentname 
            string update = txt_name.Text;
            if (update != "")
            {               
                string query_update = "UPDATE Student_Table SET StudentName='" + update + "' Where StudentID='" + str_update + "'";
                (Application.Current as App).db.Update<StudentList>(query_update);
                MessageBox.Show("To show update name click to show students button ");
                txt_name.Text = "";
            }
            else
            {
                MessageBox.Show("Please select student from listbox to update ");
            }
        }
      
    }
}