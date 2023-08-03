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
    public partial class S_Process : Form
    {
        private IProcessRepository processRepository;
        public event EventHandler<(string processCode, string stock1, string stock2)> ProcessCodeSelected;
        public S_Process()
        {
            InitializeComponent();
            processRepository = Program.processRepository;
        }

        private void S_Process_Load(object sender, EventArgs e)
        {
            LoadProcess();
        }

        private async void LoadProcess()
        {
            var process = await processRepository.GetAllAsync();

            dgvSProcess.Rows.Clear();
            dgvSProcess.Refresh();

            int i = 0;
            foreach (var item in process)
            {
                dgvSProcess.Rows.Add();
                dgvSProcess.Rows[i].Cells["sprocess_id"].Value = item.Id;
                dgvSProcess.Rows[i].Cells["sprocess_code"].Value = item.Code;
                dgvSProcess.Rows[i].Cells["sprocess_name"].Value = item.Name;
                i++;
            }
        }

        private async void txtSProcess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var process = await processRepository.GetAllAsync();
                string search = txtSProcess.Text.Trim();
                /*품번
                품명
                TYPE*/
                if (cbbSProcess_filter.Text.Trim() == "공정코드") process = await processRepository.CodeAsync(search);
                else if (cbbSProcess_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);

                dgvSProcess.Rows.Clear();
                dgvSProcess.Refresh();

                int i = 0;
                foreach (var item in process)
                {
                    dgvSProcess.Rows.Add();
                    dgvSProcess.Rows[i].Cells["sprocess_id"].Value = item.Id;
                    dgvSProcess.Rows[i].Cells["sprocess_code"].Value = item.Code;
                    dgvSProcess.Rows[i].Cells["sprocess_name"].Value = item.Name;

                    i++;
                }
            }
        }

        private async void pbProcess_Click(object sender, EventArgs e)
        {
            var process = await processRepository.GetAllAsync();
            string search = txtSProcess.Text.Trim();
            /*품번
            품명
            TYPE*/
            if (cbbSProcess_filter.Text.Trim() == "고정코드") process = await processRepository.CodeAsync(search);
            else if (cbbSProcess_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);

            dgvSProcess.Rows.Clear();
            dgvSProcess.Refresh();

            int i = 0;
            foreach (var item in process)
            {
                dgvSProcess.Rows.Add();
                dgvSProcess.Rows[i].Cells["sprocess_id"].Value = item.Id;
                dgvSProcess.Rows[i].Cells["sprocess_code"].Value = item.Code;
                dgvSProcess.Rows[i].Cells["sprocess_name"].Value = item.Name;

                i++;
            }
        }

        private async void btnSelect_Process_Click(object sender, EventArgs e)
        {
            if (dgvSProcess.SelectedCells.Count > 0)
            {
                string processCode;
               
                int rowIndex = dgvSProcess.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvSProcess.Rows[rowIndex];
                processCode = selectedRow.Cells["sprocess_code"].Value.ToString().Trim();
                var process = await processRepository.CodeAsync(processCode);
                string stock1 = "";
                string stock2 = "";
                foreach(var item in process) 
                {
                    stock1 = item.StockUnit1;
                    stock2 = item.StockUnit2;
                }
                if (processCode == null) return;

                DialogResult result = MessageBox.Show($"선택된 공정({processCode})을 등록하시겠습니까?", "확인", MessageBoxButtons.YesNo);



                if (result == DialogResult.Yes)
                {
                    ProcessCodeSelected?.Invoke(this, (processCode, stock1, stock2));

                    // 현재 폼을 닫을 수도 있습니다 (선택 사항).
                    this.Close();
                }
                else return;
            }

        }
    }
}
