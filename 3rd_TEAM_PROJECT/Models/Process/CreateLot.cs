using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
	[Table("T1_CreateLot")]
	public class CreateLot
    {
        public int Id { get; set; }// PK
        public string Code { get; set; } // UQ

       

        public int Amount { get; set; }
        public DateTime Action { get; set; }
        public int HisNum { get; set; }
        public string ProcessCode { get; set; }

		public string Constructor { get; set; }
		public DateTime RegDate { get; set; }
		public string? Modifier { get; set; }
		public DateTime? ModDate { get; set; }

		public Item Item { get; set; } // FK
		public MProcess Process { get; set; }// FK

	}
}
