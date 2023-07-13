using _3rd_TEAM_PROJECT.Models.Acount;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Repositorys;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore.Internal;

namespace _3rd_TEAM_PROJECT
{
	public partial class Main : Form
	{
		private IFactoryRepository factoryRepository;
		//로그인한 계정을 구별
		public Acount LoggedInAcount { get; set; }
		public Login LoginForm { get; set; }

		public Main()
		{
			InitializeComponent();
			factoryRepository = Program.factoryRepository;
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
				case 5:
					LoadFactory();
					break;
				case 6:
					break;

			}
		}
		//---------------------------공장목록-----------------------------------------//
		private async void LoadFactory()
		{
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
