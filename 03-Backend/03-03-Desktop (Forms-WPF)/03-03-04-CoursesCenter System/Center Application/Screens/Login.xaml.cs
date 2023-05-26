using Center_Application.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Center_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
           var result= db.tbUsers.Where(x => x.UserName == txtUser.Text && x.Password == txtPassword.Password).ToList();
            if(result.Count()==1)
            {
                user.userName = txtUser.Text;
                Main_Screen main = new Main_Screen();
                main.Show();
                Close();
            }
            else
            MessageBox.Show("User Name or Password are invalid!");
        }
     

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();

            Close();
        }
    }
        static class user
        {
            static public string userName { get; set; }
        }

}
