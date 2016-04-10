using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Ddhp.v2016.Models;

namespace Ddhp.v2016.Migrations.Ddhp
{
    [DbContext(typeof(DdhpContext))]
    [Migration("20160410114346_RoundComplete")]
    partial class RoundComplete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ddhp.v2016.Models.Afl.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClubName");

                    b.Property<string>("ShortClubName");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "afl");

                    b.HasAnnotation("Relational:TableName", "Clubs");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Ddhp.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CoachName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "ddhp");

                    b.HasAnnotation("Relational:TableName", "Clubs");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Ddhp.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClubId");

                    b.Property<int>("FromRoundId");

                    b.Property<int>("PlayerId");

                    b.Property<int>("ToRoundId");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "ddhp");

                    b.HasAnnotation("Relational:TableName", "Contracts");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Ddhp.Round", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsLadderRound");

                    b.Property<bool>("RoundComplete");

                    b.Property<int>("RoundNumber");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:Schema", "ddhp");

                    b.HasAnnotation("Relational:TableName", "Rounds");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentAflClubId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleNames");

                    b.Property<bool>("Retired");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Players");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Stat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AflClubId");

                    b.Property<int>("Behinds");

                    b.Property<int>("Disposals");

                    b.Property<int?>("FreesAgainst");

                    b.Property<int?>("FreesFor");

                    b.Property<int?>("GoalAssists");

                    b.Property<int>("Goals");

                    b.Property<int>("Handballs");

                    b.Property<int>("Hitouts");

                    b.Property<int?>("Inside50s");

                    b.Property<int>("Kicks");

                    b.Property<int>("Marks");

                    b.Property<int>("PlayerId");

                    b.Property<int>("RoundId");

                    b.Property<int>("Tackles");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Stats");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Ddhp.Contract", b =>
                {
                    b.HasOne("Ddhp.v2016.Models.Ddhp.Club")
                        .WithMany()
                        .HasForeignKey("ClubId");

                    b.HasOne("Ddhp.v2016.Models.Ddhp.Round")
                        .WithMany()
                        .HasForeignKey("FromRoundId");

                    b.HasOne("Ddhp.v2016.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("Ddhp.v2016.Models.Ddhp.Round")
                        .WithMany()
                        .HasForeignKey("ToRoundId");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Player", b =>
                {
                    b.HasOne("Ddhp.v2016.Models.Afl.Club")
                        .WithMany()
                        .HasForeignKey("CurrentAflClubId");
                });

            modelBuilder.Entity("Ddhp.v2016.Models.Stat", b =>
                {
                    b.HasOne("Ddhp.v2016.Models.Afl.Club")
                        .WithMany()
                        .HasForeignKey("AflClubId");

                    b.HasOne("Ddhp.v2016.Models.Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("Ddhp.v2016.Models.Ddhp.Round")
                        .WithMany()
                        .HasForeignKey("RoundId");
                });
        }
    }
}
