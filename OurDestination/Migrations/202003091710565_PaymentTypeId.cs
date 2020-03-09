namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentAmounts", "MemberPaymentType_PaymentId", "dbo.MemberPaymentTypes");
            DropColumn("dbo.PaymentAmounts", "PaymentTypeId");
            RenameColumn(table: "dbo.PaymentAmounts", name: "MemberPaymentType_PaymentId", newName: "PaymentTypeId");
            RenameIndex(table: "dbo.PaymentAmounts", name: "IX_MemberPaymentType_PaymentId", newName: "IX_PaymentTypeId");
            DropPrimaryKey("dbo.MemberPaymentTypes");
            AddColumn("dbo.MemberPaymentTypes", "PaymentTypeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.MemberPaymentTypes", "PaymentTypeId");
            AddForeignKey("dbo.PaymentAmounts", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
            DropColumn("dbo.MemberPaymentTypes", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MemberPaymentTypes", "PaymentId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.PaymentAmounts", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropPrimaryKey("dbo.MemberPaymentTypes");
            DropColumn("dbo.MemberPaymentTypes", "PaymentTypeId");
            AddPrimaryKey("dbo.MemberPaymentTypes", "PaymentId");
            RenameIndex(table: "dbo.PaymentAmounts", name: "IX_PaymentTypeId", newName: "IX_MemberPaymentType_PaymentId");
            RenameColumn(table: "dbo.PaymentAmounts", name: "PaymentTypeId", newName: "MemberPaymentType_PaymentId");
            AddColumn("dbo.PaymentAmounts", "PaymentTypeId", c => c.Int());
            AddForeignKey("dbo.PaymentAmounts", "MemberPaymentType_PaymentId", "dbo.MemberPaymentTypes", "PaymentId");
        }
    }
}
