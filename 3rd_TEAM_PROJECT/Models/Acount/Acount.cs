using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Acount
{
    [Table("T1_Acount")]
	public class Acount
	{
        public int Id { get; set; } //PK
        //ToDo UQ 설정		
		public string UserId { get; set; } // 사용자 아이디 UQ
        public string Name { get; set; } // 사용자 이름
        public string DepartmentCode { get; set; } // 부서코드
        public string Position { get; set; } // 직급
        public int Authority { get; set; } = 1; // 관리 권한
        public string PassWord { get; set; } //비밀번호

        public DateTime RegDate { get; set; }// 입사일
        public Department? Department { get; set; }//FK
    }
}
