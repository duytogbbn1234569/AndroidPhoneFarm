using Code.Models;
using Code.Utils;
using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Code.Views
{
    /// <summary>
    /// Interaction logic for QuanLyThietBiView.xaml
    /// </summary>
    public partial class QuanLyThietBiView : UserControl
    {

        public QuanLyThietBiView()
        {
            InitializeComponent();
            Load();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Load();
        }
        private void Load()
        {
            List<QuanLyThietBiViewModel> tmp = new List<QuanLyThietBiViewModel>();
            var thietbi = ThietBi.GetInstance();
            thietbi.Refresh();
            var stt = 1;
            foreach (var dev in thietbi.danhSachThietBi)
            {
                var item = new QuanLyThietBiViewModel();
                item.MaThietBi = dev;
                item.SoThuTu = stt++;
                item.TrangThai = thietbi.isUsed(dev) ? "Được sử dụng" : "Không được sử dụng";
                tmp.Add(item);
            }
            dgThietBi.ItemsSource = tmp;
        }
    }
}
