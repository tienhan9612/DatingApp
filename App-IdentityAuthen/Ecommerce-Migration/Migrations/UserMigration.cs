using FluentMigrator;

namespace Ecommerce_Migration.Migrations
{
    [Migration(1)]
    public class UserMigration : Migration
    {
        public override void Down(){
            Delete.Table("User");
        }

        public override void Up(){
            Create.Table("User")
                    .WithColumn("Id").AsGuid().PrimaryKey().NotNullable().Indexed()
                    .WithColumn("UserName").AsString(250).NotNullable()
                    .WithColumn("PassWord").AsString(250).NotNullable();
        }
    }
}