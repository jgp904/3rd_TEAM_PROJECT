using _3rd_TEAM_PROJECT.Models.Account;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT.Models.WareHouse;
using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore.Internal;
using System.Windows.Forms;

namespace _3rd_TEAM_PROJECT
{
    public partial class Main : Form
    {
        private IFactoryRepository factoryRepository;
        private IWarehouseRepository warehouseRepository;
        private IInboundRepository inboundRepository;
        private IOutboundRepository outboundRepository;
        private IEquipmentRepository equipmentRepository;

        //로그인한 계정을 구별
        public Account LoggedInAccount { get; set; }
        public Login LoginForm { get; set; }

        //----------Login정보 받기-----------------//
        public string userName = "이욕학"; // SessionManger에서 Acount정보 받기

        public Main()
        {
            InitializeComponent();
            factoryRepository = Program.factoryRepository;
            warehouseRepository = Program.warehouseRepository;
            inboundRepository = Program.inboundRepository;
            outboundRepository = Program.outboundRepository;
            equipmentRepository = Program.equipmentRepository;
        }

        //TabControl 디자인 설정
        private void TabMenu_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region Tab 설정
            Graphics g = e.Graphics;
            TabPage tabPage = TabMenu.TabPages[e.Index];
            Rectangle tabBounds = TabMenu.GetTabRect(e.Index);

            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Near;
            stringFlags.LineAlignment = StringAlignment.Center;

            // 선택된 탭의 전경색을 결정합니다.
            Brush textBrush;
            Brush bgBrush;

            if (TabMenu.SelectedIndex == e.Index)
            {
                // 선택된 탭의 텍스트는 검정색이고 배경은 회색입니다.
                textBrush = new SolidBrush(Color.Black);
                bgBrush = new SolidBrush(Color.Gray);
            }
            else
            {
                // 그렇지 않으면, 기존 색상을 사용합니다.
                textBrush = new SolidBrush(tabPage.ForeColor);
                bgBrush = new SolidBrush(tabPage.BackColor);
            }

            // 배경을 채웁니다.
            g.FillRectangle(bgBrush, tabBounds);

            // 탭 텍스트를 그립니다.
            g.DrawString(tabPage.Text, this.Font, textBrush, tabBounds, new StringFormat(stringFlags));

