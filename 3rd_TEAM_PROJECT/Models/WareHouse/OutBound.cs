﻿using _3rd_TEAM_PROJECT.Models.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Models
{
	public class OutBound
	{
		public long Id { get; set; }
		public DateTime RegDate { get; set; }
		public string Contact { get; set; }

		public WareHouse? WareHouse { get; set; }
		public MProcess? MProcess { get; set; }
		
	}
}
