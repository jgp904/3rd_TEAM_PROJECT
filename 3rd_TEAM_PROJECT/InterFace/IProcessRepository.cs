using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.InterFace
{
    public interface IProcessRepository
    {
        Task<IEnumerable<MProcess>> GetAllAsync();
        Task<MProcess> AddAsync(MProcess process);
        Task<MProcess?> UpdateAsync(MProcess process);
        Task<MProcess?> DeleteAsync(int process);
        Task<IEnumerable<MProcess>> CodeAsync(string search);
        Task<IEnumerable<MProcess>> FacCodeAsync(string search);
        Task<IEnumerable<MProcess>> NameAsync(string search);
        Task<IEnumerable<MProcess>> ConstAsync(string search);
        Task<IEnumerable<MProcess>> ModiAsync(string search);
    }
}
