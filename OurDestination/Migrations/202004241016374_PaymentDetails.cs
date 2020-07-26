namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentDetails : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payment_Master", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropForeignKey("dbo.Payment_Master", "MonthId", "dbo.Months");
            DropIndex("dbo.Payment_Master", new[] { "PaymentTypeId" });
            DropIndex("dbo.Payment_Master", new[] { "MonthId" });
            CreateTable(
                "dbo.Payment_Details",
                c => new
                    {
                        PaymentDetailsId = c.Int(nullable: false, identity: true),
                        PaymentTypeId = c.Int(),
                        MonthId = c.Int(),
                        PaymentDate = c.DateTime(),
                        PaymentAmount = c.Decimal(precision: 18, scale: 2),
                        TotalAmount = c.Decimal(precision: 18, scale: 2),
                        NetAmount = c.Decimal(precision: 18, scale: 2),
                        GivenYear = c.DateTime(),
                        AddedBy = c.String(),
                        UpdatedBy = c.String(),
                        AddedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                        userid = c.Int(),
                        comid = c.Int(),
                        PaymentMasterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentDetailsId)
                .ForeignKey("dbo.MemberPaymentTypes", t => t.PaymentTypeId)
                .ForeignKey("dbo.Months", t => t.MonthId)
                .ForeignKey("dbo.Payment_Master", t => t.PaymentMasterId, cascadeDelete: true)
                .Index(t => t.PaymentTypeId)
                .Index(t => t.MonthId)
                .Index(t => t.PaymentMasterId);
            
            DropColumn("dbo.Payment_Master", "PaymentTypeId");
            DropColumn("dbo.Payment_Master", "MonthId");
            DropColumn("dbo.Payment_Master", "PaymentDate");
            DropColumn("dbo.Payment_Master", "Amount");
            DropColumn("dbo.Payment_Master", "GivenYear");
            DropColumn("dbo.Payment_Master", "Active");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payment_Master", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Payment_Master", "GivenYear", c => c.DateTime());
            AddColumn("dbo.Payment_Master", "Amount", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Payment_Master", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Payment_Master", "MonthId", c => c.Int());
            AddColumn("dbo.Payment_Master", "PaymentTypeId", c => c.Int());
            DropForeignKey("dbo.Payment_Details", "PaymentMasterId", "dbo.Payment_Master");
            DropForeignKey("dbo.Payment_Details", "MonthId", "dbo.Months");
            DropForeignKey("dbo.Payment_Details", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropIndex("dbo.Payment_Details", new[] { "PaymentMasterId" });
            DropIndex("dbo.Payment_Details", new[] { "MonthId" });
            DropIndex("dbo.Payment_Details", new[] { "PaymentTypeId" });
            DropTable("dbo.Payment_Details");
            CreateIndex("dbo.Payment_Master", "MonthId");
            CreateIndex("dbo.Payment_Master", "PaymentTypeId");
            AddForeignKey("dbo.Payment_Master", "MonthId", "dbo.Months", "MonthId");
            AddForeignKey("dbo.Payment_Master", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
        }
    }
}
