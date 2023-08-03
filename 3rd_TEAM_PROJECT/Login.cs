using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.Account;
using _3rd_TEAM_PROJECT.Properties;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using static _3rd_TEAM_PROJECT.Main;
using SessionManager = _3rd_TEAM_PROJECT.SessionManager;


namespace _3rd_TEAM_PROJECT_Desk
{
    public partial class Login : Form
    {
        // AutoLoginCancelled: �ڵ� �α����� ��ҵƴ��� Ȯ���ϴ� �÷���
        private bool AutoLoginCancelled { get; set; } = false;

        public Login()
        {
            InitializeComponent();

            // üũ�ڽ��� ���¸� �ҷ���
            checkBoxAutoLogin.Checked = Settings.Default.AutoLoginEnabled;

            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;

            // �ڵ� �α��� Ȯ�� �޼��� ����
            AutoLoginWithConfirmation();
        }

        // AutoLoginWithConfirmation: ����ڿ��� �ڵ� �α����� ������ Ȯ��
        private async void AutoLoginWithConfirmation()
        {
            // �������� ����ڸ�� ��й�ȣ�� �ҷ���
            if (Settings.Default.Username != string.Empty && Settings.Default.Password != string.Empty)
            {
                // �ڵ� �α��� �˸� �޽��� ���
                var result = MessageBox.Show("�ֱ� �α����� �������� �α����մϴ�. ����Ϸ��� '���' ��ư�� ��������.", "�ڵ� �α���", MessageBoxButtons.OKCancel);

                // ����ڰ� '���'�� ������, AutoLoginCancelled �÷��׸� ����
                if (result == DialogResult.Cancel)
                {
                    AutoLoginCancelled = true;
                }
                else
                {
                    // ����ڰ� '���'�� ������ ���� ���, 5�� �Ŀ� �ڵ� �α��� �õ�
                    if (!AutoLoginCancelled)
                    {
                        txtId.Text = Settings.Default.Username;
                        txtPw.Text = Decrypt(Settings.Default.Password);

                        await Task.Delay(500);

                        // �α��� ��ư Ŭ�� �̺�Ʈ�� ���α׷��������� ȣ��
                        btnLogin.PerformClick();
                    }
                }
            }
        }

        // CheckLogin: ����� �α��� ������ �˻�
        private Account CheckLogin()
        {
            string userId = txtId.Text;
            string password = txtPw.Text;

            using (var context = new AccountDbContext())
            {
                var account = context.Accounts
                    .Include(a => a.Department) // Department ������ ���� �������� ���� Include�� ����մϴ�.
                    .FirstOrDefault(a => a.UserId == userId && a.PassWord == password);

                return account;
            }
        }

        // btnLogin_Click: �α��� ��ư Ŭ�� �� ����Ǵ� �޼���
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account loggedInAccount = CheckLogin();

            if (loggedInAccount != null)
            {
                //�α��� �� ���ÿ� ������ ����
                if (checkBoxAutoLogin.Checked)
                {
                    Settings.Default.Username = txtId.Text;
                    Settings.Default.Password = Encrypt(txtPw.Text);
                    Settings.Default.AutoLoginEnabled = true;
                }
                else
                {
                    Settings.Default.Username = string.Empty;
                    Settings.Default.Password = string.Empty;
                    Settings.Default.AutoLoginEnabled = false;
                }
                Settings.Default.Save();


                // �α��� ���� ����
                SessionManager.Instance.Login(loggedInAccount);

                // �α��� �� �ν��Ͻ� ����
                SessionManager.Instance.LoginForm = this;

                // ���� ������ ���� �ٸ� ���� ǥ��
                //if (loggedInAccount.Department.DepartmentCode == "002")
                if (loggedInAccount.DepartmentCode == "002")
                {
                    //�ؽ�Ʈ�ڽ� û��
                    textclear();

                    Main mainForm = new Main();
                    mainForm.Show();
                }
                else if (loggedInAccount.DepartmentCode == "003")
                {
                    //�ؽ�Ʈ�ڽ� û��
                    textclear();

                    ProcessForm processForm = new ProcessForm(); // ProcessForm�� ����ڰ� ���� ���� ���Դϴ�.
                    processForm.Show();
                }
                else
                {
                    //�ؽ�Ʈ�ڽ� û��
                    textclear();

                    MessageBox.Show("�濵�����δ� WEB PAGE�� �̿����ֽʽÿ�");
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("���̵� Ȥ�� ��й�ȣ�� ��ġ���� �ʽ��ϴ�. �濵�����ο� �����Ͻʽÿ�.");
                txtPw.Text = "";
                txtPw.Focus();
            }
        }

        // btnExit_Click: ���� ��ư Ŭ�� �� ����Ǵ� �޼���
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        // textclear: �ؽ�Ʈ �Է¶� �ʱ�ȭ
        private void textclear()
        {
            txtId.Text = "";
            txtPw.Text = "";
        }

        // Encrypt: ��ȣȭ �޼���. �ؽ�Ʈ�� �Է¹޾� ��ȣȭ�� ���ڿ��� ��ȯ
        private string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("SomeEncryptionKey", new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        // Decrypt: ��ȣȭ �޼���. ��ȣȭ�� �ؽ�Ʈ�� �Է¹޾� ��ȣȭ�� ���ڿ��� ��ȯ
        private string Decrypt(string cipherText)
        {
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes("SomeEncryptionKey", new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        // picPassIcon_MouseLeave: ���콺�� ���Ĺڽ����� ����� �� ����Ǵ� �޼���
        private void picPassIcon_MouseLeave(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;
        }

        // picPassIcon_MouseMove: ���콺�� ���Ĺڽ� ������ ������ �� ����Ǵ� �޼���
        private void picPassIcon_MouseMove(object sender, MouseEventArgs e)
        {
            txtPw.UseSystemPasswordChar = false;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_Off;
        }

        // txtPw_KeyPress: ��й�ȣ �Է¶����� Ű�� ������ �� ����Ǵ� �޼���
        private void txtPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}