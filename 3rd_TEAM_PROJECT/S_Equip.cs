using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT_Desk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _3rd_TEAM_PROJECT
{
    public partial class S_Equip : Form
    {
        private IEquipmentRepository equipmentRepository;
        public event EventHandler<string> EquipCodeSelected;



        public S_Equip()
        {
            InitializeComponent();
            equipmentRepository = Program.equipmentRepository;

        }
        private void S_Equip_Load(object sender, EventArgs e)
        {
            LoadEquip();
        }
        //---설비목록--//
        private async void LoadEquip()
        {
            var equips = await equipmentRepository.GetAllAsync();

            dgvSEquip.Rows.Clear();
            dgvSEquip.Refresh();

            int i = 0;
            foreach (var item in equips)
            {
                dgvSEquip.Rows.Add();
                dgvSEquip.Rows[i].Cells["sequip_id"].Value = item.Id;
                dgvSEquip.Rows[i].Cells["sequip_code"].Value = item.Code;
                dgvSEquip.Rows[i].Cells["sequip_name"].Value = item.Name;
                dgvSEquip.Rows[i].Cells["sequip_comment"].Value = item.Comment;
                i++;
            }
        }
        //---설비검색---//
        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            var equips = await equipmentRepository.GetAllAsync();
            string search = txtSEquip.Text.Trim();

            if (cbbSEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
            else if (cbbSEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
            dgvSEquip.Rows.Clear();
            dgvSEquip.Refresh();
            int i = 0;
            foreach (var item in equips)
            {
                dgvSEquip.Rows.Add();
                dgvSEquip.Rows[i].Cells["sequip_id"].Value = item.Id;
                dgvSEquip.Rows[i].Cells["sequip_code"].Value = item.Code;
                dgvSEquip.Rows[i].Cells["sequip_name"].Value = item.Name;
                dgvSEquip.Rows[i].Cells["sequip_comment"].Value = item.Comment;
                i++;
            }
        }
        //--엔터검색--//
        private async void txtSEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var equips = await equipmentRepository.GetAllAsync();
                string search = txtSEquip.Text.Trim();

                if (cbbSEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
                else if (cbbSEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
                dgvSEquip.Rows.Clear();
                dgvSEquip.Refresh();
                int i = 0;
                foreach (var item in equips)
                {
                    dgvSEquip.Rows.Add();
                    dgvSEquip.Rows[i].Cells["sequip_id"].Value = item.Id;
                    dgvSEquip.Rows[i].Cells["sequip_code"].Value = item.Code;
                    dgvSEquip.Rows[i].Cells["sequip_name"].Value = item.Name;
                    dgvSEquip.Rows[i].Cells["sequip_comment"].Value = item.Comment;
                    i++;
                }
            }
        }



        private void btnSelect_Equip_Click(object sender, EventArgs e)
        {
            if (dgvSEquip.SelectedCells.Count > 0)
            {
                string equipCode;
                int rowIndex = dgvSEquip.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvSEquip.Rows[rowIndex];
                equipCode = selectedRow.Cells["sequip_code"].Value.ToString().Trim();

                if (equipCode == null) return;

                DialogResult result = MessageBox.Show($"선택된 설비({equipCode})을 등록하시겠습니까?", "확인", MessageBoxButtons.YesNo);



                if (result == DialogResult.Yes)
                {
                    EquipCodeSelected?.Invoke(this, equipCode);

                    // 현재 폼을 닫을 수도 있습니다 (선택 사항).
                    this.Close();
                }
                else return;
            }
        }
    }
}
