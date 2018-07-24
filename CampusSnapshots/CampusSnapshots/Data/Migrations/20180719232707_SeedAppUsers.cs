using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusSnapshots.Data.Migrations
{
    public partial class SeedAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"     
                INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [DateJoined], [FirstName], [LastName]) VALUES (N'a9b47a7f-2f81-4cb0-81ba-666a70274f5e', 0, N'6eb6ee2c-e6bc-4be1-aa9c-ba2ad28351a9', N'guest@mail.com', 0, 1, NULL, N'GUEST@MAIL.COM', N'GUEST@MAIL.COM', N'AQAAAAEAACcQAAAAEAUDgLbB9Zj7B6oWOCxdL10tc8wqMpI44JDQ+eqyWW+lbkTYVpXlU6TqjLMXVo6gRw==', NULL, 0, N'bdc06727-1da3-434b-acf7-01269a0948a2', 0, N'guest@mail.com', N'0001-01-01 00:00:00', N'', N'')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName], [DateJoined], [FirstName], [LastName]) VALUES (N'b80428eb-2977-406a-aeec-3557e0e53b8e', 0, N'c48a2ef5-5f19-419b-813b-d7a579bb43de', N'admin@snapshots.com', 0, 1, NULL, N'ADMIN@SNAPSHOTS.COM', N'ADMIN@SNAPSHOTS.COM', N'AQAAAAEAACcQAAAAEBGfNUDk/8V4DSj4+A0AOkbJ1OJbgZQwaIdC0sbI5kvxkEqPHtd9dgZiZCz4JS29nA==', NULL, 0, N'1b7722f9-f341-4477-a8f4-b1957879fe7b', 0, N'admin@snapshots.com', N'0001-01-01 00:00:00', N'', N'')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'c3f00027-25d4-4b39-99df-23878e6192af', N'09d2184b-8861-4a34-8348-915564ae22f6', N'Admin', N'ADMIN')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b80428eb-2977-406a-aeec-3557e0e53b8e', N'c3f00027-25d4-4b39-99df-23878e6192af')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
