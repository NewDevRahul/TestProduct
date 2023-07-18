using FluentMigrator;

namespace TestProduct.Migrations
{
    [Migration(45546544)]
    public class EditUsertablemigrations : Migration
    {
        public override void Up()
        {
            Rename.Column("Confirm Password").OnTable("User").To("ConfirmPassword");
        }
        public override void Down()
        {
            Rename.Column("ConfirmPassword").OnTable("User").To("Confirm Password");
        }
    }
}
