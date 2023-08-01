using _3rd_TEAM_PROJECT;
using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.Acount;
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
        // AutoLoginCancelled: 자동 로그인이 취소됐는지 확인하는 플래그
        private bool AutoLoginCancelled { get; set; } = false;

        public Login()
        {
            InitializeComponent();

            // 체크박스의 상태를 불러옴
            checkBoxAutoLogin.Checked = Settings.Default.AutoLoginEnabled;

            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;

            // 자동 로그인 확인 메서드 실행
            AutoLoginWithConfirmation();
        }

        // AutoLoginWithConfirmation: 사용자에게 자동 로그인할 것인지 확인
        private async void AutoLoginWithConfirmation()
        {
            // 설정에서 사용자명과 비밀번호를 불러옴
            if (Settings.Default.Username != string.Empty && Settings.Default.Password != string.Empty)
            {
                // 자동 로그인 알림 메시지 출력
                var result = MessageBox.Show("최근 로그인한 계정으로 로그인합니다. 취소하려면 '취소' 버튼을 누르세요.", "자동 로그인", MessageBoxButtons.OKCancel);

                // 사용자가 '취소'를 누르면, AutoLoginCancelled 플래그를 설정
                if (result == DialogResult.Cancel)
                {
                    AutoLoginCancelled = true;
                }
                else
                {
                    // 사용자가 '취소'를 누르지 않은 경우, 5초 후에 자동 로그인 시도
                    if (!AutoLoginCancelled)
                    {
                        txtId.Text = Settings.Default.Username;
                        txtPw.Text = Decrypt(Settings.Default.Password);

                        await Task.Delay(1000);

                        // 로그인 버튼 클릭 이벤트를 프로그래밍적으로 호출
                        btnLogin.PerformClick();
                    }
                }
            }
        }

        // CheckLogin: 사용자 로그인 정보를 검사
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

        // btnLogin_Click: 로그인 버튼 클릭 시 실행되는 메서드
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Acount loggedInAcount = CheckLogin();

            if (loggedInAcount != null)
            {
                //자동 로그인 체크박스 확인
                if (checkBoxAutoLogin.Checked)
                {
                    Settings.Default.Username = txtId.Text;
                    Settings.Default.Password = Encrypt(txtPw.Text);
                    Settings.Default.AutoLoginEnabled = true; // 체크박스의 상태를 저장합니다.
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.AutoLoginEnabled = false; // 체크박스의 상태를 저장합니다.
                    Settings.Default.Save();
                }

                //텍스트박스 청소
                textclear();

                // 로그인 상태 저장
                SessionManager.Instance.Login(loggedInAcount);

                // 로그인 폼 인스턴스 저장
                SessionManager.Instance.LoginForm = this;

                // 계정 정보에 따라 다른 폼을 표시
                //if (loggedInAcount.Department.DepartmentCode == "002")
                if (loggedInAcount.DepartmentCode == "002")
                {
                    Main mainForm = new Main();
                    mainForm.Show();
                }
                else if (loggedInAcount.DepartmentCode == "003")
                {
                    ProcessForm processForm = new ProcessForm(); // ProcessForm은 사용자가 새로 만든 폼입니다.
                    processForm.Show();
                }
                else
                {
                    MessageBox.Show("구매부서는 WEB PAGE를 이용해주십시오");
                }

                this.Hide();
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 일치하지 않습니다. 경영지원부에 문의하십시오.");
            }
        }

        // btnExit_Click: 종료 버튼 클릭 시 실행되는 메서드
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // textclear: 텍스트 입력란 초기화
        private void textclear()
        {
            txtId.Text = "";
            txtPw.Text = "";
        }

        // Encrypt: 암호화 메서드. 텍스트를 입력받아 암호화된 문자열을 반환
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

        // Decrypt: 복호화 메서드. 암호화된 텍스트를 입력받아 복호화된 문자열을 반환
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

        // picPassIcon_MouseLeave: 마우스가 픽쳐박스에서 벗어났을 때 실행되는 메서드
        private void picPassIcon_MouseLeave(object sender, EventArgs e)
        {
            txtPw.UseSystemPasswordChar = true;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;
        }

        // picPassIcon_MouseMove: 마우스가 픽쳐박스 위에서 움직일 때 실행되는 메서드
        private void picPassIcon_MouseMove(object sender, MouseEventArgs e)
        {
            txtPw.UseSystemPasswordChar = false;
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_Off;
        }

        // txtPw_KeyPress: 비밀번호 입력란에서 키를 눌렀을 때 실행되는 메서드
        private void txtPw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}