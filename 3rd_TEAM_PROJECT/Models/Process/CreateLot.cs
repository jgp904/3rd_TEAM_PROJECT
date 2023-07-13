﻿using System;
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
        public int Amount { get; set; }// 수량
        public DateTime ActionTime { get; set; }//실행시간
        public int HisNum { get; set; }//이력번호
        public string ActionCode { get; set; }// 실행코드
		public string ProcessCode { get; set; }// 공정코드
		public string ItemCode { get; set; } // 품번
		

		public string Constructor { get; set; } //생성자
		public DateTime RegDate { get; set; } //생성일자
		public string? Modifier { get; set; } //수정자
		public DateTime? ModDate { get; set; } //수정일자

		public Item? Item { get; set; } // FK 품번
		public MProcess? Process { get; set; }// FK 공정

	}
}
