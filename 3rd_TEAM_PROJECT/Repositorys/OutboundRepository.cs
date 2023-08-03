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
    public class OutboundRepository : IOutboundRepository
    {
        //계정 테이블 DbContext
        private readonly AccountDbContext accountDb;
        //그 외 테이블 DbContext
        private readonly MProcessDbcontext mprocessDb;

        public OutboundRepository(AccountDbContext accountDbContext, MProcessDbcontext mProcessDbcontext)
        {
            this.accountDb = accountDbContext;
            this.mprocessDb = mProcessDbcontext;
        }

        //출고 내역 불러오기
        public async Task<IEnumerable<OutBound>> GetAllAsync()
        {
            var items = await mprocessDb.OutBounds.ToListAsync();
            return items.OrderBy(x => x.Id).ToList();
        }

        //추가
        //창고에서 수량 감소
        public async Task<OutBound> ReleaseAsync(OutBound outBound)
        {
            // 창고에서 해당 상품을 찾습니다.
            var wareHouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == outBound.Product);

            if (wareHouseItem == null)
            {
                MessageBox.Show("해당 상품이 창고에 없습니다.");
                return null;
            }

            if (wareHouseItem.Amount < outBound.Amount)
            {
                MessageBox.Show("창고의 재고 수량이 출고하려는 수량보다 적습니다.");
                return null;
            }

            // 창고의 상품 수량을 출고 수량만큼 감소시킵니다.
            wareHouseItem.Amount -= outBound.Amount;

            // 출고 내역을 저장합니다.
            mprocessDb.OutBounds.Add(outBound);

            await mprocessDb.SaveChangesAsync();

            return outBound;
        }

        //수정
        public async Task<OutBound?> UpdateAsync(OutBound original, OutBound updated)
        {
            // 창고에서 원본 출고 내역의 상품을 찾아 수량을 원상 복구합니다.
            var wareHouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == original.Product);
            if (wareHouseItem != null)
            {
                wareHouseItem.Amount += original.Amount;
            }

            // 수정된 출고 내역에 따라 창고에서 상품을 다시 감소시킵니다.
            wareHouseItem = await mprocessDb.WareHouses.FirstOrDefaultAsync(w => w.Product == updated.Product);
            if (wareHouseItem != null)
            {
                // 수정된 수량이 현재 창고에 있는 수량보다 많다면 에러를 반환합니다.
                if (wareHouseItem.Amount < updated.Amount)
                {
                    MessageBox.Show("창고의 재고 수량이 출고하려는 수량보다 적습니다.");
                }

                wareHouseItem.Amount -= updated.Amount;
            }

            // 출고 내역을 수정합니다.
            var outBoundItem = await mprocessDb.OutBounds.FirstOrDefaultAsync(ob => ob.Id == original.Id);
            if (outBoundItem != null)
            {
                outBoundItem.Product = updated.Product;
                outBoundItem.Item = updated.Item;
                outBoundItem.Amount = updated.Amount;
                outBoundItem.MProcessCode = updated.MProcessCode;
                outBoundItem.Contact = updated.Contact;
                // 기타 필요한 필드를 여기에 추가하세요.
            }

            await mprocessDb.SaveChangesAsync();

            return updated;
        }

        //내역 검색
        public async Task<IEnumerable<OutBound>> GetProductAsync(string text)
        {
            // 입력받은 텍스트를 소문자로 변환합니다.
            text = text.ToLower();

            // 출고 내역에서 입력받은 텍스트와 일치하는 내역을 검색합니다.
            var outbounds = await mprocessDb.OutBounds
                .Where(ob => ob.Product.ToLower().Contains(text)
                             || ob.Item.ToLower().Contains(text)
                             || ob.MProcessCode.ToLower().Contains(text)
                             || ob.Contact.ToLower().Contains(text))
                .ToListAsync();

            return outbounds;
        }

    }
}
