﻿using _3rd_TEAM_PROJECT.Models.WareHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Repositorys
{
    public interface IOutboundRepository
    {
        //출고 실행 => 창고의 수량 감소
        Task<OutBound> ReleaseAsync(OutBound outBound);

        //출고 취소 => 창고의 수량 증가
        Task<OutBound?> DisReleasedAsync(OutBound outBound);

        //내역 수정
        Task<OutBound?> UpdateAsync(OutBound original, OutBound updated);
    }
}