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
                MessageBox.Show("���̵� Ȥ�� ��й�ȣ�� ��ġ���� �ʽ��ϴ�. �濵�����ο� �����Ͻʽÿ�.");
        }

        private bool CheckLogin()
        {
            //�α��� ��Ģ
            throw new NotImplementedException();
        }
    }
}