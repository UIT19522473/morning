using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNote
{
    public class Account
    {
        public string query = @"Data Source=.;Initial Catalog=DTBEvent;Integrated Security=True";

        //public string query = "Server=tcp:dtbevent-sever.database.windows.net,1433;Initial Catalog=DTBEvent;Persist Security Info=False;User ID=tuan;Password=123456tT;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        protected string user;
        protected List<Job> jobList;
        public Account()
        {
            user = "";
            jobList = new List<Job>();
        }

        public List<Job> JobList { get => jobList; set => jobList = value; }
        public string Username { get => user; set => user = value; }

    }
}
