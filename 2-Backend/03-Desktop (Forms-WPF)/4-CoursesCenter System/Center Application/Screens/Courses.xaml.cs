using Center_Application.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();
        string ImagePath="";
        int id = 0;
        tbCours result;


        public Courses()
        {
            InitializeComponent();

            userName.Content = user.userName;

            ViewCourses.ItemsSource = db.tbCourses.Select(x => new {x.ID,x.courseName,x.Price,x.Instructor,x.tbCategory.categoryName,x.Notes }).ToList();

            txtCategory.ItemsSource = db.tbCategories.ToList();

        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtInstructor.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Name ,Instructor and Price are Required");
                return;
            }

            decimal price;
            decimal.TryParse(txtPrice.Text,out price);

            tbCours c = new DB.tbCours();
            c.courseName = txtName.Text;
            c.Instructor = txtInstructor.Text;
            c.Notes = txtNotes.Text;
            c.Price = price;
            c.Categoryid = int.Parse(txtCategory.SelectedValue.ToString());

            db.tbCourses.Add(c);
            db.SaveChanges();

            if (ImagePath != "")
            {
                string newPath = Environment.CurrentDirectory + $"\\Images\\Courses\\{c.ID}.png";
                File.Copy(ImagePath, newPath);
                c.Image = newPath;
                db.SaveChanges();

            }
            MessageBox.Show("Done!");
            ViewCourses.ItemsSource = db.tbCourses.Select(x => new { x.ID, x.courseName, x.Price, x.Instructor, x.tbCategory.categoryName, x.Notes }).ToList();

        }

        private void btEditImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img.Source = new BitmapImage(new Uri(op.FileName));
                ImagePath = op.FileName;
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewCourses.ItemsSource = db.tbCourses.Where(x => x.courseName.Contains( txtName.Text)).Select(x => new { x.ID, x.courseName, x.Price, x.Instructor, x.tbCategory.categoryName, x.Notes }).ToList();
        }

        private void ViewCourses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
            id= int.Parse( GetSelectedCellValue());
            result = db.tbCourses.SingleOrDefault(x => x.ID == id);

            txtID.Text = result.ID.ToString();
            txtInstructor.Text = result.Instructor;
            txtName.Text = result.courseName;
            txtNotes.Text = result.Notes;
            txtPrice.Text = result.Price.ToString();
            txtCategory.SelectedValue = result.Categoryid;
            img.Source= new BitmapImage(new Uri(result.Image));
            }
            catch { }
        }

        public string GetSelectedCellValue()
        {
            DataGridCellInfo cellInfo = ViewCourses.SelectedCells[0];
            if (cellInfo == null) return null;

            DataGridBoundColumn column = cellInfo.Column as DataGridBoundColumn;
            if (column == null) return null;

            FrameworkElement element = new FrameworkElement() { DataContext = cellInfo.Item };
            BindingOperations.SetBinding(element, TagProperty, column.Binding);

            return element.Tag.ToString();
        }

        private void btEdit_Click(object sender, RoutedEventArgs e)
        {
            if (id != 0)
            {

                result.Instructor = txtInstructor.Text;
                result.courseName = txtName.Text;
                result.Notes = txtNotes.Text;
                result.Price = decimal.Parse(txtPrice.Text);
                result.Categoryid=int.Parse( txtCategory.SelectedValue.ToString());
                if (ImagePath != "")
                {
                    string newPath = Environment.CurrentDirectory + $"\\Images\\Courses\\{result.ID}.png";
                    File.Copy(ImagePath, newPath,true);
                    result.Image = newPath;
                }

                db.SaveChanges();
                MessageBox.Show("Done!");
                ViewCourses.ItemsSource = db.tbCourses.Select(x => new { x.ID, x.courseName, x.Price, x.Instructor, x.tbCategory.categoryName, x.Notes }).ToList();

            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
           var r= MessageBox.Show("Are you sure?","Delete",MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
            var result = db.tbCourses.Find(id);
            db.tbCourses.Remove(result);
            db.SaveChanges();
            MessageBox.Show("Done!");
            ViewCourses.ItemsSource = db.tbCourses.ToList();
            }
        }

        private void txtCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = int.Parse(txtCategory.SelectedValue.ToString());
                ViewCourses.ItemsSource = db.tbCourses.Where(x => x.Categoryid == id).Select(x => new { x.ID, x.courseName, x.Price, x.Instructor, x.tbCategory.categoryName, x.Notes }).ToList();

               
            }
            catch { }
        }

        private void ViewCourses_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString()== "tbCategory")
            {
                e.Column.Visibility = Visibility.Collapsed;
            }
            
            
        }
    }
}
