using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3rd_TEAM_PROJECT
{
	public partial class S_Factory : Form
	{
		private readonly IFactoryRepository factoryRepository;
		public event EventHandler<string> FacCodeSelected;

		public S_Factory()
		{
			InitializeComponent();
			factoryRepository = Program.factoryRepository;
		}

		private void S_Factory_Load(object sender, EventArgs e)
		{
			LoadFac();
		}

		private async void LoadFac()
		{
			var items = await factoryRepository.GetAllAsync();

			dgvSFac.Rows.Clear();
			dgvSFac.Refresh();

			int i = 0;
			foreach (var item in items)
			{
				dgvSFac.Rows.Add();
				dgvSFac.Rows[i].Cells["sfac_id"].Value = item.Id;
				dgvSFac.Rows[i].Cells["sfac_code"].Value = item.Code;
				dgvSFac.Rows[i].Cells["sfac_name"].Value = item.Name;

				i++;
			}
		}

		private async void pbFac_Click(object sender, EventArgs e)
		{
			var items = await factoryRepository.GetAllAsync();
			string search = txtSFac.Text.Trim();

			if (cbbSFac_filter.Text.Trim() == "공장코드") items = await factoryRepository.CodeAsync(search);
			else if (cbbSFac_filter.Text.Trim() == "공장명") items = await factoryRepository.NameAsync(search);
			dgvSFac.Rows.Clear();
			dgvSFac.Refresh();

			int i = 0;
			foreach (var item in items)
			{
				dgvSFac.Rows.Add();
				dgvSFac.Rows[i].Cells["sfac_id"].Value = item.Id;
				dgvSFac.Rows[i].Cells["sfac_code"].Value = item.Code;
				dgvSFac.Rows[i].Cells["sfac_name"].Value = item.Name;
				i++;
			}
		}

		private async void txtSFac_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (char)Keys.Enter)
			{
				var items = await factoryRepository.GetAllAsync();
				string search = txtSFac.Text.Trim();

				if (cbbSFac_filter.Text.Trim() == "공장코드") items = await factoryRepository.CodeAsync(search);
				else if (cbbSFac_filter.Text.Trim() == "공장명") items = await factoryRepository.NameAsync(search);
				dgvSFac.Rows.Clear();
				dgvSFac.Refresh();

				int i = 0;
				foreach (var item in items)
				{
					dgvSFac.Rows.Add();
					dgvSFac.Rows[i].Cells["sfac_id"].Value = item.Id;
					dgvSFac.Rows[i].Cells["sfac_code"].Value = item.Code;
					dgvSFac.Rows[i].Cells["sfac_name"].Value = item.Name;
					i++;
				}
			}
		}

		private void btnSelect_Item_Click(object sender, EventArgs e)//품번등록
		{
			

		}

		private void btnSelect_Fac_Click(object sender, EventArgs e)
		{
			if (dgvSFac.SelectedCells.Count > 0)
			{
				string facCode;
				int rowIndex = dgvSFac.SelectedCells[0].RowIndex;

				DataGridViewRow selectedRow = dgvSFac.Rows[rowIndex];
				facCode = selectedRow.Cells["sfac_code"].Value.ToString().Trim();

				if (facCode == null) return;

				DialogResult result = MessageBox.Show($"선택된 공장({facCode})을 등록하시겠습니까?", "확인", MessageBoxButtons.YesNo);



				if (result == DialogResult.Yes)
				{
					FacCodeSelected?.Invoke(this, facCode);

					// 현재 폼을 닫을 수도 있습니다 (선택 사항).
					this.Close();
				}
				else return;
			}
		}
	}
}
