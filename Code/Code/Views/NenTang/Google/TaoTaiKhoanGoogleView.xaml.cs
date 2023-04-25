using Code.Utils;
using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static Code.ViewModels.TaoTaiKhoanGoogleViewModel;

namespace Code.Views.NenTang.Google
{
    /// <summary>
    /// Interaction logic for TaoTaiKhoanGoogleView.xaml
    /// </summary>
    public partial class TaoTaiKhoanGoogleView : UserControl
    {
        public TaoTaiKhoanGoogleView()
        {
            var viewModel = TaoTaiKhoanGoogleViewModel.GetInstance();
            InitializeComponent();
            this.DataContext = viewModel;
            deviceStatus.ItemsSource = viewModel.devices;
        }
    }
}
