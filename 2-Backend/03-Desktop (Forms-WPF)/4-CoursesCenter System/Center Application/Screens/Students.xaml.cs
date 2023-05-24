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
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();
        string ImagePath = "";
        int id = 0;
        tbStudent result;

        public Students()
        {
            InitializeComponent();
            ViewStudent.ItemsSource = db.tbStudents.Select(x => new {x.ID,x.studentName,x.Phone,x.Email,x.Address,x.Notes }).ToList();
            userName.Content = user.userName;


        }


        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" )
            {
                MessageBox.Show("Name and Phone are Required");
                return;
            }

            

            tbStudent c = new DB.tbStudent();
            c.studentName = txtName.Text;
            c.Address = txtAddress.Text;
            c.Notes = txtNotes.Text;
            c.Email = txtEmail.Text;
            c.Phone = txtPhone.Text;
            db.tbStudents.Add(c);
            db.SaveChanges();

            if (ImagePath != "")
            {
                string newPath = Environment.CurrentDirectory + $"\\Images\\Students\\{c.ID}.png";
                File.Copy(ImagePath, newPath);
                c.Image = newPath;
                db.SaveChanges();

            }
            MessageBox.Show("Done!");
            ViewStudent.ItemsSource = db.tbStudents.Select(x => new { x.ID, x.studentName, x.Phone, x.Email, x.Address, x.Notes }).ToList();


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
            ViewStudent.ItemsSource = db.tbStudents.Where(x => x.studentName.Contains(txtName.Text)).Select(x => new { x.ID, x.studentName, x.Phone, x.Email, x.Address, x.Notes }).ToList();
        }

        private void ViewStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                id = int.Parse(GetSelectedCellValue());
                result = db.tbStudents.SingleOrDefault(x => x.ID == id);

                txtID.Text = result.ID.ToString();
                txtName.Text = result.studentName;
                 txtAddress.Text = result.Address;
                 txtNotes.Text = result.Notes;
                 txtEmail.Text = result.Email;
                txtPhone.Text = result.Phone;
                img.Source = new BitmapImage(new Uri(result.Image));
            }
            catch { }
        }

        public string GetSelectedCellValue()
        {
            DataGridCellInfo cellInfo = ViewStudent.SelectedCells[0];
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

                result.Notes = txtNotes.Text;
                result.studentName = txtName.Text;
                result.Phone = txtPhone.Text;
                result.Email = txtEmail.Text;
                result.Address = txtAddress.Text;

                if (ImagePath != "")
                {
                    string newPath = Environment.CurrentDirectory + $"\\Images\\Students\\{result.ID}.png";
                    File.Copy(ImagePath, newPath, true);
                    result.Image = newPath;
                }

                db.SaveChanges();
                MessageBox.Show("Done!");
                ViewStudent.ItemsSource = db.tbStudents.ToList();

            }
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                var result = db.tbStudents.Find(id);
                db.tbStudents.Remove(result);
                db.SaveChanges();
                MessageBox.Show("Done!");
                ViewStudent.ItemsSource = db.tbStudents.Select(x => new { x.ID, x.studentName, x.Phone, x.Email, x.Address, x.Notes }).ToList();
            }
        }
    }
}
