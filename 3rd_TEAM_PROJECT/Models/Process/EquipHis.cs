using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    public class EquipHis : Equipment
    {
       
        public string Code { get; set; } //설비코드
        public string Name { get; set; } //설비명
        public string? Comment { get; set; } //설명
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
        public string? Modifier { get; set; }
        public DateTime? ModDate { get; set; }
        Equipment? Equipment { get; set; }
    }
}
