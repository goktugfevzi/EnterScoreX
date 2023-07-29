
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{

    public class EnterScoreXContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-ITA1D3N\\SQLEXPRESS;database= DbEnterScoreX;integrated security = true");
            //optionsBuilder.UseSqlServer("server=entescorexdb.database.windows.net;database=DbEnterScoreX;user=enterscore;password=Eskisehir26.");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(x => x.HomeTeam)
                .WithMany(y => y.HomesMatches)
                .HasForeignKey(z => z.HomeTeamID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Match>()
               .HasOne(x => x.AwayTeam)
               .WithMany(y => y.AwayMatches)
               .HasForeignKey(z => z.AwayTeamID)
               .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fixture>()
             .HasOne(x => x.HomeTeam)
             .WithMany(y => y.HomesResult)
             .HasForeignKey(z => z.HomeTeamID)
             .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Fixture>()
               .HasOne(x => x.AwayTeam)
               .WithMany(y => y.AwayResult)
               .HasForeignKey(z => z.AwayTeamID)
               .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<Goal>()
             .HasOne(x => x.GoalForTeam)
             .WithMany(y => y.GoalForTeam)
             .HasForeignKey(z => z.GoalForTeamID)
             .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Goal>()
               .HasOne(x => x.GoalAgainstTeam)
               .WithMany(y => y.GoalAgainstTeam)
               .HasForeignKey(z => z.GoalAgainstTeamID)
               .OnDelete(DeleteBehavior.ClientSetNull);



        }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Referee> Referees { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamStatistic> TeamStatistics { get; set; }

        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<RefereeDrive> RefereeDrives { get; set; }
    }
}
