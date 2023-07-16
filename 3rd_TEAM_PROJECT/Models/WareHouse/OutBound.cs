using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.WareHouse
{
	[Table("T1_OutBound")]
	public class OutBound
	{
		public long Id { get; set; }
		public string Product { get; set; }	// 품번
		public string Item { get; set; }	// 품목
		public int Amount { get; set; }		// 수량
		public string MProcessCode { get; set; }//공정 코드
		public string Contact { get; set; }	//담당자
		public DateTime RegDate { get; set; }	//생성일자


        public WareHouse? WareHouse { get; set; }// 창고 Id
        public Process.MProcess? MProcess { get; set; } // 공정 Id
       
    }
}
