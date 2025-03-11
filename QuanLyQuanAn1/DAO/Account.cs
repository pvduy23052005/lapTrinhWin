using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn1.DAO
{
    internal class Account
    {
        private static Account singleton;

        internal static Account Singleton
        {
            get
            {
                if (singleton == null) singleton = new Account();
                return singleton;
            }
            private set { singleton = value; }
        }
        private Account()
        {

        }
        public bool login(string username, string password)
        {
            string query = "SELECT * FROM Account WHERE Username = @Username AND Password = @Password";

            DataTable kt = DataProvider.Singleton.ExeCuteQuery(query, new object[] { username, password });

            return kt.Rows.Count > 0;
        }


    }
}
