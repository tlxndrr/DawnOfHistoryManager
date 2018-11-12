using DawnOfHistoryManager.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class GameContext : DbContext
    {
        //Reference data
        public DbSet<Civ>         Civs         { get; set; }
        public DbSet<Ability>     Abilities    { get; set; }

        public void ListAsync()
        {
            throw new NotImplementedException();
        }

        public DbSet<Advancement> Advancements { get; set; }

        //Active data
        public DbSet<ActiveCiv>        ActiveCivs        { get; set; }
        public DbSet<OwnedAdvancement> OwnedAdvancements { get; set; }

        public GameContext(DbContextOptions<GameContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Database Seeding - Civilizations, Advancements, and Abilities
            modelBuilder.Entity<Civ>().HasData(Iteration1Seeder.GetSeedCivilizations());
            modelBuilder.Entity<Advancement>().HasData(Iteration1Seeder.GetSeedAdvancements());
            modelBuilder.Entity<Ability>().HasData(Iteration1Seeder.GetSeedAbilities());
        }
    }
}
