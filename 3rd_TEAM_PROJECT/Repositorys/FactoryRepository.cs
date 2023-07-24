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
using static System.Net.Mime.MediaTypeNames;

namespace _3rd_TEAM_PROJECT.Repositorys
{

    public class FactoryRepository : IFactoryRepository
	{
		private readonly MProcessDbcontext mprocessdb;

	

		public FactoryRepository()
		{
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
		public async Task<Factory?> UpdateAsync(Factory factory)
		{
			var existingFactory = await mprocessdb.Factories.FindAsync(factory.Id);
			if (existingFactory == null)return null;

			existingFactory.Code = factory.Code;
			existingFactory.Name = factory.Name;
			existingFactory.Modifier = factory.Modifier;
			existingFactory.ModDate = factory.ModDate;

			await mprocessdb.SaveChangesAsync();
			return existingFactory;
		}
		public async Task<IEnumerable<Factory>> CodeAsync(string search)
		{
			return await mprocessdb.Factories
			.Where(x =>(x.Code != null && x.Code.Contains(search)))
			.OrderBy(x => x.Id)
			.ToListAsync();
		}

		public async Task<IEnumerable<Factory>> NameAsync(string search)
		{
			return await mprocessdb.Factories
			.Where(x => (x.Name != null && x.Name.Contains(search)))
			.OrderBy(x => x.Id)
			.ToListAsync();
		}

		public async Task<IEnumerable<Factory>> ConstAsync(string search)
		{
			return await mprocessdb.Factories
			.Where(x => (x.Constructor != null && x.Constructor.Contains(search)))
			.OrderBy(x => x.Id)
			.ToListAsync();
		}

		public async Task<IEnumerable<Factory>> ModiAsync(string search)
		{
			return await mprocessdb.Factories
			.Where(x => (x.Modifier != null && x.Modifier.Contains(search)))
			.OrderBy(x => x.Id)
			.ToListAsync();
		}
	}
}
