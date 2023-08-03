using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys.InterFace
{
    public interface ILotRepository
    {
        Task<IEnumerable<CreateLot>> GetAllAsync();
        Task<IEnumerable<LotHis>> GetAllHisAsync();
        Task<CreateLot> AddAsync(CreateLot lots);
        Task<CreateLot?> UpdateAsync(CreateLot lots);
        Task<CreateLot?> DeleteAsync(int lots);
        Task<LotHis?> DeleteHisAsync(int lots);


        Task<IEnumerable<CreateLot>> CodeAsync(string search);
        Task<IEnumerable<CreateLot>> ProcessCodeAsync(string search);
        Task<IEnumerable<CreateLot>> ItemCodeAsync(string search);      
        Task<IEnumerable<CreateLot>> ConstAsync(string search);
        Task<IEnumerable<CreateLot>> ModiAsync(string search);
        Task<IEnumerable<CreateLot>> ActionCode(string search);
        Task<IEnumerable<LotHis>> ActionCodeHis(string search);
        Task<IEnumerable<CreateLot>> EquipCode(string search);

        Task<IEnumerable<LotHis>> HisAsync(string search);
    }
}
