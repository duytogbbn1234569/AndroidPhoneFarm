using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Code.Models;
using Code.Utils;
using Code.ViewModels;

namespace Code.Views
{
    /// <summary>
    /// Interaction logic for PopupChonThietBiView.xaml
    /// </summary>
    /// 

    public delegate void OnStartAction(List<string> thietbi);

    public partial class PopupChonThietBiView : Window
    {
        private OnStartAction onStartAction;
        private static ThietBi thietBi = null;

        public PopupChonThietBiView(OnStartAction onStartAction = null)
        {
            this.onStartAction = onStartAction;
            List<PopupChonThietBiViewModel> tmp = new List<PopupChonThietBiViewModel>();
            thietBi = ThietBi.GetInstance();
            int stt = 1;
            foreach (var dev in thietBi.danhSachThietBi)
            {
                if (!thietBi.isUsed(dev))
                {
                    var item = new PopupChonThietBiViewModel();
                    item.MaThietBi = dev;
                    item.SoThuTu = stt++;
                    tmp.Add(item);
                }
            }
            InitializeComponent();
            dgThietBi.ItemsSource = tmp;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (PopupChonThietBiViewModel c in dgThietBi.ItemsSource)
            {
                c.IsSelected = false;
            }
        }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (PopupChonThietBiViewModel c in dgThietBi.ItemsSource)
            {
                c.IsSelected = true;
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            var thietbi = new List<string>();
            foreach (PopupChonThietBiViewModel c in dgThietBi.ItemsSource)
            {
                if (c.IsSelected)
                {
                    thietbi.Add(c.MaThietBi);
                    thietBi.setUse(c.MaThietBi, true);
                }
            }
            if (thietbi.Count != 0) onStartAction?.Invoke(thietbi);
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void selectThietBi(object sender, RoutedEventArgs e)
        {
            var selectedItem = dgThietBi.SelectedIndex;
            if (selectedItem != -1)
            {
                var source = (List<PopupChonThietBiViewModel>)dgThietBi.ItemsSource;
                var item = source[selectedItem];
                source[selectedItem].IsSelected = !item.IsSelected;

            }

        }
    }
}
