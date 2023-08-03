using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.WareHouse;
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
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly AccountDbContext accountDb;
        private readonly MProcessDbcontext mprocessDb;

        public WarehouseRepository(AccountDbContext accountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.accountDb = accountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        //창고 목록 불러오기
        public async Task<IEnumerable<WareHouse>> GetAllAsync()
        {
            var items = await mprocessDb.WareHouses.ToListAsync();
            return items.OrderByDescending(x => x.Id).ToList();
        }

        public async Task<IEnumerable<WareHouse>> GetProductAsync(string text)
        {
            text = text.ToLower();

            return await mprocessDb.WareHouses
                .Where(WareHouses =>
                    (WareHouses.Product != null && WareHouses.Product.ToLower().Contains(text)) ||
                    (WareHouses.Item != null && WareHouses.Item.ToLower().Contains(text)))
                .OrderBy(warehouse => warehouse.Id)
                .ToListAsync();
        }

    }
}
