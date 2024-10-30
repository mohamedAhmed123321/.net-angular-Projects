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
using StoreBl.Bl;
using StoreBl.Models;

namespace StoreWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void FillItemData()
        {
            ClsItems oClsItems = new ClsItems();
            List<ItemModel> lstItems = oClsItems.GetAll();
            gvItems.ItemsSource = lstItems;
        }
        public MainWindow()
        {
            InitializeComponent();
            FillItemData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClsItems oClsItems = new ClsItems();
            ItemModel oItemModel = new ItemModel();
            oItemModel.ItemName = txtItemName.Text;
            oItemModel.ItemPrice = Convert.ToDecimal(txtItemPrice.Text);
            oClsItems.Add(oItemModel);
            FillItemData();
        }
    }
}
