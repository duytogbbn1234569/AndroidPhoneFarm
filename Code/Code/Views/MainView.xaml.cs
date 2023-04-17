using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Code.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
        private void CollapsedPanel(StackPanel panel)
        {
            if (panel.Visibility == Visibility.Visible)
            {
                panel.Visibility = Visibility.Collapsed;
            }
        }
        private void btnQuanLyTaiKhoan_Click(object sender, RoutedEventArgs e)
        {
            CollapsedPanel(pnlGoogle);
            CollapsedPanel(pnlYoutube);
            CollapsedPanel(pnlFacebook);
            if (pnlQuanLyTaiKhoan.Visibility == Visibility.Collapsed)
            {
                pnlQuanLyTaiKhoan.Visibility = Visibility.Visible;
            }
            else
            {
                pnlQuanLyTaiKhoan.Visibility = Visibility.Collapsed;
            }
        }

        private void btnGoogle_Click(object sender, RoutedEventArgs e)
        {
            CollapsedPanel(pnlQuanLyTaiKhoan);
            CollapsedPanel(pnlYoutube);
            CollapsedPanel(pnlFacebook);
            if (pnlGoogle.Visibility == Visibility.Collapsed)
            {
                pnlGoogle.Visibility = Visibility.Visible;
            }
            else
            {
                pnlGoogle.Visibility = Visibility.Collapsed;
            }
        }

        private void btnYoutube_Click(object sender, RoutedEventArgs e)
        {
            CollapsedPanel(pnlGoogle);
            CollapsedPanel(pnlQuanLyTaiKhoan);
            CollapsedPanel(pnlFacebook);
            if (pnlYoutube.Visibility == Visibility.Collapsed)
            {
                pnlYoutube.Visibility = Visibility.Visible;
            }
            else
            {
                pnlYoutube.Visibility = Visibility.Collapsed;
            }
        }

        private void btnFacebook_Click(object sender, RoutedEventArgs e)
        {
            CollapsedPanel(pnlGoogle);
            CollapsedPanel(pnlYoutube);
            CollapsedPanel(pnlQuanLyTaiKhoan);
            if (pnlFacebook.Visibility == Visibility.Collapsed)
            {
                pnlFacebook.Visibility = Visibility.Visible;
            }
            else
            {
                pnlFacebook.Visibility = Visibility.Collapsed;
            }
        }
    }
}
