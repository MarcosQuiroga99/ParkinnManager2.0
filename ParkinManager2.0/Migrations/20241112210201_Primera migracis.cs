using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkinManager2._0.Migrations
{
    /// <inheritdoc />
    public partial class Primeramigracis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "estacionamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxPlaza = table.Column<int>(type: "int", nullable: false),
                    tipoVehiculos = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estacionamientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    TipoPlan = table.Column<int>(type: "int", nullable: false),
                    TipoVehiculo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "administradors",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Legajo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FehcaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administradors", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_administradors_estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Dni = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiculoID = table.Column<int>(type: "int", nullable: false),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FehcaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaAlta = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Dni);
                    table.ForeignKey(
                        name: "FK_cliente_estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "vehiculos",
                columns: table => new
                {
                    Patente = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoDeVehiculo = table.Column<int>(type: "int", nullable: true),
                    ClienteID = table.Column<int>(type: "int", nullable: false),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehiculos", x => x.Patente);
                    table.ForeignKey(
                        name: "FK_vehiculos_cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "cliente",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_vehiculos_estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehiculoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EstacionamientoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "cliente",
                        principalColumn: "Dni",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ticket_estacionamientos_EstacionamientoId",
                        column: x => x.EstacionamientoId,
                        principalTable: "estacionamientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ticket_vehiculos_VehiculoId",
                        column: x => x.VehiculoId,
                        principalTable: "vehiculos",
                        principalColumn: "Patente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administradors_EstacionamientoId",
                table: "administradors",
                column: "EstacionamientoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cliente_EstacionamientoId",
                table: "cliente",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_ClienteId",
                table: "ticket",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_EstacionamientoId",
                table: "ticket",
                column: "EstacionamientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_VehiculoId",
                table: "ticket",
                column: "VehiculoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_ClienteID",
                table: "vehiculos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_vehiculos_EstacionamientoId",
                table: "vehiculos",
                column: "EstacionamientoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administradors");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "vehiculos");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "estacionamientos");
        }
    }
}
