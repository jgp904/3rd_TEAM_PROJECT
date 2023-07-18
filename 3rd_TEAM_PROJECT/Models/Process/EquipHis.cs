using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    [Table("T1_EquipHis")]
    public class EquipHis : Equipment
    {
        public int Id { get; set; }

        Equipment? Equipment { get; set; }
    }
}
