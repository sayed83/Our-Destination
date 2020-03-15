namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Payment_Master_Details : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentAmounts", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.PaymentAmounts", "MemberId", "dbo.Members");
            DropForeignKey("dbo.PaymentAmounts", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropForeignKey("dbo.PaymentAmounts", "MonthId", "dbo.Months");
            DropIndex("dbo.PaymentAmounts", new[] { "PaymentTypeId" });
            DropIndex("dbo.PaymentAmounts", new[] { "MemberId" });
            DropIndex("dbo.PaymentAmounts", new[] { "DepartmentId" });
            DropIndex("dbo.PaymentAmounts", new[] { "MonthId" });
            CreateTable(
                "dbo.Professions",
                c => new
                    {
                        ProfessionId = c.Int(nullable: false, identity: true),
                        ProfessionName = c.String(),
                    })
                .PrimaryKey(t => t.ProfessionId);
            
            CreateTable(
                "dbo.Payment_Details",
                c => new
                    {
                        PaymentDetailsId = c.Int(nullable: false, identity: true),
                        PaymentTypeId = c.Int(),
                        MemberId = c.Int(),
                        DepartmentId = c.Int(),
                        MonthId = c.Int(),
                        PaymentDate = c.DateTime(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        GivenYear = c.DateTime(),
                        AddedBy = c.String(),
                        UpdatedBy = c.String(),
                        AddedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                        PaymentMasterId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentDetailsId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .ForeignKey("dbo.MemberPaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.Months", t => t.MonthId)
                .ForeignKey("dbo.Payment_Master", t => t.PaymentMasterId)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.MemberId)
                .Index(t => t.DepartmentId)
                .Index(t => t.MonthId)
                .Index(t => t.PaymentMasterId);
            
            CreateTable(
                "dbo.Payment_Master",
                c => new
                    {
                        PaymentMasterId = c.Int(nullable: false, identity: true),
                        AddedBy = c.String(),
                        UpdatedBy = c.String(),
                        AddedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        Active = c.Boolean(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentMasterId);
            
            AddColumn("dbo.Members", "ProfessionId", c => c.Int());
            CreateIndex("dbo.Members", "ProfessionId");
            AddForeignKey("dbo.Members", "ProfessionId", "dbo.Professions", "ProfessionId");
            DropColumn("dbo.Members", "Profession");
            DropTable("dbo.PaymentAmounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PaymentAmounts",
                c => new
                    {
                        PaymentAmountId = c.Int(nullable: false, identity: true),
                        PaymentTypeId = c.Int(),
                        MemberId = c.Int(),
                        DepartmentId = c.Int(),
                        MonthId = c.Int(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        Active = c.Boolean(nullable: false),
                        userid = c.Int(),
                        comid = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentAmountId);
            
            AddColumn("dbo.Members", "Profession", c => c.String());
            DropForeignKey("dbo.Payment_Details", "PaymentMasterId", "dbo.Payment_Master");
            DropForeignKey("dbo.Payment_Details", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Payment_Details", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropForeignKey("dbo.Payment_Details", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Payment_Details", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Members", "ProfessionId", "dbo.Professions");
            DropIndex("dbo.Payment_Details", new[] { "PaymentMasterId" });
            DropIndex("dbo.Payment_Details", new[] { "MonthId" });
            DropIndex("dbo.Payment_Details", new[] { "DepartmentId" });
            DropIndex("dbo.Payment_Details", new[] { "MemberId" });
            DropIndex("dbo.Payment_Details", new[] { "PaymentTypeId" });
            DropIndex("dbo.Members", new[] { "ProfessionId" });
            DropColumn("dbo.Members", "ProfessionId");
            DropTable("dbo.Payment_Master");
            DropTable("dbo.Payment_Details");
            DropTable("dbo.Professions");
            CreateIndex("dbo.PaymentAmounts", "MonthId");
            CreateIndex("dbo.PaymentAmounts", "DepartmentId");
            CreateIndex("dbo.PaymentAmounts", "MemberId");
            CreateIndex("dbo.PaymentAmounts", "PaymentTypeId");
            AddForeignKey("dbo.PaymentAmounts", "MonthId", "dbo.Months", "MonthId");
            AddForeignKey("dbo.PaymentAmounts", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
            AddForeignKey("dbo.PaymentAmounts", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.PaymentAmounts", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
