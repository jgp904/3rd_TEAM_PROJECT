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
        public int Id { get; set; } // PK
        public string FactoryCode { get; set; }// 공장코드 UQ
        public string FactoryName { get; set; }//공장명
		public string Constructor { get; set; }//생성자
		public DateTime RegDate { get; set; }//생성일자
		public string Modifier { get; set; }//수정자
		public DateTime? ModDate { get; set; }//수정일자

	}
}
