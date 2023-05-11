using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
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
using Code.Models;
namespace Code.Views.QuanLyTaiKhoan
{
    /// <summary>
    /// Interaction logic for TaiKhoanGoogleView.xaml
    /// </summary>
    public partial class TaiKhoanGoogleView : UserControl
    {
        public ObservableCollection<ThongTinTaiKhoan> taiKhoans;
        private BackgroundWorker bk = new BackgroundWorker();
        DbSet<TaiKhoanGoogle> objectList = null;
        public TaiKhoanGoogleView()
        {
            taiKhoans = new ObservableCollection<ThongTinTaiKhoan>();
            InitializeComponent();
            dgTaiKhoan.ItemsSource = taiKhoans;
            bk.DoWork += (obj, e) =>
            {
                objectList = DataProvider.Ins.db.TaiKhoanGoogles;
            };
            bk.RunWorkerCompleted += (obj, e) =>
            {
                Load();
            };
            bk.RunWorkerAsync();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            bk.RunWorkerAsync();
        }

        private void btnDeleteError_Click(object sender, RoutedEventArgs e)
        {
            var objectList = DataProvider.Ins.db.TaiKhoanGoogles;
            foreach (var item in objectList)
            {
                if (AccountStatus.IsError(item.TrangThai))
                {
                    DataProvider.Ins.db.TaiKhoanGoogles.Remove(item);
                }
            }
            DataProvider.Ins.db.SaveChanges();
            MessageBox.Show("Xóa thành công");
            bk.RunWorkerAsync();
        }
        private void Load()
        {
            taiKhoans.Clear();
            int stt = 1;
            foreach (var item in objectList)
            {
                ThongTinTaiKhoan taiKhoan = new ThongTinTaiKhoan();
                taiKhoan.STT = stt++;
                taiKhoan.TenDangNhap = item.TenDangNhap;
                taiKhoan.MatKhau = item.MatKhau;
                taiKhoan.HoTen = string.Format("{0} {1}", item.Ho, item.Ten);
                taiKhoan.GioiTinh = item.GioiTinh == 0 ? "Nữ" : item.GioiTinh == 1 ? "Nam" : "Không";
                taiKhoan.NgaySinh = string.Format("{0}/{1}/{2}", item.NgaySinh, item.ThangSinh, item.NamSinh);
                taiKhoan.TrangThai = AccountStatus.GetDescription(item.TrangThai);
                taiKhoan.MaThietBi = item.IDThietBi;
                taiKhoans.Add(taiKhoan);
            }
        }
    }
}
