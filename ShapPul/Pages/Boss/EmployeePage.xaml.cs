using ShapPul.ClassHelper;
using ShapPul.DB;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShapPul.Pages.Boss
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {

        Entities1 e = new Entities1();

        public EmployeePage()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetListProduct()
        {
            var query =
                from A in e.Employee
                join R in e.Role on A.IdRole equals R.IdRole
                where A.IdRole == 1 || A.IdRole == 2
                orderby A.LastName
                select new { LastName = A.LastName, A.FirstName, A.Patronymic, R.Name };

            List<Employee> employees = new List<Employee>();
            employees = EFClass.Context.Employee.ToList();

            LvEmployee.ItemsSource = employees;
        }

        private void BtnAddEmp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/Boss/AddEmployee.xaml", UriKind.Relative));
        }
    }
}
