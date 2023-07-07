using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models
{
	public class WareHouse
	{
        public int Id { get; set; } // PK
        public string Product { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
    }
}
