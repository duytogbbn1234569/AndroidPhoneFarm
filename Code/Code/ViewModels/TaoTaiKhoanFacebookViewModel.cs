using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.ViewModels
{
    public class TaoTaiKhoanFacebookViewModel:ViewModelBase
    {
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
    }
}
