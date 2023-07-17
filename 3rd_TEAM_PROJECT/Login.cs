using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.Acount;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;
using static _3rd_TEAM_PROJECT.Main;
using SessionManager = _3rd_TEAM_PROJECT.SessionManager;

namespace _3rd_TEAM_PROJECT_Desk
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();

            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;

        }
        private Acount CheckLogin()
        {
            string userId = txtId.Text;
            string password = txtPw.Text;

            using (var context = new AcountDbContext())
            {
                var acount = context.Acounts
                    .Include(a => a.Department) // Department 정보도 같이 가져오기 위해 Include를 사용합니다.
                    .FirstOrDefault(a => a.UserId == userId && a.PassWord == password);

                return acount;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acount loggedInAcount = CheckLogin();

            textclear();

            if (loggedInAcount != null)
            {
                // 로그인 상태 저장
                SessionManager.Instance.Login(loggedInAcount);

                // 로그인 폼 인스턴스 저장
                SessionManager.Instance.LoginForm = this;

                // 계정 정보에 따라 다른 폼을 표시
                if (loggedInAcount.Department.DepartmentCode == "001")
                {
                    Main mainForm = new Main();
                    mainForm.Show();
                }
                else
                {
                    ProcessForm processForm = new ProcessForm(); // ProcessForm은 사용자가 새로 만든 폼입니다.
                    processForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다. 경영지원부에 문의하십시오.");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textclear()
        {
            txtId.Text = "";
            txtPw.Text = "";
        }

        private void picPassIcon_MouseLeave(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;
        }

        private void picPassIcon_MouseMove(object sender, MouseEventArgs e)
        {
            txtPw.UseSystemPasswordChar = false;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_Off;
        }

        private void txtPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}