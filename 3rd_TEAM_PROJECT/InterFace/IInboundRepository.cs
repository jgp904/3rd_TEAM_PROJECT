using _3rd_TEAM_PROJECT.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.InterFace
{
    public interface IInboundRepository
    {
        //입고 목록 가져오기
        Task<IEnumerable<InBound>> GetAllAsync();

        //입고 내역 수정
        Task<InBound?> UpdateAsync(InBound original, InBound updated);

        //입고 추가
        Task<InBound> AddAsync(InBound inbound);

        //내역 검색
        Task<IEnumerable<InBound>> GetProductAsync(string text);
    }
}
