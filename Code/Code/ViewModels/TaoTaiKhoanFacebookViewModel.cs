using Code.Models;
using Code.Utils.Story;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.ViewModels
{
    public class TaoTaiKhoanFacebookViewModel:ViewModelBase
    {
        private string[] arrHo = { "Nguyen", "Tran", "Ngo", "Ha", "Đinh", "Phan" };
        private string[] arrTen = { "Duy", "Khanh", "Mai", "Huyen", "Quynh", "Linh", "Huong", "Hoang", "Nguyen", "Nam", "Anh" };

        private static TaoTaiKhoanFacebookViewModel INSTANCE = null;

        public static TaoTaiKhoanFacebookViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TaoTaiKhoanFacebookViewModel();
            }
            return INSTANCE;
        }
        public TaoTaiKhoanFacebookViewModel() : base()
        {
          
        }
        protected override BaseScript createScriptToRun(string thietbiId, string url)
        {
            var account = AccountFactory.RandomFaceBookAccount(thietbiId);
            if (account == null)
            {
                return null;
            }
            account = DataProvider.Ins.db.TaiKhoanFacebooks.Add(account);
            DataProvider.Ins.db.SaveChanges();

            var script = new TaoTaiKhoanFacebook(thietbiId, account);

            return script;
        }
    }
}
