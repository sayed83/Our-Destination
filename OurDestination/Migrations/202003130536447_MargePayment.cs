namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MargePayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payment_Details", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Payment_Details", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Payment_Details", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropForeignKey("dbo.Payment_Details", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Payment_Details", "PaymentMasterId", "dbo.Payment_Master");
            DropIndex("dbo.Payment_Details", new[] { "PaymentTypeId" });
            DropIndex("dbo.Payment_Details", new[] { "MemberId" });
            DropIndex("dbo.Payment_Details", new[] { "DepartmentId" });
            DropIndex("dbo.Payment_Details", new[] { "MonthId" });
            DropIndex("dbo.Payment_Details", new[] { "PaymentMasterId" });
            AddColumn("dbo.Payment_Master", "PaymentTypeId", c => c.Int());
            AddColumn("dbo.Payment_Master", "MemberId", c => c.Int());
            AddColumn("dbo.Payment_Master", "DepartmentId", c => c.Int());
            AddColumn("dbo.Payment_Master", "MonthId", c => c.Int());
            AddColumn("dbo.Payment_Master", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Payment_Master", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Payment_Master", "GivenYear", c => c.DateTime());
            CreateIndex("dbo.Payment_Master", "PaymentTypeId");
            CreateIndex("dbo.Payment_Master", "MemberId");
            CreateIndex("dbo.Payment_Master", "DepartmentId");
            CreateIndex("dbo.Payment_Master", "MonthId");
            AddForeignKey("dbo.Payment_Master", "DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Payment_Master", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Payment_Master", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
            AddForeignKey("dbo.Payment_Master", "MonthId", "dbo.Months", "MonthId");
            DropTable("dbo.Payment_Details");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.PaymentDetailsId);
            
            DropForeignKey("dbo.Payment_Master", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Payment_Master", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropForeignKey("dbo.Payment_Master", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Payment_Master", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Payment_Master", new[] { "MonthId" });
            DropIndex("dbo.Payment_Master", new[] { "DepartmentId" });
            DropIndex("dbo.Payment_Master", new[] { "MemberId" });
            DropIndex("dbo.Payment_Master", new[] { "PaymentTypeId" });
            DropColumn("dbo.Payment_Master", "GivenYear");
            DropColumn("dbo.Payment_Master", "Amount");
            DropColumn("dbo.Payment_Master", "PaymentDate");
            DropColumn("dbo.Payment_Master", "MonthId");
            DropColumn("dbo.Payment_Master", "DepartmentId");
            DropColumn("dbo.Payment_Master", "MemberId");
            DropColumn("dbo.Payment_Master", "PaymentTypeId");
            CreateIndex("dbo.Payment_Details", "PaymentMasterId");
            CreateIndex("dbo.Payment_Details", "MonthId");
            CreateIndex("dbo.Payment_Details", "DepartmentId");
            CreateIndex("dbo.Payment_Details", "MemberId");
            CreateIndex("dbo.Payment_Details", "PaymentTypeId");
            AddForeignKey("dbo.Payment_Details", "PaymentMasterId", "dbo.Payment_Master", "PaymentMasterId");
            AddForeignKey("dbo.Payment_Details", "MonthId", "dbo.Months", "MonthId");
            AddForeignKey("dbo.Payment_Details", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
            AddForeignKey("dbo.Payment_Details", "MemberId", "dbo.Members", "MemberId");
            AddForeignKey("dbo.Payment_Details", "DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
