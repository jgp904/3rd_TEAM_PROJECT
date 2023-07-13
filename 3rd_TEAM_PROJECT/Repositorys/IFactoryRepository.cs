using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
	public interface IFactoryRepository
	{
		Task<IEnumerable<Factory>> GetAllAsync();
		Task<Factory> AddAsync(Factory factory);
		Task<Factory?> UpdateAsync(Factory factory);
		Task<Factory?> DeleteAsync(int factory);
	}
}
