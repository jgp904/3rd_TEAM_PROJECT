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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            btnLogin = new Button();
            btnExit = new Button();
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
            // textBox1
            // 
            textBox1.Location = new Point(28, 133);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "아이디를 입력하세요";
            textBox1.Size = new Size(202, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(28, 176);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "비밀번호를 입력하세요";
            textBox2.Size = new Size(202, 23);
            textBox2.TabIndex = 2;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(28, 217);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(86, 35);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "로그인";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(144, 217);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(86, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "종료";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 279);
            Controls.Add(btnExit);
            Controls.Add(btnLogin);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button btnLogin;
        private Button btnExit;
    }
}