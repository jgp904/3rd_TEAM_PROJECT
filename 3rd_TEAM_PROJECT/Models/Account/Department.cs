using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Account
{
    [Table("T1_Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } //부서명
        public string DepartmentCode { get; set; } //부서코드
    }
}
