using Center_Application.Screens;
using System.Windows;

namespace Center_Application
{
    /// <summary>
    /// Interaction logic for Main_Screen.xaml
    /// </summary>
    public partial class Main_Screen : Window
    {
        public Main_Screen()
        {
            InitializeComponent();
            userName.Content = user.userName;

        }


        private void imgStudentsDetails_Click(object sender, RoutedEventArgs e)
        {
            Student_Details st = new Student_Details();
            st.Show();
        }


        private void imgEmployees_Click(object sender, RoutedEventArgs e)
        {
            Employees em = new Employees();
            em.Show();
        }

        private void imgReports_Click(object sender, RoutedEventArgs e)
        {
            Reports re = new Reports();
            re.Show();
        }

        private void imgCourses_Click(object sender, RoutedEventArgs e)
        {
            Courses c = new Courses();
            c.Show();
        }

        private void imgStudents_Click(object sender, RoutedEventArgs e)
        {
            Students st = new Students();
            st.Show();
        }

        private void NewUser_Click(object sender, RoutedEventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            MainWindow l = new MainWindow();
            l.Show();
        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            Category c = new Category();
            c.Show();
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            Courses c = new Courses();
            c.Show();
        }

        private void Students_Click(object sender, RoutedEventArgs e)
        {
            Students st = new Students();
            st.Show();
        }

        private void Employees_Click(object sender, RoutedEventArgs e)
        {
            Employees em = new Employees();
            em.Show();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            Reports re = new Reports();
            re.Show();
        }
    }
}
