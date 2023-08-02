

using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _3rd_TEAM_PROJECT
{
    public partial class ProcessForm : Form
    {
        private IFactoryRepository factoryRepository;
        private IEquipmentRepository equipmentRepository;
        private IProcessRepository processRepository;
        private IItemRepository itemRepository;
        private ILotRepository lotRepository;


        public string SEquip { get; set; }
        //----------Login정보 받기-----------------//
        public string userName = "박재걸"; // SessionManger에서 Acount정보 받기

        public ProcessForm()
        {
            InitializeComponent();
            factoryRepository = Program.factoryRepository;
            equipmentRepository = Program.equipmentRepository;
            processRepository = Program.processRepository;
            itemRepository = Program.itemRepository;
            lotRepository = Program.lotRepository;
        }
        private void ProcessForm_Load(object sender, EventArgs e)
        {
            LoadFactory();
        }
        //TabControl 디자인 설정

        private void tabProcess_DrawItem(object sender, DrawItemEventArgs e)
        {
            #region Tab 설정
            Graphics g = e.Graphics;
            TabPage tabPage = tabProcess.TabPages[e.Index];
            Rectangle tabBounds = tabProcess.GetTabRect(e.Index);

            StringFormat stringFlags = new StringFormat();
            stringFlags.Alignment = StringAlignment.Near;
            stringFlags.LineAlignment = StringAlignment.Center;

            // 선택된 탭의 전경색을 결정합니다.
            Brush textBrush;
            Brush bgBrush;

            if (tabProcess.SelectedIndex == e.Index)
            {
                // 선택된 탭의 텍스트는 검정색이고 배경은 회색입니다.
                textBrush = new SolidBrush(Color.Black);
                bgBrush = new SolidBrush(Color.LightGray);
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
        private void tabProcess_Selected(object sender, TabControlEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    LoadFactory();//공장설정 
                    break;
                case 1:
                    LoadEquip();//설비설정
                    break;
                case 2:
                    LoadEquipHis();//설비 이력조회
                    break;
                case 3:
                    LoadProcess();//공정 설정
                    break;
                case 4:
                    LoadItem();//품번 설정
                    break;
                case 5:
                    LoadLot();//Lot 설정
                    break;
                case 6:
                    LoadLotHis();//Lot 이력조회
                    break;
                case 7:
                    LoadLotProcess();//Lot 작업 시작종료
                    break;

            }
        }



        // -----------------------------------------------------------------공장-----------------------------------------------------------------------------------------------------//
        #region 공장설정
        //공장목록
        private async void LoadFactory()
        {
            txtfac_Const.Text = userName;

            var factories = await factoryRepository.GetAllAsync();

            dgvfac.Rows.Clear();
            dgvfac.Refresh();
            int i = 0;
            foreach (var fact in factories)
            {
                dgvfac.Rows.Add();
                dgvfac.Rows[i].Cells["fac_id"].Value = fact.Id;
                dgvfac.Rows[i].Cells["fac_code"].Value = fact.Code;
                dgvfac.Rows[i].Cells["fac_name"].Value = fact.Name;
                dgvfac.Rows[i].Cells["fac_const"].Value = fact.Constructor;
                dgvfac.Rows[i].Cells["fac_regdate"].Value = fact.RegDate.ToString("yyyy-MM-dd");
                dgvfac.Rows[i].Cells["fac_modi"].Value = fact.Modifier;
                dgvfac.Rows[i].Cells["fac_moddate"].Value = fact.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }


        // -------공장 상세설명---------//
        private void dgvfac_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbfacId.Text = selectedRow.Cells["fac_id"].Value.ToString();
                    txtfac_Code.Text = selectedRow.Cells["fac_code"].Value.ToString();
                    txtfac_Name.Text = selectedRow.Cells["fac_name"].Value.ToString();
                    txtfac_Const.Text = selectedRow.Cells["fac_const"].Value.ToString();
                    txtfac_Regdate.Text = selectedRow.Cells["fac_regdate"].Value.ToString();
                    if (selectedRow.Cells["fac_modi"].Value != null) txtfac_Modi.Text = selectedRow.Cells["fac_modi"].Value.ToString();
                    else txtfac_Modi.Text = "";
                    if (selectedRow.Cells["fac_moddate"].Value != null) txtfac_Moddate.Text = selectedRow.Cells["fac_moddate"].Value.ToString();
                    else txtfac_Moddate.Text = "";
                }
            }
        }
        // -------공장 생성---------//
        private async void btnCFactory_Click(object sender, EventArgs e)
        {
            Factory? factory;
            var items = await factoryRepository.GetAllAsync();

            string code = txtfac_Code.Text.Trim();
            string name = txtfac_Name.Text.Trim();
            string constructor = txtfac_Const.Text.Trim();

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
                    Constructor = userName,
                    RegDate = DateTime.Now
                };
                factory = await factoryRepository.AddAsync(factory);
                MessageBox.Show("생성완료");
                LoadFactory();
                return;
            }
        }
        // -------공장 수정---------//
        private async void btnUFactory_Click(object sender, EventArgs e)
        {
            Factory? factory;

            string code = txtfac_Code.Text.Trim();
            string name = txtfac_Name.Text.Trim();

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
            else
            {
                factory = new()
                {
                    Id = int.Parse(lbfacId.Text.Trim()),
                    Code = code,
                    Name = name,
                    Modifier = userName,
                    ModDate = DateTime.Now
                };
                factory = await factoryRepository.UpdateAsync(factory);
                MessageBox.Show("수정완료");
                LoadFactory();
                return;
            }
        }
        // -------공장 삭제---------//
        private async void btnDFactory_Click(object sender, EventArgs e)
        {
            if (dgvfac.SelectedCells.Count > 0)
            {
                int rowIndex = dgvfac.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvfac.Rows[rowIndex];
                if (selectedRow.Cells["fac_id"].Value == null) return;

                DialogResult result = MessageBox.Show($"선택된 공장({selectedRow.Cells["fac_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    int id = (int)selectedRow.Cells["fac_id"].Value;
                    await factoryRepository.DeleteAsync(id);

                    LoadFactory();
                }
                else return;
            }
        }
        //---------공장검색----------//
        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            var items = await factoryRepository.GetAllAsync();
            string search = txtfacSearch.Text.Trim();
            if (cbbFilter.Text.Trim() == "공장코드") items = await factoryRepository.CodeAsync(search);
            else if (cbbFilter.Text.Trim() == "공장명") items = await factoryRepository.NameAsync(search);
            else if (cbbFilter.Text.Trim() == "생성자") items = await factoryRepository.ConstAsync(search);
            else if (cbbFilter.Text.Trim() == "수정자") items = await factoryRepository.ModiAsync(search);

            dgvfac.Rows.Clear();
            dgvfac.Refresh();
            int i = 0;
            foreach (var item in items)
            {
                dgvfac.Rows.Add();
                dgvfac.Rows[i].Cells["fac_id"].Value = item.Id;
                dgvfac.Rows[i].Cells["fac_code"].Value = item.Code;
                dgvfac.Rows[i].Cells["fac_name"].Value = item.Name;
                dgvfac.Rows[i].Cells["fac_const"].Value = item.Constructor;
                dgvfac.Rows[i].Cells["fac_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvfac.Rows[i].Cells["fac_modi"].Value = item.Modifier;
                dgvfac.Rows[i].Cells["fac_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");

                i++;
            }
        }
        //--엔터검색--//
        private async void txtfacSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var items = await factoryRepository.GetAllAsync();
                string search = txtfacSearch.Text.Trim();
                if (cbbFilter.Text.Trim() == "공장코드") items = await factoryRepository.CodeAsync(search);
                else if (cbbFilter.Text.Trim() == "공장명") items = await factoryRepository.NameAsync(search);
                else if (cbbFilter.Text.Trim() == "생성자") items = await factoryRepository.ConstAsync(search);
                else if (cbbFilter.Text.Trim() == "수정자") items = await factoryRepository.ModiAsync(search);

                dgvfac.Rows.Clear();
                dgvfac.Refresh();
                int i = 0;
                foreach (var item in items)
                {
                    dgvfac.Rows.Add();
                    dgvfac.Rows[i].Cells["fac_id"].Value = item.Id;
                    dgvfac.Rows[i].Cells["fac_code"].Value = item.Code;
                    dgvfac.Rows[i].Cells["fac_name"].Value = item.Name;
                    dgvfac.Rows[i].Cells["fac_const"].Value = item.Constructor;
                    dgvfac.Rows[i].Cells["fac_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                    dgvfac.Rows[i].Cells["fac_modi"].Value = item.Modifier;
                    dgvfac.Rows[i].Cells["fac_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");

                    i++;
                }

            }
        }
        #endregion
        //------------------------------------------------------------------설비------------------------------------------------------------------------------------------------------//
        #region 설비설정      

        private async void LoadEquip()//--설비목록--
        {
            txtEquip_Const.Text = userName;
            var equip = await equipmentRepository.GetAllAsync();

            dgvEquip.Rows.Clear();
            dgvEquip.Refresh();

            int i = 0;
            foreach (var item in equip)
            {
                dgvEquip.Rows.Add();
                dgvEquip.Rows[i].Cells["equip_id"].Value = item.Id;
                dgvEquip.Rows[i].Cells["equip_processcode"].Value = item.ProcessCode;//공정추가 완
                dgvEquip.Rows[i].Cells["equip_code"].Value = item.Code;
                dgvEquip.Rows[i].Cells["equip_name"].Value = item.Name;
                dgvEquip.Rows[i].Cells["equip_comment"].Value = item.Comment;
                dgvEquip.Rows[i].Cells["equip_status"].Value = item.Status;
                dgvEquip.Rows[i].Cells["equip_event"].Value = item.Event;
                dgvEquip.Rows[i].Cells["equip_const"].Value = item.Constructor;
                dgvEquip.Rows[i].Cells["equip_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvEquip.Rows[i].Cells["equip_modi"].Value = item.Modifier;
                dgvEquip.Rows[i].Cells["equip_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }  //--End설비목록


        private void dgvEquip_CellClick(object sender, DataGridViewCellEventArgs e)//--설비 상세---//
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbEquipId.Text = selectedRow.Cells["equip_id"].Value.ToString();
                    txtEquip_Code.Text = selectedRow.Cells["equip_code"].Value.ToString();
                    txtEquip_ProCode.Text = selectedRow.Cells["equip_processcode"].Value.ToString();

                    txtEquip_Name.Text = selectedRow.Cells["equip_name"].Value.ToString();
                    txtEquip_Comment.Text = selectedRow.Cells["equip_comment"].Value.ToString();
                    cbbEquipStatus.Text = selectedRow.Cells["equip_status"].Value.ToString();
                    cbbEquipEvent.Text = selectedRow.Cells["equip_event"].Value.ToString();

                    txtEquip_Const.Text = selectedRow.Cells["equip_const"].Value.ToString();
                    txtEquip_Regdate.Text = selectedRow.Cells["equip_regdate"].Value.ToString();
                    if (selectedRow.Cells["equip_modi"].Value != null) txtEquip_Modi.Text = selectedRow.Cells["equip_modi"].Value.ToString();
                    else txtEquip_Modi.Text = "";
                    if (selectedRow.Cells["equip_moddate"].Value != null) txtEquip_Moddate.Text = selectedRow.Cells["equip_moddate"].Value.ToString();
                    else txtEquip_Moddate.Text = "";
                }
            }

        }//end설비 상세    
        #region 공정등록

        private void SProcess_ProcessCodeSelected(object sender, (string processCode, string stock1, string? stock2) args)// 공정 검색
        {
            // 선택된 공정 코드
            string processCode = args.processCode;
            // 재고 정보
            txtLot_Stock1.Text = args.stock1;
            txtLot_Stock2.Text = args.stock2;


            // 선택된 공정 코드를 다른 폼에 표시하거나 처리할 수 있습니다.
            txtLot_ProcessCode.Text = processCode;
            txtEquip_ProCode.Text = processCode;
            txtlotEnd_NextPro.Text = processCode;
        }
        private void txtEquip_ProCode_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }

        private void pbEquipPro_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }
        #endregion
        private async void btnEquipC_Click(object sender, EventArgs e) //--설비생성--//
        {
            Equipment? equipment;
            var equips = await equipmentRepository.GetAllAsync();
            string code = txtEquip_Code.Text.Trim();
            string name = txtEquip_Name.Text.Trim();
            string processcode = txtEquip_ProCode.Text.Trim();


            foreach (var item in equips)
            {
                if (item.Code == code)
                {
                    MessageBox.Show("이미존재한 설비입니다.");
                    return;
                }

            }
            if (code.Length == 0)
            {
                MessageBox.Show("설비코드를 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("설비이름을 입력하세요.");
                return;
            }
            else if (processcode.Length == 0)
            {
                MessageBox.Show("공정을 등록하세요.");
                return;
            }
            else
            {
                equipment = new()
                {
                    ProcessCode = processcode,
                    Code = code,
                    Name = name,
                    Comment = txtEquip_Comment.Text.Trim(),
                    Status = cbbEquipStatus.Text.Trim(),
                    Event = cbbEquipEvent.Text.Trim(),
                    Constructor = userName,
                    RegDate = DateTime.Now,
                };
                equipment = await equipmentRepository.AddAsync(equipment);
                MessageBox.Show("생성완료");
                LoadEquip();
                return;
            }
        }//end설비생성

        private async void btnEquipU_Click(object sender, EventArgs e)//--설비 수정--//
        {
            Equipment? equipment;

            string code = txtEquip_Code.Text.Trim();
            string name = txtEquip_Name.Text.Trim();
            string processcode = txtEquip_ProCode.Text.Trim();

            string comment = txtEquip_Comment.Text;

            string status = cbbEquipStatus.Text.ToString().Trim();
            string e_event = cbbEquipEvent.Text.ToString().Trim();

            if (code.Length == 0)
            {
                MessageBox.Show("설비코드를 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("설비이름을 입력하세요.");
                return;
            }
            else if (processcode.Length == 0)
            {
                MessageBox.Show("공정을 등록하세요.");
                return;
            }
            else
            {

                if (e_event != "NON")
                {
                    CreateLot? createLot;
                    var lot = await lotRepository.EquipCode(code);
                    status = "Stop";
                    foreach (var item in lot)
                    {
                        createLot = new()
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Amount1 = item.Amount1,
                            Amount2 = item.Amount2,
                            StockUnit1 = item.StockUnit1,
                            StockUnit2 = item.StockUnit2,

                            ActionCode = "Stop",
                            ActionTime = DateTime.Now,
                            EquipCode = item.EquipCode,
                            ProcessCode = item.ProcessCode,
                            ItemCode = item.ItemCode,
                            ItemType = item.ItemType,



                            Modifier = userName,
                            ModDate = DateTime.Now,
                        };
                        createLot = await lotRepository.UpdateAsync(createLot);
                    }
                }
                else if (e_event == "NON")
                {
                    if (status != "Stop") status = cbbEquipStatus.Text.ToString().Trim();
                    else status = "Ready";
                    CreateLot? createLot;
                    var lot = await lotRepository.EquipCode(code);
                    foreach (var item in lot)
                    {

                        createLot = new()
                        {
                            Id = item.Id,
                            Code = item.Code,
                            Amount1 = item.Amount1,
                            Amount2 = item.Amount2,
                            StockUnit1 = item.StockUnit1,
                            StockUnit2 = item.StockUnit2,

                            ActionCode = "Run",
                            ActionTime = DateTime.Now,
                            ProcessCode = item.ProcessCode,
                            EquipCode = item.EquipCode,
                            ItemCode = item.ItemCode,
                            ItemType = item.ItemType,


                            Modifier = userName,
                            ModDate = DateTime.Now,
                        };
                        createLot = await lotRepository.UpdateAsync(createLot);
                    }

                }//-----------------------------------------
                equipment = new()
                {
                    Id = int.Parse(lbEquipId.Text.Trim()),
                    ProcessCode = processcode,
                    Code = code,
                    Name = name,
                    Comment = comment,
                    Status = status,
                    Event = e_event,

                    Modifier = userName,
                    ModDate = DateTime.Now
                };

                equipment = await equipmentRepository.UpdateAsync(equipment);
                MessageBox.Show("수정완료");
                LoadEquip();
                return;
            }
        }//end//--설비 수정--//

        private async void btnEquipD_Click(object sender, EventArgs e) //--설비 삭제--//
        {
            if (dgvEquip.SelectedCells.Count > 0)
            {
                int rowIndex = dgvEquip.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvEquip.Rows[rowIndex];
                int id = (int)selectedRow.Cells["equip_id"].Value;

                if (id == null) return;

                DialogResult result = MessageBox.Show($"선택된 설비({selectedRow.Cells["equip_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    await equipmentRepository.DeleteAsync(id);

                    LoadEquip();
                }
                else return;
            }
        }//end설비 삭제

        private async void pictureBox1_Click(object sender, EventArgs e)//----설비 검색------//
        {
            var equips = await equipmentRepository.GetAllAsync();
            string search = searchEquip.Text.Trim();

            if (cbbEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비상태") equips = await equipmentRepository.StatusAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비이벤트") equips = await equipmentRepository.EventAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "공정코트") equips = await equipmentRepository.ProcessCodeAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "생성자") equips = await equipmentRepository.ConstAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "수정자") equips = await equipmentRepository.ModiAsync(search);

            dgvEquip.Rows.Clear();
            dgvEquip.Refresh();
            int i = 0;
            foreach (var item in equips)
            {
                dgvEquip.Rows.Add();
                dgvEquip.Rows[i].Cells["equip_id"].Value = item.Id;
                dgvEquip.Rows[i].Cells["equip_processcode"].Value = item.ProcessCode;
                dgvEquip.Rows[i].Cells["equip_code"].Value = item.Code;
                dgvEquip.Rows[i].Cells["equip_name"].Value = item.Name;
                dgvEquip.Rows[i].Cells["equip_comment"].Value = item.Comment;
                dgvEquip.Rows[i].Cells["equip_status"].Value = item.Status;
                dgvEquip.Rows[i].Cells["equip_event"].Value = item.Event;
                dgvEquip.Rows[i].Cells["equip_const"].Value = item.Constructor;
                dgvEquip.Rows[i].Cells["equip_regdate"].Value = item.RegDate;
                dgvEquip.Rows[i].Cells["equip_modi"].Value = item.Modifier;
                dgvEquip.Rows[i].Cells["equip_moddate"].Value = item.ModDate;
                i++;
            }
        }//end설비 검색       
         //---엔터 설비검색---//
        private async void searchEquip_KeyPress(object sender, KeyPressEventArgs e)//---엔터 설비검색---//
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var equips = await equipmentRepository.GetAllAsync();
                string search = searchEquip.Text.Trim();

                if (cbbEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비상태") equips = await equipmentRepository.StatusAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비이벤트") equips = await equipmentRepository.EventAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "공정코트") equips = await equipmentRepository.ProcessCodeAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "생성자") equips = await equipmentRepository.ConstAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "수정자") equips = await equipmentRepository.ModiAsync(search);

                dgvEquip.Rows.Clear();
                dgvEquip.Refresh();
                int i = 0;
                foreach (var item in equips)
                {
                    dgvEquip.Rows.Add();
                    dgvEquip.Rows[i].Cells["equip_id"].Value = item.Id;
                    dgvEquip.Rows[i].Cells["equip_processcode"].Value = item.ProcessCode;
                    dgvEquip.Rows[i].Cells["equip_code"].Value = item.Code;
                    dgvEquip.Rows[i].Cells["equip_name"].Value = item.Name;
                    dgvEquip.Rows[i].Cells["equip_comment"].Value = item.Comment;
                    dgvEquip.Rows[i].Cells["equip_status"].Value = item.Status;
                    dgvEquip.Rows[i].Cells["equip_event"].Value = item.Event;
                    dgvEquip.Rows[i].Cells["equip_const"].Value = item.Constructor;
                    dgvEquip.Rows[i].Cells["equip_regdate"].Value = item.RegDate;
                    dgvEquip.Rows[i].Cells["equip_modi"].Value = item.Modifier;
                    dgvEquip.Rows[i].Cells["equip_moddate"].Value = item.ModDate;
                    i++;
                }

            }
        }//end--엔터 설비검색


        #endregion
        //-----------------------------------------------------------------설비이력--------------------------------------------------------------------------------------------------//
        #region 설비이력조회
        private async void LoadEquipHis()//이력조회
        {
            var equipHis = await equipmentRepository.GetAllHisAsync();
            dgvEquipHis.Rows.Clear();
            dgvEquipHis.Refresh();
            int i = 0;
            foreach (var item in equipHis)
            {
                dgvEquipHis.Rows.Add();
                dgvEquipHis.Rows[i].Cells["equipHis_id"].Value = item.Id;
                dgvEquipHis.Rows[i].Cells["equipHis_processcode"].Value = item.ProcessCode;//공정추가 완
                dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
                dgvEquipHis.Rows[i].Cells["equipHis_name"].Value = item.Name;
                dgvEquipHis.Rows[i].Cells["equipHis_comment"].Value = item.Comment;
                dgvEquipHis.Rows[i].Cells["equipHis_history"].Value = item.History;
                dgvEquipHis.Rows[i].Cells["equipHis_status"].Value = item.Status;
                dgvEquipHis.Rows[i].Cells["equipHis_event"].Value = item.Event;
                dgvEquipHis.Rows[i].Cells["equipHis_const"].Value = item.Constructor;
                dgvEquipHis.Rows[i].Cells["equipHis_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvEquipHis.Rows[i].Cells["equipHis_modi"].Value = item.Modifier;
                dgvEquipHis.Rows[i].Cells["equipHis_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }//end이력조회
        private void dgvEquipHis_CellClick(object sender, DataGridViewCellEventArgs e)     //---이력상세--//
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    txtEquip_ProCode.Text = selectedRow.Cells["equipHis_processcode"].Value.ToString();
                    txtEquipHis_Code.Text = selectedRow.Cells["equipHis_code"].Value.ToString();
                    txtEquipHis_ProCode.Text = selectedRow.Cells["equipHis_processcode"].Value.ToString();
                    txtEquipHis_Name.Text = selectedRow.Cells["equipHis_name"].Value.ToString();
                    txtEquipHis_Comment.Text = selectedRow.Cells["equipHis_comment"].Value.ToString();
                    txtEquipHis_Status.Text = selectedRow.Cells["equipHis_status"].Value.ToString();
                    txtEquipHis_Event.Text = selectedRow.Cells["equipHis_event"].Value.ToString();

                    txtEquipHis_Const.Text = selectedRow.Cells["equipHis_const"].Value.ToString();
                    txtEquipHis_Regdate.Text = selectedRow.Cells["equipHis_regdate"].Value.ToString();
                    if (selectedRow.Cells["equipHis_modi"].Value != null) txtEquipHis_Modi.Text = selectedRow.Cells["equipHis_modi"].Value.ToString();
                    else txtEquipHis_Modi.Text = "";
                    if (selectedRow.Cells["equipHis_moddate"].Value != null) txtEquipHis_Moddate.Text = selectedRow.Cells["equipHis_moddate"].Value.ToString();
                    else txtEquipHis_Moddate.Text = "";
                }
            }
        }//end이력상세
        private async void pictureBox2_Click(object sender, EventArgs e)//---이력 검색-----//
        {
            string search = searchEquipCode.Text.Trim();
            var equips = await equipmentRepository.HisAsync(search);
            dgvEquipHis.Rows.Clear();
            dgvEquipHis.Refresh();
            int i = 0;
            foreach (var item in equips)
            {
                dgvEquipHis.Rows.Add();
                dgvEquipHis.Rows[i].Cells["equipHis_id"].Value = item.Id;
                dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
                dgvEquipHis.Rows[i].Cells["equipHis_processcode"].Value = item.ProcessCode;
                dgvEquipHis.Rows[i].Cells["equipHis_name"].Value = item.Name;
                dgvEquipHis.Rows[i].Cells["equipHis_comment"].Value = item.Comment;
                dgvEquipHis.Rows[i].Cells["equipHis_status"].Value = item.Status;
                dgvEquipHis.Rows[i].Cells["equipHis_event"].Value = item.Event;
                dgvEquipHis.Rows[i].Cells["equipHis_const"].Value = item.Constructor;
                dgvEquipHis.Rows[i].Cells["equipHis_regdate"].Value = item.RegDate;
                dgvEquipHis.Rows[i].Cells["equipHis_modi"].Value = item.Modifier;
                dgvEquipHis.Rows[i].Cells["equipHis_moddate"].Value = item.ModDate;
                i++;
            }

        }//end이력 검색
        private async void searchEquipCode_KeyPress(object sender, KeyPressEventArgs e) //----엔터 이력조회--//
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string search = searchEquipCode.Text.Trim();
                var equips = await equipmentRepository.HisAsync(search);
                dgvEquipHis.Rows.Clear();
                dgvEquipHis.Refresh();
                int i = 0;
                foreach (var item in equips)
                {
                    dgvEquipHis.Rows.Add();
                    dgvEquipHis.Rows[i].Cells["equipHis_id"].Value = item.Id;
                    dgvEquipHis.Rows[i].Cells["equipHis_processcode"].Value = item.ProcessCode;//공정추가 완
                    dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
                    dgvEquipHis.Rows[i].Cells["equipHis_name"].Value = item.Name;
                    dgvEquipHis.Rows[i].Cells["equipHis_comment"].Value = item.Comment;
                    dgvEquipHis.Rows[i].Cells["equipHis_history"].Value = item.History;
                    dgvEquipHis.Rows[i].Cells["equipHis_status"].Value = item.Status;
                    dgvEquipHis.Rows[i].Cells["equipHis_event"].Value = item.Event;
                    dgvEquipHis.Rows[i].Cells["equipHis_const"].Value = item.Constructor;
                    dgvEquipHis.Rows[i].Cells["equipHis_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                    dgvEquipHis.Rows[i].Cells["equipHis_modi"].Value = item.Modifier;
                    dgvEquipHis.Rows[i].Cells["equipHis_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                    i++;
                }

            }
        }//end 엔터 이력조회

        private async void btnEquipHis_DeleteList_Click(object sender, EventArgs e)//삭제된설비 이력조회
        {
            string search = "Delete";
            var equips = await equipmentRepository.DeleteHis(search);
            dgvEquipHis.Rows.Clear();
            dgvEquipHis.Refresh();
            int i = 0;
            foreach (var item in equips)
            {
                dgvEquipHis.Rows.Add();
                dgvEquipHis.Rows[i].Cells["equipHis_id"].Value = item.Id;
                dgvEquipHis.Rows[i].Cells["equipHis_processcode"].Value = item.ProcessCode;//공정추가 완
                dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
                dgvEquipHis.Rows[i].Cells["equipHis_name"].Value = item.Name;
                dgvEquipHis.Rows[i].Cells["equipHis_comment"].Value = item.Comment;
                dgvEquipHis.Rows[i].Cells["equipHis_history"].Value = item.History;
                dgvEquipHis.Rows[i].Cells["equipHis_status"].Value = item.Status;
                dgvEquipHis.Rows[i].Cells["equipHis_event"].Value = item.Event;
                dgvEquipHis.Rows[i].Cells["equipHis_const"].Value = item.Constructor;
                dgvEquipHis.Rows[i].Cells["equipHis_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvEquipHis.Rows[i].Cells["equipHis_modi"].Value = item.Modifier;
                dgvEquipHis.Rows[i].Cells["equipHis_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        private async void btnEquipHis_ListDelete_Click(object sender, EventArgs e)
        {
            string equipcode = txtEquipHis_Code.Text.Trim();
            var equipHis = await equipmentRepository.HisAsync(equipcode);

            DialogResult result = MessageBox.Show($"선택된 설비({equipcode})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                foreach (var item in equipHis) { var hisDel = await equipmentRepository.DeleteHisAsync(item.Id); };
                LoadEquipHis();
            }
            else return;
        }

        private async void btnEquipHis_delete_Click(object sender, EventArgs e)
        {

            if (dgvEquipHis.SelectedCells.Count > 0)
            {
                int rowIndex = dgvEquipHis.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvEquipHis.Rows[rowIndex];
                int id = (int)selectedRow.Cells["equipHis_id"].Value;

                if (id == null) return;

                DialogResult result = MessageBox.Show($"선택된 설비({selectedRow.Cells["equipHis_code"].Value})의 이력ID{id}번을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    await equipmentRepository.DeleteHisAsync(id);

                    LoadEquipHis();
                }
                else return;
            }
        }
        #endregion
        //------------------------------------------------------------------공정------------------------------------------------------------------------------------------------------//
        #region 공정설정
        private async void LoadProcess()//공정 목록
        {
            txtProcess_Const.Text = userName;
            var process = await processRepository.GetAllAsync();

            dgvProcess.Rows.Clear();
            dgvProcess.Refresh();

            int i = 0;
            foreach (var item in process)
            {
                dgvProcess.Rows.Add();
                dgvProcess.Rows[i].Cells["process_id"].Value = item.Id;
                dgvProcess.Rows[i].Cells["process_faccode"].Value = item.FacCode;
                dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;


                dgvProcess.Rows[i].Cells["process_stock1"].Value = item.StockUnit1;
                dgvProcess.Rows[i].Cells["process_stock2"].Value = item.StockUnit2;

                dgvProcess.Rows[i].Cells["process_const"].Value = item.Constructor;
                dgvProcess.Rows[i].Cells["process_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvProcess.Rows[i].Cells["process_modi"].Value = item.Modifier;
                dgvProcess.Rows[i].Cells["process_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        #region 공장등록
        private void SFac_FacCodeSelected(object sender, string faccode)// 공정 검색
        {
            txtProcess_FacCode.Text = faccode;
        }


        private void pbPro_Fac_Click(object sender, EventArgs e)
        {
            S_Factory factory = new S_Factory();
            factory.FacCodeSelected += SFac_FacCodeSelected;
            factory.ShowDialog();
        }
        private void txtProcess_FacCode_Click(object sender, EventArgs e)
        {
            S_Factory factory = new S_Factory();
            factory.FacCodeSelected += SFac_FacCodeSelected;
            factory.ShowDialog();
        }
        #endregion

        private async void btnProcess_C_Click(object sender, EventArgs e)//공정 생성
        {
            MProcess? mprocess;
            var process = await processRepository.GetAllAsync();
            string code = txtProcess_Code.Text.Trim();
            string name = txtProcess_Name.Text.Trim();
            string factory = txtProcess_FacCode.Text.Trim();

            foreach (var item in process)
            {
                if (item.Code == code)
                {
                    MessageBox.Show("이미존재한 공정입니다.");
                    return;
                }

            }
            if (code.Length == 0)
            {
                MessageBox.Show("공정코드를 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("공정이름을 입력하세요.");
                return;
            }
            else if (factory.Length == 0)
            {
                MessageBox.Show("공장을 등록하세요.");
                return;
            }
            else
            {
                mprocess = new()
                {
                    FacCode = factory,
                    Code = code,
                    Name = name,
                    Comment = txtProcess_Comment.Text.Trim(),


                    StockUnit1 = cbbStock1.Text.Trim(),
                    StockUnit2 = cbbStock2.Text.Trim(),

                    Constructor = userName,
                    RegDate = DateTime.Now,
                };
                mprocess = await processRepository.AddAsync(mprocess);
                MessageBox.Show("생성완료");

                LoadProcess();
                return;
            }
        }
        private void dgvProcess_CellClick(object sender, DataGridViewCellEventArgs e)//공정 상세
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbProcessId.Text = selectedRow.Cells["process_id"].Value.ToString();
                    txtProcess_FacCode.Text = selectedRow.Cells["process_faccode"].Value.ToString();
                    txtProcess_Code.Text = selectedRow.Cells["process_code"].Value.ToString();

                    txtProcess_Name.Text = selectedRow.Cells["process_name"].Value.ToString();
                    txtProcess_Comment.Text = selectedRow.Cells["process_comment"].Value.ToString();

                    cbbStock1.Text = selectedRow.Cells["process_stock1"].Value.ToString();
                    cbbStock2.Text = selectedRow.Cells["process_stock2"].Value.ToString();

                    txtProcess_Const.Text = selectedRow.Cells["process_const"].Value.ToString();
                    txtProcess_Regdate.Text = selectedRow.Cells["process_regdate"].Value.ToString();
                    if (selectedRow.Cells["process_modi"].Value != null) txtProcess_Modi.Text = selectedRow.Cells["process_modi"].Value.ToString();
                    else txtProcess_Modi.Text = "";
                    if (selectedRow.Cells["process_moddate"].Value != null) txtProcess_Moddate.Text = selectedRow.Cells["process_moddate"].Value.ToString();
                    else txtProcess_Moddate.Text = "";
                }
            }
        }
        private async void btnProcess_U_Click(object sender, EventArgs e)//공정 수정
        {
            MProcess? mprocess;

            string code = txtProcess_Code.Text.Trim();
            string name = txtProcess_Name.Text.Trim();
            string factory = txtProcess_FacCode.Text.Trim();
            if (code.Length == 0)
            {
                MessageBox.Show("공정코드를 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("공정이름을 입력하세요.");
                return;
            }
            else if (factory.Length == 0)
            {
                MessageBox.Show("공장을 등록하세요.");
                return;
            }
            else
            {
                mprocess = new()
                {
                    Id = int.Parse(lbProcessId.Text.Trim()),
                    FacCode = factory,
                    Code = code,
                    Name = name,
                    Comment = txtProcess_Comment.Text.Trim(),

                    StockUnit1 = cbbStock1.Text.Trim(),
                    StockUnit2 = cbbStock2.Text.Trim(),

                    Constructor = userName,
                    RegDate = DateTime.Now,
                };
                mprocess = await processRepository.UpdateAsync(mprocess);
                MessageBox.Show("수정완료");
                LoadProcess();
                return;
            }
        }

        private async void btnProcess_D_Click(object sender, EventArgs e)//공정 삭제
        {
            if (dgvProcess.SelectedCells.Count > 0)
            {
                int rowIndex = dgvProcess.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvProcess.Rows[rowIndex];
                int id = (int)selectedRow.Cells["process_id"].Value;

                if (id == null) return;

                DialogResult result = MessageBox.Show($"선택된 공정({selectedRow.Cells["process_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    await processRepository.DeleteAsync(id);

                    LoadProcess();
                }
                else return;
            }

        }
        private async void searchProcess_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var process = await processRepository.GetAllAsync();
                string search = searchProcess.Text.Trim();

                if (cbbProcess_filter.Text.Trim() == "공정코드") process = await processRepository.CodeAsync(search);
                else if (cbbProcess_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);
                else if (cbbProcess_filter.Text.Trim() == "공장코드") process = await processRepository.FacCodeAsync(search);//////

                else if (cbbProcess_filter.Text.Trim() == "생성자") process = await processRepository.ConstAsync(search);
                else if (cbbProcess_filter.Text.Trim() == "수정자") process = await processRepository.ModiAsync(search);

                dgvProcess.Rows.Clear();
                dgvProcess.Refresh();

                int i = 0;
                foreach (var item in process)
                {
                    dgvProcess.Rows.Add();
                    dgvProcess.Rows[i].Cells["process_id"].Value = item.Id;
                    dgvProcess.Rows[i].Cells["process_faccode"].Value = item.FacCode;
                    dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                    dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                    dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;


                    dgvProcess.Rows[i].Cells["process_stock1"].Value = item.StockUnit1;
                    dgvProcess.Rows[i].Cells["process_stock2"].Value = item.StockUnit2;

                    dgvProcess.Rows[i].Cells["process_const"].Value = item.Constructor;
                    dgvProcess.Rows[i].Cells["process_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                    dgvProcess.Rows[i].Cells["process_modi"].Value = item.Modifier;
                    dgvProcess.Rows[i].Cells["process_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                    i++;
                }

            }
        }

        private async void pictureBox3_Click(object sender, EventArgs e)
        {
            var process = await processRepository.GetAllAsync();
            string search = searchProcess.Text.Trim();

            if (cbbProcess_filter.Text.Trim() == "공정코드") process = await processRepository.CodeAsync(search);
            else if (cbbProcess_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);
            else if (cbbProcess_filter.Text.Trim() == "공장코드") process = await processRepository.FacCodeAsync(search);//////

            else if (cbbProcess_filter.Text.Trim() == "생성자") process = await processRepository.ConstAsync(search);
            else if (cbbProcess_filter.Text.Trim() == "수정자") process = await processRepository.ModiAsync(search);

            dgvProcess.Rows.Clear();
            dgvProcess.Refresh();

            int i = 0;
            foreach (var item in process)
            {
                dgvProcess.Rows.Add();
                dgvProcess.Rows[i].Cells["process_id"].Value = item.Id;
                dgvProcess.Rows[i].Cells["process_faccode"].Value = item.FacCode;
                dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;


                dgvProcess.Rows[i].Cells["process_stock1"].Value = item.StockUnit1;
                dgvProcess.Rows[i].Cells["process_stock2"].Value = item.StockUnit2;

                dgvProcess.Rows[i].Cells["process_const"].Value = item.Constructor;
                dgvProcess.Rows[i].Cells["process_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvProcess.Rows[i].Cells["process_modi"].Value = item.Modifier;
                dgvProcess.Rows[i].Cells["process_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        #endregion
        //-----------------------------------------------------품번------------------------------------------------------------------//
        #region 품번 설정
        public async void LoadItem()//품번 목록
        {
            txtItem_Const.Text = userName;
            var items = await itemRepository.GetAllAsync();

            dgvItem.Rows.Clear();
            dgvItem.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvItem.Rows.Add();
                dgvItem.Rows[i].Cells["item_id"].Value = item.Id;
                dgvItem.Rows[i].Cells["item_code"].Value = item.Code;
                dgvItem.Rows[i].Cells["item_name"].Value = item.Name;
                dgvItem.Rows[i].Cells["item_comment"].Value = item.Comment;
                dgvItem.Rows[i].Cells["item_type"].Value = item.Type;

                dgvItem.Rows[i].Cells["item_const"].Value = item.Constructor;
                dgvItem.Rows[i].Cells["item_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvItem.Rows[i].Cells["item_modi"].Value = item.Modifier;
                dgvItem.Rows[i].Cells["item_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        private void dgvItem_CellClick(object sender, DataGridViewCellEventArgs e)//품번 상세
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbItem_Id.Text = selectedRow.Cells["item_id"].Value.ToString();
                    txtItem_Code.Text = selectedRow.Cells["item_code"].Value.ToString();
                    txtItem_Name.Text = selectedRow.Cells["item_name"].Value.ToString();
                    txtItem_Comment.Text = selectedRow.Cells["item_comment"].Value.ToString();

                    cbbItem_Type.Text = selectedRow.Cells["item_type"].Value.ToString();

                    txtItem_Const.Text = selectedRow.Cells["item_const"].Value.ToString();
                    txtItem_Regdate.Text = selectedRow.Cells["item_regdate"].Value.ToString();
                    if (selectedRow.Cells["item_modi"].Value != null) txtItem_Modi.Text = selectedRow.Cells["item_modi"].Value.ToString();
                    else txtItem_Modi.Text = "";
                    if (selectedRow.Cells["item_moddate"].Value != null) txtItem_Moddate.Text = selectedRow.Cells["item_moddate"].Value.ToString();
                    else txtItem_Moddate.Text = "";
                }
            }
        }
        private async void btnItem_C_Click(object sender, EventArgs e)//품번 생성
        {
            Item? items;
            var item = await itemRepository.GetAllAsync();
            string code = txtItem_Code.Text.Trim();
            string name = txtItem_Name.Text.Trim();
            string type = cbbItem_Type.Text.Trim();

            foreach (var item1 in item)
            {
                if (item1.Code == code)
                {
                    MessageBox.Show("이미존재한 공정입니다.");
                    return;
                }

            }
            if (code.Length == 0)
            {
                MessageBox.Show("품번을 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("품명을 입력하세요.");
                return;
            }
            else if (type == "품번타입")
            {
                MessageBox.Show("타입을 선택하세요.");
                return;
            }
            else
            {
                items = new()
                {
                    Code = code,
                    Name = name,
                    Comment = txtProcess_Comment.Text.Trim(),

                    Type = type,

                    Constructor = userName,
                    RegDate = DateTime.Now,
                };
                items = await itemRepository.AddAsync(items);
                MessageBox.Show("수정완료");

                LoadItem();
                return;
            }
        }

        private async void btnItem_U_Click(object sender, EventArgs e)//품번 수정
        {
            Item? items;

            string code = txtItem_Code.Text.Trim();
            string name = txtItem_Name.Text.Trim();
            string type = cbbItem_Type.Text.Trim();
            if (code.Length == 0)
            {
                MessageBox.Show("품번을 입력하세요.");
                return;
            }
            else if (name.Length == 0)
            {
                MessageBox.Show("품명을 입력하세요.");
                return;
            }
            else if (type == "품번타입")
            {
                MessageBox.Show("타입을 선택하세요.");
                return;
            }
            else
            {
                items = new()
                {
                    Id = int.Parse(lbItem_Id.Text.Trim()),
                    Code = code,
                    Name = name,
                    Comment = txtItem_Comment.Text.Trim(),

                    Type = type,

                    Modifier = userName,
                    ModDate = DateTime.Now,
                };
                items = await itemRepository.UpdateAsync(items);
                MessageBox.Show("수정완료");
                LoadItem();
                return;
            }

        }

        private async void btnItem_D_Click(object sender, EventArgs e)//품번 삭제
        {
            if (dgvItem.SelectedCells.Count > 0)
            {
                int rowIndex = dgvItem.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvItem.Rows[rowIndex];
                int id = (int)selectedRow.Cells["item_id"].Value;

                if (id == null) return;

                DialogResult result = MessageBox.Show($"선택된 품번({selectedRow.Cells["item_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    await itemRepository.DeleteAsync(id);

                    LoadItem();
                }
                else return;
            }

        }
        private async void searchItem_KeyPress(object sender, KeyPressEventArgs e)//품번 검색 textbox
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var items = await itemRepository.GetAllAsync();
                string search = searchItem.Text.Trim();

                if (cbbItem.Text.Trim() == "품번") items = await itemRepository.CodeAsync(search);
                else if (cbbItem.Text.Trim() == "품명") items = await itemRepository.NameAsync(search);
                else if (cbbItem.Text.Trim() == "TYPE") items = await itemRepository.TypeAsync(search);
                else if (cbbItem.Text.Trim() == "생성자") items = await itemRepository.ConstAsync(search);
                else if (cbbItem.Text.Trim() == "수정자") items = await itemRepository.ModiAsync(search);

                dgvItem.Rows.Clear();
                dgvItem.Refresh();

                int i = 0;
                foreach (var item in items)
                {
                    dgvItem.Rows.Add();
                    dgvItem.Rows[i].Cells["item_id"].Value = item.Id;
                    dgvItem.Rows[i].Cells["item_code"].Value = item.Code;
                    dgvItem.Rows[i].Cells["item_name"].Value = item.Name;
                    dgvItem.Rows[i].Cells["item_comment"].Value = item.Comment;
                    dgvItem.Rows[i].Cells["item_type"].Value = item.Type;

                    dgvItem.Rows[i].Cells["item_const"].Value = item.Constructor;
                    dgvItem.Rows[i].Cells["item_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                    dgvItem.Rows[i].Cells["item_modi"].Value = item.Modifier;
                    dgvItem.Rows[i].Cells["item_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                    i++;
                }

            }
        }

        private async void pictureBox5_Click(object sender, EventArgs e)//품번 검색 picturebox
        {
            var items = await itemRepository.GetAllAsync();
            string search = searchItem.Text.Trim();

            if (cbbItem.Text.Trim() == "품번") items = await itemRepository.CodeAsync(search);
            else if (cbbItem.Text.Trim() == "품명") items = await itemRepository.NameAsync(search);
            else if (cbbItem.Text.Trim() == "TYPE") items = await itemRepository.TypeAsync(search);
            else if (cbbItem.Text.Trim() == "생성자") items = await itemRepository.ConstAsync(search);
            else if (cbbItem.Text.Trim() == "수정자") items = await itemRepository.ModiAsync(search);

            dgvItem.Rows.Clear();
            dgvItem.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvItem.Rows.Add();
                dgvItem.Rows[i].Cells["item_id"].Value = item.Id;
                dgvItem.Rows[i].Cells["item_code"].Value = item.Code;
                dgvItem.Rows[i].Cells["item_name"].Value = item.Name;
                dgvItem.Rows[i].Cells["item_comment"].Value = item.Comment;
                dgvItem.Rows[i].Cells["item_type"].Value = item.Type;

                dgvItem.Rows[i].Cells["item_const"].Value = item.Constructor;
                dgvItem.Rows[i].Cells["item_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvItem.Rows[i].Cells["item_modi"].Value = item.Modifier;
                dgvItem.Rows[i].Cells["item_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        #endregion
        //-----------------------------------------------------Lot------------------------------------------------------------------//
        #region Lot설정
        private async void LoadLot()// Lot목록
        {
            txtLot_Const.Text = userName;
            var items = await lotRepository.GetAllAsync();

            dgvLot.Rows.Clear();
            dgvLot.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvLot.Rows.Add();
                dgvLot.Rows[i].Cells["lot_id"].Value = item.Id;
                dgvLot.Rows[i].Cells["lot_code"].Value = item.Code;
                dgvLot.Rows[i].Cells["lot_amount1"].Value = item.Amount1;
                dgvLot.Rows[i].Cells["lot_amount2"].Value = item.Amount2;
                dgvLot.Rows[i].Cells["lot_stock1"].Value = item.StockUnit1;
                dgvLot.Rows[i].Cells["lot_stock2"].Value = item.StockUnit2;

                dgvLot.Rows[i].Cells["lot_actiontime"].Value = item.ActionTime.ToString("MM.dd.HH.mm");
                dgvLot.Rows[i].Cells["lot_actioncode"].Value = item.ActionCode;

                dgvLot.Rows[i].Cells["lot_equipcode"].Value = item.EquipCode;
                dgvLot.Rows[i].Cells["lot_processcode"].Value = item.ProcessCode;
                dgvLot.Rows[i].Cells["lot_itemcode"].Value = item.ItemCode;


                dgvLot.Rows[i].Cells["lot_const"].Value = item.Constructor;
                dgvLot.Rows[i].Cells["lot_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                dgvLot.Rows[i].Cells["lot_modi"].Value = item.Modifier;
                dgvLot.Rows[i].Cells["lot_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                i++;
            }
        }
        private void dgvLot_CellClick(object sender, DataGridViewCellEventArgs e)//Lot상세
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbLot_Id.Text = selectedRow.Cells["lot_id"].Value.ToString();
                    txtLot_Code.Text = selectedRow.Cells["lot_code"].Value.ToString();
                    txtLot_Amount1.Text = selectedRow.Cells["lot_amount1"].Value.ToString();
                    txtLot_Amount2.Text = selectedRow.Cells["lot_amount2"].Value.ToString();

                    txtLot_Stock1.Text = selectedRow.Cells["lot_stock1"].Value.ToString();
                    txtLot_Stock2.Text = selectedRow.Cells["lot_stock2"].Value.ToString();


                    txtLot_ProcessCode.Text = selectedRow.Cells["lot_processcode"].Value.ToString();
                    txtLot_ItemCode.Text = selectedRow.Cells["lot_itemcode"].Value.ToString();


                    txtLot_Const.Text = selectedRow.Cells["lot_const"].Value.ToString();
                    txtLot_Regdate.Text = selectedRow.Cells["lot_regdate"].Value.ToString();
                    if (selectedRow.Cells["lot_modi"].Value != null) txtLot_Modi.Text = selectedRow.Cells["lot_modi"].Value.ToString();
                    else txtLot_Modi.Text = "";
                    if (selectedRow.Cells["lot_moddate"].Value != null) txtLot_Moddate.Text = selectedRow.Cells["lot_moddate"].Value.ToString();
                    else txtLot_Moddate.Text = "";
                }
            }

        }

        private async void btnLot_C_Click(object sender, EventArgs e)//Lot생성
        {
            CreateLot? createLot;

            var lots = await lotRepository.GetAllAsync();

            string code = txtLot_Code.Text.Trim();
            string amount1txt = txtLot_Amount1.Text.Trim();
            string amount2txt = txtLot_Amount2.Text.Trim();
            string processcode = txtLot_ProcessCode.Text.Trim();
            string itemcode = txtLot_ItemCode.Text.Trim();
            string stock2 = txtLot_Stock2.Text.Trim();
            string itemtype = "";


            var itemtypes = await itemRepository.CodeAsync(itemcode);
            foreach (var item in itemtypes)
            {
                itemtype = item.Type.ToString();
            }

            foreach (var item in lots)
            {
                if (item.Code == code)
                {
                    MessageBox.Show("이미존재한 Lot번호입니다.");
                    return;
                }

            }
            if (code.Length == 0)
            {
                MessageBox.Show("Lot번호를 입력하세요.");
                return;
            }
            else if (amount1txt.Length == 0)
            {
                MessageBox.Show("수량1을 입력하세요.");
                return;
            }
            else if (stock2.Length != 0 && amount2txt.Length == 0)
            {
                MessageBox.Show("수량2를 입력하세요.");
                return;
            }
            else if (processcode.Length == 0)
            {
                MessageBox.Show("공정을 설정하세요.");
                return;
            }
            else if (itemcode.Length == 0)
            {
                MessageBox.Show("품번을 설정하세요.");
                return;
            }
            else
            {
                int amount1 = int.Parse(amount1txt.Trim());
                int amount2 = 0;
                if (amount2txt.Length != 0) amount2 = int.Parse(amount2txt.Trim());
                createLot = new()
                {
                    Code = code,
                    Amount1 = amount1,
                    Amount2 = amount2,
                    StockUnit1 = txtLot_Stock1.Text.Trim(),
                    StockUnit2 = txtLot_Stock2.Text.Trim(),

                    ActionCode = "Create",
                    ActionTime = DateTime.Now,
                    HisNum = 0,
                    ProcessCode = processcode,
                    ItemCode = itemcode,
                    ItemType = itemtype,

                    Constructor = userName,
                    RegDate = DateTime.Now,
                };
                createLot = await lotRepository.AddAsync(createLot);
                MessageBox.Show("생성완료");

                LoadLot();
                return;
            }

        }
        #region 공정등록
        private void txtLot_ProcessCode_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }

        private void pbsProcess_Click(object sender, EventArgs e)
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }

        #endregion
        #region 품번 등록
        private void SItem_ItemCodeSelected(object sender, string itemcode)
        {
            // S_Equip 폼에서 선택한 값인 equipCode를 처리합니다.
            txtLot_ItemCode.Text = itemcode;
        }
        private void txtLot_ItemCode_Click(object sender, EventArgs e)
        {
            S_Item s_Item = new S_Item();
            s_Item.ItemCodeSelected += SItem_ItemCodeSelected;
            s_Item.ShowDialog();
        }

        private void pbsItem_Click(object sender, EventArgs e)
        {
            S_Item s_Item = new S_Item();
            s_Item.ItemCodeSelected += SItem_ItemCodeSelected;
            s_Item.ShowDialog();
        }
        #endregion
        private async void btnLot_U_Click(object sender, EventArgs e)//Lot 수정
        {
            CreateLot? createLot;

            string code = txtLot_Code.Text.Trim();
            int amount1 = int.Parse(txtLot_Amount1.Text.Trim());
            int amount2 = int.Parse(txtLot_Amount2.Text.Trim());
            string processcode = txtLot_ProcessCode.Text.Trim();
            string itemcode = txtLot_ItemCode.Text.Trim();
            string stock2 = txtLot_Stock2.Text.Trim();
            string itemtype = "";
            var itemtypes = await itemRepository.CodeAsync(itemcode);
            foreach (var item in itemtypes)
            {
                itemtype = item.Type.ToString();
            }
            if (code.Length == 0)
            {
                MessageBox.Show("Lot번호를 입력하세요.");
                return;
            }
            else if (amount1 == null)
            {
                MessageBox.Show("수량1을 입력하세요.");
                return;
            }
            else if (stock2.Length != 0 && amount2 == null)
            {
                MessageBox.Show("수량2를 입력하세요.");
                return;
            }
            else if (processcode.Length == 0)
            {
                MessageBox.Show("공정을 설정하세요.");
                return;
            }
            else if (itemcode.Length == 0)
            {
                MessageBox.Show("품번을 설정하세요.");
                return;
            }
            else
            {
                createLot = new()
                {
                    Id = int.Parse(lbLot_Id.Text.Trim()),
                    Code = code,
                    Amount1 = amount1,
                    Amount2 = amount2,
                    StockUnit1 = txtLot_Stock1.Text.Trim(),
                    StockUnit2 = txtLot_Stock2.Text.Trim(),

                    ActionCode = "Modify",
                    ActionTime = DateTime.Now,

                    ProcessCode = processcode,
                    ItemCode = itemcode,
                    ItemType = itemtype,

                    Modifier = userName,
                    ModDate = DateTime.Now,
                };
                createLot = await lotRepository.UpdateAsync(createLot);
                MessageBox.Show("수정완료");

                LoadLot();
                return;
            }

        }

        private async void btnLot_D_Click(object sender, EventArgs e)//Lot 삭제
        {
            if (dgvLot.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLot.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvLot.Rows[rowIndex];
                int id = (int)selectedRow.Cells["lot_id"].Value;

                if (id == null) return;

                DialogResult result = MessageBox.Show($"선택된 Lot번호({selectedRow.Cells["lot_code"].Value})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    await lotRepository.DeleteAsync(id);

                    LoadLot();
                }
                else return;
            }
        }
        private async void txtsearchLot_KeyPress(object sender, KeyPressEventArgs e)//Search LotNum
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var lots = await lotRepository.GetAllAsync();
                string search = txtsearchLot.Text.Trim();

                if (cbbLot_filter.Text.Trim() == "Lot번호") lots = await lotRepository.CodeAsync(search);
                else if (cbbLot_filter.Text.Trim() == "공정코드") lots = await lotRepository.ProcessCodeAsync(search);
                else if (cbbLot_filter.Text.Trim() == "품번") lots = await lotRepository.ItemCodeAsync(search);
                else if (cbbLot_filter.Text.Trim() == "생성자") lots = await lotRepository.ConstAsync(search);
                else if (cbbLot_filter.Text.Trim() == "수정자") lots = await lotRepository.ModiAsync(search);

                dgvLot.Rows.Clear();
                dgvLot.Refresh();

                int i = 0;
                foreach (var item in lots)
                {
                    dgvLot.Rows.Add();
                    dgvLot.Rows[i].Cells["lot_id"].Value = item.Id;
                    dgvLot.Rows[i].Cells["lot_code"].Value = item.Code;
                    dgvLot.Rows[i].Cells["lot_amount1"].Value = item.Amount1;
                    dgvLot.Rows[i].Cells["lot_amount2"].Value = item.Amount2;
                    dgvLot.Rows[i].Cells["lot_stock1"].Value = item.StockUnit1;
                    dgvLot.Rows[i].Cells["lot_stock2"].Value = item.StockUnit2;

                    dgvLot.Rows[i].Cells["lot_actiontime"].Value = item.ActionTime.ToString("MM.dd.HH.mm");
                    dgvLot.Rows[i].Cells["lot_actioncode"].Value = item.ActionCode;

                    dgvLot.Rows[i].Cells["lot_equipcode"].Value = item.EquipCode;
                    dgvLot.Rows[i].Cells["lot_processcode"].Value = item.ProcessCode;
                    dgvLot.Rows[i].Cells["lot_itemcode"].Value = item.ItemCode;


                    dgvLot.Rows[i].Cells["lot_const"].Value = item.Constructor;
                    dgvLot.Rows[i].Cells["lot_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                    dgvLot.Rows[i].Cells["lot_modi"].Value = item.Modifier;
                    dgvLot.Rows[i].Cells["lot_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                    i++;
                }

            }
        }

        private async void pictureBox6_Click(object sender, EventArgs e)//Search LotNum click PictureBox
        {
            var lots = await lotRepository.GetAllAsync();
            string search = txtsearchLot.Text.Trim();

            if (cbbLot_filter.Text.Trim() == "Lot번호") lots = await lotRepository.CodeAsync(search);
            else if (cbbLot_filter.Text.Trim() == "공정코드") lots = await lotRepository.ProcessCodeAsync(search);
            else if (cbbLot_filter.Text.Trim() == "품번") lots = await lotRepository.ItemCodeAsync(search);
            else if (cbbLot_filter.Text.Trim() == "생성자") lots = await lotRepository.ConstAsync(search);
            else if (cbbLot_filter.Text.Trim() == "수정자") lots = await lotRepository.ModiAsync(search);

            dgvLot.Rows.Clear();
            dgvLot.Refresh();

            int i = 0;
            foreach (var item in lots)
            {
                dgvLot.Rows.Add();
                dgvLot.Rows[i].Cells["lot_id"].Value = item.Id;
                dgvLot.Rows[i].Cells["lot_code"].Value = item.Code;
                dgvLot.Rows[i].Cells["lot_amount1"].Value = item.Amount1;
                dgvLot.Rows[i].Cells["lot_amount2"].Value = item.Amount2;
                dgvLot.Rows[i].Cells["lot_stock1"].Value = item.StockUnit1;
                dgvLot.Rows[i].Cells["lot_stock2"].Value = item.StockUnit2;

                dgvLot.Rows[i].Cells["lot_actiontime"].Value = item.ActionTime.ToString("MM.dd.HH.mm");
                dgvLot.Rows[i].Cells["lot_actioncode"].Value = item.ActionCode;

                dgvLot.Rows[i].Cells["lot_equipcode"].Value = item.EquipCode;
                dgvLot.Rows[i].Cells["lot_processcode"].Value = item.ProcessCode;
                dgvLot.Rows[i].Cells["lot_itemcode"].Value = item.ItemCode;


                dgvLot.Rows[i].Cells["lot_const"].Value = item.Constructor;
                dgvLot.Rows[i].Cells["lot_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                dgvLot.Rows[i].Cells["lot_modi"].Value = item.Modifier;
                dgvLot.Rows[i].Cells["lot_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                i++;
            }
        }
        #endregion
        //-----------------------------------------------------Lot이력-------------------------------------------------------------------------//
        #region Lot이력조회
        public async void LoadLotHis()
        {
            txtLothis_Const.Text = userName;
            var items = await lotRepository.GetAllHisAsync();

            dgvLotHis.Rows.Clear();
            dgvLotHis.Refresh();

            int i = 0;
            foreach (var item in items)
            {
                dgvLotHis.Rows.Add();
                dgvLotHis.Rows[i].Cells["lothis_id"].Value = item.Id;
                dgvLotHis.Rows[i].Cells["lothis_hisnum"].Value = item.HisNum;
                dgvLotHis.Rows[i].Cells["lothis_code"].Value = item.Code;
                dgvLotHis.Rows[i].Cells["lothis_amount1"].Value = item.Amount1;
                dgvLotHis.Rows[i].Cells["lothis_amount2"].Value = item.Amount2;
                dgvLotHis.Rows[i].Cells["lothis_stock1"].Value = item.StockUnit1;
                dgvLotHis.Rows[i].Cells["lothis_stock2"].Value = item.StockUnit2;
                dgvLotHis.Rows[i].Cells["lothis_actiontime"].Value = item.ActionTime;
                dgvLotHis.Rows[i].Cells["lothis_actioncode"].Value = item.ActionCode;

                dgvLotHis.Rows[i].Cells["lothis_processcode"].Value = item.ProcessCode;
                dgvLotHis.Rows[i].Cells["lothis_itemcode"].Value = item.ItemCode;
                dgvLotHis.Rows[i].Cells["lothis_equipcode"].Value = item.EquipCode;

                dgvLotHis.Rows[i].Cells["lothis_const"].Value = item.Constructor;
                dgvLotHis.Rows[i].Cells["lothis_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                dgvLotHis.Rows[i].Cells["lothis_modi"].Value = item.Modifier;
                dgvLotHis.Rows[i].Cells["lothis_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                i++;
            }
        }
        private async void searchLotHis_KeyPress(object sender, KeyPressEventArgs e)// 이력조회
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string search = searchLotHis.Text.Trim();
                var lots = await lotRepository.HisAsync(search);

                dgvLotHis.Rows.Clear();
                dgvLotHis.Refresh();

                int i = 0;
                foreach (var item in lots)
                {
                    dgvLotHis.Rows.Add();
                    dgvLotHis.Rows[i].Cells["lothis_id"].Value = item.Id;
                    dgvLotHis.Rows[i].Cells["lothis_hisnum"].Value = item.HisNum;
                    dgvLotHis.Rows[i].Cells["lothis_code"].Value = item.Code;
                    dgvLotHis.Rows[i].Cells["lothis_amount1"].Value = item.Amount1;
                    dgvLotHis.Rows[i].Cells["lothis_amount2"].Value = item.Amount2;
                    dgvLotHis.Rows[i].Cells["lothis_stock1"].Value = item.StockUnit1;
                    dgvLotHis.Rows[i].Cells["lothis_stock2"].Value = item.StockUnit2;
                    dgvLotHis.Rows[i].Cells["lothis_actiontime"].Value = item.ActionTime;
                    dgvLotHis.Rows[i].Cells["lothis_actioncode"].Value = item.ActionCode;
                    dgvLotHis.Rows[i].Cells["lothis_processcode"].Value = item.ProcessCode;
                    dgvLotHis.Rows[i].Cells["lothis_itemcode"].Value = item.ItemCode;
                    dgvLotHis.Rows[i].Cells["lothis_const"].Value = item.Constructor;
                    dgvLotHis.Rows[i].Cells["lothis_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                    dgvLotHis.Rows[i].Cells["lothis_modi"].Value = item.Modifier;
                    dgvLotHis.Rows[i].Cells["lothis_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                    i++;
                }

            }
        }

        private async void pbLotHis_Click(object sender, EventArgs e)//이력조회
        {
            string search = searchLotHis.Text.Trim();
            var lots = await lotRepository.HisAsync(search);

            dgvLotHis.Rows.Clear();
            dgvLotHis.Refresh();

            int i = 0;
            foreach (var item in lots)
            {
                dgvLotHis.Rows.Add();
                dgvLotHis.Rows[i].Cells["lothis_id"].Value = item.Id;
                dgvLotHis.Rows[i].Cells["lothis_hisnum"].Value = item.HisNum;
                dgvLotHis.Rows[i].Cells["lothis_code"].Value = item.Code;
                dgvLotHis.Rows[i].Cells["lothis_amount1"].Value = item.Amount1;
                dgvLotHis.Rows[i].Cells["lothis_amount2"].Value = item.Amount2;
                dgvLotHis.Rows[i].Cells["lothis_stock1"].Value = item.StockUnit1;
                dgvLotHis.Rows[i].Cells["lothis_stock2"].Value = item.StockUnit2;
                dgvLotHis.Rows[i].Cells["lothis_actiontime"].Value = item.ActionTime;
                dgvLotHis.Rows[i].Cells["lothis_actioncode"].Value = item.ActionCode;
                dgvLotHis.Rows[i].Cells["lothis_processcode"].Value = item.ProcessCode;
                dgvLotHis.Rows[i].Cells["lothis_itemcode"].Value = item.ItemCode;
                dgvLotHis.Rows[i].Cells["lothis_const"].Value = item.Constructor;
                dgvLotHis.Rows[i].Cells["lothis_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                dgvLotHis.Rows[i].Cells["lothis_modi"].Value = item.Modifier;
                dgvLotHis.Rows[i].Cells["lothis_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                i++;
            }
        }
        private void dgvLotHis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbLotHis_Id.Text = selectedRow.Cells["lothis_id"].Value.ToString();
                    txtLothis_Code.Text = selectedRow.Cells["lothis_code"].Value.ToString();
                    txtLothis_amount1.Text = selectedRow.Cells["lothis_amount1"].Value.ToString();
                    txtLothis_amount2.Text = selectedRow.Cells["lothis_amount2"].Value.ToString();
                    txtLothis_Stock1.Text = selectedRow.Cells["lothis_stock1"].Value.ToString();
                    txtLothis_Stock2.Text = selectedRow.Cells["lothis_stock2"].Value.ToString();
                    txtLothis_ActionCode.Text = selectedRow.Cells["lothis_actioncode"].Value.ToString();
                    txtLothis_ActionTime.Text = selectedRow.Cells["lothis_actiontime"].Value.ToString();


                    txtLothis_ProCode.Text = selectedRow.Cells["lothis_processcode"].Value.ToString();
                    txtLothis_ItemCode.Text = selectedRow.Cells["lothis_itemcode"].Value.ToString();


                    txtLothis_Const.Text = selectedRow.Cells["lothis_const"].Value.ToString();
                    txtLothis_Regdate.Text = selectedRow.Cells["lothis_regdate"].Value.ToString();
                    if (selectedRow.Cells["lothis_modi"].Value != null) txtLothis_Modi.Text = selectedRow.Cells["lothis_modi"].Value.ToString();
                    else txtLothis_Modi.Text = "";
                    if (selectedRow.Cells["lothis_moddate"].Value != null) txtLothis_Moddate.Text = selectedRow.Cells["lothis_moddate"].Value.ToString();
                    else txtLothis_Moddate.Text = "";
                }
            }
        }
        private async void btnLotHis_delList_Click(object sender, EventArgs e)//삭제 이력조회
        {
            string actioncode = "Delete";

            var lots = await lotRepository.ActionCodeHis(actioncode);

            dgvLotHis.Rows.Clear();
            dgvLotHis.Refresh();

            int i = 0;
            foreach (var item in lots)
            {
                dgvLotHis.Rows.Add();
                dgvLotHis.Rows[i].Cells["lothis_id"].Value = item.Id;
                dgvLotHis.Rows[i].Cells["lothis_hisnum"].Value = item.HisNum;
                dgvLotHis.Rows[i].Cells["lothis_code"].Value = item.Code;
                dgvLotHis.Rows[i].Cells["lothis_amount1"].Value = item.Amount1;
                dgvLotHis.Rows[i].Cells["lothis_amount2"].Value = item.Amount2;
                dgvLotHis.Rows[i].Cells["lothis_stock1"].Value = item.StockUnit1;
                dgvLotHis.Rows[i].Cells["lothis_stock2"].Value = item.StockUnit2;
                dgvLotHis.Rows[i].Cells["lothis_actiontime"].Value = item.ActionTime;
                dgvLotHis.Rows[i].Cells["lothis_actioncode"].Value = item.ActionCode;
                dgvLotHis.Rows[i].Cells["lothis_processcode"].Value = item.ProcessCode;
                dgvLotHis.Rows[i].Cells["lothis_itemcode"].Value = item.ItemCode;
                dgvLotHis.Rows[i].Cells["lothis_const"].Value = item.Constructor;
                dgvLotHis.Rows[i].Cells["lothis_regdate"].Value = item.RegDate.ToString("MM.dd.HH.mm");
                dgvLotHis.Rows[i].Cells["lothis_modi"].Value = item.Modifier;
                dgvLotHis.Rows[i].Cells["lothis_moddate"].Value = item.ModDate?.ToString("MM.dd.HH.mm");
                i++;
            }

        }
        private async void btnLotHis_ListDel_Click(object sender, EventArgs e)
        {
            string lotcode = txtLothis_Code.Text.Trim();
            var lothis = await lotRepository.HisAsync(lotcode);

            DialogResult result = MessageBox.Show($"선택된 설비({lotcode})을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                foreach (var item in lothis) { var hisDel = await lotRepository.DeleteHisAsync(item.Id); };
                LoadLotHis();
            }
            else return;

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (dgvLotHis.SelectedCells.Count > 0)
            {
                int rowIndex = dgvLotHis.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dgvLotHis.Rows[rowIndex];
                string lotcode = selectedRow.Cells["lothis_code"].Value.ToString();
                string hisnum = selectedRow.Cells["lothis_hisnum"].Value.ToString();
                int id = (int)selectedRow.Cells["lothis_id"].Value;
                if (lotcode == null) return;

                DialogResult result = MessageBox.Show($"선택된 설비({lotcode})의 이력번호{hisnum}번을 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {

                    var hisDel = await lotRepository.DeleteHisAsync(id);

                    LoadLotHis();
                }
                else return;
            }
        }
        #endregion
        //-----------------------------------------------------Lot작업-----------------------------------------------------------------------------------------------------------//
        #region Lot작업 시작
        public void LotStartClear()//Lot정보 Clear
        {
            lotStart_equipcode.Items.Clear();
            lotStart_itemcode.Text = "";
            lotStart_itemname.Text = "";
            lotStart_processcode.Text = "";
            lotStart_processname.Text = "";
            lotStart_amount1.Text = "";
            lotStart_amount2.Text = "";
        }
        private async void lotStart_Code_KeyPress(object sender, KeyPressEventArgs e) //Lot검색
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string lotcode = lotStart_Code.Text.Trim();
                var lot = await lotRepository.CodeAsync(lotcode);
                if (lot.Count() == 0)
                {
                    MessageBox.Show("존제하지 않는 Lot번호입니다.");
                    return;
                }

                string lotnum = "", itemcode = "", itemname = "", processcode = "", processname = "";
                string amount1 = "", amount2 = "";

                foreach (var item in lot)
                {
                    lotnum = item.Code;
                    itemcode = item.ItemCode;
                    if (item.NextProcessCode == null) processcode = item.ProcessCode;
                    else processcode = item.NextProcessCode;
                    amount1 = $"{item.Amount1}  {item.StockUnit1}";
                    amount2 = $"{item.Amount2}  {item.StockUnit2}";
                }
                var process = await processRepository.CodeAsync(processcode);
                foreach (var item in process)
                {
                    processname = item.Name;
                }
                var item1 = await itemRepository.CodeAsync(itemcode);
                foreach (var item in item1)
                {
                    itemname = item.Name;
                }
                var equip = await equipmentRepository.ProcessCodeAsync(processcode);
                lotStart_equipcode.Items.Clear();
                foreach (var item in equip)
                {
                    lotStart_equipcode.Items.Add(item.Code);
                }
                lotStart_lotCode.Text = lotnum;
                lotStart_itemcode.Text = itemcode;
                lotStart_itemname.Text = itemname;
                lotStart_processcode.Text = processcode;
                lotStart_processname.Text = processname;
                lotStart_amount1.Text = amount1;
                lotStart_amount2.Text = amount2;

            }
        }
        private async void pictureBox7_Click(object sender, EventArgs e)//검색
        {
            string lotcode = lotStart_Code.Text.Trim();
            var lot = await lotRepository.CodeAsync(lotcode);
            if (lot.Count() == 0)
            {
                MessageBox.Show("존제하지 않는 Lot번호입니다.");
                return;
            }

            string lotnum = "", itemcode = "", itemname = "", processcode = "", processname = "";
            string amount1 = "", amount2 = "";
            int a1 = 0, a2 = 0;
            foreach (var item in lot)
            {
                lotnum = item.Code;
                itemcode = item.ItemCode;
                if (item.NextProcessCode == null) processcode = item.ProcessCode;
                else processcode = item.NextProcessCode;
                amount1 = $"{item.Amount1}  {item.StockUnit1}";
                amount2 = $"{item.Amount2}  {item.StockUnit2}";

            }
            var process = await processRepository.CodeAsync(processcode);
            foreach (var item in process)
            {
                processname = item.Name;
            }
            var item1 = await itemRepository.CodeAsync(itemcode);
            foreach (var item in item1)
            {
                itemname = item.Name;
            }
            var equip = await equipmentRepository.ProcessCodeAsync(processcode);
            lotStart_equipcode.Items.Clear();
            foreach (var item in equip)
            {
                lotStart_equipcode.Items.Add(item.Code);
            }
            lotStart_lotCode.Text = lotnum;
            lotStart_itemcode.Text = itemcode;
            lotStart_itemname.Text = itemname;
            lotStart_processcode.Text = processcode;
            lotStart_processname.Text = processname;
            lotStart_amount1.Text = amount1;
            lotStart_amount2.Text = amount2;
        }

        private void btnlotStart_Clear_Click(object sender, EventArgs e) // 새로고침 버튼
        {
            LotStartClear();
        }

        private async void btnlotStart_Click(object sender, EventArgs e) // 실행 버튼
        {
            CreateLot? createLot = null;

            string equip = lotStart_equipcode.Text.Trim();
            string lotcode = lotStart_lotCode.Text.Trim();
            string process = lotStart_processcode.Text.Trim();
            if (lotcode.Length == 0)
            {
                MessageBox.Show("Lot번호를 조회 후 작업을 시작하세요");
                return;
            }

            var lot = await lotRepository.CodeAsync(lotcode);


            if (equip.Length == 0)
            {
                MessageBox.Show("설비를 설정하세요.");
                return;
            }
            else
            {
                foreach (var item in lot)
                {
                    if (item.ActionCode == "Stop" || item.ActionCode == "Start" || item.ActionCode == "Run")
                    {
                        MessageBox.Show("작업을 완료하지 않거나 작업이 중단되어 작업을 실행할수 없습니다.");
                        return;
                    }
                    createLot = new()
                    {
                        Id = item.Id,

                        Code = item.Code,
                        Amount1 = item.Amount1,
                        Amount2 = item.Amount2,
                        StockUnit1 = item.StockUnit1,
                        StockUnit2 = item.StockUnit2,

                        EquipCode = equip,
                        ProcessCode = process,
                        ItemCode = item.ItemCode,
                        ItemType = item.ItemType,

                        ActionCode = "Start",
                        ActionTime = DateTime.Now,

                        Modifier = userName,
                        ModDate = DateTime.Now,

                    };
                }

                if (createLot != null)
                {

                    Equipment? equipment = null;
                    var equips = await equipmentRepository.CodeAsync(equip);
                    foreach (var item in equips)
                    {
                        if (item.Status == "Stop") { MessageBox.Show($"{item.Code}는 동작하지 않습니다."); return; }
                        else if (item.Status == "Process") { MessageBox.Show($"{item.Code}는 동작중 입니다."); return; }
                        equipment = new()
                        {
                            Id = item.Id,
                            ProcessCode = item.ProcessCode,
                            Code = item.Code,
                            Name = item.Name,
                            Comment = item.Comment,
                            Status = "Process",
                            Event = item.Event,

                            Modifier = userName,
                            ModDate = DateTime.Now
                        };
                    }
                    if (equips != null)
                    {
                        equipment = await equipmentRepository.UpdateAsync(equipment);
                    }
                    else
                    {
                        MessageBox.Show("해당하는 Lot의 설비를 찾을 수 없습니다.");
                        return;
                    }
                    createLot = await lotRepository.UpdateAsync(createLot);
                    MessageBox.Show("작업 시작");
                    return;
                }
                else
                {
                    MessageBox.Show("해당하는 Lot을 찾을 수 없습니다.");
                    return;
                }


            }

        }
        #endregion

        #region Lot 작업종료
        public void LotEndClear()//Lot정보 Clear
        {
            lotEnd_Equip.Items.Clear();
            lotEnd_lotCode.Text = "";
            lotEnd_ItemCode.Text = "";
            lotEnd_ItemName.Text = "";
            lotEnd_ProCode.Text = "";
            lotEnd_ProName.Text = "";
            lotEnd_Amount1.Text = "";
            lotEnd_Amount2.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LotEndClear();
        }
        private async void lotEnd_Code_KeyPress(object sender, KeyPressEventArgs e)//Lot조회
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string lotcode = lotStart_Code.Text.Trim();
                var lot = await lotRepository.CodeAsync(lotcode);
                if (lot.Count() == 0)
                {
                    MessageBox.Show("존제하지 않는 Lot번호입니다.");
                    return;
                }


                foreach (var item in lot)
                {
                    lotEnd_lotCode.Text = item.Code;
                    lotEnd_ItemCode.Text = item.ItemCode;
                    lotEnd_ProCode.Text = item.ProcessCode;
                    lotEnd_Amount1.Text = $"{item.Amount1}  {item.StockUnit1}";
                    lotEnd_Amount2.Text = $"{item.Amount2}  {item.StockUnit2}";
                }
                string processcode = lotEnd_ProCode.Text.Trim();
                string itemcode = lotEnd_ItemCode.Text.Trim();

                var process = await processRepository.CodeAsync(processcode);
                foreach (var item in process)
                {
                    lotEnd_ProName.Text = item.Name;
                }
                var item1 = await itemRepository.CodeAsync(itemcode);
                foreach (var item in item1)
                {
                    lotEnd_ItemName.Text = item.Name;
                }
                var equip = await equipmentRepository.ProcessCodeAsync(processcode);
                lotEnd_Equip.Items.Clear();
                foreach (var item in equip)
                {
                    lotEnd_Equip.Items.Add(item.Code);
                }
            }
        }
        private async void pictureBox8_Click(object sender, EventArgs e)//Lot조회
        {
            string lotcode = lotStart_Code.Text.Trim();
            var lot = await lotRepository.CodeAsync(lotcode);
            if (lot.Count() == 0)
            {
                MessageBox.Show("존제하지 않는 Lot번호입니다.");
                return;
            }


            foreach (var item in lot)
            {
                lotEnd_lotCode.Text = item.Code;
                lotEnd_ItemCode.Text = item.ItemCode;
                lotEnd_ProCode.Text = item.ProcessCode;
                lotEnd_Amount1.Text = $"{item.Amount1}  {item.StockUnit1}";
                lotEnd_Amount2.Text = $"{item.Amount2}  {item.StockUnit2}";
            }
            string processcode = lotEnd_ProCode.Text.Trim();
            string itemcode = lotEnd_ItemCode.Text.Trim();

            var process = await processRepository.CodeAsync(processcode);
            foreach (var item in process)
            {
                lotEnd_ProName.Text = item.Name;
            }
            var item1 = await itemRepository.CodeAsync(itemcode);
            foreach (var item in item1)
            {
                lotEnd_ItemName.Text = item.Name;
            }
            var equip = await equipmentRepository.ProcessCodeAsync(processcode);
            lotStart_equipcode.Items.Clear();
            foreach (var item in equip)
            {
                lotStart_equipcode.Items.Add(item.Code);
            }
        }
        private void txtlotEnd_NextPro_Click(object sender, EventArgs e)//공정검색
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }

        private void pictureBox9_Click(object sender, EventArgs e)//공정검색
        {
            S_Process s_Process = new S_Process();
            s_Process.ProcessCodeSelected += SProcess_ProcessCodeSelected;
            s_Process.ShowDialog();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            CreateLot? createLot = null;

            string equip = lotEnd_Equip.Text.Trim();
            string lotcode = lotEnd_lotCode.Text.Trim();
            string process = lotEnd_ProCode.Text.Trim();
            if (lotcode.Length == 0)
            {
                MessageBox.Show("Lot번호를 조회 후 작업을 시작하세요");
                return;
            }

            var lot = await lotRepository.CodeAsync(lotcode);


            if (equip.Length == 0)
            {
                MessageBox.Show("설비를 설정하세요.");
                return;
            }
            else
            {
                foreach (var item in lot)
                {
                    if (item.ActionCode == "Stop" || item.ActionCode == "End")
                    {
                        MessageBox.Show("작업을 시작하지 않거나 중단되어 작업을 완료할수 없습니다.");
                        return;
                    }
                    createLot = new()
                    {
                        Id = item.Id,

                        Code = item.Code,
                        Amount1 = item.Amount1,
                        Amount2 = item.Amount2,
                        StockUnit1 = item.StockUnit1,
                        StockUnit2 = item.StockUnit2,

                        EquipCode = equip,
                        ProcessCode = process,
                        NextProcessCode = txtlotEnd_NextPro.Text.Trim(),
                        ItemCode = item.ItemCode,
                        ItemType = item.ItemType,

                        ActionCode = "End",
                        ActionTime = DateTime.Now,

                        Modifier = userName,
                        ModDate = DateTime.Now,

                    };
                }

                if (createLot != null)
                {
                    Equipment? equipment = null;
                    var equips = await equipmentRepository.CodeAsync(equip);
                    foreach (var item in equips)
                    {
                        if (item.Status == "Stop") { MessageBox.Show($"{item.Code}는 동작하지 않습니다."); return; }
                        else if (item.Status == "Ready") { MessageBox.Show($"{item.Code}는 동작준비중 입니다."); return; }
                        equipment = new()
                        {
                            Id = item.Id,
                            ProcessCode = item.ProcessCode,
                            Code = item.Code,
                            Name = item.Name,
                            Comment = item.Comment,
                            Status = "Ready",
                            Event = item.Event,

                            Modifier = userName,
                            ModDate = DateTime.Now
                        };
                    }
                    if (equips != null)
                    {
                        equipment = await equipmentRepository.UpdateAsync(equipment);
                    }
                    else
                    {
                        MessageBox.Show("해당하는 Lot의 설비를 찾을 수 없습니다.");
                        return;
                    }
                    createLot = await lotRepository.UpdateAsync(createLot);
                    MessageBox.Show("작업 완료");
                    return;

                }
                else
                {
                    MessageBox.Show("해당하는 Lot을 찾을 수 없습니다.");
                    return;
                }


            }
        }

        #endregion

        private void LoadLotProcess()
        {
            lotStart_equipcode.Items.Clear();
            lotStart_itemcode.Text = "";
            lotStart_itemname.Text = "";
            lotStart_processcode.Text = "";
            lotStart_processname.Text = "";
            lotStart_amount1.Text = "";
            lotStart_amount2.Text = "";
            lotEnd_Equip.Items.Clear();
            lotEnd_lotCode.Text = "";
            lotEnd_ItemCode.Text = "";
            lotEnd_ItemName.Text = "";
            lotEnd_ProCode.Text = "";
            lotEnd_ProName.Text = "";
            lotEnd_Amount1.Text = "";
            lotEnd_Amount2.Text = "";
        }

        private void ProcessForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.OpenForms 컬렉션의 복사본을 만들고 이 복사본을 순회하는 방법을 제안할 수 있습니다. 다음은 해당 방법을 적용한 코드입니다:

            // 화면 닫을 때 확인메시지 출력
            DialogResult result = MessageBox.Show("프로그램을 종료하시겠습니까?", "Exit", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // 폼 닫기 이벤트 취소하지 않음
                e.Cancel = false;

                // 열려있는 폼 확인
                List<Form> openForms = new List<Form>();
                foreach (Form form in Application.OpenForms)
                    openForms.Add(form);

                foreach (Form form in openForms)
                {
                    //열려있는 폼이 로그인 폼이면
                    if (form is Login)
                    {
                        // 폼 닫음
                        form.Close();
                        break;
                    }
                }
            }
            else
            {
                // 'No'를 눌렀을 때 폼 닫기 이벤트 취소
                e.Cancel = true;
            }
        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            // 로그아웃 처리
            SessionManager.Instance.Logout();

            // 현재 메인 폼을 숨깁니다.
            this.Hide();
            //this.Close();

            // 저장된 로그인 폼 인스턴스를 다시 표시합니다.
            SessionManager.Instance.LoginForm.Show();
        }


    }
}
