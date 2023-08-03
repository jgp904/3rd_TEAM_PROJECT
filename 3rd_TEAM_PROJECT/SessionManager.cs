using _3rd_TEAM_PROJECT.Models.Account;
using _3rd_TEAM_PROJECT_Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT
{
    public class SessionManager
    {
        // 싱글톤 패턴을 위한 인스턴스를 private으로 선언
        private static SessionManager _instance;

        // private 생성자로 인해 외부에서 인스턴스를 직접 생성하지 못하도록 함
        private SessionManager(){}

        // SessionManager의 인스턴스에 접근하는 정적 속성
        public static SessionManager Instance
        {
            get
            {
                // 인스턴스가 null일 경우, 새로운 인스턴스를 생성하여 반환
                if (_instance == null)
                {
                    _instance = new SessionManager();
                }

                // 인스턴스가 null이 아닐 경우, 기존의 인스턴스 반환
                return _instance;
            }
        }

        // 로그인 메서드, Account 객체를 받아 LoggedInAccount에 저장
        public void Login(Account acount)
        {
            LoggedInAccount = acount;
        }

        // 로그아웃 메서드, LoggedInAccount를 null로 설정하여 로그아웃 상태 표현
        public void Logout()
        {
            LoggedInAccount = null;
        }

        // 현재 로그인한 계정 정보를 저장
        public Account LoggedInAccount { get; private set; }

        // 로그인 폼을 저장하는 속성
        // set 접근자를 public으로 변경하였습니다.
        public Login LoginForm { get; set; }


    }
}
