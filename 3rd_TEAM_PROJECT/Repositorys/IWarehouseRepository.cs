using _3rd_TEAM_PROJECT.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public interface IWarehouseRepository
    {
        //재고 리스트 가져오기
        Task<IEnumerable<WareHouse>> GetAllAsync();

        ////재고 삭제
        //Task<WareHouse?> DeleteAsync(long id);

        ////재고 수정
        //Task<WareHouse?> UpdateAsync(WareHouse wareHouse);

        ////재고 추가
        //Task<WareHouse> AddAsync(WareHouse wareHouse);

    }
}
