using _3rd_TEAM_PROJECT;

namespace _3rd_TEAM_PROJECT_Desk
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool loginOk = CheckLogin();

            if (loginOk)
            {
                Main mainForm = new Main();
                mainForm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다. 경영지원부에 문의하십시오.");
        }

        private bool CheckLogin()
        {
            //로그인 규칙
            throw new NotImplementedException();
        }
    }
}