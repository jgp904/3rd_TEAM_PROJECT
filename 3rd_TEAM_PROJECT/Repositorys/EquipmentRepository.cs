using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
	public class EquipmentRepository : IEquipmentRepository
	{
		private readonly AcountDbContext acountdb;
		private readonly MProcessDbcontext mprocessdb;

		private readonly IEquipmentRepository equipmentRepository;

		public EquipmentRepository()
		{
			acountdb = Program.acountdb;
			mprocessdb = Program.mprocessdb;
		}

		public async Task<Equipment> AddAsync(Equipment equip)
		{
			await mprocessdb.Equipments.AddAsync(equip);
			await mprocessdb.SaveChangesAsync();
			return equip;
		}

		public Task<Equipment?> DeleteAsync(Equipment factory)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Equipment>> GetAllAsync()
		{
			var equip = await mprocessdb.Equipments.ToListAsync();
			return equip.OrderBy(x=>x.Id).ToList();
		}

		public Task<Equipment?> UpdateAsync(Equipment factory)
		{
			throw new NotImplementedException();
		}
	}
}
