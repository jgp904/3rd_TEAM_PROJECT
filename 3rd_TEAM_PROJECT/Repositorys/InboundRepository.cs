using _3rd_TEAM_PROJECT.Data;
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
        private readonly AcountDbContext acountDb;
        //그 외 테이블 DbContext
        private readonly MProcessDbcontext mprocessDb;

        public InboundRepository(AcountDbContext acountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.acountDb = acountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        //입고 추가 하면 창고에 적재되어야 한다
        public async Task<InBound> AddAsync(InBound inbound)
        {
            // 현재 로그인한 사용자의 이름을 담당자로 설정합니다.
            inbound.Contact = SessionManager.Instance.LoggedInAcount.Name;

            // 입고 내역을 저장합니다.
            mprocessDb.InBounds.Add(inbound);

            // 창고에 상품을 적재합니다.
            var wareHouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == inbound.Product);
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
                    Amount = inbound.Amount
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
            return items.OrderBy(x => x.Id).ToList();
        }

        //입고 내역 검색 결과
        public async Task<IEnumerable<InBound>> GetProductAsync(string text)
        {
            return await mprocessDb.InBounds
                .Where(inbound =>
                    (inbound.Product != null && inbound.Product.Contains(text)) ||
                    (inbound.Vendor != null && inbound.Vendor.Contains(text)) ||
                    (inbound.Item != null && inbound.Item.Contains(text)) ||
                    (inbound.Contact != null && inbound.Contact.Contains(text)))
                .OrderBy(inbound => inbound.Id)
                .ToListAsync();
        }
    }
}
