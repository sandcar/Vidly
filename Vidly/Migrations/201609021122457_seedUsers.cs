namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
                INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'57bbf90a-12bf-450e-b3e2-057606761d72', N'admin@vidly.com', 0, N'AJfcYymRtbqwr4U5JRB5D59QucbqQTsywEsNaMOqnyFff9osiXO+LHA0BPGOkd5X0w==', N'c5599b62-f907-4cdd-bc70-3cd7c84b340c', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                 INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'6a1b6ea3-1510-4908-8935-d50a7bd0d112', N'guest@vidly.com', 0, N'ADq3V4yUH4ynfitUnbTux8ugrqNFnCd3rQ4E01yo4ODd3uRzeq021AUELimeCX1gmw==', N'c07274ff-2067-4ccd-87a1-173d680e03de', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                 INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'e1e23569-1f10-4ab6-ae0c-d25f07562549', N'cmo.matrix@gmail.com', 0, N'AB+b1RCf2OKeu/o8N1i5VhFgMRhflKSomxHz0hu6bACNK7ZoVU6OcF7zzz5dCL01/g==', N'1e5916e1-c97f-4c0f-bc9d-5d906286152d', NULL, 0, 0, NULL, 1, 0, N'cmo.matrix@gmail.com')
            ");


            Sql(@"
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fab9e1c7-c74d-4201-858a-79884773ca40', N'CanManageMovies')
            ");

            Sql(@"

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'57bbf90a-12bf-450e-b3e2-057606761d72', N'fab9e1c7-c74d-4201-858a-79884773ca40')

            ");



          

        }

    public override void Down()
        {
        }
    }
}
