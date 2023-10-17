using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

using Microsoft.EntityFrameworkCore;
using TestProject.Players;
namespace TestProject.Models
{

    public enum Positions
    {
        GK, DF, MF, FWD
    }

    public class LeagueContext : DbContext
    {

        public LeagueContext(DbContextOptions<LeagueContext> Options) : base(Options)
        {

        }

        public DbSet<PlayerClass> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<TeamClass> Teams { get; set; }



    }
}

