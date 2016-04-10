using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Ddhp.v2016.Migrations.Ddhp
{
    public partial class RoundCompleteRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Contract_Club_ClubId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_FromRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Player_PlayerId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_ToRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Player_Club_CurrentAflClubId", table: "Players");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Club_AflClubId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Player_PlayerId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Round_RoundId", table: "Stats");
            migrationBuilder.DropColumn(name: "RoundComplete", schema: "ddhp", table: "Rounds");
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "ddhp",
                table: "Rounds",
                nullable: false);
            migrationBuilder.AddColumn<bool>(
                name: "Complete",
                schema: "ddhp",
                table: "Rounds",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Club_ClubId",
                schema: "ddhp",
                table: "Contracts",
                column: "ClubId",
                principalSchema: "ddhp",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                onDelete: ReferentialAction.Restrict);
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
                onDelete: ReferentialAction.Restrict);
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
            migrationBuilder.DropForeignKey(name: "FK_Contract_Club_ClubId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_FromRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Player_PlayerId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Contract_Round_ToRoundId", schema: "ddhp", table: "Contracts");
            migrationBuilder.DropForeignKey(name: "FK_Player_Club_CurrentAflClubId", table: "Players");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Club_AflClubId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Player_PlayerId", table: "Stats");
            migrationBuilder.DropForeignKey(name: "FK_Stat_Round_RoundId", table: "Stats");
            migrationBuilder.DropColumn(name: "Complete", schema: "ddhp", table: "Rounds");
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "ddhp",
                table: "Rounds",
                nullable: false)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);
            migrationBuilder.AddColumn<bool>(
                name: "RoundComplete",
                schema: "ddhp",
                table: "Rounds",
                nullable: false,
                defaultValue: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Club_ClubId",
                schema: "ddhp",
                table: "Contracts",
                column: "ClubId",
                principalSchema: "ddhp",
                principalTable: "Clubs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
                name: "FK_Stat_Club_AflClubId",
                table: "Stats",
                column: "AflClubId",
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
