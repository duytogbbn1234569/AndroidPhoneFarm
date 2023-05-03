using Code.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Code.ViewModels
{
    public class PopupChonThietBiViewModel : ViewModelBase
    {
        private bool _IsSelected = false;
        private int _SoThuTu { get; set; }
        private string _MaThietBi { get; set; }
        public string MaThietBi
        {
            get { return _MaThietBi; }
            set { _MaThietBi = value; OnPropertyChanged("MaThietBi"); }
        }
        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }
        public int SoThuTu
        {
            get { return _SoThuTu; }
            set { _SoThuTu = value; OnPropertyChanged("SoThuTu"); }
        }

        public PopupChonThietBiViewModel()
        {

        }

    }
}
