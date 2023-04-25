using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.ViewModels
{
    public class QuanLyThietBiViewModel:ViewModelBase
    {
        private string _TrangThai { get; set; }
        private int _SoThuTu { get; set; }
        private string _MaThietBi { get; set; }
        public string MaThietBi
        {
            get { return _MaThietBi; }
            set { _MaThietBi = value; OnPropertyChanged("MaThietBi"); }
        }
        public string TrangThai
        {
            get { return _TrangThai; }
            set
            {
                _TrangThai = value;
                OnPropertyChanged("TrangThai");
            }
        }
        public int SoThuTu
        {
            get { return _SoThuTu; }
            set { _SoThuTu = value; OnPropertyChanged("SoThuTu"); }
        }
        public QuanLyThietBiViewModel()
        {

        }
    }
}
