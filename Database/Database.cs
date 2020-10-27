using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Database
{
    public class Database : DbContext, IDatabase
    {
        private DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=127.0.0.1;Database=Handball;Integrated Security=true;Persist Security Info=true");
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public List<Team> AllTeams()
        {
            return Teams.ToList();
        }

        public void DeleteTeam(Team team)
        {
            Teams.Remove(team);
            SaveChanges();
        }

        public void UpdateTeam(Team team)
        {
            Teams.Update(team);
        }
    }
}
