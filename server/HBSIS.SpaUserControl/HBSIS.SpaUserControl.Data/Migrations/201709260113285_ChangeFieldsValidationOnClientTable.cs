namespace HBSIS.SpaUserControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFieldsValidationOnClientTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AlterColumn("dbo.Client", "PhoneNumber", c => c.String(nullable: false, maxLength: 11, unicode: false));
            AlterColumn("dbo.Client", "DocumentNumber", c => c.String(nullable: false, maxLength: 14, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Client", "DocumentNumber", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Client", "PhoneNumber", c => c.String(maxLength: 100, unicode: false));
            AlterColumn("dbo.Client", "Email", c => c.String(nullable: false, maxLength: 11, unicode: false));
        }
    }
}
