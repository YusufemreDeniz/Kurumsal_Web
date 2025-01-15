namespace Kurumsal_Web11.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationAdı : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                {
                    AdminId = c.Int(nullable: false, identity: true),
                    Eposta = c.String(nullable: false, maxLength: 50),
                    Sifre = c.String(nullable: false, maxLength: 50),
                    Yetki = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AdminId);

            CreateTable(
                "dbo.Blog",
                c => new
                {
                    BlogId = c.Int(nullable: false, identity: true),
                    Baslik = c.String(),
                    Icerik = c.String(),
                    ResimURL = c.String(),
                    KategoriId = c.Int(),
                })
                .PrimaryKey(t => t.BlogId)
                .ForeignKey("dbo.Kategori", t => t.KategoriId)
                .Index(t => t.KategoriId);

            CreateTable(
                "dbo.Kategori",
                c => new
                {
                    KategoriId = c.Int(nullable: false, identity: true),
                    KategoriAd = c.String(nullable: false, maxLength: 50),
                    Aciklama = c.String(),
                })
                .PrimaryKey(t => t.KategoriId);

            CreateTable(
                "dbo.Yorum",
                c => new
                {
                    YorumId = c.Int(nullable: false, identity: true),
                    AdSoyad = c.String(nullable: false, maxLength: 50),
                    Eposta = c.String(),
                    YorumIcerik = c.String(),
                    Onay = c.Boolean(nullable: false),
                    BlogId = c.Int(),
                })
                .PrimaryKey(t => t.YorumId)
                .ForeignKey("dbo.Blog", t => t.BlogId)
                .Index(t => t.BlogId);

            CreateTable(
                "dbo.Hakkimizda",
                c => new
                {
                    HakkimizdaId = c.Int(nullable: false, identity: true),
                    Aciklama = c.String(nullable: false),
                })
                .PrimaryKey(t => t.HakkimizdaId);

            CreateTable(
                "dbo.Hizmet",
                c => new
                {
                    HizmetID = c.Int(nullable: false, identity: true),
                    Baslik = c.String(nullable: false, maxLength: 150),
                    Aciklama = c.String(),
                    ResimURL = c.String(),
                })
                .PrimaryKey(t => t.HizmetID);

            CreateTable(
                "dbo.Iletisim",
                c => new
                {
                    IletisimId = c.Int(nullable: false, identity: true),
                    Adres = c.String(maxLength: 500),
                    Telefon = c.String(maxLength: 250),
                    Email = c.String(),
                    Whatsapp = c.String(),
                    Facebook = c.String(),
                    Twitter = c.String(),
                    Instagram = c.String(),
                })
                .PrimaryKey(t => t.IletisimId);

            CreateTable(
                "dbo.Kimlik",
                c => new
                {
                    KimlikId = c.Int(nullable: false, identity: true),
                    Title = c.String(nullable: false, maxLength: 150),
                    Keywords = c.String(nullable: false, maxLength: 250),
                    Description = c.String(nullable: false, maxLength: 500),
                    LogoURL = c.String(),
                    Unvan = c.String(),
                })
                .PrimaryKey(t => t.KimlikId);

            CreateTable(
                "dbo.Slider",
                c => new
                {
                    SliderId = c.Int(nullable: false, identity: true),
                    Baslik = c.String(maxLength: 30),
                    Acikllama = c.String(maxLength: 150),
                    ResimURL = c.String(maxLength: 250),
                })
                .PrimaryKey(t => t.SliderId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorum", "BlogId", "dbo.Blog");
            DropForeignKey("dbo.Blog", "KategoriId", "dbo.Kategori");
            DropIndex("dbo.Yorum", new[] { "BlogId" });
            DropIndex("dbo.Blog", new[] { "KategoriId" });
            DropTable("dbo.Slider");
            DropTable("dbo.Kimlik");
            DropTable("dbo.Iletisim");
            DropTable("dbo.Hizmet");
            DropTable("dbo.Hakkimizda");
            DropTable("dbo.Yorum");
            DropTable("dbo.Kategori");
            DropTable("dbo.Blog");
            DropTable("dbo.Admin");
        }
    }
}
