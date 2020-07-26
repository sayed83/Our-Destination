namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelModidy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Committees", "UpdatedBy", c => c.String());
            AddColumn("dbo.Committees", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Committees", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Professions", "userid", c => c.Int());
            AddColumn("dbo.Professions", "comid", c => c.Int());
            AddColumn("dbo.Professions", "AddedBy", c => c.String());
            AddColumn("dbo.Professions", "UpdatedBy", c => c.String());
            AddColumn("dbo.Professions", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Professions", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Customers", "userid", c => c.String());
            AddColumn("dbo.Customers", "comid", c => c.Int());
            AddColumn("dbo.Customers", "AddedBy", c => c.String());
            AddColumn("dbo.Customers", "UpdatedBy", c => c.String());
            AddColumn("dbo.Customers", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Customers", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Orders", "userid", c => c.Int());
            AddColumn("dbo.Orders", "comid", c => c.Int());
            AddColumn("dbo.Orders", "AddedBy", c => c.String());
            AddColumn("dbo.Orders", "UpdatedBy", c => c.String());
            AddColumn("dbo.Orders", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Orders", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Departments", "userid", c => c.String());
            AddColumn("dbo.Departments", "comid", c => c.Int());
            AddColumn("dbo.Departments", "AddedBy", c => c.String());
            AddColumn("dbo.Departments", "UpdatedBy", c => c.String());
            AddColumn("dbo.Departments", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Departments", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.Invests", "UpdatedBy", c => c.String());
            AddColumn("dbo.Invests", "AddedDate", c => c.DateTime());
            AddColumn("dbo.Invests", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MemberInvoiceLists", "userid", c => c.Int());
            AddColumn("dbo.MemberInvoiceLists", "comid", c => c.Int());
            AddColumn("dbo.MemberInvoiceLists", "AddedBy", c => c.String());
            AddColumn("dbo.MemberInvoiceLists", "UpdatedBy", c => c.String());
            AddColumn("dbo.MemberInvoiceLists", "AddedDate", c => c.DateTime());
            AddColumn("dbo.MemberInvoiceLists", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MonthlyPaymentSetups", "PaymentTypeId", c => c.Int());
            AddColumn("dbo.MonthlyPaymentSetups", "userid", c => c.String());
            AddColumn("dbo.MonthlyPaymentSetups", "comid", c => c.Int());
            AddColumn("dbo.MonthlyPaymentSetups", "AddedBy", c => c.String());
            AddColumn("dbo.MonthlyPaymentSetups", "UpdatedBy", c => c.String());
            AddColumn("dbo.MonthlyPaymentSetups", "AddedDate", c => c.DateTime());
            AddColumn("dbo.MonthlyPaymentSetups", "UpdatedDate", c => c.DateTime());
            AddColumn("dbo.MemberPaymentTypes", "PaymentAmount", c => c.String());
            AddColumn("dbo.MemberPaymentTypes", "userid", c => c.String());
            AddColumn("dbo.MemberPaymentTypes", "comid", c => c.Int());
            AddColumn("dbo.MemberPaymentTypes", "AddedBy", c => c.String());
            AddColumn("dbo.MemberPaymentTypes", "UpdatedBy", c => c.String());
            AddColumn("dbo.MemberPaymentTypes", "AddedDate", c => c.DateTime());
            AddColumn("dbo.MemberPaymentTypes", "UpdatedDate", c => c.DateTime());
            AlterColumn("dbo.Committees", "userid", c => c.String());
            CreateIndex("dbo.MonthlyPaymentSetups", "PaymentTypeId");
            AddForeignKey("dbo.MonthlyPaymentSetups", "PaymentTypeId", "dbo.MemberPaymentTypes", "PaymentTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlyPaymentSetups", "PaymentTypeId", "dbo.MemberPaymentTypes");
            DropIndex("dbo.MonthlyPaymentSetups", new[] { "PaymentTypeId" });
            AlterColumn("dbo.Committees", "userid", c => c.Int());
            DropColumn("dbo.MemberPaymentTypes", "UpdatedDate");
            DropColumn("dbo.MemberPaymentTypes", "AddedDate");
            DropColumn("dbo.MemberPaymentTypes", "UpdatedBy");
            DropColumn("dbo.MemberPaymentTypes", "AddedBy");
            DropColumn("dbo.MemberPaymentTypes", "comid");
            DropColumn("dbo.MemberPaymentTypes", "userid");
            DropColumn("dbo.MemberPaymentTypes", "PaymentAmount");
            DropColumn("dbo.MonthlyPaymentSetups", "UpdatedDate");
            DropColumn("dbo.MonthlyPaymentSetups", "AddedDate");
            DropColumn("dbo.MonthlyPaymentSetups", "UpdatedBy");
            DropColumn("dbo.MonthlyPaymentSetups", "AddedBy");
            DropColumn("dbo.MonthlyPaymentSetups", "comid");
            DropColumn("dbo.MonthlyPaymentSetups", "userid");
            DropColumn("dbo.MonthlyPaymentSetups", "PaymentTypeId");
            DropColumn("dbo.MemberInvoiceLists", "UpdatedDate");
            DropColumn("dbo.MemberInvoiceLists", "AddedDate");
            DropColumn("dbo.MemberInvoiceLists", "UpdatedBy");
            DropColumn("dbo.MemberInvoiceLists", "AddedBy");
            DropColumn("dbo.MemberInvoiceLists", "comid");
            DropColumn("dbo.MemberInvoiceLists", "userid");
            DropColumn("dbo.Invests", "UpdatedDate");
            DropColumn("dbo.Invests", "AddedDate");
            DropColumn("dbo.Invests", "UpdatedBy");
            DropColumn("dbo.Departments", "UpdatedDate");
            DropColumn("dbo.Departments", "AddedDate");
            DropColumn("dbo.Departments", "UpdatedBy");
            DropColumn("dbo.Departments", "AddedBy");
            DropColumn("dbo.Departments", "comid");
            DropColumn("dbo.Departments", "userid");
            DropColumn("dbo.Orders", "UpdatedDate");
            DropColumn("dbo.Orders", "AddedDate");
            DropColumn("dbo.Orders", "UpdatedBy");
            DropColumn("dbo.Orders", "AddedBy");
            DropColumn("dbo.Orders", "comid");
            DropColumn("dbo.Orders", "userid");
            DropColumn("dbo.Customers", "UpdatedDate");
            DropColumn("dbo.Customers", "AddedDate");
            DropColumn("dbo.Customers", "UpdatedBy");
            DropColumn("dbo.Customers", "AddedBy");
            DropColumn("dbo.Customers", "comid");
            DropColumn("dbo.Customers", "userid");
            DropColumn("dbo.Professions", "UpdatedDate");
            DropColumn("dbo.Professions", "AddedDate");
            DropColumn("dbo.Professions", "UpdatedBy");
            DropColumn("dbo.Professions", "AddedBy");
            DropColumn("dbo.Professions", "comid");
            DropColumn("dbo.Professions", "userid");
            DropColumn("dbo.Committees", "UpdatedDate");
            DropColumn("dbo.Committees", "AddedDate");
            DropColumn("dbo.Committees", "UpdatedBy");
        }
    }
}
