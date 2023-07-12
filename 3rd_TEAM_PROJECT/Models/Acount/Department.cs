using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Acount
{
    [Table("T1_Department")]
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentCode { get; set; }
    }
}
