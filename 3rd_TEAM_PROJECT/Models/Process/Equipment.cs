using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    [Table("T1_Equipment")]
    public class Equipment
	{
		public int Id { get; set; }//PK
		public string Code { get; set; }
		public string Name { get; set; }
		public string? Comment { get; set; }
		public string Status { get; set; }
		public string Event { get; set; }

		public string Constructor { get; set; }
		public DateTime RegDate { get; set; }
		public string? Modifier { get; set; }
		public DateTime?  ModDate { get; set; }

		
	}
}
