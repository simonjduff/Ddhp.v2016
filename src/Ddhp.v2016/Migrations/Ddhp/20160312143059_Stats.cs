using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Ddhp.v2016.Migrations.Ddhp
{
    public partial class Stats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_FromRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Player_PlayerId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_ToRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Player_Club_CurrentAflClubId", table: "Players");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Player_PlayerId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Round_RoundId", table: "Stats");
            migrationBuilder.AddColumn<int>(
                name: "AflClubId",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Behinds",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Disposals",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "FreesAgainst",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "FreesFor",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "GoalAssists",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Goals",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Handballs",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Hitouts",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Inside50s",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Kicks",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Marks",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddColumn<int>(
                name: "Tackles",
                table: "Stats",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Round_FromRoundId",
                schema: "ddhp",
                table: "Contracts",
                column: "FromRoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Player_PlayerId",
                schema: "ddhp",
                table: "Contracts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Round_ToRoundId",
                schema: "ddhp",
                table: "Contracts",
                column: "ToRoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Player_Club_CurrentAflClubId",
                table: "Players",
                column: "CurrentAflClubId",
                principalSchema: "afl",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Stat_Club_AflClubId",
                table: "Stats",
                column: "AflClubId",
                principalSchema: "afl",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Stat_Player_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Stat_Round_RoundId",
                table: "Stats",
                column: "RoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_FromRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Player_PlayerId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_ToRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Player_Club_CurrentAflClubId", table: "Players");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Club_AflClubId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Player_PlayerId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Round_RoundId", table: "Stats");
            migrationBuilder.DropColumn(name: "AflClubId", table: "Stats");
            migrationBuilder.DropColumn(name: "Behinds", table: "Stats");
            migrationBuilder.DropColumn(name: "Disposals", table: "Stats");
            migrationBuilder.DropColumn(name: "FreesAgainst", table: "Stats");
            migrationBuilder.DropColumn(name: "FreesFor", table: "Stats");
            migrationBuilder.DropColumn(name: "GoalAssists", table: "Stats");
            migrationBuilder.DropColumn(name: "Goals", table: "Stats");
            migrationBuilder.DropColumn(name: "Handballs", table: "Stats");
            migrationBuilder.DropColumn(name: "Hitouts", table: "Stats");
            migrationBuilder.DropColumn(name: "Inside50s", table: "Stats");
            migrationBuilder.DropColumn(name: "Kicks", table: "Stats");
            migrationBuilder.DropColumn(name: "Marks", table: "Stats");
            migrationBuilder.DropColumn(name: "Tackles", table: "Stats");
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Round_FromRoundId",
                schema: "ddhp",
                table: "Contracts",
                column: "FromRoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Player_PlayerId",
                schema: "ddhp",
                table: "Contracts",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Round_ToRoundId",
                schema: "ddhp",
                table: "Contracts",
                column: "ToRoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Player_Club_CurrentAflClubId",
                table: "Players",
                column: "CurrentAflClubId",
                principalSchema: "afl",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Stat_Player_PlayerId",
                table: "Stats",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Stat_Round_RoundId",
                table: "Stats",
                column: "RoundId",
                principalSchema: "ddhp",
                principalTable: "Rounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
