using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class TheLoaiBus
    {
        public BindingList<LoaiSach> getList()
        {
            var list = DBContextSingleTon.Instance.LoaiSach.ToList();
            return new BindingList<LoaiSach>(list);
        }

        public List<LoaiSach> getAll()
        {
            return DBContextSingleTon.Instance.LoaiSach.ToList();
        }


        public bool add(string tenTheLoai)
        {
            var exist = DBContextSingleTon.Instance.LoaiSach.Where(m => m.TenLoaiSach == tenTheLoai).FirstOrDefault();
            if (exist == null)
            {
                var loaiSach = new LoaiSach();
                loaiSach.TenLoaiSach = tenTheLoai;

                var result = DBContextSingleTon.Instance.LoaiSach.Add(loaiSach);
                DBContextSingleTon.Instance.SaveChanges();

                return true;
            }
            return false;
        }

        public void delete(long id)
        {
            var ls = DBContextSingleTon.Instance.LoaiSach.Where(m => m.MaLoaiSach == id).FirstOrDefault();
            if (ls != null)
            {
                DBContextSingleTon.Instance.LoaiSach.Remove(ls);
                DBContextSingleTon.Instance.SaveChanges();
            }

        }

        public List<string> edit(long id, string tenTL)
        {
            var errors = new List<string>();
            var exist = isExistName(tenTL);
            if (exist)
            {
                errors.Add("Thể loại đã tồn tại!");
            }

            if (errors.Count <= 0)
            {
                var ls = DBContextSingleTon.Instance.LoaiSach.Where(m => m.MaLoaiSach == id).FirstOrDefault();
                if (ls != null)
                {
                    ls.TenLoaiSach = tenTL;
                    DBContextSingleTon.Instance.SaveChanges();
                }
            }

            return errors;
        }

        private bool isExistName(string name)
        {
            var exist = DBContextSingleTon.Instance.LoaiSach.Where(m => m.TenLoaiSach == name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public LoaiSach findByMaLoaiSach(long maTheLoai)
        {
            var result = DBContextSingleTon.Instance.LoaiSach.Where(m => m.MaLoaiSach == maTheLoai).FirstOrDefault();
            return result;
        }

        private bool isExistId(string name)
        {
            var exist = DBContextSingleTon.Instance.LoaiSach.Where(m => m.TenLoaiSach == name).FirstOrDefault();
            if (exist != null)
            {
                return true;
            }
            return false;
        }

        public List<LoaiSach> findListByTenTheLoai(string tenTheLoai)
        {
            var exist = DBContextSingleTon.Instance.LoaiSach.Where(m => m.TenLoaiSach.ToLower().Contains(tenTheLoai.ToLower())).ToList();
            return exist;
        }
    }
}
