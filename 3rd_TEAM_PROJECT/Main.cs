using _3rd_TEAM_PROJECT.Models.Acount;
using _3rd_TEAM_PROJECT.Models.Process;
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

        //로그인한 계정을 구별
        public Acount LoggedInAcount { get; set; }
        public Login LoginForm { get; set; }

        public Main()
        {
            InitializeComponent();
            factoryRepository = Program.factoryRepository;
            warehouseRepository = Program.warehouseRepository;
            inboundRepository = Program.inboundRepository;
            outboundRepository = Program.outboundRepository;
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
            //화면 닫을 때 확인메시지 출력
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //계정에 따라 보여지는 탭을 구별한다
            //DepartmentCode에 따라 구분한다

            //계정 사용 원할 경우 아래 주석을 해제하고, Programs.cs파일의 주석을 해제하면된다.
            //if (SessionManager.Instance.LoggedInAcount.Department.DepartmentCode != "001")
            //{
            //    //TabMenu.TabPages[0].Parent = null;  // 첫 번째 탭을 숨깁니다.
            //}

            LoadWarehouse();
        }
        //로그아웃 메뉴 클릭 시
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
                    break;
                case 3:
                    //출고
                    break;
                case 4:
                    //출고 검색
                    break;
                case 5:
                    LoadFactory();
                    break;
                case 6:
                    break;

            }
        }
        //---------------------------구매라인-----------------------------------------//
        //창고
        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ensure that the clicked cell is valid
            if (e.RowIndex >= 0)
            {
                // Get the clicked row
                DataGridViewRow row = this.dgvWarehouse.Rows[e.RowIndex];

                // Assign the row data to the TextBoxes
                txWareId.Text = row.Cells["warehouse_id"].Value?.ToString();
                txWareProduct.Text = row.Cells["warehouse_product"].Value?.ToString();
                txWareItem.Text = row.Cells["warehouse_item"].Value?.ToString();
                txWareAmount.Text = row.Cells["warehouse_amount"].Value?.ToString();
            }
        }
        private async void LoadWarehouse()
        {
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
        #region 입고
        //입고
        private void dgvInbound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the clicked row
            DataGridViewRow row = this.dgvInbound.Rows[e.RowIndex];

            // Assign the row data to the TextBoxes
            //txWareId.Text = row.Cells["warehouse_id"].Value?.ToString();
            txtInboundId.Text = row.Cells["inbound_id"].Value?.ToString();
            txtInboundProduct.Text = row.Cells["inbound_product"].Value?.ToString();
            txtInboundItem.Text = row.Cells["inbound_item"].Value?.ToString();
            txtInboundVender.Text = row.Cells["inbound_vender"].Value?.ToString();
            txtInboundAmount.Text = row.Cells["inbound_amount"].Value?.ToString();
            txtInboundContact.Text = row.Cells["inbound_contact"].Value?.ToString();
            txtInboundRegdate.Text = row.Cells["inbound_regdate"].Value?.ToString();
        }

        //입고 내역 추가
        private async void btnInAdd_Click(object sender, EventArgs e)
        {
            // 값이 비어있지 않은지 확인
            if (string.IsNullOrWhiteSpace(txtInboundProduct.Text) ||
               string.IsNullOrWhiteSpace(txtInboundItem.Text) ||
               string.IsNullOrWhiteSpace(txtInboundVender.Text) ||
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
                Vendor = txtInboundVender.Text,
                Amount = amount,
                Contact = SessionManager.Instance.LoggedInAcount.Name,
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
                    Vendor = selectedRow.Cells["inbound_vender"].Value?.ToString(),
                    Amount = Convert.ToInt32(selectedRow.Cells["inbound_amount"].Value),
                    Contact = selectedRow.Cells["inbound_contact"].Value?.ToString(),
                };

                var updated = new InBound
                {
                    Id = Convert.ToInt64(txtInboundId.Text),
                    Product = txtInboundProduct.Text,
                    Item = txtInboundItem.Text,
                    Vendor = txtInboundVender.Text,
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
                int rowIndex = dgvInboundSearch.Rows.Add();
                DataGridViewRow row = dgvInboundSearch.Rows[rowIndex];

                row.Cells["inbound_id"].Value = item.Id;
                row.Cells["inbound_product"].Value = item.Product;
                row.Cells["inbound_item"].Value = item.Item;
                row.Cells["inbound_vender"].Value = item.Vendor;
                row.Cells["inbound_amount"].Value = item.Amount;
                row.Cells["inbound_contact"].Value = item.Contact;
                row.Cells["inbound_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
            }

        }

        //입고 검색
        private void dgvInboundSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
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
        //출고
        //내역 TextBox에 출력
        private void dgvOutBound_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Get the clicked row
            DataGridViewRow row = this.dgvOutBound.Rows[e.RowIndex];

            // Assign the row data to the TextBoxes
            //txWareId.Text = row.Cells["warehouse_id"].Value?.ToString();
            txtOutBoundId.Text = row.Cells["outbound_id"].Value?.ToString();
            txtOutBoundProduct.Text = row.Cells["outbound_product"].Value?.ToString();
            txtOutBoundItem.Text = row.Cells["outbound_item"].Value?.ToString();
            txtOutBoundAmount.Text = row.Cells["outbound_amount"].Value?.ToString();
            txtOutBoundMProcess.Text = row.Cells["outbound_vendor"].Value?.ToString();
            txtOutBoundContact.Text = row.Cells["outbound_contact"].Value?.ToString();
            txtOutBoundRegdate.Text = row.Cells["outbound_regdate"].Value?.ToString();
        }
        //내역 추가
        private async void btnOutBoundAdd_Click(object sender, EventArgs e)
        {
            // 값이 비어있지 않은지 확인
            if (string.IsNullOrWhiteSpace(txtOutBoundProduct.Text) ||
               string.IsNullOrWhiteSpace(txtOutBoundItem.Text) ||
               string.IsNullOrWhiteSpace(txtOutBoundMProcess.Text) ||
               string.IsNullOrWhiteSpace(txtOutBoundAmount.Text))
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

            var outbound = new OutBound
            {
                Product = txtOutBoundProduct.Text,
                Item = txtOutBoundItem.Text,
                Amount = amount,
                MProcessCode = txtOutBoundMProcess.Text,
                Contact = SessionManager.Instance.LoggedInAcount.Name,
                RegDate = DateTime.Now,
            };

            try
            {
                var result = await outboundRepository.ReleaseAsync(outbound);
                MessageBox.Show("성공적으로 출고되었습니다.");
                LoadOutbound();
            }
            catch (Exception ex)
            {
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
                    Id = Convert.ToInt64(txtOutBoundId.Text),
                    Product = txtOutBoundProduct.Text,
                    Item = txtOutBoundItem.Text,
                    Amount = Convert.ToInt32(txtOutBoundAmount.Text),
                    MProcessCode = txtOutBoundMProcess.Text,
                    Contact = txtOutBoundContact.Text
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
            if (items == null)
            {
                return;  //테이블에 값이 없을 경우 메소드 실행 중지
            }

            dgvInbound.Rows.Clear();
            dgvInbound.Refresh();

            foreach (var item in items)
            {
                int rowIndex = dgvInboundSearch.Rows.Add();
                DataGridViewRow row = dgvInboundSearch.Rows[rowIndex];

                row.Cells["outbound_id"].Value = item.Id;
                row.Cells["outbound_product"].Value = item.Product;
                row.Cells["outbound_item"].Value = item.Item;
                row.Cells["outbound_mprocess"].Value = item.MProcessCode;
                row.Cells["outbound_amount"].Value = item.Amount;
                row.Cells["outbound_contact"].Value = item.Contact;
                row.Cells["outbound_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
            }
        }
        #endregion
        //---------------------------공장목록-----------------------------------------//
        private async void LoadFactory()
        {
            var items = await factoryRepository.GetAllAsync();

            if (items == null)
            {
                return;  //테이블에 값이 없을 경우 메소드 실행 중지
            }
            //DataGridView Clear
            dgvFactory.Rows.Clear();
            dgvFactory.Refresh();


            int i = 0;
            foreach (var item in items)
            {
                dgvFactory.Rows.Add();
                dgvFactory.Rows[i].Cells["fac_id"].Value = item.Id;
                dgvFactory.Rows[i].Cells["fac_code"].Value = item.Code;
                dgvFactory.Rows[i].Cells["fac_name"].Value = item.Name;
                dgvFactory.Rows[i].Cells["fac_const"].Value = item.Constructor;
                dgvFactory.Rows[i].Cells["fac_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvFactory.Rows[i].Cells["fac_modifier"].Value = item.Modifier;
                dgvFactory.Rows[i].Cells["fac_update"].Value = item.ModDate?.ToString("yyyy-MM-dd");

                i++;
            }

        }
        //--공장 생성 버튼
        private async void btnCFactory_Click(object sender, EventArgs e)
        {
            Factory? factory;
            var items = await factoryRepository.GetAllAsync();

            string code = txtfacCode.Text.Trim();
            string name = txtfacName.Text.Trim();
            string constructor = txtfacConst.Text.Trim();

            foreach (var item in items)
            {
                if (item.Code == code)
                {
                    MessageBox.Show("이미 존재한 공장 코드입니다.");
                    return;
                }
            }

            if (code.Length == 0)
            {
                MessageBox.Show("공장코드를 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("공장이름을 입력하세요.");
                return;
            }
            else if (constructor.Length == 0)
            {
                MessageBox.Show("생성자를 입력하세요.");
                return;
            }
            else
            {
                factory = new()
                {
                    Code = code,
                    Name = name,
                    Constructor = constructor,
                    RegDate = DateTime.Now
                };
                factory = await factoryRepository.AddAsync(factory);
                MessageBox.Show("생성완료");
                LoadFactory();
                return;
            }

        }
        //---공장 삭제--
        private async void dgvFactory_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
        }
        private async void dgvFactory_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (dgvFactory.Rows[e.Row.Index].Cells["fac_id"].Value == null) return;
            int id = (int)dgvFactory.Rows[e.Row.Index].Cells["fac_id"].Value;
            await factoryRepository.DeleteAsync(id);
        }

        private async void btnDFactory_Click(object sender, EventArgs e)
        {
            if (dgvFactory.SelectedCells.Count > 0)
            {
                int rowIndex = dgvFactory.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvFactory.Rows[rowIndex];
                if (selectedRow.Cells["fac_id"].Value == null) return;

                DialogResult result = MessageBox.Show($"선택된 공장({selectedRow.Cells["fac_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int id = (int)selectedRow.Cells["fac_id"].Value;
                    await factoryRepository.DeleteAsync(id);
                    MessageBox.Show("삭제완료.");
                    LoadFactory();
                }
                else return;
            }
        }
    }
}
