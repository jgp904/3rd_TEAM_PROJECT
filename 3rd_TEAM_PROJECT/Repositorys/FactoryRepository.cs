using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
	public class FactoryRepository : IFactoryRepository
	{

		public Task<Factory> AddAsync(Factory factory)
		{
			throw new NotImplementedException();
		}

		public Task<Factory?> DeleteAsync(Factory factory)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Factory>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Factory?> UpdateAsync(Factory factory)
		{
			throw new NotImplementedException();
		}
	}
}
