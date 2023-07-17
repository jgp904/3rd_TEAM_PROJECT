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
                    .Include(a => a.Department) // Department ������ ���� �������� ���� Include�� ����մϴ�.
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
                // �α��� ���� ����
                SessionManager.Instance.Login(loggedInAcount);

                // �α��� �� �ν��Ͻ� ����
                SessionManager.Instance.LoginForm = this;

                // ���� ������ ���� �ٸ� ���� ǥ��
                if (loggedInAcount.Department.DepartmentCode == "001")
                {
                    Main mainForm = new Main();
                    mainForm.Show();
                }
                else
                {
                    ProcessForm processForm = new ProcessForm(); // ProcessForm�� ����ڰ� ���� ���� ���Դϴ�.
                    processForm.Show();
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("���̵� Ȥ�� ��й�ȣ�� ��ġ���� �ʽ��ϴ�. �濵�����ο� �����Ͻʽÿ�.");
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