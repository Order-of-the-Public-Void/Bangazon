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
                        Users_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.Users_UserId)
                .Index(t => t.Users_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        State = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        UserName = c.String(),
                        Recommendation_RecommendationId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Recommendations", t => t.Recommendation_RecommendationId)
                .Index(t => t.Recommendation_RecommendationId);
            
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
                        Users_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PaymentMethodId)
                .ForeignKey("dbo.Users", t => t.Users_UserId)
                .Index(t => t.Users_UserId);
            
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
                "dbo.Recommendations",
                c => new
                    {
                        RecommendationId = c.Int(nullable: false, identity: true),
                        Products_ProductId = c.Int(),
                        Sender_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RecommendationId)
                .ForeignKey("dbo.Products", t => t.Products_ProductId)
                .ForeignKey("dbo.Users", t => t.Sender_UserId)
                .Index(t => t.Products_ProductId)
                .Index(t => t.Sender_UserId);
            
            CreateTable(
                "dbo.ProductUsers",
                c => new
                    {
                        Product_ProductId = c.Int(nullable: false),
                        User_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Product_ProductId, t.User_UserId })
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .Index(t => t.Product_ProductId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recommendations", "Sender_UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Recommendation_RecommendationId", "dbo.Recommendations");
            DropForeignKey("dbo.Recommendations", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.PaymentMethods", "Users_UserId", "dbo.Users");
            DropForeignKey("dbo.LineItems", "Products_ProductId", "dbo.Products");
            DropForeignKey("dbo.LineItems", "Orders_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Users_UserId", "dbo.Users");
            DropForeignKey("dbo.ProductUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ProductUsers", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductUsers", new[] { "User_UserId" });
            DropIndex("dbo.ProductUsers", new[] { "Product_ProductId" });
            DropIndex("dbo.Recommendations", new[] { "Sender_UserId" });
            DropIndex("dbo.Recommendations", new[] { "Products_ProductId" });
            DropIndex("dbo.ProductImages", new[] { "Products_ProductId" });
            DropIndex("dbo.PaymentMethods", new[] { "Users_UserId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.Users", new[] { "Recommendation_RecommendationId" });
            DropIndex("dbo.Orders", new[] { "Users_UserId" });
            DropIndex("dbo.LineItems", new[] { "Products_ProductId" });
            DropIndex("dbo.LineItems", new[] { "Orders_OrderId" });
            DropTable("dbo.ProductUsers");
            DropTable("dbo.Recommendations");
            DropTable("dbo.ProductImages");
            DropTable("dbo.PaymentMethods");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
            DropTable("dbo.LineItems");
        }
    }
}
