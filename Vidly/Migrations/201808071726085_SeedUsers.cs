namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6a42b5dd-4ac4-4a55-a594-97c5462b319f', N'guest@test.com', 0, N'AGabOo1NEP+KQIKaOMttYCtzbjtA5f6DKu9ed3+dzHfawucfoWXKPlhiP74lIpZ4pA==', N'312341b1-cac9-461c-b30a-b834c9bc56f1', NULL, 0, 0, NULL, 1, 0, N'guest@test.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ee5cf950-f78e-4a1b-a230-dfdceb594fa9', N'admin@test.com', 0, N'AK2St4mhJL1MFE25C52P8V39yrV6zx2qHKzvmHk+LB3n0Z87jY0Fj1mWgLs6PFkg4g==', N'b25de8e7-1d3d-4a57-9369-b1f7a0b366b1', NULL, 0, 0, NULL, 1, 0, N'admin@test.com')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ee5cf950-f78e-4a1b-a230-dfdceb594fa9', N'10ab9fff-7a23-4f32-8878-a0ae2484cd84')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'10ab9fff-7a23-4f32-8878-a0ae2484cd84', N'CanManageMovies')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
