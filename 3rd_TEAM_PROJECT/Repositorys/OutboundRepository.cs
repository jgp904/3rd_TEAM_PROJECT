using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.WareHouse;
using _3rd_TEAM_PROJECT.Repositorys.InterFace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public class OutboundRepository : IOutboundRepository
    {
        //계정 테이블 DbContext
        private readonly AcountDbContext acountDb;
        //그 외 테이블 DbContext
        private readonly MProcessDbcontext mprocessDb;

        public OutboundRepository(AcountDbContext acountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.acountDb = acountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        public Task<OutBound?> DisReleasedAsync(OutBound outBound)
        {
            throw new NotImplementedException();
        }

        public Task<OutBound> ReleaseAsync(OutBound outBound)
        {
            throw new NotImplementedException();
        }

        public Task<OutBound?> UpdateAsync(OutBound original, OutBound updated)
        {
            throw new NotImplementedException();
        }
    }
}
