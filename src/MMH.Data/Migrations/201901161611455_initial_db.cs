namespace MMH.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        Neighborhood = c.String(),
                        PostalCode = c.String(),
                        CityId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: false)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: false)
                .Index(t => t.CityId)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.City",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.State", t => t.StateId, cascadeDelete: false)
                .Index(t => t.StateId);
            
            CreateTable(
                "dbo.State",
                c => new
                    {
                        StateId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StateId);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.DocumentType", t => t.DocumentTypeId, cascadeDelete: false)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentType",
                c => new
                    {
                        DocumentTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DonnationAd",
                c => new
                    {
                        DonnationAdId = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.DonnationAdId)
                .ForeignKey("dbo.Advertiser", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Phone",
                c => new
                    {
                        PhoneId = c.Int(nullable: false, identity: true),
                        DDD = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PhoneId)
                .ForeignKey("dbo.Advertiser", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRole", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.IdentityUser_Id)
                .Index(t => t.RoleId)
                .Index(t => t.IdentityUser_Id);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureId = c.Long(nullable: false),
                        Name = c.String(),
                        ImageData = c.Binary(),
                        DonnationAdId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.PictureId)
                .ForeignKey("dbo.DonnationAd", t => t.PictureId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.AspNetRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Advertiser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Id)
                .ForeignKey("dbo.Document", t => t.DocumentId, cascadeDelete: true)
                .ForeignKey("dbo.Address", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.DocumentId)
                .Index(t => t.AddressId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Advertiser", "AddressId", "dbo.Address");
            DropForeignKey("dbo.Advertiser", "DocumentId", "dbo.Document");
            DropForeignKey("dbo.Advertiser", "Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "IdentityUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRole");
            DropForeignKey("dbo.Picture", "PictureId", "dbo.DonnationAd");
            DropForeignKey("dbo.Phone", "Id", "dbo.Advertiser");
            DropForeignKey("dbo.DonnationAd", "Id", "dbo.Advertiser");
            DropForeignKey("dbo.Document", "DocumentTypeId", "dbo.DocumentType");
            DropForeignKey("dbo.Address", "StateId", "dbo.State");
            DropForeignKey("dbo.Address", "CityId", "dbo.City");
            DropForeignKey("dbo.City", "StateId", "dbo.State");
            DropIndex("dbo.Advertiser", new[] { "AddressId" });
            DropIndex("dbo.Advertiser", new[] { "DocumentId" });
            DropIndex("dbo.Advertiser", new[] { "Id" });
            DropIndex("dbo.AspNetRole", "RoleNameIndex");
            DropIndex("dbo.Picture", new[] { "PictureId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.Phone", new[] { "Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "IdentityUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.DonnationAd", new[] { "Id" });
            DropIndex("dbo.Document", new[] { "DocumentTypeId" });
            DropIndex("dbo.City", new[] { "StateId" });
            DropIndex("dbo.Address", new[] { "StateId" });
            DropIndex("dbo.Address", new[] { "CityId" });
            DropTable("dbo.Advertiser");
            DropTable("dbo.AspNetRole");
            DropTable("dbo.Picture");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Phone");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.DonnationAd");
            DropTable("dbo.DocumentType");
            DropTable("dbo.Document");
            DropTable("dbo.State");
            DropTable("dbo.City");
            DropTable("dbo.Address");
        }
    }
}
