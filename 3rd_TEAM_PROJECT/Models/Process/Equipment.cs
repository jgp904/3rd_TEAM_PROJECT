using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    [Table("T1_Equipment")]
    public class Equipment
	{
		public int Id { get; set; }//PK
		public string Code { get; set; }
		public string Name { get; set; }
		public string? Comment { get; set; }
		public string Status { get; set; }
		/* 설비상태
		Ready : 생산준비상태
		Stop : 설비 작동 중지
		Process : 작업중
		*/
		public string Event { get; set; }
		/*설비이벤트
		 * 고장: BreakeDown
		 * 정비: Maintenance
		 * 위험: Emergency
		 * NON : NON
		 */

		public string Constructor { get; set; }
		public DateTime RegDate { get; set; }
		public string? Modifier { get; set; }
		public DateTime?  ModDate { get; set; }

		
	}
}
