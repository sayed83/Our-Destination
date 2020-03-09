namespace OurDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Month_Add_With_PaymentAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PaymentAmounts", "MonthId", c => c.Int());
            CreateIndex("dbo.PaymentAmounts", "MonthId");
            AddForeignKey("dbo.PaymentAmounts", "MonthId", "dbo.Months", "MonthId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentAmounts", "MonthId", "dbo.Months");
            DropIndex("dbo.PaymentAmounts", new[] { "MonthId" });
            DropColumn("dbo.PaymentAmounts", "MonthId");
        }
    }
}
