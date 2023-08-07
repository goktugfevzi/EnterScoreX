﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(EnterScoreXContext))]
    partial class EnterScoreXContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityLayer.Concrete.Coach", b =>
                {
                    b.Property<int>("CoachID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoachID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoachID");

                    b.ToTable("Coachs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ContactUs", b =>
                {
                    b.Property<int>("ContactUsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactUsID"), 1L, 1);

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("MessageStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContactUsID");

                    b.ToTable("ContactUses");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Fixture", b =>
                {
                    b.Property<int>("FixtureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FixtureID"), 1L, 1);

                    b.Property<int>("AwayTeamID")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamID")
                        .HasColumnType("int");

                    b.Property<int>("SeasonID")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int");

                    b.Property<bool>("WeekCompleted")
                        .HasColumnType("bit");

                    b.HasKey("FixtureID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("HomeTeamID");

                    b.HasIndex("SeasonID");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Goal", b =>
                {
                    b.Property<int>("GoalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoalID"), 1L, 1);

                    b.Property<int?>("GoalAgainstTeamID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("GoalForTeamID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("GoalTime")
                        .HasColumnType("int");

                    b.Property<int>("MatchID")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("GoalID");

                    b.HasIndex("GoalAgainstTeamID");

                    b.HasIndex("GoalForTeamID");

                    b.HasIndex("MatchID");

                    b.HasIndex("PlayerID");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Match", b =>
                {
                    b.Property<int>("MatchID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MatchID"), 1L, 1);

                    b.Property<int?>("AwayTeamAirealDualSuccess")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamFoulCount")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamGoals")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamPassSuccess")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamShots")
                        .HasColumnType("int");

                    b.Property<int?>("AwayTeamShotsOnTarget")
                        .HasColumnType("int");

                    b.Property<int?>("FixtureID")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamAirealDualSuccess")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamFoulCount")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamGoals")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamPassSuccess")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamShots")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamShotsOnTarget")
                        .HasColumnType("int");

                    b.Property<int?>("RefereeID")
                        .HasColumnType("int");

                    b.Property<int?>("StadiumID")
                        .HasColumnType("int");

                    b.HasKey("MatchID");

                    b.HasIndex("AwayTeamID");

                    b.HasIndex("FixtureID");

                    b.HasIndex("HomeTeamID");

                    b.HasIndex("RefereeID");

                    b.HasIndex("StadiumID");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("PositionID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("SavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamID")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("PlayerID");

                    b.HasIndex("PositionID");

                    b.HasIndex("TeamID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PlayerStatistic", b =>
                {
                    b.Property<int>("PlayerStatisticID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlayerStatisticID"), 1L, 1);

                    b.Property<int>("AsistScore")
                        .HasColumnType("int");

                    b.Property<int>("GoalScore")
                        .HasColumnType("int");

                    b.Property<int>("PlayerID")
                        .HasColumnType("int");

                    b.HasKey("PlayerStatisticID");

                    b.HasIndex("PlayerID");

                    b.ToTable("PlayerStatistics");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PositionID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionID");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Referee", b =>
                {
                    b.Property<int>("RefereeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefereeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefereeID");

                    b.ToTable("Referees");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Season", b =>
                {
                    b.Property<int>("SeasonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SeasonTime")
                        .HasColumnType("datetime2");

                    b.HasKey("SeasonID");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Stadium", b =>
                {
                    b.Property<int>("StadiumID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StadiumID"), 1L, 1);

                    b.Property<string>("Capacity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StadiumID");

                    b.ToTable("Stadiums");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"), 1L, 1);

                    b.Property<int>("CoachID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedFileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SavedUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StadiumID")
                        .HasColumnType("int");

                    b.HasKey("TeamID");

                    b.HasIndex("CoachID");

                    b.HasIndex("StadiumID");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("EntityLayer.Concrete.TeamStatistic", b =>
                {
                    b.Property<int>("TeamStatisticID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamStatisticID"), 1L, 1);

                    b.Property<int?>("Average")
                        .HasColumnType("int");

                    b.Property<int?>("DrawCount")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsAgainst")
                        .HasColumnType("int");

                    b.Property<int?>("GoalsFor")
                        .HasColumnType("int");

                    b.Property<int?>("LoseCount")
                        .HasColumnType("int");

                    b.Property<int?>("PlayedCount")
                        .HasColumnType("int");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<int?>("WinCount")
                        .HasColumnType("int");

                    b.HasKey("TeamStatisticID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamStatistics");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Fixture", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Team", "AwayTeam")
                        .WithMany("AwayResult")
                        .HasForeignKey("AwayTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Team", "HomeTeam")
                        .WithMany("HomesResult")
                        .HasForeignKey("HomeTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayTeam");

                    b.Navigation("HomeTeam");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Goal", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Team", "GoalAgainstTeam")
                        .WithMany("GoalAgainstTeam")
                        .HasForeignKey("GoalAgainstTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Team", "GoalForTeam")
                        .WithMany("GoalForTeam")
                        .HasForeignKey("GoalForTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Match", "Match")
                        .WithMany("Goals")
                        .HasForeignKey("MatchID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Player", "player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GoalAgainstTeam");

                    b.Navigation("GoalForTeam");

                    b.Navigation("Match");

                    b.Navigation("player");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Match", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Team", "AwayTeam")
                        .WithMany("AwayMatches")
                        .HasForeignKey("AwayTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Fixture", "Fixture")
                        .WithMany("Matches")
                        .HasForeignKey("FixtureID");

                    b.HasOne("EntityLayer.Concrete.Team", "HomeTeam")
                        .WithMany("HomesMatches")
                        .HasForeignKey("HomeTeamID")
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Referee", "Referee")
                        .WithMany()
                        .HasForeignKey("RefereeID");

                    b.HasOne("EntityLayer.Concrete.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("StadiumID");

                    b.Navigation("AwayTeam");

                    b.Navigation("Fixture");

                    b.Navigation("HomeTeam");

                    b.Navigation("Referee");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Player", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamID");

                    b.Navigation("Position");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityLayer.Concrete.PlayerStatistic", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Team", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Stadium", "Stadium")
                        .WithMany()
                        .HasForeignKey("StadiumID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("EntityLayer.Concrete.TeamStatistic", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Team", "Team")
                        .WithMany("Statistics")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Fixture", b =>
                {
                    b.Navigation("Matches");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Match", b =>
                {
                    b.Navigation("Goals");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Team", b =>
                {
                    b.Navigation("AwayMatches");

                    b.Navigation("AwayResult");

                    b.Navigation("GoalAgainstTeam");

                    b.Navigation("GoalForTeam");

                    b.Navigation("HomesMatches");

                    b.Navigation("HomesResult");

                    b.Navigation("Players");

                    b.Navigation("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}
