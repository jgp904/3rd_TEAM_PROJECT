using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
	[Table("T1_Item")]
	public class Item
    {
        public int Id { get; set; } // PK
        public string Code { get; set; }
		public string Name { get; set; } // vnaaud
        public string Type { get; set; }
		/*
		 * 품번타입
		 * 제품
		 * 반제품
		 * 원재료
		 */

		public string Constructor { get; set; }
		public DateTime RegDate { get; set; }
		public string? Modifier { get; set; }
		public DateTime? ModDate { get; set; }

		
	}
}
