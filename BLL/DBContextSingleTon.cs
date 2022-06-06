using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    class DBContextSingleTon
    {
        private static readonly AppDBContext instance = new AppDBContext();

        static DBContextSingleTon() { }

        private DBContextSingleTon() { }

        public static AppDBContext Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
