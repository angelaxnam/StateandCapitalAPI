using System;
using Microsoft.EntityFrameworkCore;

namespace stateandcapitalapp_api.context
{
	public class PortfolioDbContext : DbContext
	{
		public DbSet<Capital> Capital { get; set; }
		public DbSet<Question> Question { get; set; }
		public DbSet<State> State{ get; set; }
		public DbSet<Score> Score { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			var connString = System.Environment.GetEnvironmentVariable("PG_CONNECTION");
			optionsBuilder.UseNpgsql(connString);
		}
	}
}