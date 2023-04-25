using Code.Models;
using Code.Utils;
using Code.Utils.Story;
using Code.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace Code.ViewModels
{
    public class TaoTaiKhoanGoogleViewModel : ViewModelBase
    {

        public class DeviceStatus: ViewModelBase
        {
            private int stt;
            private string deviceId;
            private TrangThai status;

            public class TrangThai
            {
                private readonly string name;
                private TrangThai(string name)
                {
                    this.name = name;
                }

                public override string ToString()
                {
                    return this.name;
                }

                public static TrangThai DANG_CHAY = new TrangThai("Đang chạy");
                public static TrangThai THANH_CONG = new TrangThai("Thành công");
                public static TrangThai THAT_BAI = new TrangThai("Thất bại");
            }
            public int Stt
            {
                get
                {
                    return this.stt;
                }
                set
                {
                    this.stt = value;
                    this.OnPropertyChanged("Stt");
                }
            }
            public TrangThai Status
            {
                get
                {
                    return this.status;
                }
                set
                {
                    this.status = value;
                    this.OnPropertyChanged("Status");
                }
            }
            public string DeviceId
            {
                get
                {
                    return this.deviceId;
                }
                set
                {
                    this.deviceId = value;
                    this.OnPropertyChanged("DeviceId");
                }
            }
        }

        private int _thanhCong;
        public int ThanhCong
        {
            get { return this._thanhCong; }
            set
            {
                this._thanhCong = value;
                OnPropertyChanged("ThanhCong");
            }
        }
        private int _thatBai;
        public int ThatBai
        {
            get { return this._thatBai; }
            set
            {
                this._thatBai = value;
                OnPropertyChanged("ThatBai");
            }
        }

        Mutex mutexThanhCong = new Mutex();
        private void TangThanhCong()
        {
            mutexThanhCong.WaitOne();
            ++ThanhCong;
            mutexThanhCong.ReleaseMutex();
        }

        Mutex mutexThatBai = new Mutex();
        private void TangThatBai()
        {
            mutexThatBai.WaitOne();
            ++ThatBai;
            mutexThatBai.ReleaseMutex();
        }

        public string[] arrHo = { "Nguyen", "Tran", "Ngo", "Ha", "Đinh", "Phan" };
        public string[] arrTen = { "Duy", "Khanh", "Mai", "Huyen", "Quynh", "Linh", "Huong", "Hoang", "Nguyen", "Nam", "Anh"};
        private List<Thread> threads = new List<Thread>();
        public ObservableCollection<DeviceStatus> devices = new ObservableCollection<DeviceStatus>();
        private Dispatcher mainDispatcher = Dispatcher.CurrentDispatcher;


        public ICommand ShowPopUpWindowCommand { get; }
        public ICommand StopAction { get; }

        private static TaoTaiKhoanGoogleViewModel INSTANCE = null;

        public static TaoTaiKhoanGoogleViewModel GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new TaoTaiKhoanGoogleViewModel();
            }
            return INSTANCE;
        }

        private TaoTaiKhoanGoogleViewModel()
        {
            ShowPopUpWindowCommand = new ViewModelCommand(ExecuteShowPopUpWindow);
            StopAction = new ViewModelCommand(ExecuteStopAction);

        }

        private PopupChonThietBiView popupChonThietBiView;

        private void ThemCongViecTaoTaiKhoan(List<string> thietbi)
        {
            Console.WriteLine("Có " + thietbi.Count + " được chọn");
            var thread = new Thread(new ThreadStart(() =>
            {
                CreateGooleAccount(thietbi);
            }));
            thread.Start();
            this.threads.Add(thread);
        }

        private void ExecuteShowPopUpWindow(object obj)
        {
            popupChonThietBiView?.Close();
            popupChonThietBiView = new PopupChonThietBiView(ThemCongViecTaoTaiKhoan);
            popupChonThietBiView.Show();
        }

        private void ExecuteStopAction(object obj)
        {

            foreach (Thread thread in threads)
            {
                thread.Interrupt();
                thread.Abort();
            }
            this.threads = new List<Thread>();
        }

        private void CreateGooleAccount(List<string> thietbi)
        {
            Console.WriteLine("Bắt đầu thực hiện tạo tài khoản");
            Thread[] jobThreads = new Thread[thietbi.Count];
            try
            {
                int nextIndex = 0;
                while (true)
                {
                    if (nextIndex != -1)
                    {
                        var prefix = RandomString(10);
                        Random rnd = new Random();
                        var account = new TaiKhoanGoogle();
                        account.Ten = arrTen[rnd.Next(0, arrTen.Length - 1)];
                        account.TenDangNhap = String.Format("{0}{1}", prefix, rnd.Next(1, 1000));
                        account.Ho = arrHo[rnd.Next(0, arrHo.Length - 1)];
                        account.MatKhau = "Abc13579";
                        account.NamSinh = 2000 + rnd.Next(-10, 10);
                        account.NgaySinh = rnd.Next(1, 28);
                        account.ThangSinh = rnd.Next(0, 11);
                        account.GioiTinh = rnd.Next(0, 2);
                        jobThreads[nextIndex] = new Thread(new ThreadStart(() =>
                        {
                            ThucThiTaoTaiKhoanTrenThietBi(thietbi[nextIndex], account);
                        }));
                        jobThreads[nextIndex].Start();
                        Console.WriteLine("Tạo tài khoản Google trên thiết bị " + thietbi[nextIndex]);
                    }
                    Thread.Sleep(2000);
                    nextIndex = -1;
                    for (int i = 0; i < jobThreads.Length; i++)
                    {
                        if (jobThreads[i] == null || !jobThreads[i].IsAlive)
                        {
                            nextIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                foreach (var thread in jobThreads)
                {
                    thread?.Abort();
                }
            }
            finally
            {
                Console.WriteLine("Kết thúc thực hiện tạo tài khoản");
            }
        }

        private void ThucThiTaoTaiKhoanTrenThietBi(string idThietBi, TaiKhoanGoogle account)
        {
            Console.WriteLine("Chạy thiết bị " + idThietBi);
            var status = new DeviceStatus { Stt = devices.Count+1, DeviceId = idThietBi, Status = DeviceStatus.TrangThai.DANG_CHAY };
            mainDispatcher.Invoke(() =>
            {
                devices.Add(status);
            });
            var job = new CreateGoogleAccountScript(idThietBi, account);
            try
            {
                if (job.Run())
                {
                    status.Status = DeviceStatus.TrangThai.THANH_CONG;
                    DataProvider.Ins.db.TaiKhoanGoogles.Add(account);
                    TangThanhCong();
                }
                else
                {
                    status.Status = DeviceStatus.TrangThai.THAT_BAI;
                    TangThatBai();
                }
            }
            catch (Exception ex)
            {
                status.Status = DeviceStatus.TrangThai.THAT_BAI;
                TangThatBai();
            }
            finally
            {
                Console.WriteLine("Chạy xong " + idThietBi);
            }
        }
        private string RandomString(int length = 10)
        {
            var allowChars = "qweryuiopasdfghjklzxcvbnm";
            var random = new Random();
            var str = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var index = random.Next(allowChars.Length);
                str.Append(allowChars[index]);
            }
            return str.ToString();
        }
    }
}
