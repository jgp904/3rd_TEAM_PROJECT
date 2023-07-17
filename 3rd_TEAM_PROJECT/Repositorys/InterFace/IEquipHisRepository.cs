using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys.InterFace
{
    public interface IEquiHisRepository
    {
        Task<EquipHis> AddEquipHisAsync(EquipHis factory);
    }
}
