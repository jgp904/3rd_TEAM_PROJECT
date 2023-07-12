using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models.Process
{
	[Table("T1_MProcess")]
	public class MProcess
	{
        public int Id { get; set; } // PK
        public string ProcessCode { get; set; } // UQ
        public string ProcessName { get; set; }
        public string? ProcessComent { get; set; } // Null허용
        public string? StockUnit1 { get; set;}
        public string? StockUnit2 { get; set;}
        public string Constructor { get; set; }
        public DateTime RegDate { get; set; }
        public string Modifier { get; set; }
        public DateTime? ModDate { get; set; }

        //설비


        //공장
        public Factory  Factories { get; set; }
    }
}
