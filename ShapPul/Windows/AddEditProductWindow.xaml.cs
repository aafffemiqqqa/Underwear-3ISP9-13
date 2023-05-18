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
using System.IO;
using Microsoft.Win32;

namespace ShapPul.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        private string pathImageProduct = null;
        private bool isEdit = false;
        Product editProduct;

        public AddEditProductWindow()
        {
            InitializeComponent();

            CmbModel.ItemsSource = EFClass.Context.Model.ToList();
            CmbModel.DisplayMemberPath = "Name";
            CmbModel.SelectedIndex = 0;

            CmbColor.ItemsSource = EFClass.Context.Color.ToList();
            CmbColor.DisplayMemberPath = "Name";
            CmbColor.SelectedIndex = 0;

            CmbSize.ItemsSource = EFClass.Context.Size.ToList();
            CmbSize.DisplayMemberPath = "Name";
            CmbSize.SelectedIndex = 0;
        }

        public AddEditProductWindow(Product product)
        {
            InitializeComponent();

            CmbModel.ItemsSource = EFClass.Context.Model.ToList();
            CmbModel.DisplayMemberPath = "Name";
            CmbModel.SelectedIndex = 0;

            CmbColor.ItemsSource = EFClass.Context.Color.ToList();
            CmbColor.DisplayMemberPath = "Name";
            CmbColor.SelectedIndex = 0;

            CmbSize.ItemsSource = EFClass.Context.Size.ToList();
            CmbSize.DisplayMemberPath = "Name";
            CmbSize.SelectedIndex = 0;

            TbName.Text = product.Name;
            TbPrice.Text = product.Cost.ToString();
            CmbModel.SelectedItem = EFClass.Context.Model.ToList().Where(i => i.IdModel == product.IdModel).FirstOrDefault();
            CmbSize.SelectedItem = EFClass.Context.Size.ToList().Where(i => i.IdSize == product.IdSize).FirstOrDefault();
            CmbColor.SelectedItem = EFClass.Context.Color.ToList().Where(i => i.IdColor == product.IdColor).FirstOrDefault();

            if (product.Image != null)
            {
                using (MemoryStream ms = new MemoryStream(product.Image))
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.StreamSource = ms;
                    bitmapImage.EndInit();
                    ImgProduct.Source = bitmapImage;
                }
            }

            TblockTitle.Text = "Изменение товара";
            BtnAddProduct.Content = "Изменить";
            isEdit = true;
            editProduct = product;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName;
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                editProduct.Name = TbName.Text;
                editProduct.Cost = Convert.ToDecimal(TbPrice.Text);
                editProduct.IdModel = (CmbModel.SelectedItem as Model).IdModel;
                editProduct.IdSize = (CmbSize.SelectedItem as DB.Size).IdSize;
                editProduct.IdColor = (CmbColor.SelectedItem as DB.Color).IdColor;

                if (pathImageProduct != null)
                {
                    editProduct.Image = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар успешно изменен");
            }

            else
            {
                Product product = new Product();
                product.Name = TbName.Text;
                product.Cost = Convert.ToDecimal(TbPrice.Text);
                product.IdModel = (CmbModel.SelectedItem as Model).IdModel;
                product.IdSize = (CmbSize.SelectedItem as DB.Size).IdSize;
                product.IdColor = (CmbColor.SelectedItem as DB.Color).IdColor;

                if (pathImageProduct != null)
                {
                    product.Image = File.ReadAllBytes(pathImageProduct);
                }

                EFClass.Context.Product.Add(product);
                EFClass.Context.SaveChanges();

                MessageBox.Show("Товар добавлен");
            }

            this.Close();

        }
    }
}
