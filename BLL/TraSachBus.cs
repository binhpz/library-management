using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TraSachBus
    {
        TheLoaiBus theLoaiBus = new TheLoaiBus { };

        public BindingList<MuonTraSach> getList()
        {
            var list = DBContextSingleTon.Instance.MuonTraSach.ToList();
            return new BindingList<MuonTraSach>(list);
        }

        public List<string> Tra(long id)
        {
            var errors = new List<string>();
            var exist = DBContextSingleTon.Instance.MuonTraSach.Where(m => m.ID == id).FirstOrDefault();
            if (exist == null)
            {
                errors.Add("Thôn tin không tồn tại");
                return errors;
            }
            exist.NgayTra = DateTime.Now;
            exist.TrangThai = TrangThai.DaTra;
            DBContextSingleTon.Instance.SaveChanges();

            return errors;
        }

        public List<Sach> getListSach(long id)
        {
            var MuonTraSach = DBContextSingleTon.Instance.MuonTraSach.Where(m => m.ID == id).FirstOrDefault();
            return MuonTraSach.Sach.ToList();
        }

        public List<MuonTraSach> search(string tenDg)
        {
            return DBContextSingleTon.Instance.MuonTraSach.Where(m => m.DocGia.TenDG.ToLower().Contains(tenDg.ToLower())).ToList();
        }

    }
}
