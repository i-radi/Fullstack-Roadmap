using Center_Application.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Center_Application
{
    /// <summary>
    /// Interaction logic for Student_Details.xaml
    /// </summary>
    public partial class Student_Details : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();

        
        int id = 0;
        StudentsDetail result;
        public Student_Details()
        {
            InitializeComponent();
            ViewStudents.ItemsSource = db.StudentsDetails.Select(x=> new { x.ID, x.tbStudent.studentName, x.tbCours.courseName, x.tbCours.Instructor ,x.Date }).ToList();
            userName.Content = user.userName;

        }

        private void ViewStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                id = int.Parse(GetSelectedCellValue());
                result = db.StudentsDetails.SingleOrDefault(x => x.ID == id);

                txtID.Text = result.tbStudent.ID.ToString();
                txtName.Text = result.tbStudent.studentName;
                txtCourse.Text = result.tbCours.courseName;
                txtDate.Text = result.Date.ToString();
                txtPrice.Text= result.tbCours.Price.ToString();
                txtInstructor.Text = result.tbCours.Instructor;
                
                img.Source = (result.tbStudent.Image == null || result.tbStudent.Image == "") ? new BitmapImage(new Uri("C:\\Users\\iradi\\source\\repos\\Center Application\\Center Application\\Images\\imgStudents.png")) : new BitmapImage(new Uri(result.tbStudent.Image));
            }
            catch { }
        }

        public string GetSelectedCellValue()
        {
            DataGridCellInfo cellInfo = ViewStudents.SelectedCells[0];
            if (cellInfo == null) return null;

            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            if (column == null) return null;

            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);

            return element.Tag.ToString();
        }
        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewStudents.ItemsSource = db.StudentsDetails.Where(x => x.tbStudent.studentName.StartsWith(txtName.Text))
                .Select(x => new { x.ID, x.tbStudent.studentName, x.tbCours.courseName, x.tbCours.Instructor, x.Date }).ToList();


        }





        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == ""  || txtCourse.Text == "")
            {
                MessageBox.Show("Name and Course are Required");
                return;
            }
            StudentsDetail st = new DB.StudentsDetail();
            st.StudentId = db.tbStudents.SingleOrDefault(x => x.studentName == txtName.Text).ID;
            st.CoursesId = db.tbCourses.SingleOrDefault(x => x.courseName == txtCourse.Text).ID;
            st.Date = DateTime.Now;
            db.StudentsDetails.Add(st);
            db.SaveChanges();
            ViewStudents.ItemsSource = db.StudentsDetails.Select(x => new { x.ID, x.tbStudent.studentName, x.tbCours.courseName, x.tbCours.Instructor, x.Date }).ToList();

            MessageBox.Show("Done!");

        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Please Addor Delete Course to Student");
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                var result = db.StudentsDetails.Find(id);
                db.StudentsDetails.Remove(result);
                db.SaveChanges();
                MessageBox.Show("Done!");
                ViewStudents.ItemsSource = db.StudentsDetails.Select(x => new { x.ID, x.tbStudent.studentName, x.tbCours.courseName, x.tbCours.Instructor, x.Date }).ToList();


            }
        }

    }
}
