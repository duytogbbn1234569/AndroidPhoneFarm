using Code.Utils.Story;
using Code.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Code.ViewModels
{
    public class TaoTaiKhoanGoogleViewModel : ViewModelBase
    {
        public string[] arrHo = { "Nguyen", "Tran", "Ngo", "Ha", "Đinh", "Phan" };
        public string[] arrTen = { "Duy", "Khanh", "Mai", "Huyen", "Quynh", "Linh", "Huong", "Hoang", "Nguyen", "Nam", "Anh"};
        private List<Thread> threads;

        public ICommand ShowPopUpWindowCommand { get; }
        public ICommand StopAction { get; }

        public TaoTaiKhoanGoogleViewModel()
        {
            ShowPopUpWindowCommand = new ViewModelCommand(ExecuteShowPopUpWindow);
            StopAction = new ViewModelCommand(ExecuteStopAction);
            this.threads = new List<Thread>();
        }

        private PopupChonThietBiView popupChonThietBiView;

        private void ExecuteShowPopUpWindow(object obj)
        {
            popupChonThietBiView?.Close();
            popupChonThietBiView = new PopupChonThietBiView((thietbi) =>
            {
                var thread = new Thread(new ThreadStart(() =>
                {
                    CreateGooleAccount(thietbi);
                }));
                this.threads.Add(thread);
                thread.Start();
            });
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
            var jobThreads = new List<Thread>();
            foreach (var tb in thietbi)
            {
                jobThreads.Add(null);
            }
            try
            {
                int nextIndex = 0;
                
                while (true)
                {
                    var prefix = RandomString(10);
                    if (nextIndex != -1)
                    {
                        Random rnd = new Random();
                        var account = new TaiKhoanGoogle();
                        account.Ten = arrTen[rnd.Next(0,5)];
                        account.TenDangNhap = String.Format("{0}{1}", prefix, rnd.Next(1,1000));
                        account.Ho = arrHo[rnd.Next(0,11)];
                        account.MatKhau = "Abc13579";
                        account.NamSinh = 2000 + rnd.Next(-10, 10);
                        account.NgaySinh = rnd.Next(1,28);
                        account.ThangSinh = rnd.Next(0,11);
                        account.GioiTinh = rnd.Next(0,2);
                        jobThreads[nextIndex] = new Thread(new ThreadStart(() =>
                        {
                            ThucThiTaoTaiKhoanTrenThietBi(thietbi[nextIndex], account);
                        }));
                        jobThreads[nextIndex].Start();
                    }
                    Thread.Sleep(2000);
                    nextIndex = -1;
                    for (int i = 0; i < thietbi.Count; i++)
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
                foreach (Thread thread in threads)
                {
                    thread?.Abort();
                }
            }
        }

        private void ThucThiTaoTaiKhoanTrenThietBi(string idThietBi, TaiKhoanGoogle account)
        {
            var job = new CreateGoogleAccountScript(idThietBi, account);
            job.Run();
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
