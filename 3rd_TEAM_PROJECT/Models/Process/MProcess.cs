using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    [Table("T1_MProcess")]
    public class MProcess
	{
		public int Id { get; set; }


		public Equipment Equipment { get; set; }
		public Factory Factory { get; set; }
	}
}
