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

namespace _3rd_TEAM_PROJECT
{
    public partial class ProcessForm : Form
    {
        private IFactoryRepository factoryRepository;
        private IEquipmentRepository equipmentRepository;
        private IProcessRepository processRepository;
        private IItemRepository itemRepository;


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
        //--설비목록--
        private async void LoadEquip()
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
        }
        private async void LoadEquipHis()
        {
            var equipHis = await equipmentRepository.GetAllHisAsync();
            dgvEquipHis.Rows.Clear();
            dgvEquipHis.Refresh();
            int i = 0;
            foreach (var item in equipHis)
            {
                dgvEquipHis.Rows.Add();
                dgvEquipHis.Rows[i].Cells["equipHis_id"].Value = item.Id;
                dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
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
        }
        //--설비 상세---//
        private void dgvEquip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    lbEquipId.Text = selectedRow.Cells["equip_id"].Value.ToString();
                    txtEquip_Code.Text = selectedRow.Cells["equip_code"].Value.ToString();
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

        }
        //---이력상세--//
        private void dgvEquipHis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = (DataGridView)sender;
                DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

                if (selectedRow.Cells.Count > 1)
                {
                    txtEquipHis_Code.Text = selectedRow.Cells["equipHis_code"].Value.ToString();
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
        }
        //--설비생성--//
        private async void btnEquipC_Click(object sender, EventArgs e)
        {
            Equipment? equipment;
            var equips = await equipmentRepository.GetAllAsync();
            string code = txtEquip_Code.Text.Trim();
            string name = txtEquip_Name.Text.Trim();

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
            else
            {
                equipment = new()
                {
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
        }

        //--설비 수정--//
        private async void btnEquipU_Click(object sender, EventArgs e)
        {
            Equipment? equipment;

            string code = txtEquip_Code.Text.Trim();
            string name = txtEquip_Name.Text.Trim();

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
            else
            {
                equipment = new()
                {
                    Id = int.Parse(lbEquipId.Text.Trim()),
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
        }
        //--설비 삭제--//
        private async void btnEquipD_Click(object sender, EventArgs e)
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
        }
        //----설비 검색------//
        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            var equips = await equipmentRepository.GetAllAsync();
            string search = searchEquip.Text.Trim();

            if (cbbEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비상태") equips = await equipmentRepository.StatusAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비이벤트") equips = await equipmentRepository.EventAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "생성자") equips = await equipmentRepository.ConstAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "수정자") equips = await equipmentRepository.ModiAsync(search);

            dgvEquip.Rows.Clear();
            dgvEquip.Refresh();
            int i = 0;
            foreach (var item in equips)
            {
                dgvEquip.Rows.Add();
                dgvEquip.Rows[i].Cells["equip_id"].Value = item.Id;
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
        //---이력 조회-----//
        private async void pictureBox2_Click(object sender, EventArgs e)
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

        }
        //---엔터 설비검색---//
        private async void searchEquip_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var equips = await equipmentRepository.GetAllAsync();
                string search = searchEquip.Text.Trim();

                if (cbbEquip_filter.Text.Trim() == "설비코드") equips = await equipmentRepository.CodeAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비명") equips = await equipmentRepository.NameAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비상태") equips = await equipmentRepository.StatusAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비이벤트") equips = await equipmentRepository.EventAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "생성자") equips = await equipmentRepository.ConstAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "수정자") equips = await equipmentRepository.ModiAsync(search);

                dgvEquip.Rows.Clear();
                dgvEquip.Refresh();
                int i = 0;
                foreach (var item in equips)
                {
                    dgvEquip.Rows.Add();
                    dgvEquip.Rows[i].Cells["equip_id"].Value = item.Id;
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
        }
        //----엔터 이력조회--//
        private async void searchEquipCode_KeyPress(object sender, KeyPressEventArgs e)
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
                    dgvEquipHis.Rows[i].Cells["equipHis_code"].Value = item.Code;
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
                dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;

                dgvProcess.Rows[i].Cells["process_equipcode"].Value = item.EquipCode;
                dgvProcess.Rows[i].Cells["process_stock1"].Value = item.StockUnit1;
                dgvProcess.Rows[i].Cells["process_stock2"].Value = item.StockUnit2;

