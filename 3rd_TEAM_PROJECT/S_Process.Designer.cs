namespace _3rd_TEAM_PROJECT
{
    partial class S_Process
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_Process));
            dgvSProcess = new DataGridView();
            sprocess_id = new DataGridViewTextBoxColumn();
            sprocess_code = new DataGridViewTextBoxColumn();
            sprocess_name = new DataGridViewTextBoxColumn();
            sprocess_equipcode = new DataGridViewTextBoxColumn();
            txtSProcess = new TextBox();
            label1 = new Label();
            btnSelect_Process = new Button();
            cbbSProcess_filter = new ComboBox();
            pbProcess = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvSProcess).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProcess).BeginInit();
            SuspendLayout();
            // 
            // dgvSProcess
            // 
            dgvSProcess.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSProcess.Columns.AddRange(new DataGridViewColumn[] { sprocess_id, sprocess_code, sprocess_name, sprocess_equipcode });
            dgvSProcess.Location = new Point(12, 38);
            dgvSProcess.Name = "dgvSProcess";
            dgvSProcess.RowTemplate.Height = 25;
            dgvSProcess.Size = new Size(392, 374);
            dgvSProcess.TabIndex = 58;
            // 
            // sprocess_id
            // 
            sprocess_id.HeaderText = "ID";
            sprocess_id.Name = "sprocess_id";
            sprocess_id.Width = 50;
            // 
            // sprocess_code
            // 
            sprocess_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sprocess_code.HeaderText = "공정코드";
            sprocess_code.Name = "sprocess_code";
            // 
            // sprocess_name
            // 
            sprocess_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sprocess_name.HeaderText = "공정명";
            sprocess_name.Name = "sprocess_name";
            // 
            // sprocess_equipcode
            // 
            sprocess_equipcode.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sprocess_equipcode.HeaderText = "설비코드";
            sprocess_equipcode.Name = "sprocess_equipcode";
            // 
            // txtSProcess
            // 
            txtSProcess.Location = new Point(49, 9);
            txtSProcess.Name = "txtSProcess";
            txtSProcess.Size = new Size(227, 23);
            txtSProcess.TabIndex = 57;
            txtSProcess.KeyPress += txtSProcess_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 56;
            label1.Text = "검색";
            // 
            // btnSelect_Process
            // 
            btnSelect_Process.Location = new Point(12, 418);
            btnSelect_Process.Name = "btnSelect_Process";
            btnSelect_Process.Size = new Size(392, 23);
            btnSelect_Process.TabIndex = 61;
            btnSelect_Process.Text = "공정등록";
            btnSelect_Process.UseVisualStyleBackColor = true;
            btnSelect_Process.Click += btnSelect_Process_Click;
            // 
            // cbbSProcess_filter
            // 
            cbbSProcess_filter.FormattingEnabled = true;
            cbbSProcess_filter.Items.AddRange(new object[] { "공정코드", "공정명", "설비코드" });
            cbbSProcess_filter.Location = new Point(309, 9);
            cbbSProcess_filter.Name = "cbbSProcess_filter";
            cbbSProcess_filter.Size = new Size(95, 23);
            cbbSProcess_filter.TabIndex = 60;
            cbbSProcess_filter.Text = "공정코드";
            // 
            // pbProcess
            // 
            pbProcess.Image = (Image)resources.GetObject("pbProcess.Image");
            pbProcess.Location = new Point(282, 9);
            pbProcess.Name = "pbProcess";
            pbProcess.Size = new Size(21, 23);
            pbProcess.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProcess.TabIndex = 59;
            pbProcess.TabStop = false;
            pbProcess.Click += pbProcess_Click;
            // 
            // S_Process
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 450);
            Controls.Add(dgvSProcess);
            Controls.Add(txtSProcess);
            Controls.Add(label1);
            Controls.Add(btnSelect_Process);
            Controls.Add(cbbSProcess_filter);
            Controls.Add(pbProcess);
            Name = "S_Process";
            Text = "SearchProcess";
            Load += S_Process_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSProcess).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProcess).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSProcess;
        private DataGridViewTextBoxColumn sitem_id;
        private DataGridViewTextBoxColumn sitem_code;
        private DataGridViewTextBoxColumn sitem_name;
        private DataGridViewTextBoxColumn sitem_type;
        private TextBox txtSProcess;
        private Label label1;
        private Button btnSelect_Process;
        private ComboBox cbbSProcess_filter;
        private PictureBox pbProcess;
        private DataGridViewTextBoxColumn sprocess_id;
        private DataGridViewTextBoxColumn sprocess_code;
        private DataGridViewTextBoxColumn sprocess_name;
        private DataGridViewTextBoxColumn sprocess_equipcode;
    }
}