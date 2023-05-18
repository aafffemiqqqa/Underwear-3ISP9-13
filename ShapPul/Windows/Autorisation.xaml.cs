using ClothingStore.ClassHelper;
using ShapPul.ClassHelper;
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
using static ShapPul.ClassHelper.EFClass;

namespace ShapPul.Windows
{
    /// <summary>
    /// Логика взаимодействия для Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // поиск пользователя
            var userAuth = Context.Account.ToList()
                .Where(i => i.Login == TbLog.Text && i.Password == TbPsw.Text)
                .FirstOrDefault();

            // проверка на работника
            if (userAuth != null)
            {
                // сохранияем данные входа
                UserDataClass.User = userAuth;

                var emplAuth = Context.Employee.Where(i => i.IdAccount == userAuth.IdAccount).FirstOrDefault();

                if (emplAuth != null)
                {
                    // если не пустой то Работник

                    // сохранияем данные входа

                    UserDataClass.Employee = emplAuth;

                    // проверка роли 

                    switch (emplAuth.IdRole)
                    {
                        case 1:
                            // переход на страницу директора
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            this.Close();
                            break;

                        case 2:
                            // переход на страницу администратора
                            break;
                        case 3:
                            // переход на страницу продавца
                            break;
                        default:
                            break;
                    }

                }
                else
                {
                    ProductListWindow productListWindow = new ProductListWindow();
                    productListWindow.Show();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            ClassHelper.Navigate.navFrame.Navigate(new Check());
        }
    }
}
