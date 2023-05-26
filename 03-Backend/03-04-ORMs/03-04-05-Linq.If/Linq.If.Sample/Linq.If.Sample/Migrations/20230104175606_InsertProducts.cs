using Microsoft.EntityFrameworkCore.Migrations;

namespace Linq.If.Sample.Migrations
{
    public partial class InsertProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
INSERT INTO [dbo].[Products]
           ([Name]
           ,[ProductTypeId]
           ,[CategoryId]
           ,[Quantity]
           ,[ExpiryDate]
           ,[Price])
     VALUES
           ('Apple'
           ,1
           ,1
           ,99
           ,null
           ,1000)

INSERT INTO [dbo].[Products]
           ([Name]
           ,[ProductTypeId]
           ,[CategoryId]
           ,[Quantity]
           ,[ExpiryDate]
           ,[Price])
     VALUES
           ('BMW'
           ,1
           ,2
           ,10
           ,null
           ,200000)

INSERT INTO [dbo].[Products]
           ([Name]
           ,[ProductTypeId]
           ,[CategoryId]
           ,[Quantity]
           ,[ExpiryDate]
           ,[Price])
     VALUES
           ('Pandol 500 Tabs'
           ,2
           ,3
           ,200
           ,'2023-01-11 00:00:00'
           ,10)

INSERT INTO [dbo].[Products]
           ([Name]
           ,[ProductTypeId]
           ,[CategoryId]
           ,[Quantity]
           ,[ExpiryDate]
           ,[Price])
     VALUES
           ('Pandol Extra Tabs'
           ,2
           ,3
           ,50
           ,'2024-01-01 00:00:00'
           ,15)

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
