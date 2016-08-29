namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnBirthDateToCustomerAndUpdateOne : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());

            // update de um customer para exemplo
            Sql("UPDATE Customers SET BirthDate = '1974-05-27' WHERE ID = 3");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
