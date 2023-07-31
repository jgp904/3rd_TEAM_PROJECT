namespace _3rd_TEAM_PROJECT
{
	partial class S_Factory
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(S_Factory));
			dgvSFac = new DataGridView();
			sfac_id = new DataGridViewTextBoxColumn();
			sfac_code = new DataGridViewTextBoxColumn();
			sfac_name = new DataGridViewTextBoxColumn();
			txtSFac = new TextBox();
			label1 = new Label();
			btnSelect_Fac = new Button();
			cbbSFac_filter = new ComboBox();
			pbFac = new PictureBox();
			((System.ComponentModel.ISupportInitialize)dgvSFac).BeginInit();
			((System.ComponentModel.ISupportInitialize)pbFac).BeginInit();
			SuspendLayout();
			// 
			// dgvSFac
			// 
			dgvSFac.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvSFac.Columns.AddRange(new DataGridViewColumn[] { sfac_id, sfac_code, sfac_name });
			dgvSFac.Location = new Point(12, 38);
			dgvSFac.Name = "dgvSFac";
			dgvSFac.RowTemplate.Height = 25;
			dgvSFac.Size = new Size(392, 374);
			dgvSFac.TabIndex = 58;
			// 
			// sfac_id
			// 
			sfac_id.HeaderText = "ID";
			sfac_id.Name = "sfac_id";
			sfac_id.Width = 50;
			// 
			// sfac_code
			// 
			sfac_code.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			sfac_code.HeaderText = "공장코드";
			sfac_code.Name = "sfac_code";
			// 
			// sfac_name
			// 
			sfac_name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			sfac_name.HeaderText = "공장명";
			sfac_name.Name = "sfac_name";
			// 
			// txtSFac
			// 
			txtSFac.Location = new Point(49, 9);
			txtSFac.Name = "txtSFac";
			txtSFac.Size = new Size(227, 23);
			txtSFac.TabIndex = 57;
			txtSFac.KeyPress += txtSFac_KeyPress;
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
			// btnSelect_Fac
			// 
			btnSelect_Fac.Location = new Point(12, 418);
			btnSelect_Fac.Name = "btnSelect_Fac";
			btnSelect_Fac.Size = new Size(392, 23);
			btnSelect_Fac.TabIndex = 61;
			btnSelect_Fac.Text = "공장등록";
			btnSelect_Fac.UseVisualStyleBackColor = true;
			btnSelect_Fac.Click += btnSelect_Fac_Click;
			// 
			// cbbSFac_filter
			// 
			cbbSFac_filter.FormattingEnabled = true;
			cbbSFac_filter.Items.AddRange(new object[] { "공장코드", "공장명" });
			cbbSFac_filter.Location = new Point(309, 9);
			cbbSFac_filter.Name = "cbbSFac_filter";
			cbbSFac_filter.Size = new Size(95, 23);
			cbbSFac_filter.TabIndex = 60;
			cbbSFac_filter.Text = "공장코드";
			// 
			// pbFac
			// 
			pbFac.Image = (Image)resources.GetObject("pbFac.Image");
			pbFac.Location = new Point(282, 9);
			pbFac.Name = "pbFac";
			pbFac.Size = new Size(21, 23);
			pbFac.SizeMode = PictureBoxSizeMode.StretchImage;
			pbFac.TabIndex = 59;
			pbFac.TabStop = false;
			pbFac.Click += pbFac_Click;
			// 
			// S_Factory
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(416, 450);
			Controls.Add(dgvSFac);
			Controls.Add(txtSFac);
			Controls.Add(label1);
			Controls.Add(btnSelect_Fac);
			Controls.Add(cbbSFac_filter);
			Controls.Add(pbFac);
			Name = "S_Factory";
			Text = "S_Factory";
			Load += S_Factory_Load;
			((System.ComponentModel.ISupportInitialize)dgvSFac).EndInit();
			((System.ComponentModel.ISupportInitialize)pbFac).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView dgvSFac;
		private TextBox txtSFac;
		private Label label1;
		private Button btnSelect_Fac;
		private ComboBox cbbSFac_filter;
		private PictureBox pbFac;
		private DataGridViewTextBoxColumn sfac_id;
		private DataGridViewTextBoxColumn sfac_code;
		private DataGridViewTextBoxColumn sfac_name;
	}
}