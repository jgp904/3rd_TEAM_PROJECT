using _3rd_TEAM_PROJECT.Models.Acount;
using _3rd_TEAM_PROJECT_Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT
{
    // SessionManager.cs
    public class SessionManager
    {
        private static SessionManager _instance;

        public static SessionManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SessionManager();
                }

                return _instance;
            }
        }

        public Acount LoggedInAcount { get; private set; }

        // set 접근자를 public으로 변경하였습니다.
        public Login LoginForm { get; set; }

        private SessionManager()
        {
        }

        public void Login(Acount acount)
        {
            LoggedInAcount = acount;
        }

        public void Logout()
        {
            LoggedInAcount = null;
        }
    }
}
