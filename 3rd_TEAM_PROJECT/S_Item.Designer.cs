namespace _3rd_TEAM_PROJECT
{
    partial class S_Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_Item));
            dgvSItem = new DataGridView();
            sitem_id = new DataGridViewTextBoxColumn();
            sitem_code = new DataGridViewTextBoxColumn();
            sitem_name = new DataGridViewTextBoxColumn();
            sitem_type = new DataGridViewTextBoxColumn();
            txtSItem = new TextBox();
            label1 = new Label();
            btnSelect_Item = new Button();
            cbbSItem_filter = new ComboBox();
            pbItem = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)dgvSItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbItem).BeginInit();
            SuspendLayout();
            // 
            // dgvSItem
            // 
            dgvSItem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSItem.Columns.AddRange(new DataGridViewColumn[] { sitem_id, sitem_code, sitem_name, sitem_type });
            dgvSItem.Location = new Point(12, 38);
            dgvSItem.Name = "dgvSItem";
            dgvSItem.RowTemplate.Height = 25;
            dgvSItem.Size = new Size(392, 374);
            dgvSItem.TabIndex = 52;
            // 
            // sitem_id
            // 
            sitem_id.HeaderText = "ID";
            sitem_id.Name = "sitem_id";
            sitem_id.Width = 50;
            // 
            // sitem_code
            // 
            sitem_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sitem_code.HeaderText = "품번";
            sitem_code.Name = "sitem_code";
            // 
            // sitem_name
            // 
            sitem_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sitem_name.HeaderText = "품명";
            sitem_name.Name = "sitem_name";
            // 
            // sitem_type
            // 
            sitem_type.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sitem_type.HeaderText = "TYPE";
            sitem_type.Name = "sitem_type";
            // 
            // txtSItem
            // 
            txtSItem.Location = new Point(49, 9);
            txtSItem.Name = "txtSItem";
            txtSItem.Size = new Size(227, 23);
            txtSItem.TabIndex = 51;
            txtSItem.KeyPress += txtSItem_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 50;
            label1.Text = "검색";
            // 
            // btnSelect_Item
            // 
            btnSelect_Item.Location = new Point(12, 418);
            btnSelect_Item.Name = "btnSelect_Item";
            btnSelect_Item.Size = new Size(392, 23);
            btnSelect_Item.TabIndex = 55;
            btnSelect_Item.Text = "품번등록";
            btnSelect_Item.UseVisualStyleBackColor = true;
            btnSelect_Item.Click += btnSelect_Item_Click;
            // 
            // cbbSItem_filter
            // 
            cbbSItem_filter.FormattingEnabled = true;
            cbbSItem_filter.Items.AddRange(new object[] { "품번", "품명", "TYPE" });
            cbbSItem_filter.Location = new Point(309, 9);
            cbbSItem_filter.Name = "cbbSItem_filter";
            cbbSItem_filter.Size = new Size(95, 23);
            cbbSItem_filter.TabIndex = 54;
            cbbSItem_filter.Text = "품번";
            // 
            // pbItem
            // 
            pbItem.Image = (Image)resources.GetObject("pbItem.Image");
            pbItem.Location = new Point(282, 9);
            pbItem.Name = "pbItem";
            pbItem.Size = new Size(21, 23);
            pbItem.SizeMode = PictureBoxSizeMode.StretchImage;
            pbItem.TabIndex = 53;
            pbItem.TabStop = false;
            pbItem.Click += pbItem_Click;
            // 
            // S_Item
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(416, 450);
            Controls.Add(dgvSItem);
            Controls.Add(txtSItem);
            Controls.Add(label1);
            Controls.Add(btnSelect_Item);
            Controls.Add(cbbSItem_filter);
            Controls.Add(pbItem);
            Name = "S_Item";
            Text = "SearchItem";
            Load += S_Item_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbItem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvSItem;
        private TextBox txtSItem;
        private Label label1;
        private Button btnSelect_Item;
        private ComboBox cbbSItem_filter;
        private PictureBox pbItem;
        private DataGridViewTextBoxColumn sitem_id;
        private DataGridViewTextBoxColumn sitem_code;
        private DataGridViewTextBoxColumn sitem_name;
        private DataGridViewTextBoxColumn sitem_type;
    }
}