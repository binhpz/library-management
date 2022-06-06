using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DangNhapBus
    {
        public bool Login(string username, string password)
        {
            var exist = DBContextSingleTon.Instance.ThuThu.Where(t => t.TaiKhoan == username && t.MatKhau == password).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

    }
}