                dgvProcess.Rows[i].Cells["process_const"].Value = item.Constructor;
                dgvProcess.Rows[i].Cells["process_regdate"].Value = item.RegDate.ToString("yyyy-MM-dd");
                dgvProcess.Rows[i].Cells["process_modi"].Value = item.Modifier;
                dgvProcess.Rows[i].Cells["process_moddate"].Value = item.ModDate?.ToString("yyyy-MM-dd");
                i++;
            }
        }
        #region 설비등록
        private void txtProcess_Equip_Click(object sender, EventArgs e) //설비등록 TextBox_Click
        {
            S_Equip s_Equip = new S_Equip();
            s_Equip.EquipCodeSelected += SEquip_EquipCodeSelected; // 이벤트 핸들러 등록
            s_Equip.ShowDialog();

        }

        private void search_Equip_Click(object sender, EventArgs e)//설비등록 PictureBox_Click
        {
            S_Equip s_Equip = new S_Equip();
            s_Equip.EquipCodeSelected += SEquip_EquipCodeSelected; // 이벤트 핸들러 등록
            s_Equip.ShowDialog();
        }
        private void SEquip_EquipCodeSelected(object sender, string equipCode)
        {
            // S_Equip 폼에서 선택한 값인 equipCode를 처리합니다.
            txtProcess_Equip.Text = equipCode;
        }
        #endregion

        private async void btnProcess_C_Click(object sender, EventArgs e)//공정 생성
        {
            MProcess? mprocess;
            var process = await processRepository.GetAllAsync();
            string code = txtProcess_Code.Text.Trim();
            string name = txtProcess_Name.Text.Trim();

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
            else
            {
                mprocess = new()
                {
                    Code = code,
                    Name = name,
                    Comment = txtProcess_Comment.Text.Trim(),

                    EquipCode = txtProcess_Equip.Text.Trim(),
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
                    txtProcess_Code.Text = selectedRow.Cells["process_code"].Value.ToString();
                    txtProcess_Name.Text = selectedRow.Cells["process_name"].Value.ToString();
                    txtProcess_Comment.Text = selectedRow.Cells["process_comment"].Value.ToString();

                    txtProcess_Equip.Text = selectedRow.Cells["process_equipcode"].Value.ToString();
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
            else
            {
                mprocess = new()
                {
                    Id = int.Parse(lbProcessId.Text.Trim()),
                    Code = code,
                    Name = name,
                    Comment = txtProcess_Comment.Text.Trim(),

                    EquipCode = txtProcess_Equip.Text.Trim(),
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

                if (cbbEquip_filter.Text.Trim() == "공정코드") process = await processRepository.CodeAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "설비코드") process = await processRepository.EquipAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "생성자") process = await processRepository.ConstAsync(search);
                else if (cbbEquip_filter.Text.Trim() == "수정자") process = await processRepository.ModiAsync(search);

                dgvProcess.Rows.Clear();
                dgvProcess.Refresh();

                int i = 0;
                foreach (var item in process)
                {
                    dgvProcess.Rows.Add();
                    dgvProcess.Rows[i].Cells["process_id"].Value = item.Id;
                    dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                    dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                    dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;

                    dgvProcess.Rows[i].Cells["process_equipcode"].Value = item.EquipCode;
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

            if (cbbEquip_filter.Text.Trim() == "공정코드") process = await processRepository.CodeAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "공정명") process = await processRepository.NameAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "설비코드") process = await processRepository.EquipAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "생성자") process = await processRepository.ConstAsync(search);
            else if (cbbEquip_filter.Text.Trim() == "수정자") process = await processRepository.ModiAsync(search);

            dgvProcess.Rows.Clear();
            dgvProcess.Refresh();

            int i = 0;
            foreach (var item in process)
            {
                dgvProcess.Rows.Add();
                dgvProcess.Rows[i].Cells["process_id"].Value = item.Id;
                dgvProcess.Rows[i].Cells["process_code"].Value = item.Code;
                dgvProcess.Rows[i].Cells["process_name"].Value = item.Name;
                dgvProcess.Rows[i].Cells["process_comment"].Value = item.Comment;

                dgvProcess.Rows[i].Cells["process_equipcode"].Value = item.EquipCode;
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




    }
}
