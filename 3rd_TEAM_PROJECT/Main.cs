namespace _3rd_TEAM_PROJECT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //MainForm을 닫으면 LoginForm도 종료
            this.FormClosed += (s, e) => Application.Exit();
        }

        private void TabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region Tab Text를 가로로 보이도록 함
            Graphics g = e.Graphics;
            TabPage tabPage = TabMenu.TabPages[e.Index];
            Rectangle tabBounds = TabMenu.GetTabRect(e.Index);

            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Near;
            stringFlags.LineAlignment = StringAlignment.Center;

            // Draw the tab text using the appropriate brush.
            Brush textBrush = new SolidBrush(tabPage.ForeColor);
            g.DrawString(tabPage.Text, this.Font, textBrush, tabBounds, new StringFormat(stringFlags));
            #endregion
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //화면 닫을 때 확인메시지 출력
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
            else
                Application.Exit();
        }
    }
}
