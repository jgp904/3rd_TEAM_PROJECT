using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys.InterFace
{
	public interface IEquipmentRepository
	{
		Task<IEnumerable<Equipment>> GetAllAsync();
		Task<Equipment> AddAsync(Equipment factory);
		Task<Equipment?> UpdateAsync(Equipment factory);
		Task<Equipment?> DeleteAsync(Equipment factory);
	}
}
