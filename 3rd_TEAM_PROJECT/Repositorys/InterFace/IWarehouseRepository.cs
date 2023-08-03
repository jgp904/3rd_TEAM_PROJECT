using _3rd_TEAM_PROJECT.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys.InterFace
{
    public interface IWarehouseRepository
    {
        //재고 리스트 가져오기
        Task<IEnumerable<WareHouse>> GetAllAsync();

        //재고 검색
        Task<IEnumerable<WareHouse>> GetProductAsync(string text);

    }
}
