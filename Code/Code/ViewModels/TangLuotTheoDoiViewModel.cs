using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.ViewModels
{
    public class TangLuotTheoDoiViewModel:ViewModelBase
    {
        private static TangLuotTheoDoiViewModel INSTANCE = null;

        public static TangLuotTheoDoiViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TangLuotTheoDoiViewModel();
            }
            return INSTANCE;
        }
        public TangLuotTheoDoiViewModel() : base()
        {

        }
    }
}
