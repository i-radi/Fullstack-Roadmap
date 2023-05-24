using Center_Application.DB;
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
    /// Interaction logic for Reports.xaml
    /// </summary>
    public partial class Reports : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();

        public Reports()
        {
            InitializeComponent();
            userName.Content = user.userName;

            txtNoofCourses.Text = db.tbCourses.Count().ToString();
            txtTotalPriceOfCourses.Text = db.StudentsDetails.Sum(x=>x.tbCours.Price).ToString();
            txtNoofEmployees.Text = db.tbEmployees.Count().ToString();
            txtEmployeesSalaries.Text = db.tbEmployees.Sum(x=>x.Salary).ToString();
            txtNoofStudents.Text = db.tbStudents.Count().ToString();

            ViewDetails.ItemsSource = db.tbCourses.Select(x => new { x.courseName, x.Instructor,x.tbCategory.categoryName }).ToList();

        }

        private void txtTaxes_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal OtherExpenses, Taxes;
            decimal.TryParse(txtOtherExpenses.Text, out OtherExpenses);
            decimal.TryParse(txtTaxes.Text, out Taxes);
            txtProfit.Text = (decimal.Parse(txtTotalPriceOfCourses.Text) - (decimal.Parse(txtEmployeesSalaries.Text) + OtherExpenses + Taxes)).ToString();
        }
    }
}
