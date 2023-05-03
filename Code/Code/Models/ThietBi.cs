using Code.Utils;
using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Code.Models
{
    public class ThongTinThietBi
    {
        public string id;
        public bool trangThai;
    }
    public class ThietBi
    {
        public Dictionary<String, ThongTinThietBi> danhSachThietBi = null;
        public ThietBi()
        {

        }
        private static ThietBi INSTANCE = null;

        public static ThietBi GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ThietBi();
                INSTANCE.danhSachThietBi = INSTANCE.GetThietBi();
            }
            return INSTANCE;
        }
        public Dictionary<String, ThongTinThietBi> GetThietBi()
        {
            if (danhSachThietBi == null)
            {
                Refresh();
            }
            return danhSachThietBi;
        }

        public void Refresh()
        {
            danhSachThietBi = new Dictionary<String, ThongTinThietBi>();
            var devives = ADBUtils.getListDevices();
            foreach (var item in devives)
            {
                ThongTinThietBi thietBi = new ThongTinThietBi();
                thietBi.id = item.Item1;
                thietBi.trangThai = false;
                danhSachThietBi.Add(item.Item1, thietBi);

            }
        }
    }
}
