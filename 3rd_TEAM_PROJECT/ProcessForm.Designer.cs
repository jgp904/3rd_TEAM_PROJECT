namespace _3rd_TEAM_PROJECT
{
    partial class ProcessForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessForm));
            menuStrip1 = new MenuStrip();
            LogOut = new ToolStripMenuItem();
            tabProcess = new TabControl();
            facsetting = new TabPage();
            dgvfac = new DataGridView();
            fac_id = new DataGridViewTextBoxColumn();
            fac_code = new DataGridViewTextBoxColumn();
            fac_name = new DataGridViewTextBoxColumn();
            fac_const = new DataGridViewTextBoxColumn();
            fac_regdate = new DataGridViewTextBoxColumn();
            fac_modi = new DataGridViewTextBoxColumn();
            fac_moddate = new DataGridViewTextBoxColumn();
            cbbFilter = new ComboBox();
            label97 = new Label();
            pictureBox4 = new PictureBox();
            txtfacSearch = new TextBox();
            g_fac_setting = new GroupBox();
            lbfacId = new Label();
            btnCFactory = new Button();
            btnUFactory = new Button();
            lb = new Label();
            btnDFactory = new Button();
            label6 = new Label();
            txtfac_Moddate = new TextBox();
            label5 = new Label();
            txtfac_Modi = new TextBox();
            label4 = new Label();
            txtfac_Regdate = new TextBox();
            label3 = new Label();
            txtfac_Const = new TextBox();
            label2 = new Label();
            txtfac_Name = new TextBox();
            label1 = new Label();
            txtfac_Code = new TextBox();
            equipsetting = new TabPage();
            dgvEquip = new DataGridView();
            equip_id = new DataGridViewTextBoxColumn();
            equip_code = new DataGridViewTextBoxColumn();
            equip_name = new DataGridViewTextBoxColumn();
            equip_comment = new DataGridViewTextBoxColumn();
            equip_const = new DataGridViewTextBoxColumn();
            equip_regdate = new DataGridViewTextBoxColumn();
            equip_modi = new DataGridViewTextBoxColumn();
            equip_moddate = new DataGridViewTextBoxColumn();
            equip_status = new DataGridViewTextBoxColumn();
            equip_event = new DataGridViewTextBoxColumn();
            comboBox1 = new ComboBox();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            searchEquip = new TextBox();
            groupBox1 = new GroupBox();
            cbbEquipEvent = new ComboBox();
            cbbEquipStatus = new ComboBox();
            label8 = new Label();
            label16 = new Label();
            label17 = new Label();
            txtEquip_Comment = new TextBox();
            lbEquipId = new Label();
            btnEquipC = new Button();
            btnEquipU = new Button();
            label9 = new Label();
            btnEquipD = new Button();
            label10 = new Label();
            txtEquip_Moddate = new TextBox();
            label11 = new Label();
            txtEquip_Modi = new TextBox();
            label12 = new Label();
            txtEquip_Regdate = new TextBox();
            label13 = new Label();
            txtEquip_Const = new TextBox();
            label14 = new Label();
            txtEquip_Name = new TextBox();
            label15 = new Label();
            txtEquip_Code = new TextBox();
            tabPage1 = new TabPage();
            menuStrip1.SuspendLayout();
            tabProcess.SuspendLayout();
            facsetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvfac).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            g_fac_setting.SuspendLayout();
            equipsetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { LogOut });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1177, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // LogOut
            // 
            LogOut.Alignment = ToolStripItemAlignment.Right;
            LogOut.Name = "LogOut";
            LogOut.Size = new Size(67, 20);
            LogOut.Text = "로그아웃";
            // 
            // tabProcess
            // 
            tabProcess.Alignment = TabAlignment.Left;
            tabProcess.Controls.Add(facsetting);
            tabProcess.Controls.Add(equipsetting);
            tabProcess.Controls.Add(tabPage1);
            tabProcess.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabProcess.ItemSize = new Size(25, 100);
            tabProcess.Location = new Point(0, 24);
            tabProcess.Multiline = true;
            tabProcess.Name = "tabProcess";
            tabProcess.SelectedIndex = 0;
            tabProcess.Size = new Size(1178, 657);
            tabProcess.SizeMode = TabSizeMode.Fixed;
            tabProcess.TabIndex = 1;
            tabProcess.DrawItem += tabProcess_DrawItem;
            tabProcess.Selected += tabProcess_Selected;
            // 
            // facsetting
            // 
            facsetting.Controls.Add(dgvfac);
            facsetting.Controls.Add(cbbFilter);
            facsetting.Controls.Add(label97);
            facsetting.Controls.Add(pictureBox4);
            facsetting.Controls.Add(txtfacSearch);
            facsetting.Controls.Add(g_fac_setting);
            facsetting.Location = new Point(104, 4);
            facsetting.Name = "facsetting";
            facsetting.Padding = new Padding(3);
            facsetting.Size = new Size(1070, 649);
            facsetting.TabIndex = 0;
            facsetting.Text = "공장설정";
            facsetting.UseVisualStyleBackColor = true;
            // 
            // dgvfac
            // 
            dgvfac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvfac.Columns.AddRange(new DataGridViewColumn[] { fac_id, fac_code, fac_name, fac_const, fac_regdate, fac_modi, fac_moddate });
            dgvfac.Location = new Point(3, 36);
            dgvfac.Name = "dgvfac";
            dgvfac.RowTemplate.Height = 25;
            dgvfac.Size = new Size(854, 610);
            dgvfac.TabIndex = 42;
            dgvfac.CellClick += dgvfac_CellClick;
            // 
            // fac_id
            // 
            fac_id.HeaderText = "ID";
            fac_id.Name = "fac_id";
            fac_id.Width = 50;
            // 
            // fac_code
            // 
            fac_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fac_code.HeaderText = "공장코드";
            fac_code.Name = "fac_code";
            // 
            // fac_name
            // 
            fac_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fac_name.HeaderText = "공장명";
            fac_name.Name = "fac_name";
            // 
            // fac_const
            // 
            fac_const.HeaderText = "생성자";
            fac_const.Name = "fac_const";
            fac_const.Width = 80;
            // 
            // fac_regdate
            // 
            fac_regdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fac_regdate.HeaderText = "생성일자";
            fac_regdate.Name = "fac_regdate";
            // 
            // fac_modi
            // 
            fac_modi.HeaderText = "수정자";
            fac_modi.Name = "fac_modi";
            fac_modi.Width = 80;
            // 
            // fac_moddate
            // 
            fac_moddate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            fac_moddate.HeaderText = "수정일자";
            fac_moddate.Name = "fac_moddate";
            // 
            // cbbFilter
            // 
            cbbFilter.FormattingEnabled = true;
            cbbFilter.Items.AddRange(new object[] { "공장코드", "공장명", "생성자", "수정자" });
            cbbFilter.Location = new Point(736, 7);
            cbbFilter.Name = "cbbFilter";
            cbbFilter.Size = new Size(121, 23);
            cbbFilter.TabIndex = 41;
            cbbFilter.Text = "공장코드";
            // 
            // label97
            // 
            label97.AutoSize = true;
            label97.BackColor = Color.LightSteelBlue;
            label97.Font = new Font("굴림", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label97.Location = new Point(7, 6);
            label97.Name = "label97";
            label97.Padding = new Padding(5);
            label97.Size = new Size(47, 24);
            label97.TabIndex = 40;
            label97.Text = "검색";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(709, 7);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(21, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 39;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // txtfacSearch
            // 
            txtfacSearch.Location = new Point(60, 6);
            txtfacSearch.Name = "txtfacSearch";
            txtfacSearch.Size = new Size(643, 23);
            txtfacSearch.TabIndex = 38;
            txtfacSearch.KeyPress += txtfacSearch_KeyPress;
            // 
            // g_fac_setting
            // 
            g_fac_setting.Controls.Add(lbfacId);
            g_fac_setting.Controls.Add(btnCFactory);
            g_fac_setting.Controls.Add(btnUFactory);
            g_fac_setting.Controls.Add(lb);
            g_fac_setting.Controls.Add(btnDFactory);
            g_fac_setting.Controls.Add(label6);
            g_fac_setting.Controls.Add(txtfac_Moddate);
            g_fac_setting.Controls.Add(label5);
            g_fac_setting.Controls.Add(txtfac_Modi);
            g_fac_setting.Controls.Add(label4);
            g_fac_setting.Controls.Add(txtfac_Regdate);
            g_fac_setting.Controls.Add(label3);
            g_fac_setting.Controls.Add(txtfac_Const);
            g_fac_setting.Controls.Add(label2);
            g_fac_setting.Controls.Add(txtfac_Name);
            g_fac_setting.Controls.Add(label1);
            g_fac_setting.Controls.Add(txtfac_Code);
            g_fac_setting.Dock = DockStyle.Right;
            g_fac_setting.Location = new Point(867, 3);
            g_fac_setting.Name = "g_fac_setting";
            g_fac_setting.Size = new Size(200, 643);
            g_fac_setting.TabIndex = 0;
            g_fac_setting.TabStop = false;
            g_fac_setting.Text = "공장설정";
            // 
            // lbfacId
            // 
            lbfacId.AutoSize = true;
            lbfacId.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbfacId.Location = new Point(48, 33);
            lbfacId.Name = "lbfacId";
            lbfacId.Size = new Size(0, 21);
            lbfacId.TabIndex = 46;
            // 
            // btnCFactory
            // 
            btnCFactory.Location = new Point(2, 556);
            btnCFactory.Name = "btnCFactory";
            btnCFactory.Size = new Size(198, 23);
            btnCFactory.TabIndex = 45;
            btnCFactory.Text = "생성";
            btnCFactory.UseVisualStyleBackColor = true;
            btnCFactory.Click += btnCFactory_Click;
            // 
            // btnUFactory
            // 
            btnUFactory.Location = new Point(2, 585);
            btnUFactory.Name = "btnUFactory";
            btnUFactory.Size = new Size(198, 23);
            btnUFactory.TabIndex = 44;
            btnUFactory.Text = "수정";
            btnUFactory.UseVisualStyleBackColor = true;
            btnUFactory.Click += btnUFactory_Click;
            // 
            // lb
            // 
            lb.AutoSize = true;
            lb.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb.Location = new Point(7, 33);
            lb.Name = "lb";
            lb.Size = new Size(35, 21);
            lb.TabIndex = 14;
            lb.Text = "ID :";
            // 
            // btnDFactory
            // 
            btnDFactory.Location = new Point(2, 614);
            btnDFactory.Name = "btnDFactory";
            btnDFactory.Size = new Size(198, 23);
            btnDFactory.TabIndex = 43;
            btnDFactory.Text = "삭제";
            btnDFactory.UseVisualStyleBackColor = true;
            btnDFactory.Click += btnDFactory_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 210);
            label6.Name = "label6";
            label6.Size = new Size(62, 15);
            label6.TabIndex = 13;
            label6.Text = "수정일자 :";
            // 
            // txtfac_Moddate
            // 
            txtfac_Moddate.Location = new Point(89, 207);
            txtfac_Moddate.Name = "txtfac_Moddate";
            txtfac_Moddate.Size = new Size(100, 23);
            txtfac_Moddate.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 181);
            label5.Name = "label5";
            label5.Size = new Size(50, 15);
            label5.TabIndex = 11;
            label5.Text = "수정자 :";
            // 
            // txtfac_Modi
            // 
            txtfac_Modi.Location = new Point(89, 178);
            txtfac_Modi.Name = "txtfac_Modi";
            txtfac_Modi.Size = new Size(100, 23);
            txtfac_Modi.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 152);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 9;
            label4.Text = "생성일자 :";
            // 
            // txtfac_Regdate
            // 
            txtfac_Regdate.Location = new Point(89, 149);
            txtfac_Regdate.Name = "txtfac_Regdate";
            txtfac_Regdate.Size = new Size(100, 23);
            txtfac_Regdate.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 123);
            label3.Name = "label3";
            label3.Size = new Size(50, 15);
            label3.TabIndex = 7;
            label3.Text = "생성자 :";
            // 
            // txtfac_Const
            // 
            txtfac_Const.Location = new Point(89, 120);
            txtfac_Const.Name = "txtfac_Const";
            txtfac_Const.Size = new Size(100, 23);
            txtfac_Const.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 94);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 5;
            label2.Text = "공장명 :";
            // 
            // txtfac_Name
            // 
            txtfac_Name.Location = new Point(89, 91);
            txtfac_Name.Name = "txtfac_Name";
            txtfac_Name.Size = new Size(100, 23);
            txtfac_Name.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 65);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 3;
            label1.Text = "공장코드 :";
            // 
            // txtfac_Code
            // 
            txtfac_Code.Location = new Point(89, 62);
            txtfac_Code.Name = "txtfac_Code";
            txtfac_Code.Size = new Size(100, 23);
            txtfac_Code.TabIndex = 2;
            // 
            // equipsetting
            // 
            equipsetting.Controls.Add(dgvEquip);
            equipsetting.Controls.Add(comboBox1);
            equipsetting.Controls.Add(label7);
            equipsetting.Controls.Add(pictureBox1);
            equipsetting.Controls.Add(searchEquip);
            equipsetting.Controls.Add(groupBox1);
            equipsetting.Location = new Point(104, 4);
            equipsetting.Name = "equipsetting";
            equipsetting.Padding = new Padding(3);
            equipsetting.Size = new Size(1070, 649);
            equipsetting.TabIndex = 1;
            equipsetting.Text = "설비설정";
            equipsetting.UseVisualStyleBackColor = true;
            // 
            // dgvEquip
            // 
            dgvEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEquip.Columns.AddRange(new DataGridViewColumn[] { equip_id, equip_code, equip_name, equip_comment, equip_const, equip_regdate, equip_modi, equip_moddate, equip_status, equip_event });
            dgvEquip.Location = new Point(3, 36);
            dgvEquip.Name = "dgvEquip";
            dgvEquip.RowTemplate.Height = 25;
            dgvEquip.Size = new Size(854, 610);
            dgvEquip.TabIndex = 48;
            dgvEquip.CellClick += dgvEquip_CellClick;
            // 
            // equip_id
            // 
            equip_id.HeaderText = "ID";
            equip_id.Name = "equip_id";
            equip_id.Width = 50;
            // 
            // equip_code
            // 
            equip_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            equip_code.HeaderText = "설비코드";
            equip_code.Name = "equip_code";
            // 
            // equip_name
            // 
            equip_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            equip_name.HeaderText = "설비명";
            equip_name.Name = "equip_name";
            // 
            // equip_comment
            // 
            equip_comment.HeaderText = "설비설명";
            equip_comment.Name = "equip_comment";
            equip_comment.Width = 150;
            // 
            // equip_const
            // 
            equip_const.HeaderText = "생성자";
            equip_const.Name = "equip_const";
            equip_const.Width = 80;
            // 
            // equip_regdate
            // 
            equip_regdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            equip_regdate.HeaderText = "생성일자";
            equip_regdate.Name = "equip_regdate";
            // 
            // equip_modi
            // 
            equip_modi.HeaderText = "수정자";
            equip_modi.Name = "equip_modi";
            equip_modi.Width = 80;
            // 
            // equip_moddate
            // 
            equip_moddate.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            equip_moddate.HeaderText = "수정일자";
            equip_moddate.Name = "equip_moddate";
            // 
            // equip_status
            // 
            equip_status.HeaderText = "설비상태";
            equip_status.Name = "equip_status";
            // 
            // equip_event
            // 
            equip_event.HeaderText = "설비이벤트";
            equip_event.Name = "equip_event";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "공장코드", "공장명", "생성자", "수정자" });
            comboBox1.Location = new Point(736, 7);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 47;
            comboBox1.Text = "공장코드";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.LightSteelBlue;
            label7.Font = new Font("굴림", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(7, 6);
            label7.Name = "label7";
            label7.Padding = new Padding(5);
            label7.Size = new Size(47, 24);
            label7.TabIndex = 46;
            label7.Text = "검색";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(709, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(21, 23);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 45;
            pictureBox1.TabStop = false;
            // 
            // searchEquip
            // 
            searchEquip.Location = new Point(60, 6);
            searchEquip.Name = "searchEquip";
            searchEquip.Size = new Size(643, 23);
            searchEquip.TabIndex = 44;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(cbbEquipEvent);
            groupBox1.Controls.Add(cbbEquipStatus);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(txtEquip_Comment);
            groupBox1.Controls.Add(lbEquipId);
            groupBox1.Controls.Add(btnEquipC);
            groupBox1.Controls.Add(btnEquipU);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(btnEquipD);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(txtEquip_Moddate);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(txtEquip_Modi);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(txtEquip_Regdate);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(txtEquip_Const);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(txtEquip_Name);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(txtEquip_Code);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(867, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 643);
            groupBox1.TabIndex = 43;
            groupBox1.TabStop = false;
            groupBox1.Text = "공장설정";
            // 
            // cbbEquipEvent
            // 
            cbbEquipEvent.FormattingEnabled = true;
            cbbEquipEvent.Items.AddRange(new object[] { "BreakeDown", "Maintanunce", "Emergency" });
            cbbEquipEvent.Location = new Point(89, 178);
            cbbEquipEvent.Name = "cbbEquipEvent";
            cbbEquipEvent.Size = new Size(100, 23);
            cbbEquipEvent.TabIndex = 49;
            cbbEquipEvent.Text = "NON";
            // 
            // cbbEquipStatus
            // 
            cbbEquipStatus.FormattingEnabled = true;
            cbbEquipStatus.Items.AddRange(new object[] { "Stop", "Process" });
            cbbEquipStatus.Location = new Point(89, 149);
            cbbEquipStatus.Name = "cbbEquipStatus";
            cbbEquipStatus.Size = new Size(100, 23);
            cbbEquipStatus.TabIndex = 49;
            cbbEquipStatus.Text = "Ready";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 181);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 52;
            label8.Text = "설비이벤트 :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(7, 152);
            label16.Name = "label16";
            label16.Size = new Size(62, 15);
            label16.TabIndex = 50;
            label16.Text = "설비상태 :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(7, 123);
            label17.Name = "label17";
            label17.Size = new Size(62, 15);
            label17.TabIndex = 48;
            label17.Text = "설비설명 :";
            // 
            // txtEquip_Comment
            // 
            txtEquip_Comment.Location = new Point(89, 120);
            txtEquip_Comment.Name = "txtEquip_Comment";
            txtEquip_Comment.Size = new Size(100, 23);
            txtEquip_Comment.TabIndex = 47;
            // 
            // lbEquipId
            // 
            lbEquipId.AutoSize = true;
            lbEquipId.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lbEquipId.Location = new Point(48, 33);
            lbEquipId.Name = "lbEquipId";
            lbEquipId.Size = new Size(0, 21);
            lbEquipId.TabIndex = 46;
            // 
            // btnEquipC
            // 
            btnEquipC.Location = new Point(2, 556);
            btnEquipC.Name = "btnEquipC";
            btnEquipC.Size = new Size(198, 23);
            btnEquipC.TabIndex = 45;
            btnEquipC.Text = "생성";
            btnEquipC.UseVisualStyleBackColor = true;
            btnEquipC.Click += btnEquipC_Click;
            // 
            // btnEquipU
            // 
            btnEquipU.Location = new Point(2, 585);
            btnEquipU.Name = "btnEquipU";
            btnEquipU.Size = new Size(198, 23);
            btnEquipU.TabIndex = 44;
            btnEquipU.Text = "수정";
            btnEquipU.UseVisualStyleBackColor = true;
            btnEquipU.Click += btnEquipU_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(7, 33);
            label9.Name = "label9";
            label9.Size = new Size(35, 21);
            label9.TabIndex = 14;
            label9.Text = "ID :";
            // 
            // btnEquipD
            // 
            btnEquipD.Location = new Point(2, 614);
            btnEquipD.Name = "btnEquipD";
            btnEquipD.Size = new Size(198, 23);
            btnEquipD.TabIndex = 43;
            btnEquipD.Text = "삭제";
            btnEquipD.UseVisualStyleBackColor = true;
            btnEquipD.Click += btnEquipD_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 297);
            label10.Name = "label10";
            label10.Size = new Size(62, 15);
            label10.TabIndex = 13;
            label10.Text = "수정일자 :";
            // 
            // txtEquip_Moddate
            // 
            txtEquip_Moddate.Location = new Point(89, 294);
            txtEquip_Moddate.Name = "txtEquip_Moddate";
            txtEquip_Moddate.Size = new Size(100, 23);
            txtEquip_Moddate.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 268);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 11;
            label11.Text = "수정자 :";
            // 
            // txtEquip_Modi
            // 
            txtEquip_Modi.Location = new Point(89, 265);
            txtEquip_Modi.Name = "txtEquip_Modi";
            txtEquip_Modi.Size = new Size(100, 23);
            txtEquip_Modi.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(7, 239);
            label12.Name = "label12";
            label12.Size = new Size(62, 15);
            label12.TabIndex = 9;
            label12.Text = "생성일자 :";
            // 
            // txtEquip_Regdate
            // 
            txtEquip_Regdate.Location = new Point(89, 236);
            txtEquip_Regdate.Name = "txtEquip_Regdate";
            txtEquip_Regdate.Size = new Size(100, 23);
            txtEquip_Regdate.TabIndex = 8;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(7, 210);
            label13.Name = "label13";
            label13.Size = new Size(50, 15);
            label13.TabIndex = 7;
            label13.Text = "생성자 :";
            // 
            // txtEquip_Const
            // 
            txtEquip_Const.Location = new Point(89, 207);
            txtEquip_Const.Name = "txtEquip_Const";
            txtEquip_Const.Size = new Size(100, 23);
            txtEquip_Const.TabIndex = 6;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(7, 94);
            label14.Name = "label14";
            label14.Size = new Size(50, 15);
            label14.TabIndex = 5;
            label14.Text = "설비명 :";
            // 
            // txtEquip_Name
            // 
            txtEquip_Name.Location = new Point(89, 91);
            txtEquip_Name.Name = "txtEquip_Name";
            txtEquip_Name.Size = new Size(100, 23);
            txtEquip_Name.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(7, 65);
            label15.Name = "label15";
            label15.Size = new Size(62, 15);
            label15.TabIndex = 3;
            label15.Text = "설비코드 :";
            // 
            // txtEquip_Code
            // 
            txtEquip_Code.Location = new Point(89, 62);
            txtEquip_Code.Name = "txtEquip_Code";
            txtEquip_Code.Size = new Size(100, 23);
            txtEquip_Code.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.Location = new Point(104, 4);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1070, 649);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // ProcessForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 681);
            Controls.Add(tabProcess);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ProcessForm";
            Text = "Process";
            Load += ProcessForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabProcess.ResumeLayout(false);
            facsetting.ResumeLayout(false);
            facsetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvfac).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            g_fac_setting.ResumeLayout(false);
            g_fac_setting.PerformLayout();
            equipsetting.ResumeLayout(false);
            equipsetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEquip).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem LogOut;
        private TabControl tabProcess;
        private TabPage facsetting;
        private TabPage equipsetting;
        private GroupBox g_fac_setting;
        private DataGridView dgvfac;
        private ComboBox cbbFilter;
        private Label label97;
        private PictureBox pictureBox4;
        private TextBox txtfacSearch;
        private Label lb;
        private Label label6;
        private TextBox txtfac_Moddate;
        private Label label5;
        private TextBox txtfac_Modi;
        private Label label4;
        private TextBox txtfac_Regdate;
        private Label label3;
        private TextBox txtfac_Const;
        private Label label2;
        private TextBox txtfac_Name;
        private Label label1;
        private TextBox txtfac_Code;
        private DataGridViewTextBoxColumn fac_id;
        private DataGridViewTextBoxColumn fac_code;
        private DataGridViewTextBoxColumn fac_name;
        private DataGridViewTextBoxColumn fac_const;
        private DataGridViewTextBoxColumn fac_regdate;
        private DataGridViewTextBoxColumn fac_modi;
        private DataGridViewTextBoxColumn fac_moddate;
        private Button btnCFactory;
        private Button btnUFactory;
        private Button btnDFactory;
        private Label lbfacId;
        private ComboBox comboBox1;
        private Label label7;
        private PictureBox pictureBox1;
        private TextBox searchEquip;
        private GroupBox groupBox1;
        private Label lbEquipId;
        private Button btnEquipC;
        private Button btnEquipU;
        private Label label9;
        private Button btnEquipD;
        private Label label10;
        private TextBox txtEquip_Moddate;
        private Label label11;
        private TextBox txtEquip_Modi;
        private Label label12;
        private TextBox txtEquip_Regdate;
        private Label label13;
        private TextBox txtEquip_Const;
        private Label label14;
        private TextBox txtEquip_Name;
        private Label label15;
        private TextBox txtEquip_Code;
        private DataGridView dgvEquip;
        private Label label16;
        private Label label17;
        private TextBox txtEquip_Comment;
        private Label label8;
        private ComboBox cbbEquipStatus;
        private ComboBox cbbEquipEvent;
        private DataGridViewTextBoxColumn equip_id;
        private DataGridViewTextBoxColumn equip_code;
        private DataGridViewTextBoxColumn equip_name;
        private DataGridViewTextBoxColumn equip_comment;
        private DataGridViewTextBoxColumn equip_const;
        private DataGridViewTextBoxColumn equip_regdate;
        private DataGridViewTextBoxColumn equip_modi;
        private DataGridViewTextBoxColumn equip_moddate;
        private DataGridViewTextBoxColumn equip_status;
        private DataGridViewTextBoxColumn equip_event;
        private TabPage tabPage1;
    }
}