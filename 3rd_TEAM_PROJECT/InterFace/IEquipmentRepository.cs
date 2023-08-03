using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.InterFace
{
    public interface IEquipmentRepository
    {
        Task<IEnumerable<Equipment>> GetAllAsync();
        Task<IEnumerable<EquipHis>> GetAllHisAsync();
        Task<Equipment> AddAsync(Equipment equipment);

        Task<Equipment?> UpdateAsync(Equipment equipment);
        Task<Equipment?> DeleteAsync(int equipment);
        Task<EquipHis?> DeleteHisAsync(int equipment);

        Task<IEnumerable<EquipHis>> HisAsync(string search);

        Task<IEnumerable<Equipment>> CodeAsync(string search);
        Task<IEnumerable<Equipment>> ProcessCodeAsync(string search);
        Task<IEnumerable<Equipment>> NameAsync(string search);
        Task<IEnumerable<Equipment>> StatusAsync(string search);
        Task<IEnumerable<Equipment>> EventAsync(string search);
        Task<IEnumerable<Equipment>> ConstAsync(string search);
        Task<IEnumerable<Equipment>> ModiAsync(string search);
        Task<IEnumerable<EquipHis>> DeleteHis(string search);
    }
}
