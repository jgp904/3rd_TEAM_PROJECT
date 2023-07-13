using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.WareHouse
{
	[Table("T1_InBound")]
	public class InBound
	{
        //입고 테이블
        public long Id { get; set; }    //입고번호
		public string Product { get; set; } //품명
        public int Amount { get; set; }     //수량
        public string Vendor { get; set; }  //거래처

        public string Item { get; set; }    //품목

        public DateTime RegDate { get; set; }   //입고날짜
        public string Contact { get; set; } //담당자

        public WareHouse? WareHouse { get; set; }   //FK
    }
}
