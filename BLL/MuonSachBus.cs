using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MuonSachBus
    {
        TheLoaiBus theLoaiBus = new TheLoaiBus { };

        public List<MuonTraSach> getList()
        {
            var list = DBContextSingleTon.Instance.MuonTraSach.ToList();
            return list;
            // return new BindingList<MuonTraSach>(list);
        }

        public List<string> muon(DocGia dg, DateTime ngayMuon, DateTime ngayHenTra, List<Sach> sach)
        {
            var errors = new List<string>();

            var muonSach = new MuonTraSach { };
            muonSach.DocGia = dg;
            muonSach.Sach = sach;
            muonSach.NgayHenTra = ngayHenTra;
            muonSach.NgayMuon = ngayMuon;

            DBContextSingleTon.Instance.MuonTraSach.Add(muonSach);
            DBContextSingleTon.Instance.SaveChanges();

            return errors;
        }

        public List<Sach> getListSach(long id)
        {
            var MuonTraSach = DBContextSingleTon.Instance.MuonTraSach.Where(m => m.ID == id).FirstOrDefault();
            return MuonTraSach.Sach.ToList();
        }

        public List<MuonTraSach> search(long idDocGia)
        {
            return DBContextSingleTon.Instance.MuonTraSach.Where(m => m.DocGia.MaDG == idDocGia).ToList();
        }

    }
}
