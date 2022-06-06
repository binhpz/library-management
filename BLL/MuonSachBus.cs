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

        public BindingList<MuonTraSach> getList()
        {
            var list = DBContextSingleTon.Instance.MuonTraSach.ToList();
            return new BindingList<MuonTraSach>(list);
        }

    }
}
