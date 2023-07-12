namespace _3rd_TEAM_PROJECT
{
    partial class Main
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
            label1 = new Label();
            TabMenu = new TabControl();
            Purches_warehouse = new TabPage();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            Purches_inhis = new TabPage();
            Purches_insrch = new TabPage();
            Purches_outhis = new TabPage();
            Purches_outsrch = new TabPage();
            Product_fac = new TabPage();
            Product_proc = new TabPage();
            Product_num = new TabPage();
            Product_equip = new TabPage();
            Product_lotlist = new TabPage();
            Product_lotstart = new TabPage();
            Product_lotend = new TabPage();
            Product_lothis = new TabPage();
            menuStrip1 = new MenuStrip();
            로그아웃ToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            panel1 = new Panel();
            warehouse_id = new DataGridViewTextBoxColumn();
            warehouse_name = new DataGridViewTextBoxColumn();
            warehouse_cat = new DataGridViewTextBoxColumn();
            warehouse_count = new DataGridViewTextBoxColumn();
            TabMenu.SuspendLayout();
            Purches_warehouse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(0, 24);
            label1.Name = "label1";
            label1.Size = new Size(87, 21);
            label1.TabIndex = 3;
            label1.Text = "Session_ID";
            // 
            // TabMenu
            // 
            TabMenu.Alignment = TabAlignment.Left;
            TabMenu.Controls.Add(Purches_warehouse);
            TabMenu.Controls.Add(Purches_inhis);
            TabMenu.Controls.Add(Purches_insrch);
            TabMenu.Controls.Add(Purches_outhis);
            TabMenu.Controls.Add(Purches_outsrch);
            TabMenu.Controls.Add(Product_fac);
            TabMenu.Controls.Add(Product_proc);
            TabMenu.Controls.Add(Product_num);
            TabMenu.Controls.Add(Product_equip);
            TabMenu.Controls.Add(Product_lotlist);
            TabMenu.Controls.Add(Product_lotstart);
            TabMenu.Controls.Add(Product_lotend);
            TabMenu.Controls.Add(Product_lothis);
            TabMenu.Dock = DockStyle.Bottom;
            TabMenu.DrawMode = TabDrawMode.OwnerDrawFixed;
            TabMenu.ItemSize = new Size(25, 100);
            TabMenu.Location = new Point(0, 59);
            TabMenu.Multiline = true;
            TabMenu.Name = "TabMenu";
            TabMenu.SelectedIndex = 0;
            TabMenu.Size = new Size(1177, 622);
            TabMenu.SizeMode = TabSizeMode.Fixed;
            TabMenu.TabIndex = 4;
            TabMenu.DrawItem += TabMenu_DrawItem;
            // 
            // Purches_warehouse
            // 
            Purches_warehouse.Controls.Add(panel1);
            Purches_warehouse.Controls.Add(dataGridView1);
            Purches_warehouse.Location = new Point(104, 4);
            Purches_warehouse.Name = "Purches_warehouse";
            Purches_warehouse.Padding = new Padding(3);
            Purches_warehouse.Size = new Size(1069, 614);
            Purches_warehouse.TabIndex = 0;
            Purches_warehouse.Text = "재고";
            Purches_warehouse.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(65, 104);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(65, 75);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(65, 46);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(65, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { warehouse_id, warehouse_name, warehouse_cat, warehouse_count });
            dataGridView1.Dock = DockStyle.Left;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(240, 608);
            dataGridView1.TabIndex = 0;
            // 
            // Purches_inhis
            // 
            Purches_inhis.Location = new Point(104, 4);
            Purches_inhis.Name = "Purches_inhis";
            Purches_inhis.Padding = new Padding(3);
            Purches_inhis.Size = new Size(1069, 614);
            Purches_inhis.TabIndex = 1;
            Purches_inhis.Text = "입고 목록";
            Purches_inhis.UseVisualStyleBackColor = true;
            // 
            // Purches_insrch
            // 
            Purches_insrch.Location = new Point(104, 4);
            Purches_insrch.Name = "Purches_insrch";
            Purches_insrch.Size = new Size(1069, 614);
            Purches_insrch.TabIndex = 2;
            Purches_insrch.Text = "입고 조회";
            Purches_insrch.UseVisualStyleBackColor = true;
            // 
            // Purches_outhis
            // 
            Purches_outhis.Location = new Point(104, 4);
            Purches_outhis.Name = "Purches_outhis";
            Purches_outhis.Size = new Size(1069, 614);
            Purches_outhis.TabIndex = 3;
            Purches_outhis.Text = "출고 목록";
            Purches_outhis.UseVisualStyleBackColor = true;
            // 
            // Purches_outsrch
            // 
            Purches_outsrch.Location = new Point(104, 4);
            Purches_outsrch.Name = "Purches_outsrch";
            Purches_outsrch.Size = new Size(1069, 614);
            Purches_outsrch.TabIndex = 4;
            Purches_outsrch.Text = "출고 조회";
            Purches_outsrch.UseVisualStyleBackColor = true;
            // 
            // Product_fac
            // 
            Product_fac.Location = new Point(104, 4);
            Product_fac.Name = "Product_fac";
            Product_fac.Size = new Size(1069, 614);
            Product_fac.TabIndex = 5;
            Product_fac.Text = "공장 목록";
            Product_fac.UseVisualStyleBackColor = true;
            // 
            // Product_proc
            // 
            Product_proc.Location = new Point(104, 4);
            Product_proc.Name = "Product_proc";
            Product_proc.Size = new Size(1069, 614);
            Product_proc.TabIndex = 6;
            Product_proc.Text = "공정 설정";
            Product_proc.UseVisualStyleBackColor = true;
            // 
            // Product_num
            // 
            Product_num.Location = new Point(104, 4);
            Product_num.Name = "Product_num";
            Product_num.Size = new Size(1069, 614);
            Product_num.TabIndex = 7;
            Product_num.Text = "품번 설정";
            Product_num.UseVisualStyleBackColor = true;
            // 
            // Product_equip
            // 
            Product_equip.Location = new Point(104, 4);
            Product_equip.Name = "Product_equip";
            Product_equip.Size = new Size(1069, 614);
            Product_equip.TabIndex = 8;
            Product_equip.Text = "설비 목록";
            Product_equip.UseVisualStyleBackColor = true;
            // 
            // Product_lotlist
            // 
            Product_lotlist.Location = new Point(104, 4);
            Product_lotlist.Name = "Product_lotlist";
            Product_lotlist.Size = new Size(1069, 614);
            Product_lotlist.TabIndex = 9;
            Product_lotlist.Text = "LOT 목록";
            Product_lotlist.UseVisualStyleBackColor = true;
            // 
            // Product_lotstart
            // 
            Product_lotstart.Location = new Point(104, 4);
            Product_lotstart.Name = "Product_lotstart";
            Product_lotstart.Size = new Size(1069, 614);
            Product_lotstart.TabIndex = 10;
            Product_lotstart.Text = "LOT 작업시작";
            Product_lotstart.UseVisualStyleBackColor = true;
            // 
            // Product_lotend
            // 
            Product_lotend.Location = new Point(104, 4);
            Product_lotend.Name = "Product_lotend";
            Product_lotend.Size = new Size(1069, 614);
            Product_lotend.TabIndex = 11;
            Product_lotend.Text = "LOT 작업종료";
            Product_lotend.UseVisualStyleBackColor = true;
            // 
            // Product_lothis
            // 
            Product_lothis.Location = new Point(104, 4);
            Product_lothis.Name = "Product_lothis";
            Product_lothis.Size = new Size(1069, 614);
            Product_lothis.TabIndex = 12;
            Product_lothis.Text = "LOT 이력조회";
            Product_lothis.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { 로그아웃ToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1177, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // 로그아웃ToolStripMenuItem
            // 
            로그아웃ToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            로그아웃ToolStripMenuItem.Name = "로그아웃ToolStripMenuItem";
            로그아웃ToolStripMenuItem.Size = new Size(67, 20);
            로그아웃ToolStripMenuItem.Text = "로그아웃";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 20);
            label2.Name = "label2";
            label2.Size = new Size(26, 15);
            label2.TabIndex = 5;
            label2.Text = "ID :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 49);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "품명 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 78);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 7;
            label4.Text = "품목 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(21, 107);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 8;
            label5.Text = "수량 :";
            // 
            // panel1
            // 
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(871, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(195, 608);
            panel1.TabIndex = 9;
            // 
            // warehouse_id
            // 
            warehouse_id.HeaderText = "ID";
            warehouse_id.Name = "warehouse_id";
            warehouse_id.ReadOnly = true;
            warehouse_id.Width = 80;
            // 
            // warehouse_name
            // 
            warehouse_name.HeaderText = "품명";
            warehouse_name.Name = "warehouse_name";
            warehouse_name.Width = 450;
            // 
            // warehouse_cat
            // 
            warehouse_cat.HeaderText = "품목";
            warehouse_cat.Name = "warehouse_cat";
            warehouse_cat.Width = 450;
            // 
            // warehouse_count
            // 
            warehouse_count.HeaderText = "수량";
            warehouse_count.Name = "warehouse_count";
            warehouse_count.Width = 80;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1177, 681);
            Controls.Add(TabMenu);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            FormClosing += Main_FormClosing;
            TabMenu.ResumeLayout(false);
            Purches_warehouse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private TabControl TabMenu;
        private TabPage Purches_warehouse;
        private TabPage Purches_inhis;
        private TabPage Purches_insrch;
        private TabPage Purches_outhis;
        private TabPage Purches_outsrch;
        private TabPage Product_fac;
        private TabPage Product_proc;
        private TabPage Product_num;
        private TabPage Product_equip;
        private TabPage Product_lotlist;
        private TabPage Product_lotstart;
        private TabPage Product_lotend;
        private TabPage Product_lothis;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 로그아웃ToolStripMenuItem;
        private DataGridView dataGridView1;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private DataGridViewTextBoxColumn warehouse_id;
        private DataGridViewTextBoxColumn warehouse_name;
        private DataGridViewTextBoxColumn warehouse_cat;
        private DataGridViewTextBoxColumn warehouse_count;
    }
}