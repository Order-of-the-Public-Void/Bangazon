namespace Bangazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetUpTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LineItems",
                c => new
                    {
                        LineItemId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Orders_OrderId = c.Int(),
                        Products_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.LineItemId)
                .ForeignKey("dbo.Orders", t => t.Orders_OrderId)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .Index(t => t.Orders_OrderId)
                .Index(t => t.Products_ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Boolean(nullable: false),
                        ShippingStreet = c.String(),
                        ShippingCity = c.String(),
                        ShippingState = c.String(),
                        ShippingZip = c.Int(nullable: false),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        QuantityAvailable = c.Int(nullable: false),
                        NumberSold = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AvgCustomerRating = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LocalDelivery = c.Boolean(nullable: false),
                        DeliveryCity = c.String(),
                        PossibilityCoefficient = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(),
                        CategoryDescription = c.String(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductCategoryId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        RecommendationId = c.Int(nullable: false, identity: true),
                        Products_ProductId = c.Int(),
                        Sender_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RecommendationId)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.Products_ProductId)
                .Index(t => t.Sender_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.PaymentMethods",
                c => new
                    {
                        PaymentMethodId = c.Int(nullable: false, identity: true),
                        PaymentType = c.String(),
                        PaymentNickname = c.String(),
                        BillingAddress = c.String(),
                        BillingCity = c.String(),
                        BillingState = c.String(),
                        BillingZip = c.Int(nullable: false),
                        CreditCardNumber = c.Int(nullable: false),
                        CVV = c.Int(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        CardholderName = c.String(),
                        Users_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PaymentMethodId)
                .ForeignKey("dbo.AspNetUsers", t => t.Users_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        ProductImagesId = c.Int(nullable: false, identity: true),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Image3 = c.String(),
                        Image4 = c.String(),
                        Image5 = c.String(),
                        Products_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductImagesId)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .Index(t => t.Products_ProductId);
            
            CreateTable(
                "dbo.ProductApplicationUsers",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.ApplicationUser_Id })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.AspNetUsers", "FName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LName", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "Street", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Recommendation_RecommendationId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Recommendation_RecommendationId");
            AddForeignKey("dbo.AspNetUsers", "Recommendation_RecommendationId", "dbo.Recommendations", "RecommendationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductImages", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.PaymentMethods", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.LineItems", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.LineItems", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Users_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recommendations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recommendations", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Recommendation_RecommendationId", "dbo.Recommendations");
            DropForeignKey("dbo.Recommendations", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProductApplicationUsers", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ProductApplicationUsers", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductImages", new[] { "Products_ProductId" });
            DropIndex("dbo.PaymentMethods", new[] { "Users_Id" });
            DropIndex("dbo.Recommendations", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Recommendations", new[] { "Sender_Id" });
            DropIndex("dbo.Recommendations", new[] { "Products_ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.AspNetUsers", new[] { "Recommendation_RecommendationId" });
            DropIndex("dbo.Orders", new[] { "Users_Id" });
            DropIndex("dbo.LineItems", new[] { "Products_ProductId" });
            DropIndex("dbo.LineItems", new[] { "Orders_OrderId" });
            DropColumn("dbo.AspNetUsers", "Recommendation_RecommendationId");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "Street");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "LName");
            DropColumn("dbo.AspNetUsers", "FName");
            DropTable("dbo.ProductApplicationUsers");
            DropTable("dbo.ProductImages");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.Recommendations");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.LineItems");
        }
    }
}