            // 메모리 누수를 피하기 위해 브러시를 처리합니다.
            textBrush.Dispose();
            bgBrush.Dispose();
            #endregion
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadWarehouse();
        }
        //로그아웃
        private void LogoutMenu_Click(object sender, EventArgs e)
        {
            // 로그아웃 처리
            SessionManager.Instance.Logout();

            // 현재 메인 폼을 숨깁니다.
            this.Hide();

            // 저장된 로그인 폼 인스턴스를 다시 표시합니다.
            SessionManager.Instance.LoginForm.Show();
        }
        //------------------------TabControll Selected-------------------------------//
        private void TabMenu_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    //창고
                    LoadWarehouse();
                    break;
                case 1:
                    //재고
                    LoadInbound();
                    break;
                case 2:
                    //재고 검색
                    txtInboundSearch.Clear();
                    break;
                case 3:
                    LoadOutbound();
                    break;
                case 4:
                    //출고 검색
                    txtOutboundSearch.Clear();
                    break;
            }
        }
        #region 창고
        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            // Ensure that the clicked cell is valid
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow row = this.dgvWarehouse.Rows[e.RowIndex];

                // Assign the row data to the TextBoxes
                txtWareId.Text = row.Cells["warehouse_id"].Value?.ToString();
                txtWareProduct.Text = row.Cells["warehouse_product"].Value?.ToString();
                txtWareItem.Text = row.Cells["warehouse_item"].Value?.ToString();
                txtWareAmount.Text = row.Cells["warehouse_amount"].Value?.ToString();
            }
        }
        private async void LoadWarehouse()
        {
            txtWarehouseSearch.Clear();

            //GetAllAsync();
            var items = await warehouseRepository.GetAllAsync();

            if (items == null)
            {
                return;  //테이블에 값이 없을 경우 메소드 실행 중지
            }
            dgvWarehouse.Rows.Clear();
            dgvWarehouse.Refresh();
            int i = 0;
            foreach (var item in items)
            {
                //id, name, item, amount
                dgvWarehouse.Rows.Add();
                dgvWarehouse.Rows[i].Cells["warehouse_id"].Value = item.Id;
                dgvWarehouse.Rows[i].Cells["warehouse_product"].Value = item.Product;
                dgvWarehouse.Rows[i].Cells["warehouse_item"].Value = item.Item;
                dgvWarehouse.Rows[i].Cells["warehouse_amount"].Value = item.Amount;
                i++;
            }

        }

        private async void txtWarehouseSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string searchText = txtWarehouseSearch.Text;

                try
                {
                    var results = await warehouseRepository.GetProductAsync(searchText);

                    // 데이터 그리드 뷰를 비웁니다.
                    dgvWarehouse.Rows.Clear();

                    foreach (var result in results)
                    {
                        int rowIndex = dgvWarehouse.Rows.Add();
                        DataGridViewRow row = dgvWarehouse.Rows[rowIndex];

                        // 결과를 행에 넣습니다.
                        row.Cells["warehouse_id"].Value = result.Id.ToString();
                        row.Cells["warehouse_product"].Value = result.Product;
                        row.Cells["warehouse_item"].Value = result.Item;
                        row.Cells["warehouse_amount"].Value = result.Amount.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"검색 중 오류 발생: {ex.Message}");
                }
            }
        }
        #endregion

        #region 입고
        //입고
        private void dgvInbound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow row = this.dgvInbound.Rows[e.RowIndex];

                // Assign the row data to the TextBoxes
                //txWareId.Text = row.Cells["warehouse_id"].Value?.ToString();
                txtInboundId.Text = row.Cells["inbound_id"].Value?.ToString();
                txtInboundProduct.Text = row.Cells["inbound_product"].Value?.ToString();
                txtInboundItem.Text = row.Cells["inbound_item"].Value?.ToString();
                txtInboundVendor.Text = row.Cells["inbound_vendor"].Value?.ToString();
                txtInboundAmount.Text = row.Cells["inbound_amount"].Value?.ToString();
                txtInboundContact.Text = row.Cells["inbound_contact"].Value?.ToString();
                txtInboundRegdate.Text = row.Cells["inbound_regdate"].Value?.ToString();
            }
        }

        //입고 내역 추가
        private async void btnInAdd_Click(object sender, EventArgs e)
        {
            // 값이 비어있지 않은지 확인
            if (string.IsNullOrWhiteSpace(txtInboundProduct.Text) ||
               string.IsNullOrWhiteSpace(txtInboundItem.Text) ||
               string.IsNullOrWhiteSpace(txtInboundVendor.Text) ||
               string.IsNullOrWhiteSpace(txtInboundAmount.Text))
            {
                MessageBox.Show("입력에 필요한 필드를 모두 입력해주세요.");
                return;
            }

            // 수량이 숫자인지 확인
            if (!int.TryParse(txtInboundAmount.Text, out int amount))
            {
                MessageBox.Show("수량은 숫자만 입력 가능합니다.");
                return;
            }

            var inbound = new InBound
            {
                Product = txtInboundProduct.Text,
                Item = txtInboundItem.Text,
                Vendor = txtInboundVendor.Text,
                Amount = amount,
                Contact = SessionManager.Instance.LoggedInAccount.Name,
                RegDate = DateTime.Now,
            };

            try
            {
                var result = await inboundRepository.AddAsync(inbound);
                MessageBox.Show("데이터가 성공적으로 추가되었습니다.");
                LoadInbound();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"데이터 추가 중 오류 발생: {ex.Message}");
            }
        }

        //입고 내역 수정
        private async void btnInUpdate_Click(object sender, EventArgs e)
        {
            if (dgvInbound.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvInbound.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvInbound.Rows[selectedrowindex];

                var original = new InBound
                {
                    Id = Convert.ToInt64(selectedRow.Cells["inbound_id"].Value),
                    Product = selectedRow.Cells["inbound_product"].Value?.ToString(),
                    Item = selectedRow.Cells["inbound_item"].Value?.ToString(),
                    Vendor = selectedRow.Cells["inbound_vendor"].Value?.ToString(),
                    Amount = Convert.ToInt32(selectedRow.Cells["inbound_amount"].Value),
                    Contact = selectedRow.Cells["inbound_contact"].Value?.ToString(),
                };

                var updated = new InBound
                {
                    Id = Convert.ToInt64(txtInboundId.Text),
                    Product = txtInboundProduct.Text,
                    Item = txtInboundItem.Text,
                    Vendor = txtInboundVendor.Text,
                    Amount = Convert.ToInt32(txtInboundAmount.Text),
                    Contact = txtInboundContact.Text
                };

                var result = await inboundRepository.UpdateAsync(original, updated);

                if (result != null)
                {
                    // 업데이트 성공
                    LoadInbound();
                }
                else
                {
                    // 업데이트 실패
                    MessageBox.Show("오류를 검토하세요");
                }
            }
        }

        //입고 내역 불러오기
        private async void LoadInbound()
        {
            var items = await inboundRepository.GetAllAsync();
            if (items == null)
            {
                return;  //테이블에 값이 없을 경우 메소드 실행 중지
            }

            dgvInbound.Rows.Clear();
            dgvInbound.Refresh();

            foreach (var item in items)
            {
                int rowIndex = dgvInbound.Rows.Add();
                DataGridViewRow row = dgvInbound.Rows[rowIndex];

                row.Cells["inbound_id"].Value = item.Id;
                row.Cells["inbound_product"].Value = item.Product;
                row.Cells["inbound_item"].Value = item.Item;
                row.Cells["inbound_vendor"].Value = item.Vendor;
                row.Cells["inbound_amount"].Value = item.Amount;
                row.Cells["inbound_contact"].Value = item.Contact;
                row.Cells["inbound_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
            }

        }

        //입고 검색
        private void dgvInboundSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvInboundSearch.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().All(c => c.Value != null))
            {
                // DataGridView에서 선택한 행을 가져옵니다.
                var row = this.dgvInboundSearch.Rows[e.RowIndex];

                // 그리드 뷰의 각 셀에 대한 내용을 해당 텍스트 박스에 표시합니다.
                txtInSearchId.Text = row.Cells["insearch_id"].Value.ToString();
                txtInSearchProduct.Text = row.Cells["insearch_product"].Value.ToString();
                txtInSearchItem.Text = row.Cells["insearch_item"].Value.ToString();
                txtInSearchVendor.Text = row.Cells["insearch_Vendor"].Value.ToString();
                txtInSearchAmount.Text = row.Cells["insearch_amount"].Value.ToString();
                txtInSearchContact.Text = row.Cells["insearch_contact"].Value.ToString();
                txtInSearchRegdate.Text = row.Cells["insearch_regdate"].Value.ToString();
            }
        }


        private async void txtInboundSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string searchText = txtInboundSearch.Text;

                try
                {
                    var results = await inboundRepository.GetProductAsync(searchText);

                    // 데이터 그리드 뷰를 비웁니다.
                    dgvInboundSearch.Rows.Clear();

                    foreach (var result in results)
                    {
                        int rowIndex = dgvInboundSearch.Rows.Add();
                        DataGridViewRow row = dgvInboundSearch.Rows[rowIndex];

                        // 결과를 행에 넣습니다.
                        row.Cells["insearch_id"].Value = result.Id.ToString();
                        row.Cells["insearch_product"].Value = result.Product;
                        row.Cells["insearch_item"].Value = result.Item;
                        row.Cells["insearch_Vendor"].Value = result.Vendor;
                        row.Cells["insearch_amount"].Value = result.Amount.ToString();
                        row.Cells["insearch_contact"].Value = result.Contact;
                        row.Cells["insearch_regdate"].Value = result.RegDate.ToString("yyyy-MM-dd");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"검색 중 오류 발생: {ex.Message}");
                }
            }
        }
        #endregion

        #region 출고
        // Form 클래스 내부의 변수로 이동
        private string[] textBoxNames = new string[]{
            "txtOutboundId",
            "txtOutboundProduct",
            "txtOutboundItem",
            "txtOutboundAmount",
            "txtOutboundProcess",
            "txtOutboundContact",
            "txtOutboundRegdate"
        };
        private string[] cellNames = new string[]{
            "outbound_id",
            "outbound_product",
            "outbound_item",
            "outbound_amount",
            "outbound_process",
            "outbound_contact",
            "outbound_regdate"
        };
        private string[] searchTextBoxNames = new string[]{
            "txtOutboundSearchId",
            "txtOutboundSearchProduct",
            "txtOutboundSearchItem",
            "txtOutboundSearchAmount",
            "txtOutboundSearchProcess",
            "txtOutboundSearchContact",
            "txtOutboundSearchRegdate"
        };
        private string[] searchCellNames = new string[]{
            "outsearch_id",
            "outsearch_product",
            "outsearch_item",
            "outsearch_amount",
            "outsearch_process",
            "outsearch_contact",
            "outsearch_regdate"
        };
        // 공통 메서드 추가
        private void SetTextBoxValuesFromRow(DataGridViewRow row, string[] textBoxNames, string[] cellNames)
        {
            for (int i = 0; i < textBoxNames.Length; i++)
            {
                this.Controls[textBoxNames[i]].Text = row.Cells[cellNames[i]].Value?.ToString();
            }
        }
        private OutBound CreateOutBoundFromTextBoxes(){
            var outbound = new OutBound{
                Product = txtOutboundProduct.Text,
                Item = txtOutboundItem.Text,
                Amount = Convert.ToInt32(txtOutboundAmount.Text),
                MProcessCode = txtOutboundProcess.Text,
                Contact = txtOutboundContact.Text,
                RegDate = DateTime.Now,
            };
            return outbound;
        }
        //내역 TextBox에 출력
        private void dgvOutBound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvOutBound.Rows[e.RowIndex];
                SetTextBoxValuesFromRow(row, textBoxNames, cellNames);
            }
        }
        //내역 추가
        private async void btnOutBoundAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOutboundProduct.Text) ||
               string.IsNullOrWhiteSpace(txtOutboundItem.Text) ||
               string.IsNullOrWhiteSpace(txtOutboundProcess.Text) ||
               string.IsNullOrWhiteSpace(txtOutboundAmount.Text)){
                MessageBox.Show("입력에 필요한 필드를 모두 입력해주세요.");
                return;
            }

            if (!int.TryParse(txtOutboundAmount.Text, out int amount)){
                MessageBox.Show("수량은 숫자만 입력 가능합니다.");
                return;
            }
            var outbound = CreateOutBoundFromTextBoxes();
            try{
                var result = await outboundRepository.ReleaseAsync(outbound);
                if (result != null){
                    MessageBox.Show("성공적으로 출고되었습니다.");
                    LoadOutbound();
                }
            }
            catch (Exception ex){
                MessageBox.Show($"오류 발생: {ex.Message}");
            }
        }
        //내역 수정
        private async void btnOutBoundUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOutBound.SelectedCells.Count > 0)
            {
                int selectedrowindex = dgvOutBound.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvOutBound.Rows[selectedrowindex];

                var original = new OutBound
                {
                    Id = Convert.ToInt64(selectedRow.Cells["outbound_id"].Value),
                    Product = selectedRow.Cells["outbound_product"].Value?.ToString(),
                    Item = selectedRow.Cells["outbound_item"].Value?.ToString(),
                    Amount = Convert.ToInt32(selectedRow.Cells["outbound_amount"].Value),
                    MProcessCode = selectedRow.Cells["outbound_mprocess"].Value?.ToString(),
                    Contact = selectedRow.Cells["outbound_contact"].Value?.ToString(),
                };

                var updated = new OutBound
                {
                    Id = Convert.ToInt64(txtOutboundId.Text),
                    Product = txtOutboundProduct.Text,
                    Item = txtOutboundItem.Text,
                    Amount = Convert.ToInt32(txtOutboundAmount.Text),
                    MProcessCode = txtOutboundProcess.Text,
                    Contact = txtOutboundContact.Text
                };

                var result = await outboundRepository.UpdateAsync(original, updated);

                if (result != null)
                {
                    // 업데이트 성공
                    LoadOutbound();
                }
                else
                {
                    // 업데이트 실패
                    MessageBox.Show("오류를 검토하세요");
                }
            }
        }
        //출고 내역 불러오기
        private async void LoadOutbound()
        {
            var items = await outboundRepository.GetAllAsync();
            if (items == null) return;

            dgvOutBound.Rows.Clear();
            dgvOutBound.Refresh();

            foreach (var item in items){
                int rowIndex = dgvOutBound.Rows.Add();
                DataGridViewRow row = dgvOutBound.Rows[rowIndex];

                string[] cellValues = new string[]{
                    item.Id.ToString(),
                    item.Product,
                    item.Item,
                    item.Amount.ToString(),
                    item.MProcessCode,
                    item.Contact,
                    item.RegDate.ToString("yyyy-MM-dd")
                };

                for (int i = 0; i < cellNames.Length; i++){
                    row.Cells[cellNames[i]].Value = cellValues[i];
                }
            }
        }
        //출고 조회 Cell 클릭
        private void dgvOutboundSearch_CellClick(object sender, DataGridViewCellEventArgs e){
            if (e.RowIndex >= 0 && dgvOutboundSearch.Rows[e.RowIndex].Cells.Cast<DataGridViewCell>().All(c => c.Value != null)){
                var row = this.dgvOutboundSearch.Rows[e.RowIndex];
                SetTextBoxValuesFromRow(row, searchTextBoxNames, searchCellNames);
            }
        }
        //출고 조회
        private async void txtOutboundSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string searchText = txtOutboundSearch.Text;
                try{
                    var results = await outboundRepository.GetProductAsync(searchText);
                    // 데이터 그리드 뷰를 비웁니다.
                    dgvOutboundSearch.Rows.Clear();
                    foreach (var result in results){
                        int rowIndex = dgvOutboundSearch.Rows.Add();
                        DataGridViewRow row = dgvOutboundSearch.Rows[rowIndex];

                        string[] cellValues = new string[]
                {
                    result.Id.ToString(),
                    result.Product,
                    result.Item,
                    result.Amount.ToString(),
                    result.MProcess,
                    result.Contact,
                    result.RegDate.ToString("yyyy-MM-dd")
                };

                        // 결과를 행에 넣습니다.
                        row.Cells["outsearch_id"].Value = result.Id.ToString();
                        row.Cells["outsearch_product"].Value = result.Product;
                        row.Cells["outsearch_item"].Value = result.Item;
                        row.Cells["outsearch_amount"].Value = result.Amount.ToString();
                        row.Cells["outsearch_process"].Value = result.MProcess;
                        row.Cells["outsearch_contact"].Value = result.Contact;
                        row.Cells["outsearch_regdate"].Value = result.RegDate.ToString("yyyy-MM-dd");
                    }
                }
                catch (Exception ex){
                    MessageBox.Show($"검색 중 오류 발생: {ex.Message}");
                }
            }
        }

        private void SProcess_ProcessCodeSelected(object sender, (string processCode, string stock1, string? stock2) args)// 공정 검색
        {
            // 선택된 공정 코드
            string processCode = args.processCode;
            // 재고 정보
            txtOutboundProcess.Text = processCode;
        }

        private void txtOutboundProcess_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }

        private void pbPro_Fac_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }
        #endregion
    }
}
