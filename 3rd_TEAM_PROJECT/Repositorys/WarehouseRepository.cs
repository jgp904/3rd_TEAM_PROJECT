using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT_Desk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AcountDbContext acountDb;
        private readonly MProcessDbcontext mprocessDb;

        public WarehouseRepository(AcountDbContext acountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.acountDb = acountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }
    }
}
