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
		public string Contact { get; set; }
		public DateTime RegDate { get; set; }

<<<<<<< HEAD
        public WareHouse? WareHouse { get; set; }// 창고 Id
        public MProcess? MProcess { get; set; } // 공정 Id
       
    }
=======
		public WareHouse? WareHouse { get; set; }
		//Todo 공정 추가//
	}
>>>>>>> parent of 1ed34d0 (데이터베이스 구축)
}
