using _3rd_TEAM_PROJECT.InterFace;
using _3rd_TEAM_PROJECT.Repositorys;
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

namespace _3rd_TEAM_PROJECT
{
    public partial class S_Item : Form
    {
        private IItemRepository itemRepository;
        public event EventHandler<string> ItemCodeSelected;
        //ItemCodeSelected
        public S_Item()
        {
            InitializeComponent();
            itemRepository = Program.itemRepository;
        }

        private void S_Item_Load(object sender, EventArgs e)
        {
            LoadItem();
        }

        private async void LoadItem()//품번 목록
        {
            var items = await itemRepository.GetAllAsync();

            dgvSItem.Rows.Clear();
            dgvSItem.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvSItem.Rows.Add();
                dgvSItem.Rows[i].Cells["sitem_id"].Value = item.Id;
                dgvSItem.Rows[i].Cells["sitem_code"].Value = item.Code;
                dgvSItem.Rows[i].Cells["sitem_name"].Value = item.Name;
                dgvSItem.Rows[i].Cells["sitem_type"].Value = item.Type;
                i++;
            }
        }



        private async void txtSItem_KeyPress(object sender, KeyPressEventArgs e)//품번검색
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var items = await itemRepository.GetAllAsync();
                string search = txtSItem.Text.Trim();
                /*품번
                품명
                TYPE*/
                if (cbbSItem_filter.Text.Trim() == "품번") items = await itemRepository.CodeAsync(search);
                else if (cbbSItem_filter.Text.Trim() == "품명") items = await itemRepository.NameAsync(search);
                else if (cbbSItem_filter.Text.Trim() == "TYPE") items = await itemRepository.TypeAsync(search);
                dgvSItem.Rows.Clear();
                dgvSItem.Refresh();

                int i = 0;
                foreach (var item in items)
                {
                    dgvSItem.Rows.Add();
                    dgvSItem.Rows[i].Cells["sitem_id"].Value = item.Id;
                    dgvSItem.Rows[i].Cells["sitem_code"].Value = item.Code;
                    dgvSItem.Rows[i].Cells["sitem_name"].Value = item.Name;
                    dgvSItem.Rows[i].Cells["sitem_type"].Value = item.Type;
                    i++;
                }
            }

        }

        private async void pbItem_Click(object sender, EventArgs e)//품번검색
        {
            var items = await itemRepository.GetAllAsync();
            string search = txtSItem.Text.Trim();
            /*품번
            품명
            TYPE*/
            if (cbbSItem_filter.Text.Trim() == "품번") items = await itemRepository.CodeAsync(search);
            else if (cbbSItem_filter.Text.Trim() == "품명") items = await itemRepository.NameAsync(search);
            else if (cbbSItem_filter.Text.Trim() == "TYPE") items = await itemRepository.TypeAsync(search);
            dgvSItem.Rows.Clear();
            dgvSItem.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvSItem.Rows.Add();
                dgvSItem.Rows[i].Cells["sitem_id"].Value = item.Id;
                dgvSItem.Rows[i].Cells["sitem_code"].Value = item.Code;
                dgvSItem.Rows[i].Cells["sitem_name"].Value = item.Name;
                dgvSItem.Rows[i].Cells["sitem_type"].Value = item.Type;
                i++;
            }
        }

        private void btnSelect_Item_Click(object sender, EventArgs e)//품번등록
        {
            if (dgvSItem.SelectedCells.Count > 0)
            {
                string itemCode;
                int rowIndex = dgvSItem.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvSItem.Rows[rowIndex];
                itemCode = selectedRow.Cells["sitem_code"].Value.ToString().Trim();

                if (itemCode == null) return;

                DialogResult result = MessageBox.Show($"선택된 품번({itemCode})을 등록하시겠습니까?", "확인", MessageBoxButtons.YesNo);



                if (result == DialogResult.Yes)
                {
                    ItemCodeSelected?.Invoke(this, itemCode);

                    // 현재 폼을 닫을 수도 있습니다 (선택 사항).
                    this.Close();
                }
                else return;
            }

        }
    }
}
