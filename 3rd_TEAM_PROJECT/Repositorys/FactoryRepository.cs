using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT_Desk;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{

	public class FactoryRepository : IFactoryRepository
	{
		private readonly AcountDbContext acountdb;
		private readonly MProcessDbcontext mprocessdb;

		private readonly IFactoryRepository factoryRepository;

		public FactoryRepository()
		{
			acountdb = Program.acountdb;
			mprocessdb = Program.mprocessdb;
		}
		public async Task<Factory> AddAsync(Factory factory)
		{
			await mprocessdb.Factories.AddAsync(factory);
			await mprocessdb.SaveChangesAsync();
			return factory;
		}

		public async Task<Factory?> DeleteAsync(int factory)
		{
			var existingFatory = await mprocessdb.Factories.FindAsync(factory);
			if (existingFatory == null)return null;

			mprocessdb.Factories.Remove(existingFatory);
			await mprocessdb.SaveChangesAsync();
			return existingFatory;
		}

		public async Task<IEnumerable<Factory>> GetAllAsync()
		{
			var items = await mprocessdb.Factories.ToListAsync();
			return items.OrderBy(x=>x.Id).ToList();
		}

		public Task<Factory?> UpdateAsync(Factory factory)
		{
			throw new NotImplementedException();
		}
	}
}
