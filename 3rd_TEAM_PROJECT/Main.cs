using _3rd_TEAM_PROJECT.Models.Acount;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore.Internal;

namespace _3rd_TEAM_PROJECT
{
	public partial class Main : Form
	{
		private IFactoryRepository factoryRepository;
		private IEquipmentRepository equipmentRepository;
		//로그인한 계정을 구별
		public Acount LoggedInAcount { get; set; }
		public Login LoginForm { get; set; }
		//----------Login정보 받기-----------------//
		public string userName = "이욕학"; // SessionManger에서 Acount정보 받기

		public Main()
		{
			InitializeComponent();
			factoryRepository = Program.factoryRepository;
			equipmentRepository = Program.equipmentRepository;
		}

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
		//계정에 따라 보여지는 탭을 구별한다
		private void Main_Load(object sender, EventArgs e)
		{
			//계정의 가려지는 탭을 결정한다
			//DepartmentCode에 따라 구분한다

			//계정 사용 원할 경우 아래 주석을 해제하고, Programs.cs파일의 주석을 해제하면된다.
			//if (SessionManager.Instance.LoggedInAcount.Department.DepartmentCode != "1")
			//{
			//    //TabMenu.TabPages[0].Parent = null;  // 첫 번째 탭을 숨깁니다.
			//}
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

					break;
				case 1:

					break;
				case 2:

					break;
				case 3:

					break;
				case 4:

					break;
				case 5://Factory
					LoadFactory();
					break;
				case 6:
					break;
				case 7:
					break;
				case 8:// 설비
					LoadEquip();
					break;
				case 9:
					break;

			}
		}
		//--------------------설비목록---------------------------------------------//
		private async void LoadEquip()
		{
			txtequipConst.Text = userName;
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
				dgvEquip.Rows[i].Cells["equip_regdate"].Value = item.RegDate;
				dgvEquip.Rows[i].Cells["equip_modi"].Value = item.Modifier;
				dgvEquip.Rows[i].Cells["equip_moddate"].Value = item.ModDate;
				i++;
			}

		}
		//----설비생성--//
		private async void btnCequip_Click(object sender, EventArgs e)
		{
			Equipment? equipment;
			var equips = await equipmentRepository.GetAllAsync();
			string code = txtequiCode.Text.Trim();
			string name = txtequipName.Text.Trim();

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
					Comment = txtequiComment.Text.Trim(),
					Status = cbbequipStatus.Text.Trim(),
					Event = cbbequipEvent.Text.Trim(),
					Constructor = userName,
					RegDate = DateTime.Now,
				};
				equipment = await equipmentRepository.AddAsync(equipment);
				MessageBox.Show("생성완료");
				LoadEquip();
				return;
			}
		}

		//---------------------------공장목록-----------------------------------------//

		private async void LoadFactory()
		{
			txtfacConst.Text = userName;

			var items = await factoryRepository.GetAllAsync();
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
		//--공장 생성 버튼--//
		private async void btnCFactory_Click(object sender, EventArgs e)
		{
			Factory? factory;
			var items = await factoryRepository.GetAllAsync();

			string code = txtfacCode.Text.Trim();
			string name = txtfacName.Text.Trim();


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
		//---공장 삭제--


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
		//--선택한 셀 오를쪽 상세정보에 뜰수있게
		private void dgvFactory_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure a valid cell is clicked
			{
				DataGridView dgv = (DataGridView)sender;
				DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

				if (selectedRow.Cells.Count > 1)
				{
					lbfacId.Text = selectedRow.Cells["fac_id"].Value.ToString();
					txtfacCode.Text = selectedRow.Cells["fac_code"].Value.ToString();
					txtfacName.Text = selectedRow.Cells["fac_name"].Value.ToString();
					txtfacConst.Text = selectedRow.Cells["fac_const"].Value.ToString();
					txtfacRegdate.Text = selectedRow.Cells["fac_regdate"].Value.ToString();
					if (selectedRow.Cells["fac_modifier"].Value != null) txtfacModifier.Text = selectedRow.Cells["fac_modifier"].Value.ToString();
					else txtfacModifier.Text = "";
					if (selectedRow.Cells["fac_update"].Value != null) txtfacModiDate.Text = selectedRow.Cells["fac_update"].Value.ToString();
					else txtfacModiDate.Text = "";
				}
			}
		}

		//------수정-------------//
		private async void btnUFactory_Click(object sender, EventArgs e)
		{
			Factory? factory;

			string code = txtfacCode.Text.Trim();
			string name = txtfacName.Text.Trim();

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
		//---------공장검색---------//
		private async void pictureBox4_Click(object sender, EventArgs e)
		{
			var items = await factoryRepository.GetAllAsync();
			string search = txtfacSearch.Text.Trim();
			if (cbbFilter.Text.Trim() == "공장코드") items = await factoryRepository.CodeAsync(search);
			else if (cbbFilter.Text.Trim() == "공장명") items = await factoryRepository.NameAsync(search);
			else if (cbbFilter.Text.Trim() == "생성자") items = await factoryRepository.ConstAsync(search);
			else if (cbbFilter.Text.Trim() == "수정자") items = await factoryRepository.ModiAsync(search);

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

		//------엔터 공장검색---///
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
		}



	}
}
