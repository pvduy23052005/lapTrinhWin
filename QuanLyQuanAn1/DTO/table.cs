using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn1.DTO
{
    public class table
    {

        public table(int iD, string name , string status)
        {
            this.ID = iD;
            this.Name = name;
            this.status = status; 
        }

        // gan cac hang vao cai list < table > 
        public table(DataRow row)
        {
            this.iD = (int)row["id"];
            this.name = row["name"].ToString();
            this.status = row["status"].ToString();
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        // ham set get name  .
        private string name;

        public string Name 
        { 
            get { return name;  }
            set { name = value; }
        }

        // ham set get iD .
        private int iD;

        public int ID 
        { 
            get { return iD; }
            set { iD = value; }
        } 
    }
}
