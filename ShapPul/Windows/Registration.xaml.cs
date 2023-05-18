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
using ShapPul.ClassHelper;
using ShapPul.Windows;
using ShapPul.DB;

namespace ShapPul.Windows
{
    /// <summary>
    /// Логика взаимодействия для Check.xaml
    /// </summary>
    public partial class Check : Window
    {
        public Check()
        {
            InitializeComponent();

            CmbRole.ItemsSource = EFClass.Context.Role.ToList();
            CmbRole.DisplayMemberPath = "Name";
            CmbRole.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbLog.Text))
            {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbLN.Text))
            {
                MessageBox.Show("Имя не может быть пустым или состоять из пробелов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbFN.Text))
            {
                MessageBox.Show("Фамилия не может быть пустой или состоять из пробелов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(TbPsw.Password))
            {
                MessageBox.Show("Пароль не может быть пустым или состоять из пробелов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            EFClass.Context.Account.Add(new Account()
            {
                Login = TbLog.Text,
                Password = TbPsw.Password,
                IdRole = (CmbRole.SelectedItem as Role).IdRole
            });

            EFClass.Context.SaveChanges();

            MessageBox.Show("ОК");

        }
    }

    
}
