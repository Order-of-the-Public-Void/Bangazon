namespace Bangazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableSetUp : DbMigration
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
                    })
                .PrimaryKey(t => t.LineItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.Boolean(nullable: false),
                        ShippingStreet = c.String(),
                        ShippingCity = c.String(),
                        ShippingZip = c.Int(nullable: false),
                        LineItem_LineItemId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.LineItems", t => t.LineItem_LineItemId)
                .Index(t => t.LineItem_LineItemId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FName = c.String(),
                        LName = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Zip = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                        UserName = c.String(),
                        Order_OrderId = c.Int(),
                        PaymentMethod_PaymentMethodId = c.Int(),
                        Recommendation_RecommendationId = c.Int(),
                        Recommendation_RecommendationId1 = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.PaymentMethods", t => t.PaymentMethod_PaymentMethodId)
                .ForeignKey("dbo.Recommendations", t => t.Recommendation_RecommendationId)
                .ForeignKey("dbo.Recommendations", t => t.Recommendation_RecommendationId1)
                .Index(t => t.Order_OrderId)
                .Index(t => t.PaymentMethod_PaymentMethodId)
                .Index(t => t.Recommendation_RecommendationId)
                .Index(t => t.Recommendation_RecommendationId1);
            
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
                        LineItem_LineItemId = c.Int(),
                        ProductImage_ProductImagesId = c.Int(),
                        Recommendation_RecommendationId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.LineItems", t => t.LineItem_LineItemId)
                .ForeignKey("dbo.ProductImages", t => t.ProductImage_ProductImagesId)
                .ForeignKey("dbo.Recommendations", t => t.Recommendation_RecommendationId)
                .Index(t => t.LineItem_LineItemId)
                .Index(t => t.ProductImage_ProductImagesId)
                .Index(t => t.Recommendation_RecommendationId);
            
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
                    })
                .PrimaryKey(t => t.PaymentMethodId);
            
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
                    })
                .PrimaryKey(t => t.ProductImagesId);
            
            CreateTable(
                "dbo.Recommendations",
                c => new
                    {
                        RecommendationId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.RecommendationId);
            
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
            DropForeignKey("dbo.Users", "Recommendation_RecommendationId1", "dbo.Recommendations");
            DropForeignKey("dbo.Users", "Recommendation_RecommendationId", "dbo.Recommendations");
            DropForeignKey("dbo.Products", "Recommendation_RecommendationId", "dbo.Recommendations");
            DropForeignKey("dbo.Products", "ProductImage_ProductImagesId", "dbo.ProductImages");
            DropForeignKey("dbo.Users", "PaymentMethod_PaymentMethodId", "dbo.PaymentMethods");
            DropForeignKey("dbo.Products", "LineItem_LineItemId", "dbo.LineItems");
            DropForeignKey("dbo.Orders", "LineItem_LineItemId", "dbo.LineItems");
            DropForeignKey("dbo.Users", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.ProductUsers", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.ProductUsers", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.ProductUsers", new[] { "User_UserId" });
            DropIndex("dbo.ProductUsers", new[] { "Product_ProductId" });
            DropIndex("dbo.ProductCategories", new[] { "Product_ProductId" });
            DropIndex("dbo.Products", new[] { "Recommendation_RecommendationId" });
            DropIndex("dbo.Products", new[] { "ProductImage_ProductImagesId" });
            DropIndex("dbo.Products", new[] { "LineItem_LineItemId" });
            DropIndex("dbo.Users", new[] { "Recommendation_RecommendationId1" });
            DropIndex("dbo.Users", new[] { "Recommendation_RecommendationId" });
            DropIndex("dbo.Users", new[] { "PaymentMethod_PaymentMethodId" });
            DropIndex("dbo.Users", new[] { "Order_OrderId" });
            DropIndex("dbo.Orders", new[] { "LineItem_LineItemId" });
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
