using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusSnapshots.Data.Migrations
{
    public partial class SeedAppUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'03a4bd80-3291-4cbb-8a22-3468c850f845', 0, N'5262d685-980b-4f6a-a935-846d0ecf34b0', N'guest@snapshots.com', 0, 1, NULL, N'GUEST@SNAPSHOTS.COM', N'GUEST@SNAPSHOTS.COM', N'AQAAAAEAACcQAAAAEC14tZfvYAnLFtXBC6WkImUt95gcIgYyQeuRND+0qB7Km6EwWxM8WJx6T63PZJdJMQ==', NULL, 0, N'b944fe96-c732-47fc-8d79-8d1243c16d0d', 0, N'guest@snapshots.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [AccessFailedCount], [ConcurrencyStamp], [Email], [EmailConfirmed], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [TwoFactorEnabled], [UserName]) VALUES (N'4ebba55f-dec1-49ac-b757-7c6f3673ddfc', 0, N'690620ad-50c6-40cc-a218-85d81449e9e6', N'admin@snapshots.com', 0, 1, NULL, N'ADMIN@SNAPSHOTS.COM', N'ADMIN@SNAPSHOTS.COM', N'AQAAAAEAACcQAAAAELslp0NyMXZJ2AEmHJ83m17uhNkkrklIqwBgNZsdb8xb6s7fU8QHP4htAC3bXpLEwQ==', NULL, 0, N'9c08303c-71fc-47f2-9858-ef3bf9f21c10', 0, N'admin@snapshots.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [ConcurrencyStamp], [Name], [NormalizedName]) VALUES (N'7eadece9-9e6a-4047-bef1-9c65615e3507', N'a78c899a-4f0b-4e4a-88b2-2a287ac4896a', N'Admin', N'ADMIN')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4ebba55f-dec1-49ac-b757-7c6f3673ddfc', N'7eadece9-9e6a-4047-bef1-9c65615e3507')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
