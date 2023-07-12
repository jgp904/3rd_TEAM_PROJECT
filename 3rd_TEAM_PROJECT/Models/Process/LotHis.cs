using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
	[Table("T1_LotHis")]
	internal class LotHis
    {
        public int Id { get; set; }//PK

		public DateTime? ModDate { get; set; }
		public string? Modifier { get; set; }
        public CreateLot? CreateLot { get; set; }
	}
}
