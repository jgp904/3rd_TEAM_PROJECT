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

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public class LotRepository : ILotRepository
    {
        private readonly MProcessDbcontext mprocessdb;
        public LotRepository()
        {
            mprocessdb = Program.mprocessdb;
        }
        public async Task<CreateLot> AddAsync(CreateLot lots)
        {
            await mprocessdb.CreateLots.AddAsync(lots);
            await mprocessdb.SaveChangesAsync();
            var lotHis = new LotHis
            {
                Code = lots.Code,
                Amount1 = lots.Amount1,
                Amount2 = lots.Amount2,
                StockUnit1 = lots.StockUnit1,
                StockUnit2 = lots.StockUnit2,

                ActionTime = lots.ActionTime,
                ActionCode = lots.ActionCode,

                HisNum = lots.HisNum,
                ProcessCode = lots.ProcessCode,
                ItemCode = lots.ItemCode,
                EquipCode = lots.EquipCode,

                Constructor = lots.Constructor,
                RegDate = lots.RegDate,
            };
            await mprocessdb.LotHis.AddAsync(lotHis);
            await mprocessdb.SaveChangesAsync();
            return lots;
        }


        public async Task<CreateLot?> DeleteAsync(int lots)
        {
            var existingLot = await mprocessdb.CreateLots.FindAsync(lots);
            if (existingLot == null) return null;

            mprocessdb.CreateLots.Remove(existingLot);
            await mprocessdb.SaveChangesAsync();
            return existingLot;
        }

        public async Task<CreateLot?> UpdateAsync(CreateLot lots)
        {
            var existingLot = await mprocessdb.CreateLots.FindAsync(lots.Id);
            int hisnum = existingLot.HisNum + 1;
            if (existingLot == null) return null;

            existingLot.Code = lots.Code;
            existingLot.Amount1 = lots.Amount1;
            existingLot.Amount2 = lots.Amount2;
            existingLot.StockUnit1 = lots.StockUnit1;
            existingLot.StockUnit2 = lots.StockUnit2;

            existingLot.ActionCode = lots.ActionCode;
            existingLot.ActionTime = lots.ActionTime;
            existingLot.HisNum = hisnum;
            existingLot.ProcessCode = lots.ProcessCode;
            existingLot.NextProcessCode = lots.NextProcessCode;
            existingLot.ItemCode = lots.ItemCode;
            existingLot.EquipCode = lots.EquipCode;

            existingLot.Modifier = lots.Modifier;
            existingLot.ModDate = lots.ModDate;

            await mprocessdb.SaveChangesAsync();
            var lotHis = new LotHis
            {
                Code = existingLot.Code,
                Amount1 = existingLot.Amount1,
                Amount2 = existingLot.Amount2,

                StockUnit1 = existingLot.StockUnit1,
                StockUnit2 = existingLot.StockUnit2,

                ActionTime = existingLot.ActionTime,
                ActionCode = existingLot.ActionCode,

                HisNum = existingLot.HisNum,
                ProcessCode = existingLot.ProcessCode,
                ItemCode = existingLot.ItemCode,
                EquipCode = existingLot.EquipCode,

                Constructor = existingLot.Constructor,
                RegDate = existingLot.RegDate,
                Modifier = existingLot.Modifier,
                ModDate = existingLot.ModDate,
            };
            await mprocessdb.LotHis.AddAsync(lotHis);
            await mprocessdb.SaveChangesAsync();
           

            return existingLot;
        }
       

        public async Task<IEnumerable<CreateLot>> GetAllAsync()
        {
            var lots = await mprocessdb.CreateLots.ToListAsync();
            return lots.OrderBy(x => x.Id).ToList();
        }
        public async Task<IEnumerable<LotHis>> GetAllHisAsync()
        {
            var lots = await mprocessdb.LotHis.ToListAsync();
            return lots.OrderByDescending(x => x.Id).ToList();
        }
        public async Task<IEnumerable<CreateLot>> CodeAsync(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.Code != null && x.Code.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }
        public async Task<IEnumerable<CreateLot>> ConstAsync(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.Constructor != null && x.Constructor.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreateLot>> ItemCodeAsync(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.ItemCode != null && x.ItemCode.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreateLot>> ModiAsync(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.Modifier != null && x.Modifier.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreateLot>> ProcessCodeAsync(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.ProcessCode != null && x.ProcessCode.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreateLot>> ActionCode(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x => (x.ActionCode != null && x.ActionCode.Contains(search)))
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<LotHis>> HisAsync(string search)
        {
            return await mprocessdb.LotHis
                .Where(x => (x.Code != null && x.Code.Contains(search)))
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<IEnumerable<CreateLot>> EquipCode(string search)
        {
            return await mprocessdb.CreateLots
                .Where(x=>(x.EquipCode != null && x.EquipCode.Contains(search)))
                .OrderByDescending(x=>x.Id)
                .ToListAsync();
        }
    }
}
