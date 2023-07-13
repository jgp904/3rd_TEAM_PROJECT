using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.Models.WareHouse;
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
        private readonly AcountDbContext acountDb;
        private readonly MProcessDbcontext mprocessDb;

        public WarehouseRepository(AcountDbContext acountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.acountDb = acountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        #region 창고
        //창고에 추가
        public async Task<WareHouse> AddAsync(WareHouse wareHouse)
        {
            await mprocessDb.WareHouses.AddAsync(wareHouse);
            await mprocessDb.SaveChangesAsync();
            return wareHouse;
        }
        //창고 목록 삭제
        public async Task<WareHouse?> DeleteAsync(long id)
        {
            var existingItem = await mprocessDb.WareHouses.FindAsync(id);
            if (existingItem == null) return null;

            mprocessDb.WareHouses.Remove(existingItem);
            await mprocessDb.SaveChangesAsync();
            return existingItem;
        }
        //창고 목록 불러오기
        public async Task<IEnumerable<WareHouse>> GetAllAsync()
        {
            var items = await mprocessDb.WareHouses.ToListAsync();
            return items.OrderBy(x => x.Id).ToList();
        }
        //창고 수정
        public async Task<WareHouse?> UpdateAsync(WareHouse wareHouse)
        {
            var existingItem = await mprocessDb.WareHouses.FindAsync(wareHouse.Id);
            if (existingItem == null) return null;

            //existingItem.Barcode = WareHouses.Barcode;
            existingItem.Product = wareHouse.Product;
            existingItem.Item = wareHouse.Item;
            existingItem.Amount = wareHouse.Amount;

            await mprocessDb.SaveChangesAsync();
            return existingItem;
        }
        #endregion
    }
}
