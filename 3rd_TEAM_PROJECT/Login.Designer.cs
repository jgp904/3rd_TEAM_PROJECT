namespace _3rd_TEAM_PROJECT_Desk
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtId = new TextBox();
            txtPw = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
            picPassIcon = new PictureBox();
            checkBoxAutoLogin = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)picPassIcon).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(89, 47);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 0;
            label1.Text = "로그인";
            // 
            // txtId
            // 
            txtId.Location = new Point(28, 133);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "아이디를 입력하세요";
            txtId.Size = new Size(202, 23);
            txtId.TabIndex = 1;
            // 
            // txtPw
            // 
            txtPw.Location = new Point(28, 176);
            txtPw.Name = "txtPw";
            txtPw.PlaceholderText = "비밀번호를 입력하세요";
            txtPw.Size = new Size(202, 23);
            txtPw.TabIndex = 2;
            txtPw.KeyPress += txtPw_KeyPress;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(28, 236);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(86, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(144, 236);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "종료";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // picPassIcon
            // 
            picPassIcon.Image = _3rd_TEAM_PROJECT.Properties.Resources.PasswardChar_On;
            picPassIcon.Location = new Point(236, 170);
            picPassIcon.Name = "picPassIcon";
            picPassIcon.Size = new Size(33, 35);
            picPassIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picPassIcon.TabIndex = 5;
            picPassIcon.TabStop = false;
            picPassIcon.MouseLeave += picPassIcon_MouseLeave;
            picPassIcon.MouseMove += picPassIcon_MouseMove;
            // 
            // checkBoxAutoLogin
            // 
            checkBoxAutoLogin.AutoSize = true;
            checkBoxAutoLogin.Location = new Point(30, 205);
            checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            checkBoxAutoLogin.Size = new Size(90, 19);
            checkBoxAutoLogin.TabIndex = 6;
            checkBoxAutoLogin.Text = "자동 로그인";
            checkBoxAutoLogin.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(281, 305);
            Controls.Add(checkBoxAutoLogin);
            Controls.Add(picPassIcon);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(txtPw);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)picPassIcon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox txtPw;
        private Button btnLogin;
        private Button btnExit;
        private PictureBox picPassIcon;
        private CheckBox checkBoxAutoLogin;
    }
}