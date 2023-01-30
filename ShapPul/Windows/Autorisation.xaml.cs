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

        private void Btn_Enter_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = Context.Account.ToList()
                .Where(i => i.Login == TbLog.Text && i.Password == TbPsw.Text)
                .FirstOrDefault();
            if (userAuth != null)
            {
                MessageBox.Show("ОК");
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
