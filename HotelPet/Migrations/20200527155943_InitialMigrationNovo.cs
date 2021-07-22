using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelPet.Migrations
{
    public partial class InitialMigrationNovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelInfo_Endereco_EnderecoId",
                table: "HotelInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelInfo_Usuario_PessoaJuridicaId",
                table: "HotelInfo");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaJuridicaId",
                table: "HotelInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "HotelInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelInfo_Endereco_EnderecoId",
                table: "HotelInfo",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelInfo_Usuario_PessoaJuridicaId",
                table: "HotelInfo",
                column: "PessoaJuridicaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelInfo_Endereco_EnderecoId",
                table: "HotelInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelInfo_Usuario_PessoaJuridicaId",
                table: "HotelInfo");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaJuridicaId",
                table: "HotelInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "HotelInfo",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(nullable: true),
                    PessoaJuridicaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_Usuario_PessoaJuridicaId",
                        column: x => x.PessoaJuridicaId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_posts_PessoaJuridicaId",
                table: "posts",
                column: "PessoaJuridicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelInfo_Endereco_EnderecoId",
                table: "HotelInfo",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelInfo_Usuario_PessoaJuridicaId",
                table: "HotelInfo",
                column: "PessoaJuridicaId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
