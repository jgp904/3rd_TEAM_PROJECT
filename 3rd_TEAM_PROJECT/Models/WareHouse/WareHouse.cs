using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.WareHouse
{
	[Table("T1_WareHouse")]
	public class WareHouse
	{
        public int Id { get; set; } // PK
        public string Product { get; set; }//UQ
        public string Item { get; set; }
        public int Amount { get; set; }
    }
}
