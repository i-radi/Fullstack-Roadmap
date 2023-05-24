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

namespace Center_Application.Screens
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Category : Window
    {
        dbCoursesCenterEntities db = new dbCoursesCenterEntities();
        int id;
        public Category()
        {
            InitializeComponent();
            txtCategory.ItemsSource = db.tbCategories.ToList();

        }
        private void txtCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                 id = int.Parse(txtCategory.SelectedValue.ToString());
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            var r = MessageBox.Show("Are you sure?", "Delete", MessageBoxButton.YesNo);
            if (r == MessageBoxResult.Yes)
            {
                var result = db.tbCategories.Find(id);
                db.tbCategories.Remove(result);
                db.SaveChanges();
                MessageBox.Show("Done!");
            }
        }
    

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtNewCategory.Text == "" )
            {
                MessageBox.Show("Name Category is Required");
                return;
            }

            
            tbCategory c = new DB.tbCategory();
            c.categoryName = txtNewCategory.Text;
            
            db.tbCategories.Add(c);
            db.SaveChanges();

            MessageBox.Show("Done!");
        }
    }
}
