using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
    [Table("T1_Factory")]
    public class Factory
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }

        public string Constructor { get; set; }
        public DateTime RegDate { get; set; }
        public string Modifier { get; set; }
        public DateTime? ModDate { get; set; }

    }
}
