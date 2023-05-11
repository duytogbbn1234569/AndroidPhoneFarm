using AngleSharp.Common;
using Code.Utils;
using Code.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Code.Models
{
    public class ThietBi
    {
        public List<string> danhSachThietBi = new List<string>();

        private HashSet<string> thietBiDuocSuDung = new HashSet<string>();

        public ThietBi()
        {

        }
        private static ThietBi INSTANCE = null;

        public static ThietBi GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new ThietBi();
                INSTANCE.Refresh();
            }
            return INSTANCE;
        }

        public void Refresh()
        {
            danhSachThietBi = new List<string>();
            var devives = ADBUtils.getListDevices();
            foreach (var item in devives)
            {
                danhSachThietBi.Add(item.Item1);
            }
        }

        public bool isUsed(string id)
        {
            return thietBiDuocSuDung.Contains(id);
        }

        public void setUse(string thietbi, bool used)
        {
            if (used)
            {
                thietBiDuocSuDung.Add(thietbi);
            }
            else
            {
                thietBiDuocSuDung.Remove(thietbi);
            }
        }
    }
}
