using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DocGiaBus
    {
        public BindingList<DocGia> getList()
        {
            var list = DBContextSingleTon.Instance.DocGia.ToList();
            return new BindingList<DocGia>(list);
        }

        public List<string> add(string ten, DateTime ngaySinh, string diaChi, string cmnd, string sdt, DateTime nhh)
        {
            var errors = new List<string>();
            var exist = DBContextSingleTon.Instance.DocGia.Where(dg => dg.SoCMT == cmnd || dg.SDT == sdt).FirstOrDefault();
            if (exist != null)
            {
                errors.Add("Số cmnd hoặc số điện thoại đã tồn tại!");
                return errors;
            }

            var docgia = new DocGia { };
            docgia.TenDG = ten;
            docgia.NgaySinh = ngaySinh;
            docgia.DiaChi = diaChi;
            docgia.SoCMT = cmnd;
            docgia.SDT = sdt;
            docgia.NgayHetHanThe = nhh;

            DBContextSingleTon.Instance.DocGia.Add(docgia);
            DBContextSingleTon.Instance.SaveChanges();

            return errors;
        }

        public List<string> edit(long maDG, string ten, DateTime ngaySinh, string diaChi, string cmnd, string sdt, DateTime nhh)
        {
            var errors = new List<string>();
            var docgia = DBContextSingleTon.Instance.DocGia.Where(dg => dg.MaDG == maDG).FirstOrDefault();
            if (docgia == null)
            {
                errors.Add("Độc giả không tồn tại!");
                return errors;
            }

            docgia.TenDG = ten;
            docgia.NgaySinh = ngaySinh;
            docgia.DiaChi = diaChi;
            docgia.SoCMT = cmnd;
            docgia.SDT = sdt;
            docgia.NgayHetHanThe = nhh;

            DBContextSingleTon.Instance.SaveChanges();

            return errors;
        }

        public List<string> delete(long maDG)
        {
            var errors = new List<string>();
            var docgia = DBContextSingleTon.Instance.DocGia.Where(dg => dg.MaDG == maDG).FirstOrDefault();
            if (docgia == null)
            {
                errors.Add("Độc giả không tồn tại!");
                return errors;
            }

            DBContextSingleTon.Instance.DocGia.Remove(docgia);

            DBContextSingleTon.Instance.SaveChanges();

            return errors;
        }

        public List<DocGia> search(string tenDocGia, string sdt, string cmnd)
        {
            var exist = DBContextSingleTon.Instance.DocGia.Where(m => m.TenDG.ToLower().Contains(tenDocGia.ToLower()) || m.SDT == sdt || m.SoCMT == cmnd).ToList();
            return exist;
        }
    }
}
