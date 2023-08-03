using _3rd_TEAM_PROJECT.Data;
using _3rd_TEAM_PROJECT.InterFace;
using _3rd_TEAM_PROJECT.Models.WareHouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public class InboundRepository : IInboundRepository
    {
        //계정 테이블 DbContext
        private readonly AccountDbContext accountDb;
        //그 외 테이블 DbContext
        private readonly MProcessDbcontext mprocessDb;

        public InboundRepository(AccountDbContext accountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.accountDb = accountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        //입고 추가 하면 창고에 적재되어야 한다
        public async Task<InBound> AddAsync(InBound inbound)
        {
            // 입고 내역을 저장합니다.
            mprocessDb.InBounds.Add(inbound);

            // 창고에 상품을 적재합니다.
            var wareHouseItem = await mprocessDb
                .WareHouses
                .FirstOrDefaultAsync(w => w.Product == inbound.Product);
            if (wareHouseItem != null)
            {
                // 상품이 이미 존재하면 수량을 증가시킵니다.
                wareHouseItem.Amount += inbound.Amount;
            }
            else
            {
                // 새로운 상품이면 창고에 추가합니다.
                mprocessDb.WareHouses.Add(new WareHouse
                {
                    Product = inbound.Product,
                    Item = inbound.Item,
                    Amount = inbound.Amount,
                });
            }

            // 변경사항을 저장합니다.
            await mprocessDb.SaveChangesAsync();

            return inbound;
        }

        //입고 내역을 수정하면 창고에서도 수정되어야 한다
        public async Task<InBound?> UpdateAsync(InBound original, InBound updated)
        {
            // 원본 데이터 찾기
            var originalInbound = await mprocessDb.InBounds.FirstOrDefaultAsync(i => i.Id == original.Id);
            if (originalInbound == null)
            {
                // 원본 데이터를 찾을 수 없는 경우
                return null;
            }

            // 원본 Product 수량 감소
            var originalWarehouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == original.Product);
            if (originalWarehouseItem != null)
            {
                originalWarehouseItem.Amount -= original.Amount;
            }

            // 업데이트된 데이터 적용
            originalInbound.Product = updated.Product;
            originalInbound.Item = updated.Item;
            originalInbound.Amount = updated.Amount;
            originalInbound.Vendor = updated.Vendor;
            originalInbound.RegDate = updated.RegDate;

            // 업데이트된 Product 수량 증가
            var updatedWarehouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == updated.Product);
            if (updatedWarehouseItem != null)
            {
                updatedWarehouseItem.Amount += updated.Amount;
            }
            else
            {
                // 새로운 Product인 경우 창고에 추가
                mprocessDb.WareHouses.Add(new WareHouse
                {
                    Product = updated.Product,
                    Item = updated.Item,
                    Amount = updated.Amount
                });
            }

            // 변경사항 저장
            await mprocessDb.SaveChangesAsync();

            return originalInbound;
        }


        //입고 내역을 가져온다
        public async Task<IEnumerable<InBound>> GetAllAsync()
        {
            var items = await mprocessDb.InBounds.ToListAsync();
            return items.OrderByDescending(x => x.Id).ToList();
        }

        //입고 내역 검색 결과
        public async Task<IEnumerable<InBound>> GetProductAsync(string text)
        {
            text = text.ToLower();

            return await mprocessDb.InBounds
                .Where(inbound =>
                    (inbound.Product != null && inbound.Product.ToLower().Contains(text)) ||
                    (inbound.Vendor != null && inbound.Vendor.ToLower().Contains(text)) ||
                    (inbound.Item != null && inbound.Item.ToLower().Contains(text)) ||
                    (inbound.Contact != null && inbound.Contact.ToLower().Contains(text)))
                .OrderByDescending(inbound => inbound.Id)
                .ToListAsync();
        }
    }
}
