﻿using _3rd_TEAM_PROJECT.Models;
using _3rd_TEAM_PROJECT.Models.Process;
using _3rd_TEAM_PROJECT.Models.WareHouse;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Data
{
	public class MProcessDbcontext : DbContext
	{
		/*로그인 : user0706 / 1234
		DB : LTDB*/
		string strConn = "Server=127.0.0.1; Database=LTDB; uid=user0706; pwd=1234; Encrypt=false";


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)// 데이터베이스를 연결하는 메서드
		{
			optionsBuilder
				.UseSqlServer(strConn)
				.LogTo(message => Debug.WriteLine(message))   // 디버그모드에서 '출력' 창에 표시
				.EnableSensitiveDataLogging()
				;
		}
		//각 속성 매핑
		//------------------공정---------------------------------//
		public DbSet<CreateLot> CreateLots { get; set; }
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<Factory> Factories { get; set; }
		public DbSet<Item> Items { get; set; }
		
		public DbSet<MProcess> MProcesses { get; set; }

		//--------------------창고-------------------------------//
		public DbSet<InBound> InBounds { get; set; }
		public DbSet<OutBound> OutBounds { get; set; }
		public DbSet<WareHouse> WareHouses { get; set; }
		//---------------------이력조회--------------------------//
		public DbSet<EquipHis> EquipHis { get; set; }
        public DbSet<LotHis> LotHis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CreateLot>()
				.HasIndex(j => j.Code)
				.IsUnique();
			modelBuilder.Entity<Equipment>()
				.HasIndex(j => j.Code)
				.IsUnique();
			modelBuilder.Entity<Factory>()
				.HasIndex(j => j.Code)
				.IsUnique();
			modelBuilder.Entity<Item>()
				.HasIndex(j => j.Code)
				.IsUnique();
			modelBuilder.Entity<Models.Process.MProcess>()
				.HasIndex(j => j.Code)
				.IsUnique();
			modelBuilder.Entity<WareHouse>()
				.HasIndex(j => j.Product)
				.IsUnique();

		}
	}
}
