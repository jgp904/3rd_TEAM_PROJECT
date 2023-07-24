namespace _3rd_TEAM_PROJECT
{
    partial class S_Equip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_Equip));
            label1 = new Label();
            txtSEquip = new TextBox();
            dgvSEquip = new DataGridView();
            sequip_id = new DataGridViewTextBoxColumn();
            sequip_code = new DataGridViewTextBoxColumn();
            sequip_name = new DataGridViewTextBoxColumn();
            sequip_comment = new DataGridViewTextBoxColumn();
            pictureBox4 = new PictureBox();
            cbbSEquip_filter = new ComboBox();
            btnSelect_Equip = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSEquip).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "검색";
            // 
            // txtSEquip
            // 
            txtSEquip.Location = new Point(49, 6);
            txtSEquip.Name = "txtSEquip";
            txtSEquip.Size = new Size(227, 23);
            txtSEquip.TabIndex = 2;
            txtSEquip.KeyPress += txtSEquip_KeyPress;
            // 
            // dgvSEquip
            // 
            dgvSEquip.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSEquip.Columns.AddRange(new DataGridViewColumn[] { sequip_id, sequip_code, sequip_name, sequip_comment });
            dgvSEquip.Location = new Point(12, 35);
            dgvSEquip.Name = "dgvSEquip";
            dgvSEquip.RowTemplate.Height = 25;
            dgvSEquip.Size = new Size(392, 374);
            dgvSEquip.TabIndex = 3;
      
            // 
            // sequip_id
            // 
            sequip_id.HeaderText = "ID";
            sequip_id.Name = "sequip_id";
            sequip_id.Width = 50;
            // 
            // sequip_code
            // 
            sequip_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sequip_code.HeaderText = "설비코드";
            sequip_code.Name = "sequip_code";
            // 
            // sequip_name
            // 
            sequip_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sequip_name.HeaderText = "설비명";
            sequip_name.Name = "sequip_name";
            // 
            // sequip_comment
            // 
            sequip_comment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sequip_comment.HeaderText = "설비설명";
            sequip_comment.Name = "sequip_comment";
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(282, 6);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(21, 23);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 40;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // cbbSEquip_filter
            // 
            cbbSEquip_filter.FormattingEnabled = true;
            cbbSEquip_filter.Items.AddRange(new object[] { "설비코드", "설비명" });
            cbbSEquip_filter.Location = new Point(309, 6);
            cbbSEquip_filter.Name = "cbbSEquip_filter";
            cbbSEquip_filter.Size = new Size(95, 23);
            cbbSEquip_filter.TabIndex = 48;
            cbbSEquip_filter.Text = "설비코드";
            // 
            // btnSelect_Equip
            // 
            btnSelect_Equip.Location = new Point(12, 415);
            btnSelect_Equip.Name = "btnSelect_Equip";
            btnSelect_Equip.Size = new Size(392, 23);
            btnSelect_Equip.TabIndex = 49;
            btnSelect_Equip.Text = "설비등록";
            btnSelect_Equip.UseVisualStyleBackColor = true;
            btnSelect_Equip.Click += btnSelect_Equip_Click;
            // 
            // S_Equip
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 450);
            Controls.Add(btnSelect_Equip);
            Controls.Add(cbbSEquip_filter);
            Controls.Add(pictureBox4);
            Controls.Add(dgvSEquip);
            Controls.Add(txtSEquip);
            Controls.Add(label1);
            Name = "S_Equip";
            Text = "Form1";
            Load += S_Equip_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSEquip).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSEquip;
        private DataGridView dgvSEquip;
        private PictureBox pictureBox4;
        private DataGridViewTextBoxColumn sequip_id;
        private DataGridViewTextBoxColumn sequip_code;
        private DataGridViewTextBoxColumn sequip_name;
        private DataGridViewTextBoxColumn sequip_comment;
        private ComboBox cbbSEquip_filter;
        private Button btnSelect_Equip;
    }
}