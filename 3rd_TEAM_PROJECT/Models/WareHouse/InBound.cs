using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.WareHouse
{
	[Table("T1_InBound")]
	public class InBound
	{
        public long Id { get; set; }
		public string Product { get; set; }
		public string Item { get; set; }

		public int Amount { get; set; }
        public string Vendor { get; set; }



		public DateTime RegDate { get; set; }
        public string Contact { get; set; }

        public WareHouse? WareHouse { get; set; }
    }
}
