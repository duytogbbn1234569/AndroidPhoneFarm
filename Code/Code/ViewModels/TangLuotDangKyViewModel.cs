using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YoutubeExplode;
using YoutubeExplode.Common;

namespace Code.ViewModels
{
    public class TangLuotDangKyViewModel : ViewModelBase
    {
        private string _duongDan;
        private string _soLuotCanTang;
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
        public string SoLuotCanTang
        {
            get { return _soLuotCanTang; }
            set
            {
                _soLuotCanTang = value;
                OnPropertyChanged("SoLuotCanTang");
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

        public TangLuotDangKyViewModel()
        {
            GetInformation = new ViewModelCommand(ExecuteGetInformation);
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
