namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Committees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Position = c.String(nullable: false),
                        ElactedDate = c.DateTime(),
                        userid = c.Int(),
                        comid = c.Int(),
                        EntryDate = c.DateTime(),
                        AddedBy = c.String(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberId = c.Int(nullable: false, identity: true),
                        MemberName = c.String(nullable: false),
                        JoiningDate = c.DateTime(),
                        FatherName = c.String(),
                        MotherName = c.String(),
                        SpouseName = c.String(),
                        Nationality = c.Int(),
                        DOB = c.DateTime(nullable: false),
                        Email = c.String(),
                        PhotoPath = c.String(),
                        Image = c.Binary(),
                        PhoneNo = c.String(nullable: false),
                        MaritalStatus = c.Int(),
                        Religion = c.Int(),
                        Gender = c.Int(),
                        EducationalQualification = c.String(),
                        NIDNo = c.String(),
                        PassportNo = c.String(),
                        TinNo = c.String(),
                        PresentAddress = c.String(),
                        PermanentAddress = c.String(),
                        NomineeName = c.String(),
                        RelationWithNominee = c.String(),
                        NomineeNIDNo = c.String(),
                        NomineePhoneNo = c.String(),
                        userid = c.Int(),
                        comid = c.Int(),
                        IsActive = c.Boolean(nullable: false),
                        EntryDate = c.DateTime(),
                        BloodGroupId = c.Int(),
                    })
                .PrimaryKey(t => t.MemberId)
                .ForeignKey("dbo.BloodGroups", t => t.BloodGroupId)
                .Index(t => t.BloodGroupId);
            
            CreateTable(
                "dbo.BloodGroups",
                c => new
                    {
                        BloodGroupId = c.Int(nullable: false, identity: true),
                        BloodGroupName = c.String(),
                    })
                .PrimaryKey(t => t.BloodGroupId);
            
            CreateTable(
                "dbo.Expenses_Details",
                c => new
                    {
                        ExpenceDetailsId = c.Int(nullable: false, identity: true),
                        ExpenceDescription = c.String(),
                        userid = c.Int(),
                        comid = c.Int(),
                        EntryDate = c.DateTime(),
                        AddedBy = c.String(),
                        ExpenceMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenceDetailsId)
                .ForeignKey("dbo.Expenses_Master", t => t.ExpenceMasterId)
                .Index(t => t.ExpenceMasterId);
            
            CreateTable(
                "dbo.Expenses_Master",
                c => new
                    {
                        ExpenceMasterId = c.Int(nullable: false, identity: true),
                        ExpensesName = c.String(nullable: false),
                        ExpensesAmnount = c.Single(nullable: false),
                        ExpensesDate = c.DateTime(),
                        ExpensesDec = c.String(),
                        userid = c.Int(),
                        comid = c.Int(),
                        EntryDate = c.DateTime(),
                        AddedBy = c.String(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.ExpenceMasterId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Invests",
                c => new
                    {
                        InvestId = c.Int(nullable: false, identity: true),
                        InvestPurpose = c.String(nullable: false),
                        InvestAmount = c.Single(nullable: false),
                        InvestDate = c.DateTime(nullable: false),
                        ExpireDate = c.DateTime(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                        EntryDate = c.DateTime(),
                        AddedBy = c.String(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.InvestId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Profits",
                c => new
                    {
                        ProfitId = c.Int(nullable: false, identity: true),
                        ProfitDec = c.String(nullable: false),
                        ProfitAmount = c.Single(nullable: false),
                        GivenDate = c.DateTime(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                        EntryDate = c.DateTime(),
                        AddedBy = c.String(),
                        InvestId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfitId)
                .ForeignKey("dbo.Invests", t => t.InvestId)
                .Index(t => t.InvestId);
            
            //CreateTable(
            //    "dbo.AspNetRoles",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Name = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserRoles",
            //    c => new
            //        {
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            RoleId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.UserId, t.RoleId })
            //    .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId)
            //    .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Transections",
                c => new
                    {
                        TransectionId = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        GivenDate = c.DateTime(nullable: false),
                        EntryDate = c.DateTime(),
                        TransectionAmount = c.Single(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                        MemberId = c.Int(),
                    })
                .PrimaryKey(t => t.TransectionId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            //CreateTable(
            //    "dbo.AspNetUsers",
            //    c => new
            //        {
            //            Id = c.String(nullable: false, maxLength: 128),
            //            Email = c.String(maxLength: 256),
            //            EmailConfirmed = c.Boolean(nullable: false),
            //            PasswordHash = c.String(),
            //            SecurityStamp = c.String(),
            //            PhoneNumber = c.String(),
            //            PhoneNumberConfirmed = c.Boolean(nullable: false),
            //            TwoFactorEnabled = c.Boolean(nullable: false),
            //            LockoutEndDateUtc = c.DateTime(),
            //            LockoutEnabled = c.Boolean(nullable: false),
            //            AccessFailedCount = c.Int(nullable: false),
            //            UserName = c.String(nullable: false, maxLength: 256),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            //CreateTable(
            //    "dbo.AspNetUserClaims",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //            ClaimType = c.String(),
            //            ClaimValue = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.AspNetUserLogins",
            //    c => new
            //        {
            //            LoginProvider = c.String(nullable: false, maxLength: 128),
            //            ProviderKey = c.String(nullable: false, maxLength: 128),
            //            UserId = c.String(nullable: false, maxLength: 128),
            //        })
            //    .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
            //    .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
            //    .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            //DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Transections", "MemberId", "dbo.Members");
            //DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Profits", "InvestId", "dbo.Invests");
            DropForeignKey("dbo.Invests", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Expenses_Details", "ExpenceMasterId", "dbo.Expenses_Master");
            DropForeignKey("dbo.Expenses_Master", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Committees", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Members", "BloodGroupId", "dbo.BloodGroups");
           // DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
           // DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
          //  DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Transections", new[] { "MemberId" });
          //  DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
          //  DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
          //  DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Profits", new[] { "InvestId" });
            DropIndex("dbo.Invests", new[] { "MemberId" });
            DropIndex("dbo.Expenses_Master", new[] { "MemberId" });
            DropIndex("dbo.Expenses_Details", new[] { "ExpenceMasterId" });
            DropIndex("dbo.Members", new[] { "BloodGroupId" });
            DropIndex("dbo.Committees", new[] { "MemberId" });
          //  DropTable("dbo.AspNetUserLogins");
          //  DropTable("dbo.AspNetUserClaims");
           // DropTable("dbo.AspNetUsers");
            DropTable("dbo.Transections");
          //  DropTable("dbo.AspNetUserRoles");
          //  DropTable("dbo.AspNetRoles");
            DropTable("dbo.Profits");
            DropTable("dbo.Invests");
            DropTable("dbo.Expenses_Master");
            DropTable("dbo.Expenses_Details");
            DropTable("dbo.BloodGroups");
            DropTable("dbo.Members");
            DropTable("dbo.Committees");
        }
    }
}
