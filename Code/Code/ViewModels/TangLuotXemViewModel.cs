using Code.Utils.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YoutubeExplode;

namespace Code.ViewModels
{
    public class TangLuotXemViewModel : ViewModelBase
    {
        YoutubeClient youtube = new YoutubeClient();
        private const int ThoiGianXemToiThieu = 30;

        private static TangLuotXemViewModel INSTANCE = null;

        public static TangLuotXemViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TangLuotXemViewModel();
            }
            return INSTANCE;
        }
        private string _duongDan;
        private int _soLuotCanTang;
        private int _thoiGianXem;
        private string _trangThai;
        private string _tieuDe;
        private string _thoiLuong;
        private string _soLuotXem;

        public string DuongDan
        {
            get { return _duongDan;}
            set
            {
                _duongDan = value;
                OnPropertyChanged("DuongDan");
            }
        }
        public int SoLuotCanTang
        {
            get { return _soLuotCanTang; }
            set
            {
                _soLuotCanTang = value;
                OnPropertyChanged("SoLuotCanTang");
            }
        }
        public int ThoiGianXem
        {
            get { return _thoiGianXem; }
            set
            {
                _thoiGianXem = value;
                OnPropertyChanged("ThoiGianXem");
            }
        }
        public string TrangThai
        {
            get { return _trangThai; }
            set
            {
                _trangThai = value;
                OnPropertyChanged("TrangThai");
            }
        }
        public string TieuDe
        {
            get { return _tieuDe; }
            set
            {
                _tieuDe = value;
                OnPropertyChanged("TieuDe");
            }
        }
        public string ThoiLuong
        {
            get { return _thoiLuong; }
            set
            {
                _thoiLuong = value;
                OnPropertyChanged("ThoiLuong");
            }
        }
        public string SoLuotXem
        {
            get { return _soLuotXem; }
            set
            {
                _soLuotXem = value;
                OnPropertyChanged("SoLuotXem");
            }
        }
        public ICommand GetInformation { get; }

        private TangLuotXemViewModel() : base()
        {
            GetInformation = new ViewModelCommand(ExecuteGetInformation);
            ThoiGianXem = ThoiGianXemToiThieu;
            SoLuotCanTang = 5;
        }
        protected override bool ThucHienCongViecTrenThietBi(string idThietBi, string u)
        {
            var r = base.ThucHienCongViecTrenThietBi(idThietBi, u);
            TrangThai = this.ThanhCong.ToString();
            return r;
        }
        protected override void QuanLyCongViecChoCacThietBi(List<string> thietbi, long soLanLap)
        {
            soLanLap = SoLuotCanTang;
            base.QuanLyCongViecChoCacThietBi(thietbi, soLanLap);
        }
        protected override void ExecuteShowPopUpWindow(object obj)
        {
            var canExcute = KiemTraURLHopLe(DuongDan);

            if (canExcute)
            {
                base.ExecuteShowPopUpWindow(obj);
            }
            else
            {
                MessageBox.Show("Thông tin nhập sai vui lòng nhâp lại");
            }
        }

        private bool KiemTraURLHopLe(string url)
        {
            var regex = new Regex(@"^(https?\:\/\/)?(www\.youtube\.com\/watch\?v=|youtu\.be\/)(.+)$");
            if (DuongDan != null)
            {
                if (regex.IsMatch(DuongDan))
                {
                    return true;
                }
            }
            return false;
        }

        private async void ExecuteGetInformation(object obj)
        {
            var video = await youtube.Videos.GetAsync(DuongDan);

            TieuDe = video.Title; 
            ThoiLuong = video.Duration.ToString();
            SoLuotXem = video.Engagement.ViewCount.ToString();
        }

        protected override BaseScript createScriptToRun(string thietbiId, string url)
        {
            return new XemVideoYoutubeScript(thietbiId, url, ThoiGianXem);
        }

        protected override string getCurrentUrl()
        {
            return DuongDan;
        }
    }
}
