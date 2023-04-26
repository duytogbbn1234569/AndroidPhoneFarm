using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Code.Views;

namespace Code.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Fields
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;


        //Properties

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }

            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public string Caption
        {
            get
            {
                return _caption;
            }

            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public IconChar Icon
        {
            get
            {
                return _icon;
            }

            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        //--> Commands
        public ICommand ShowQuanLyHeThongViewCommand { get; }
        public ICommand ShowQuanLyThietBiViewCommand { get; }
        public ICommand ShowTaiKhoanFacebookViewCommand { get; }
        public ICommand ShowTaiKhoanGoogleViewCommand { get; }
        public ICommand ShowTaoTaiKhoanGoogleViewCommand { get; }
        public ICommand ShowTaoTaiKhoanFacebookViewCommand { get; }
        public ICommand ShowTangLuotXemViewCommand { get; }
        public ICommand ShowTangDangKyViewCommand { get; }
        public ICommand ShowTangTheoDoiViewCommand { get; }

        public MainViewModel()
        {

            //Initialize commands
            ShowQuanLyHeThongViewCommand = new ViewModelCommand(ExecuteShowQuanLyHeThongViewCommand);
            ShowQuanLyThietBiViewCommand = new ViewModelCommand(ExecuteShowQuanLyThietBiViewCommand);

            ShowTaiKhoanFacebookViewCommand = new ViewModelCommand(ExecuteShowTaiKhoanFacebookViewCommand);
            ShowTaiKhoanGoogleViewCommand = new ViewModelCommand(ExecuteShowTaiKhoanGoogleViewCommand);
            ShowTaoTaiKhoanGoogleViewCommand = new ViewModelCommand(ExecuteShowTaoTaiKhoanGoogleViewCommand);

            ShowTaoTaiKhoanFacebookViewCommand = new ViewModelCommand(ExecuteShowTaoTaiKhoanFacebookViewCommand);
            ShowTangLuotXemViewCommand = new ViewModelCommand(ExecuteShowTangLuotXemViewCommand);

            ShowTangDangKyViewCommand = new ViewModelCommand(ExecuteShowTangDangKyViewCommand);
            ShowTangTheoDoiViewCommand = new ViewModelCommand(ExecuteShowTangTheoDoiViewCommand);

            //Default view
            ExecuteShowQuanLyHeThongViewCommand(null);

        }

        private void ExecuteShowTangTheoDoiViewCommand(object obj)
        {
            CurrentChildView = TangLuotTheoDoiViewModel.GetInstance();
            Caption = "Tăng lượt theo dõi";
            Icon = IconChar.ArrowUpRightDots;
        }

        private void ExecuteShowTangDangKyViewCommand(object obj)
        {
            CurrentChildView = TangLuotDangKyViewModel.GetInstance();
            Caption = "Tăng lượt đăng ký";
            Icon = IconChar.ArrowUpRightDots;
        }

        private void ExecuteShowTangLuotXemViewCommand(object obj)
        {
            CurrentChildView = TangLuotXemViewModel.GetInstance();
            Caption = "Tăng lượt xem";
            Icon = IconChar.ChartLine;
        }

        private void ExecuteShowTaoTaiKhoanFacebookViewCommand(object obj)
        {
            CurrentChildView = TaoTaiKhoanFacebookViewModel.GetInstance();
            Caption = "Tạo tài khoản";
            Icon = IconChar.User;
        }

        private void ExecuteShowTaoTaiKhoanGoogleViewCommand(object obj)
        {
            CurrentChildView = TaoTaiKhoanGoogleViewModel.GetInstance();
            Caption = "Tạo tài khoản";
            Icon = IconChar.User;
        }

        private void ExecuteShowTaiKhoanGoogleViewCommand(object obj)
        {
            CurrentChildView = new TaiKhoanGoogleViewModel();
            Caption = "Google";
            Icon = IconChar.Google;
        }

        private void ExecuteShowTaiKhoanFacebookViewCommand(object obj)
        {
            CurrentChildView = new TaiKhoanFacbookViewModel();
            Caption = "Facebook";
            Icon = IconChar.Facebook;
        }

        private void ExecuteShowQuanLyHeThongViewCommand(object obj)
        {
            CurrentChildView = new QuanLyHeThongViewModel();
            Caption = "Quản lý hệ thống";
            Icon = IconChar.Gear;
        }

        private void ExecuteShowQuanLyThietBiViewCommand(object obj)
        {
            CurrentChildView = new QuanLyThietBiViewModel();
            Caption = "Quản lý thiết bị";
            Icon = IconChar.UserGroup;
        }
    }
}
