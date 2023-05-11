using Code.Models;
using Code.Utils;
using Code.Utils.Story;
using Code.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
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
            var account = AccountFactory.RandomGoogleAccount(thietbiId);

            account = DataProvider.Ins.db.TaiKhoanGoogles.Add(account);
            DataProvider.Ins.db.SaveChanges();

            var script = new CreateGoogleAccountScript(thietbiId, account);

            return script;
        }
    }
}
