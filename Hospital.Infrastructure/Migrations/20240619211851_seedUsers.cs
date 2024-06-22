using Hospital.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hash = new PasswordHasher<AppUser>();
            var id = Guid.NewGuid().ToString();
            var adminId = Guid.NewGuid().ToString();
            var patientId = Guid.NewGuid().ToString();
            var doctorId = Guid.NewGuid().ToString();

            //insert into user
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "Email", "NormalizedEmail", "FirstName", "LastName", "UserName", "NormalizedUserName", "PasswordHash", "EmailConfirmed", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnabled", "AccessFailedCount" },
                values: new object[] { id, "zidan@gmail.com", "ZIDAN@GMAIL.COM", "zidan", "zezo", "zidanzezo", "ZIDANZEZO", hash.HashPassword(null, "Zidan@123"), true, true, false, false, 0 }
                );

            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp"},
               values: new object[] { adminId, HospitalRoles.Admin.ToString(), HospitalRoles.Admin.ToString().ToUpper(), Guid.NewGuid().ToString()}
               );
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { patientId, HospitalRoles.Patient.ToString(), HospitalRoles.Patient.ToString().ToUpper(), Guid.NewGuid().ToString() }
               );
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { doctorId, HospitalRoles.Doctor.ToString(), HospitalRoles.Doctor.ToString().ToUpper(), Guid.NewGuid().ToString() }
               );
            migrationBuilder.InsertData(
               table: "AspNetUserRoles",
               columns: new[] { "UserId", "RoleId"},
               values: new object[] { id,adminId }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from AspNetUsers where Email = 'zidan@gmail.com'");
            migrationBuilder.Sql("delete from AspNetRoles where Name in ('Admin' ,'Patient','Doctor')");
        }
    }
}
