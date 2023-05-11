using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Code.Models
{
    static class AccountStatus
    {
        public const int PENDING = 0;
        public const int CREATED = 1;
        public const int FAILED = 2;
        public const int CREATING = 3;

        public static string GetDescription(int status)
        {

            switch (status)
            {
                case AccountStatus.CREATED:
                    {
                        return "Truy cập";
                    }
                case AccountStatus.FAILED:
                    {
                        return "Lỗi, tạo thất bại";
                    }
                case AccountStatus.PENDING:
                    {
                        return "Chuẩn bị trước";
                    }
                case AccountStatus.CREATING:
                    {
                        return "Đang được tạo";
                    }
                default:
                    {
                        return "Lỗi, không xác định";
                    }
            }
        }

        public static bool IsError(int status)
        {
            return status != PENDING && status != CREATED && status != CREATING;
        }
    }

    static class AccountFactory
    {

        public static readonly string[] arrHo = { "Nguyen", "Tran", "Ngo", "Ha", "Đinh", "Phan" };
        public static readonly string[] arrTen = { "Duy", "Khanh", "Mai", "Huyen", "Quynh", "Linh", "Huong", "Hoang", "Nguyen", "Nam", "Anh" };

        public static TaiKhoanGoogle RandomGoogleAccount(string deviceId)
        {
            var prefix = RandomString(10);
            Random rnd = new Random();
            var account = new TaiKhoanGoogle();
            account.Ten = arrTen[rnd.Next(0, arrTen.Length - 1)];
            account.TenDangNhap = String.Format("{0}{1}", prefix, rnd.Next(1, 1000));
            account.Ho = arrHo[rnd.Next(0, arrHo.Length - 1)];
            account.MatKhau = "Abc13579@!";
            account.NamSinh = 2000 + rnd.Next(-10, 10);
            account.NgaySinh = rnd.Next(1, 28);
            account.ThangSinh = rnd.Next(1, 12);
            account.GioiTinh = rnd.Next(0, 2);
            account.IDThietBi = deviceId;
            account.TrangThai = AccountStatus.PENDING;

            return account;
        }
        public static TaiKhoanFacebook RandomFaceBookAccount(string deviceId)
        {
            var allG = DataProvider.Ins.db.TaiKhoanGoogles.ToList();
            var allF = DataProvider.Ins.db.TaiKhoanFacebooks.ToList();
            var gAccount = allG.Find((acc) =>
            {
                var isTrue = acc.IDThietBi == deviceId && acc.TrangThai == AccountStatus.CREATED;
                if (isTrue)
                {
                    isTrue = allF.All((fb) =>
                    {
                        return fb.IDTaiKhoanG != acc.IDTaiKhoanG;
                    });
                }
                return isTrue;
            });
            if (gAccount == null)
            {
                return null;
            }

            var prefix = RandomString(10);
            Random rnd = new Random();
            var account = new TaiKhoanFacebook();
            account.Ten = arrTen[rnd.Next(0, arrTen.Length - 1)];
            account.TenDangNhap = String.Format("{0}{1}", prefix, rnd.Next(1, 1000));
            account.Ho = arrHo[rnd.Next(0, arrHo.Length - 1)];
            account.MatKhau = "Abc13579@!";
            account.NamSinh = 2000 + rnd.Next(-10, 10);
            account.NgaySinh = rnd.Next(1, 28);
            account.ThangSinh = rnd.Next(1, 12);
            account.GioiTinh = rnd.Next(0, 2);
            account.IDThietBi = deviceId;
            account.TrangThai = AccountStatus.PENDING;
            account.IDTaiKhoanG = gAccount.IDTaiKhoanG;

            return account;
        }

        public static string RandomString(int length = 10, string allowChars = "qweryuiopasdfghjklzxcvbnm")
        {
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
