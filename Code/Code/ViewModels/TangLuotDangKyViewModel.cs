using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Code.ViewModels
{
    public class TangLuotDangKyViewModel : ViewModelBase
    {
        private static TangLuotDangKyViewModel INSTANCE = null;

        public static TangLuotDangKyViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TangLuotDangKyViewModel();
            }
            return INSTANCE;
        }
        private string _duongDan;
        private int _soLuotTang;
        private string _trangThai;
        private string _tenKenh;
        private string _soVideo;
        private string _soLuotXem;

        public string DuongDan
        {
            get { return _duongDan; }
            set
            {
                _duongDan = value;
                OnPropertyChanged("DuongDan");
            }
        }
        public int SoLuotTang
        {
            get { return _soLuotTang; }
            set
            {
                _soLuotTang = value;
                OnPropertyChanged("SoLuotTang");
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
        public string TenKenh
        {
            get { return _tenKenh; }
            set
            {
                _tenKenh = value;
                OnPropertyChanged("TenKenh");
            }
        }
        public string SoVideo
        {
            get { return _soVideo; }
            set
            {
                _soVideo = value;
                OnPropertyChanged("SoVideo");
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

        public TangLuotDangKyViewModel() : base()
        {
            GetInformation = new ViewModelCommand(ExecuteGetInformation);
            SoLuotTang = 2;
        }
        protected override void QuanLyCongViecChoCacThietBi(List<string> thietbi, long soLanLap)
        {
            soLanLap = SoLuotTang;
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
                MessageBox.Show("Thông tin nhập sai vui lòng nhập lại");
            }
        }

        private bool KiemTraURLHopLe(string url)
        {
            var regex = new Regex(@"^(https?\:\/\/)?(www\.)?youtube\.com\/(c|channel)\/(?:@)?([a-zA-Z0-9_-]{1,})$");
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

            var youtube = new YoutubeClient();
            bool flag = true;
            if (DuongDan.IndexOf("@") >= 0)
            {
                flag = false;
            }
            var channel = flag == true ? await youtube.Channels.GetAsync(DuongDan) : await youtube.Channels.GetByHandleAsync(DuongDan);
            TenKenh = channel.Title;
            var videos = await youtube.Channels.GetUploadsAsync(@"https://www.youtube.com/channel/" + channel.Id);
            SoVideo = videos.Count().ToString();
        }
    }
}
