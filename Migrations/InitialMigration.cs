using FluentMigrator;

namespace TestProduct.Migrations
{
    [Migration(12346)]
    public class InitialMigration : Migration
    {
        public override void Up()
        {
            Create.Table("User")
            .WithColumn("UserId").AsInt32().PrimaryKey().Identity()
            .WithColumn("FirstName").AsString().NotNullable()
            .WithColumn("LastName").AsString().NotNullable()
            .WithColumn("Email").AsString().NotNullable()
            .WithColumn("Password").AsString().NotNullable()
            .WithColumn("Confirm Password").AsString().NotNullable()
            .WithColumn("IsActive").AsBoolean().NotNullable();
        }
        public override void Down()
        {
        }
    }
}
