using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;

namespace Code.ViewModels
{
    public class TangLuotXemViewModel : ViewModelBase
    {
        private string _duongDan;
        private string _soLuotCanTang;
        private string _thoiGianXem;
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
        public string SoLuotCanTang
        {
            get { return _soLuotCanTang; }
            set
            {
                _soLuotCanTang = value;
                OnPropertyChanged("SoLuotCanTang");
            }
        }
        public string ThoiGianXem
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

        public TangLuotXemViewModel()
        {
            GetInformation = new ViewModelCommand(ExecuteGetInformation);
        }

        private async void ExecuteGetInformation(object obj)
        {

            var youtube = new YoutubeClient();

            var video = await youtube.Videos.GetAsync(DuongDan);

            TieuDe = video.Title; 
            ThoiLuong = video.Duration.ToString();
            SoLuotXem = video.Engagement.ViewCount.ToString();
        }
    }
}
