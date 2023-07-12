using _3rd_TEAM_PROJECT.Models;
using _3rd_TEAM_PROJECT.Models.Acount;
using _3rd_TEAM_PROJECT.Models.Process;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rd_TEAM_PROJECT.Data
{
    internal class AcountDbContext : DbContext
	{
		/*로그인 : user0706 / 1234
		DB : LTDB*/
		string strConn = "Server=127.0.0.1; Database=LTDB; uid=user0706; pwd=1234; Encrypt=false";

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer(strConn)
				.LogTo(message => Debug.WriteLine(message))   // 디버그모드에서 '출력' 창에 표시
				.EnableSensitiveDataLogging()
				;
		}
		public DbSet<Acount> Acounts { get; set; }
		public DbSet<Department> Departments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Acount>()
				.HasIndex(j => j.UserId)
				.IsUnique();
		}
	}
}
