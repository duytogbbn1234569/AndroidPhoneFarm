using Code.Utils;
using Code.Utils.Story;
using Code.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Code.ViewModels
{
    public class TaoTaiKhoanGoogleViewModel : ViewModelBase
    {
        private string[] arrHo = { "Nguyen", "Tran", "Ngo", "Ha", "Đinh", "Phan" };
        private string[] arrTen = { "Duy", "Khanh", "Mai", "Huyen", "Quynh", "Linh", "Huong", "Hoang", "Nguyen", "Nam", "Anh" };

        private static TaoTaiKhoanGoogleViewModel INSTANCE = null;

        public static TaoTaiKhoanGoogleViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TaoTaiKhoanGoogleViewModel();
            }
            return INSTANCE;
        }

        private TaoTaiKhoanGoogleViewModel() : base()
        {

        }
        protected override BaseScript createScriptToRun(string thietbiId, string url)
        {
            var prefix = RandomString(10);
            Random rnd = new Random();
            var account = new TaiKhoanGoogle();
            account.Ten = arrTen[rnd.Next(0, arrTen.Length - 1)];
            account.TenDangNhap = String.Format("{0}{1}", prefix, rnd.Next(1, 1000));
            account.Ho = arrHo[rnd.Next(0, arrHo.Length - 1)];
            account.MatKhau = "Abc13579";
            account.NamSinh = 2000 + rnd.Next(-10, 10);
            account.NgaySinh = rnd.Next(1, 28);
            account.ThangSinh = rnd.Next(0, 11);
            account.GioiTinh = rnd.Next(0, 2);

            return new CreateGoogleAccountScript(thietbiId, account);
        }
    }
}
