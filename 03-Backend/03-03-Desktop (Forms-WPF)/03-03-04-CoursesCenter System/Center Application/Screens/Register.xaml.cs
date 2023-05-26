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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();
        string ImagePath="";
        public Register()
        {
            InitializeComponent();
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {

            tbUser user = new tbUser
            {
                UserName = txtUser.Text,
                Password = txtPassword.Password,
                Email = txtEmail.Text,
                Phone = txtPhone.Text,

            };
            db.tbUsers.Add(user);
            db.SaveChanges();
            if (ImagePath != "")
            {
                string newPath = Environment.CurrentDirectory + $"\\Images\\Users\\{user.ID}.png";
                File.Copy(ImagePath, newPath);
                user.Image = newPath;
                db.SaveChanges();

            }

            MessageBox.Show("Done!");

            Main_Screen main = new Main_Screen();
            main.Show();
            Close();
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
    }
}
